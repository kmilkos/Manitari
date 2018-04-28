﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.AuditTrail;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using LlamachantFramework.Module.Interfaces;

namespace LlamachantFramework.Module.Controllers.AuditTrail
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class ViewAuditTrailController : ViewController, IModelExtender
    {
        private static bool? AuditTrailEnabled = null;
        public PopupWindowShowAction ViewAuditTrailAction { get { return actionViewAuditTrail; } }

        public ViewAuditTrailController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
            this.TargetViewType = ViewType.DetailView;
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
            if (!AuditTrailEnabled.HasValue)
                AuditTrailEnabled = this.Application.Modules.FindModule<AuditTrailModule>() != null;

            SetAuditTrailActionVisibility();

            if (AuditTrailEnabled.Value)
                this.View.CurrentObjectChanged += View_CurrentObjectChanged;
        }

        private void SetAuditTrailActionVisibility()
        {
            IModelAuditTrailOptions options = Application.Model.Options as IModelAuditTrailOptions;
            this.actionViewAuditTrail.Active[this.Name] = AuditTrailEnabled.Value && (options.CanViewAuditTrail == AuditTrailOption.All ||
                (options.CanViewAuditTrail == AuditTrailOption.UserSpecific && SecuritySystem.CurrentUser is IAuditTrailUser && ((IAuditTrailUser)SecuritySystem.CurrentUser).CanViewAuditTrail));
            this.actionViewAuditTrail.Active[this.Name] &= this.View.CurrentObject != null && !typeof(AuditDataItemPersistent).IsAssignableFrom(this.View.CurrentObject.GetType());
        }

        private void actionViewAuditTrail_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            IObjectSpace space = Application.CreateObjectSpace();
            if (space is XPObjectSpace)
            {
                AuditTrailDetails details = new AuditTrailDetails((space as XPObjectSpace).Session, this.View.CurrentObject);
                e.View = Application.CreateDetailView(space, details);
            }
        }

        private void View_CurrentObjectChanged(object sender, EventArgs e)
        {
            SetAuditTrailActionVisibility();
        }

        protected override void OnDeactivated()
        {
            if (AuditTrailEnabled.Value)
                this.View.CurrentObjectChanged -= View_CurrentObjectChanged;

            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        public void ExtendModelInterfaces(ModelInterfaceExtenders extenders)
        {
            extenders.Add<IModelOptions, IModelAuditTrailOptions>();
        }
    }

    [DomainComponent]
    public class AuditTrailDetails
    {
        public AuditTrailDetails(Session session, object audit)
        {
            _name = String.Format("Audit trail for {0}", CaptionHelper.GetClassCaption(audit.GetType().FullName));
            AuditTrail = AuditedObjectWeakReference.GetAuditTrail(session, audit);
        }

        private string _name;
        public string Name { get { return _name; } }
        public XPCollection<AuditDataItemPersistent> AuditTrail { get; private set; }
    }

    public interface IModelAuditTrailOptions : IModelNode
    {
        [System.ComponentModel.Category("Llamachant Framework")]
        AuditTrailOption CanViewAuditTrail { get; set; }
    }

    public enum AuditTrailOption { None = 0, All = 1, UserSpecific = 2 }
}
