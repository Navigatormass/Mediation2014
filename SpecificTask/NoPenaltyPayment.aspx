﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MediationMasterPage.master" AutoEventWireup="true" CodeFile="NoPenaltyPayment.aspx.cs" Inherits="SpecificTask_NoPenaltyPayment" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
          function SelectAll(obj) {
              var ChkAll = obj; //document.getElementById('PageManager_chkAll');


              var IsChecked = ChkAll.checked;

              var Chk = ChkAll;

              Parent = document.getElementById('ctl00_ContentPlaceHolder1_MediationCaseManager');
              var items = Parent.getElementsByTagName('input');

              for (i = 0; i < items.length; i++) {
                  if (items[i].id != Chk && items[i].type == "checkbox") {
                      if (items[i].checked != IsChecked) {
                          items[i].click();
                      }
                  }
              }
          }         
    </script>
  
    <div>
        <table class="navTable">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
       
    <div id="header2">
        To begin printing  Penalty Payment Letter &nbsp;&nbsp;<asp:Label ID="lblIdError" runat="server" Text="" CssClass="error" /><br />           
    </div>

    <div class="left" style="vertical-align:top;"></div>
    
    <asp:Table ID="Table1" runat="server" Width="95%"  >
        <asp:TableRow>
            <%--<asp:TableCell>  
                <asp:DropDownList ID="lstCoordinatorName" runat="server" 
                     DataSourceID="SqlDataSourceCoordinatorName"  DataTextField="FullName"  
                     DataMember="DefaultView" DataValueField="CoordinatorID"  CssClass="valign" 
                     Width="150px" ForeColor="#003399" Font-Bold="True">
           
                    <asp:ListItem Value="0">Select</asp:ListItem>                                                
                </asp:DropDownList>

                <asp:SqlDataSource ID="SqlDataSourceCoordinatorName" runat="server" EnableCaching="true" ConnectionString ="<%$ ConnectionStrings:Mediation2014ConnectionString %>"                     
                SelectCommand="SELECT [CoordinatorID], [FirstName]+', '+[LastName] AS 'FullName' FROM [Coordinator] union SELECT NULL, '--- Select One ----' ORDER BY [FullName]"></asp:SqlDataSource>

                <br />
            </asp:TableCell>--%>

            <asp:TableCell>&nbsp; &nbsp;&nbsp; &nbsp&nbsp; &nbsp&nbsp; &nbsp&nbsp; &nbsp
                <asp:Button ID="btnPrint" runat="server" Text="Print Penalty Payment Letter" Width="200px" ToolTip="Print Penalty Payment Letter" 
                    CssClass="button" CausesValidation="False" TabIndex="3" OnClick="btnPrint_Click"  PostBackUrl="~/SpecificTask/NoPenaltyPayment.aspx" />
                <asp:Button ID="btnDelete" runat="server" CssClass="button" 
                    OnClick="btnDelete_Click"  TabIndex="3" Text="Penalty Payment Letter Printed Clear Selected List"  Width="320px" ToolTip="Penalty Payment Letter Printed Clear Selected List" style="margin-left:510px; vertical-align:top;"/>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    
    <asp:GridView ID="MediationCaseManager" OnRowCommand="MediationCaseManager_RowCommand" runat="server" AutoGenerateColumns="False" 
        AutoGenerateDeleteButton="False" AutoGenerateEditButton="False" Width="95%" PagerStyle-BackColor="#669966" 
        DataKeyNames="MediationCaseInformationID"  HorizontalAlign="Center" OnPageIndexChanging="MediationCaseManager_PageIndexChanging"
        OnRowDataBound="MediationCaseManager_RowDataBound" OnSorting="MediationCaseManager_Sorting" >
        
        <HeaderStyle BackColor="#669966"   Font-Bold="True"  ForeColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="Select">
                <HeaderTemplate>
                    <asp:CheckBox Id="chkAll" runat="server" onclick="javascript:SelectAll(this);" ToolTip="Check to select or deselect all check boxes" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chk" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:Label id="MediationCaseInformationID" runat="server" Text='<%# Eval("MediationCaseInformationID") %>' Visible="false" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:boundfield DataField="CreateDate" dataformatstring="{0:MMM d, yyyy}" 
                HeaderText="Create Date" htmlencode="false" SortExpression="CreateDate" />
            <asp:boundfield DataField="MediationCaseInformationID" HeaderText="MediationID" 
                SortExpression="MediationID" />
            <asp:boundfield DataField="Name" HeaderText="Name" 
                SortExpression="Name"  />
            <asp:boundfield DataField="clcAddress1" HeaderText="Certificate Contact Address" 
                SortExpression="clcAddress1" />
            <%--<asp:boundfield DataField="CreateDate" dataformatstring="{0:MMM d, yyyy}" 
                HeaderText="Create Date" htmlencode="false" SortExpression="CreateDate" />--%>
        </Columns>
    </asp:GridView>

    <CR:CrystalReportViewer id="CrystalReportViewer1" runat="server" AutoDataBind="true"
        Height="50px" Width="350px" CssFilename="~/App_Themes/RIHskin/Crystal.css" CssClass="crpage" 
        HasCrystalLogo="False" ToolbarImagesFolderUrl="~/images/CrystalToolbar/" HasExportButton="False" />
</asp:Content>