<%@ Page Language="C#" MasterPageFile= "~/Reports/DailyReportsMasterPage.master" AutoEventWireup="true" CodeFile= "ScheduledNoConference.aspx.cs" Inherits="Mediation2014Reports" Title="Scheduled Mediation With No Conference Report" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID= "rptContentMaster1" Runat="Server">

    <CR:CrystalReportViewer ID="dailyReportViewer" runat="server" AutoDataBind="True"  
        EnableDatabaseLogonPrompt="false" 
        BestFitPage="true" 
        ToolPanelView="None"
        CssClass="crpage"
        CssFilename="Crystal.css" 
        DisplayGroupTree="False"
        HasCrystalLogo="False" 
        HasDrillUpButton="True" 
        HasGotoPageButton="True" 
        HasSearchButton="True"
        HasExportButton="true" Height="50px" 
        HasToggleGroupTreeButton="True"  
        ReportSourceID="CrystalReportSource1" 
        ReuseParameterValuesOnRefresh="true"
        SeparatePages="true" Width="350px" />
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
    </CR:CrystalReportSource>

</asp:Content>