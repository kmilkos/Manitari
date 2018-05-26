Option Infer On

Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports System.Web.SessionState

Public Class Global_asax
    Inherits System.Web.HttpApplication

    Protected Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
        CorsSupport.HandlePreflightRequest(HttpContext.Current)
    End Sub

        Protected Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)        
	       DevExpress.XtraReports.Web.WebDocumentViewer.DefaultWebDocumentViewerContainer.Register(Of DevExpress.XtraReports.Web.WebDocumentViewer.IWebDocumentViewerReportResolver, DevExpress.ExpressApp.ReportsV2.Mobile.XafReportsResolver(Of ManitariMobileApplication))()
        End Sub

       	End Class
