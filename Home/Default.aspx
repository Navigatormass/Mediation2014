<%@ Page Language="C#" MasterPageFile="../MediationMasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" Title="Mediation Application" %>

<asp:Content ID="HomeContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table class="navTable">
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
   
         <div style="margin-left: 20px;">
        <asp:ImageButton ID="imgLogo" runat="server" AlternateText="Back to Home Base" CssClass="logo" ImageUrl="../images/mainlogo.gif" />
        <div id="header">
            Mediation Application</div>
        <ul class="homeListings">
            <li><span class="homeListTitles">
                <asp:LinkButton ID="AddMortgagor" runat="server" OnClick="AddMortgagor_Click" >Add Mortgagor</asp:LinkButton></span>
                &nbsp;-&nbsp;To add a new Mortgagor in the database. </li>
            <li><span class="homeListTitles">
                <asp:LinkButton ID="SearchMortgagor" runat="server" OnClick="SearchMortgagor_Click">Search Mortgagor</asp:LinkButton></span>
                &nbsp;-&nbsp;To search, edit or add information to an existing Mortgagor
                 </li>
            <li><span class="homeListTitles">
                <asp:LinkButton ID="SpecificTask" runat="server" OnClick="SpecificTask_Click">Specific Task</asp:LinkButton></span>
                &nbsp;-&nbsp; To print first letter, second letter </li>
           
            <li><span class="homeListTitles">
                <asp:LinkButton ID="MaintainData" runat="server" >Maintain Data</asp:LinkButton></span>
                &nbsp;-&nbsp;To maintain database information this is where you  edit the Mortgagor information . </li>
            <li><span class="homeListTitles">
                <asp:LinkButton ID="ReportLink" runat="server" OnClick="ReportLink_Click">Reports</asp:LinkButton></span>
                &nbsp;-&nbsp;To View or Print specific lead loan reports. </li>
        </ul>
    </div>
</asp:Content>
