﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SpecificTask/SpecificTaskMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="SpecificTask_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%-- <script type="text/javascript">
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
  
    <%-- <div>
        <table class="navTable">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>--%>
       
    <%--<div id="header2">
         Printing  the First letter&nbsp;&nbsp;&nbsp;<asp:Label
            ID="lblIdError" runat="server" Text="" CssClass="error" /><br />
    </div>--%>
      <%--  <div class="left" style="vertical-align:top; " >

            </div>--%>
<%--   <asp:Table ID="Table1" runat="server" Width="871px"  >--%>
         <%--   <asp:TableRow>--%>
         <%--       <asp:TableCell>
                     From NoticeDate:--%>
                 <%--   <asp:TextBox ID="txtFromNoticeDate" TabIndex="1" runat="server" Width="130px" MaxLength="10" />
                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" ImageUrl="~/images/Calendar_scheduleHS.png">  </asp:ImageButton>
                     <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="RIHCalendar" TargetControlID="txtFromNoticeDate" PopupPosition="BottomRight" PopupButtonID="ImageButton1"  Enabled="True" Format="MM/dd/yyyy"></cc1:CalendarExtender> --%>

                   <%--    MaskedEditExtenderFromNoticeDate &  MaskedEditValidatorFromNoticeDate--%>
                <%--  <cc1:MaskedEditExtender ID="MaskedEditExtenderFromNoticeDate" runat="server" TargetControlID="txtFromNoticeDate" OnInvalidCssClass="MaskedEditError"
                   OnFocusCssClass="MaskedEditFocus"  MaskType="Date" Mask="99/99/9999" ErrorTooltipCssClass="MaskedEditError" AutoComplete="true" ClearMaskOnLostFocus="true"></cc1:MaskedEditExtender>
                   <cc1:MaskedEditValidator ID="MaskedEditValidatortxtFromNoticeDate" runat="server" InvalidValueMessage="Invalid date!" EmptyValueMessage="Invalid date!" ControlToValidate="txtFromNoticeDate" ControlExtender="MaskedEditExtenderFromNoticeDate"></cc1:MaskedEditValidator>
                </asp:TableCell><asp:TableCell>To Notice Date:&nbsp;                            
                 <asp:TextBox ID="txtToNoticeDate" TabIndex="6" runat="server" Width="130px" MaxLength="10" />
                  <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" ImageUrl="~/images/Calendar_scheduleHS.png"></asp:ImageButton>
                   <cc1:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="RIHCalendar" TargetControlID="txtToNoticeDate" PopupPosition="BottomRight" PopupButtonID="ImageButton2"  Enabled="True" Format="MM/dd/yyyy"></cc1:CalendarExtender> 
                 --%> 
                       <%-- MaskedEditExtenderFromNoticeDate &  MaskedEditValidatorFromNoticeDate--%>
                  <%-- <cc1:MaskedEditExtender ID="MaskedEditExtenderToNoticeDate" runat="server" TargetControlID="txtToNoticeDate" OnInvalidCssClass="MaskedEditError"
                   OnFocusCssClass="MaskedEditFocus"  MaskType="Date" Mask="99/99/9999" ErrorTooltipCssClass="MaskedEditError" AutoComplete="true" ClearMaskOnLostFocus="true"></cc1:MaskedEditExtender>
                <cc1:MaskedEditValidator ID="MaskedEditValidatorToNoticeDate" runat="server" InvalidValueMessage="Invalid date!" EmptyValueMessage="Invalid date!" ControlToValidate="txtToNoticeDate" ControlExtender="MaskedEditExtenderToNoticeDate"></cc1:MaskedEditValidator>--%>
             <%--  </asp:TableCell>--%>
                
               <%-- <asp:TableCell>--%>

               <%-- <asp:Button ID="btnSearch" runat="server" CssClass="buttonSave" 
                     OnClick="btnSearch_Click" PostBackUrl="Default.aspx" TabIndex="1" Text="Search"  Width="70px" />
                    <asp:Button ID="btnReset" runat="server" Text="Reset"  Width="70px"
                    CssClass="button" CausesValidation="False" TabIndex="1"  />
                   <asp:Button ID="btnPrint" runat="server" Text="Print"  Width="70px" OnClick="btnPrint_Click"
                    CssClass="button" CausesValidation="False" TabIndex="3"  PostBackUrl="~/SpecificTask/Default.aspx" />
                     <asp:Button ID="btnDelete" runat="server" CssClass="buttonSave" 
                     OnClick="btnDelete_Click"  TabIndex="3" Text="Clear Grid"  Width="90px" ToolTip="Select and Delete" />
                               </asp:TableCell>--%>
   <%-- </asp:TableRow>
    </asp:Table>
    --%>
   <%-- <asp:GridView ID="MediationCaseManager" OnRowCommand="MediationCaseManager_RowCommand" runat="server" AutoGenerateColumns="False" 
        AutoGenerateDeleteButton="False" AutoGenerateEditButton="False" Width="95%" PagerStyle-BackColor="#669966" 
        PageSize="50" DataKeyNames="MediationCaseInformationID"  HorizontalAlign="Center" OnPageIndexChanging="MediationCaseManager_PageIndexChanging"
        OnRowDataBound="MediationCaseManager_RowDataBound" OnSorting="MediationCaseManager_Sorting" >
              <HeaderStyle BackColor="#669966"   Font-Bold="True"  ForeColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="Select">
            <HeaderTemplate>
                <asp:CheckBox Id="chkAll" runat="server" onclick="javascript:SelectAll(this);"  ToolTip="Check to select or deselect all check boxes" />

            </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chk" runat="server" />
                </ItemTemplate>
                </asp:TemplateField>
            <asp:TemplateField HeaderText="">
              <ItemTemplate>
                <asp:Label id="MediationCaseInformationID" runat="server" Text='<%# Eval("MediationCaseInformationID")   %>'   Visible="false" />
                    </ItemTemplate>  </asp:TemplateField>
          <asp:boundfield DataField="CreateDate" dataformatstring="{0:MMM d, yyyy}" 
                    HeaderText="Create Date" htmlencode="false" SortExpression="CreateDate" />
                <asp:boundfield DataField="Name" HeaderText="Name" 
                    SortExpression="Name" />
                <asp:boundfield DataField="Address" HeaderText="Address" 
                    SortExpression="Address" />
                <asp:boundfield DataField="NoticeDate" dataformatstring="{0:MMM d, yyyy}" 
                    HeaderText="Notice Date" htmlencode="false" SortExpression="NoticeDate" />
        </Columns>
        </asp:GridView>--%>
  <%--  <CR:CrystalReportViewer id="CrystalReportViewer1" runat="server" AutoDataBind="true"
           ToolPanelView="None" BestFitPage="False" />--%>

</asp:Content>