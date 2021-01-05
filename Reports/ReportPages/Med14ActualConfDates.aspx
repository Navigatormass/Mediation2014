<%@ Page Language="C#" MasterPageFile="~/Reports/DailyReportsMasterPage.master" AutoEventWireup="true" CodeFile="Med14ActualConfDates.aspx.cs" Inherits="Mediation2014Reports" Title="Mediation Cases with Actual Dates" CodeBehind="Med14ActualConfDates.aspx" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="rptContentMaster1" runat="Server">

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
        ReuseParameterValuesOnRefresh="false"
        SeparatePages="true" Width="350px" />
    <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
    </CR:CrystalReportSource>

</asp:Content>

