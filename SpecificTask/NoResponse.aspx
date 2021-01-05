<%@ Page Title="" Language="C#" MasterPageFile="~/MediationMasterPage.master" AutoEventWireup="true" CodeFile="NoResponse.aspx.cs" Inherits="SpecificTask_NoResponse" %>
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
          function ValidateDropDown() {
              var cmbID = "<%=lstCoordinatorName.ClientID %>";
              if (document.getElementById(cmbID).selectedIndex == 0) {
                  alert("Please select a Value from drop-down box");
                  return false;
              }
              return true;
          }
          //function validate() {
          //    if (document.getElementById("lstCoordinatorName").value == "") {
          //        alert("Please select value"); // prompt user
          //        document.getElementById("lstCoordinatorName").focus(); //set focus back to control
          //        return false;
          //    }
          //}
          
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
          To begin printing  Non Response Certificate &nbsp;&nbsp;<asp:Label ID="lblIdError" runat="server" Text="" CssClass="error" /><br />
           
    </div>
        <div class="left" style="vertical-align:top; " >

            </div>
     <asp:Table ID="Table1" runat="server" Width="95%"  >
            <asp:TableRow>
                <asp:TableCell>  <asp:DropDownList ID="lstCoordinatorName" runat="server" 
                     DataSourceID="SqlDataSourceCoordinatorName"  DataTextField="FullName"  
                     DataMember="DefaultView" DataValueField="CoordinatorID"  CssClass="valign" 
                  Width="150px"    ForeColor="#003399" Font-Bold="True">
           
                 <asp:ListItem Value="0">Select</asp:ListItem>
                 <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="lstCoordinatorName" InitialValue="0" runat="server" ErrorMessage="Please select atleast one city"></asp:RequiredFieldValidator>--%>
                                  
             </asp:DropDownList>
 <%--                   <asp:CompareValidator ID="re1" runat="Server" ValueToComare="0" ConroltoCompare="lstCoordinatorName" Operator="Equal"></asp:CompareValidator>--%>
<%--                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="lstCoordinatorName" InitialValue="0"  ErrorMessage="Please select something" />--%>

                 <asp:SqlDataSource ID="SqlDataSourceCoordinatorName" runat="server" EnableCaching="true" ConnectionString ="<%$ ConnectionStrings:Mediation2014ConnectionString %>" 
                    
                 SelectCommand="SELECT [CoordinatorID], [FirstName]+', '+[LastName] AS 'FullName' FROM [Coordinator] union SELECT NULL, '--- Select One ----' ORDER BY [FullName]"></asp:SqlDataSource>
                <br /> </asp:TableCell><%--  <asp:TableCell>
                     From NoticeDate:
                    <asp:TextBox ID="txtFromNoticeDate" TabIndex="1" runat="server" Width="130px" MaxLength="10" />
                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" ImageUrl="~/images/Calendar_scheduleHS.png">  </asp:ImageButton>
                     <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="RIHCalendar" TargetControlID="txtFromNoticeDate" PopupPosition="BottomRight" PopupButtonID="ImageButton1"  Enabled="True" Format="MM/dd/yyyy"></cc1:CalendarExtender> 
                <%--      <%-- MaskedEditExtenderFromNoticeDate &  MaskedEditValidatorFromNoticeDate--%><%--  <cc1:MaskedEditExtender ID="MaskedEditExtenderFromNoticeDate" runat="server" TargetControlID="txtFromNoticeDate" OnInvalidCssClass="MaskedEditError"
                   OnFocusCssClass="MaskedEditFocus"  MaskType="Date" Mask="99/99/9999" ErrorTooltipCssClass="MaskedEditError" AutoComplete="true" ClearMaskOnLostFocus="true"></cc1:MaskedEditExtender>
                   <cc1:MaskedEditValidator ID="MaskedEditValidatortxtFromNoticeDate" runat="server" InvalidValueMessage="Invalid date!" EmptyValueMessage="Invalid date!" ControlToValidate="txtFromNoticeDate" ControlExtender="MaskedEditExtenderFromNoticeDate"></cc1:MaskedEditValidator>--%><%--   </asp:TableCell>--%><%-- <asp:TableCell>To Notice Date:&nbsp;                            
                 <asp:TextBox ID="txtToNoticeDate" TabIndex="6" runat="server" Width="130px" MaxLength="10" />
                  <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" ImageUrl="~/images/Calendar_scheduleHS.png"></asp:ImageButton>
                   <cc1:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="RIHCalendar" TargetControlID="txtToNoticeDate" PopupPosition="BottomRight" PopupButtonID="ImageButton2"  Enabled="True" Format="MM/dd/yyyy"></cc1:CalendarExtender> 
                     <%-- MaskedEditExtenderFromNoticeDate &  MaskedEditValidatorFromNoticeDate--%><%--  <cc1:MaskedEditExtender ID="MaskedEditExtenderToNoticeDate" runat="server" TargetControlID="txtToNoticeDate" OnInvalidCssClass="MaskedEditError"
                   OnFocusCssClass="MaskedEditFocus"  MaskType="Date" Mask="99/99/9999" ErrorTooltipCssClass="MaskedEditError" AutoComplete="true" ClearMaskOnLostFocus="true"></cc1:MaskedEditExtender>
                <cc1:MaskedEditValidator ID="MaskedEditValidatorToNoticeDate" runat="server" InvalidValueMessage="Invalid date!" EmptyValueMessage="Invalid date!" ControlToValidate="txtToNoticeDate" ControlExtender="MaskedEditExtenderToNoticeDate"></cc1:MaskedEditValidator>
               </asp:TableCell>--%><%--    <asp:TableCell>--%><%-- <asp:Button ID="btnSearch" runat="server" CssClass="buttonSave" 
                     OnClick="btnSearch_Click" PostBackUrl="FirstSentLetter.aspx" TabIndex="1" Text="Search"  Width="70px" />
                    <asp:Button ID="btnReset" runat="server" Text="Reset"  Width="70px"
                    CssClass="button" CausesValidation="False" TabIndex="1"  />--%><asp:TableCell>
                      
                  &nbsp; &nbsp;&nbsp; &nbsp&nbsp; &nbsp&nbsp; &nbsp&nbsp; &nbsp<asp:Button ID="btnPrint" runat="server" Text="Print Non Response Certificate"  Width="200px"    ToolTip="Print No Response Certificate" OnClientClick="javascript:return ValidateDropDown();" 
                    CssClass="button" CausesValidation="False" TabIndex="3" OnClick="btnPrint_Click"  PostBackUrl="~/SpecificTask/NoResponse.aspx" />
                     <asp:Button ID="btnDelete" runat="server" CssClass="button" 
                     OnClick="btnDelete_Click"  TabIndex="3" Text="Non Response Certificate Printed Clear Selected List"  Width="280px" ToolTip="Non Response Certificate Printed Clear Selected List"   style="margin-left:510px;  vertical-align:top;"/>
                               </asp:TableCell></asp:TableRow></asp:Table><asp:GridView ID="MediationCaseManager" OnRowCommand="MediationCaseManager_RowCommand" runat="server" AutoGenerateColumns="False" 
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
                    HeaderText="Mediation Case Date" htmlencode="false" SortExpression="CreateDate" />
               <asp:boundfield DataField="MediationCaseInformationID" HeaderText="MediationID" ControlStyle-Width="150px"  
                    SortExpression="MediationID" />
                <asp:boundfield DataField="Name" HeaderText="Name" 
                    SortExpression="Name" />
                <asp:boundfield DataField="Address" HeaderText="Address" 
                    SortExpression="Address" />
               
        </Columns>
        </asp:GridView>
 
                   <%-- <asp:CheckBox ID="chkval" runat="server" />Click on it for demo</br>
     <asp:CheckBox ID="CheckBox1" runat="server" />Click on it for newdemo--%>
      
    <CR:CrystalReportViewer id="CrystalReportViewer1" runat="server" AutoDataBind="true"
           Height="50px"
        Width="350px" CssFilename="~/App_Themes/RIHskin/Crystal.css" CssClass="crpage" HasCrystalLogo="False" ToolbarImagesFolderUrl="~/images/CrystalToolbar/" HasExportButton="False" />
  
      <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
        <Report FileName="~\Reports\CrystalReports\MediationFirstLetter.rpt">
        </Report>
    </CR:CrystalReportSource>
</asp:Content>



