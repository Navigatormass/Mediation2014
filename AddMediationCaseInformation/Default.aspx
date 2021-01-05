<%@ Page Title="Add a new Meidation Case" Language="C#" MasterPageFile="~/MediationMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="AddMediationCaseInformation_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript">
        function validate() {

            <%--Borrower Script--%>
            var BorrowerName;
            var firstname = document.getElementById("<%=txtFirstName.ClientID %>").value;
            var midname = document.getElementById("<%=txtMiddleInitial.ClientID %>").value;
            var lastname = document.getElementById(<%=txtLastName.ClientID %>).value;
            var suffix = document.getElementById("<%=lstBorrowerSuffix.ClientID%>").value;

            BorrowerName = (firstname.length > 0 ? firstname + " " : "") + (midname.length > 0 ? midname + " " : "") + (lastname.length > 0 ? lastname + " " :
            "") + (suffix.length > 0 ? suffix : "");
            document.getElementById("<%=txtPrintViewBorrower.ClientID %>").value = BorrowerName.trim();
        }
    </script>

    <!---Start Main Div--->
    <div>
        <table class="navTable">
            <tr>
                <td>&nbsp;</td>
            </tr>
        </table>
        <!--START LENGTH CHECK FUNCTION FOR TXTMORGAGOR ACCOUNT NUMBER,SEE THE IMPLEMENT FOR THIS FUNCTION-->
        <script type="text/JavaScript">

            function CheckLength(TargetObject) {

                LenString = TargetObject.value.length;

                if (LenString > 12) {

                    TargetObject.value = TargetObject.value.substring(0, 12);
                }
            }</script>
        <!---Start Header Div--->
        <div id="header">
            <asp:Label ID="lblHeader" runat="server" Text="" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblLoanInfo" runat="server" Text="" CssClass="sessionRed" /><br />
            <asp:Label ID="lblAdded" runat="server" Text="" CssClass="error" />
        </div>
        <!---End Header Div--->
        <div class="Mediationform">
            <%--  <!...Start First panel--->--%><asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:SqlDataSource ID="SqlDataSourceBorrowerList" runat="server" ConnectionString="<%$ ConnectionStrings:Mediation2014ConnectionString %>"
                        SelectCommand="SP_getMortgagorNameByMortgagorInformationID"
                        SelectCommandType="StoredProcedure">
                        <SelectParameters>
                            <asp:SessionParameter Name="MortgagorInformationID"
                                SessionField="MortgagorInformationID" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:Panel ID="pHeader" runat="server" CssClass="accordionHeader">
                        <asp:Label ID="lblText" runat="server" />
                    </asp:Panel>
                    <asp:Panel ID="pBody" runat="server" CssClass="cpBody">
                        <asp:Label ID="lblSpace1" runat="server" Width="800px" Visible="true"></asp:Label>
                        <asp:Label ID="lblMedCaseDate" runat="server"
                            Text="Med Case Date:" Width="150px" Height="15px"></asp:Label>
                        <asp:TextBox ID="txtMedCaseDate" runat="server"
                            Width="150px" MaxLength="10" ReadOnly="true" Format="MM/dd/yyyy" />
                        <br />
                        <asp:Label ID="lblSpace18" runat="server" Width="800px" Visible="true"></asp:Label>
                        <asp:Label ID="lblMedCase" runat="server"
                            CssClass="valign" Text="Med Case ID:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtMedCaseID" runat="server"
                            Width="150px" MaxLength="10" ReadOnly="true"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="lblFirstName" runat="server" Text="First Name:"
                            Width="150px"></asp:Label>
                        <asp:TextBox ID="txtFirstName" runat="server" Width="150px" MaxLength="35"
                            TabIndex="1" ReadOnly="False" Enabled="True"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName"
                            CssClass="error" ErrorMessage="First Name is a required field">*</asp:RequiredFieldValidator>
                        <br />
                        <%--Middle Initial of Borrower--%>
                        <asp:Label ID="lblMiddleInitial" runat="server" Text="Middle Initial:"
                            Width="150px"></asp:Label>
                        <asp:TextBox ID="txtMiddleInitial" runat="server" TabIndex="2" MaxLength="35" Width="150px"
                            Enabled="True"></asp:TextBox>
                        <asp:Label ID="lblSpace16" runat="server" Width="157px" />
                        <br />
                        <%--Last Name of Borrower--%>
                        <asp:Label ID="lblLastName" runat="server" Text="Last Name:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtLastName" runat="server" Width="150px" MaxLength="35"
                            TabIndex="3" ReadOnly="False" Enabled="True"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName"
                            CssClass="error" ErrorMessage="Last Name is a required field">*</asp:RequiredFieldValidator>
                        <br />
                        <%--<asp:Label ID="lblSpace17" runat="server" Width="100px" />--%>
                        <asp:Label ID="lblSuffix" runat="server" Text="Suffix:" Width="150px"></asp:Label>
                        <asp:DropDownList ID="lstBorrowerSuffix" runat="server" TabIndex="4" AutoPostBack="false" ForeColor="#003399" Font-Bold="True" AutoCompleteType="none">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Sr.</asp:ListItem>
                            <asp:ListItem>Jr.</asp:ListItem>
                            <asp:ListItem>I</asp:ListItem>
                            <asp:ListItem>II</asp:ListItem>
                            <asp:ListItem>III</asp:ListItem>
                            <asp:ListItem>IV</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <asp:Label ID="lblAlias" runat="server" Text="Alias:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtAlias" runat="server" TabIndex="5" MaxLength="70" Width="150px"></asp:TextBox><br />
                        <br />
                        <asp:Label ID="lblSpace15" runat="server" Width="615px" />
                        <asp:Label ID="Label6" runat="server" Width="130px" Text="Borrower Name" />
                        <asp:TextBox ID="txtPrintViewBorrower" runat="server" TabIndex="8" MaxLength="80" Height="50" Width="250px" TextMode="MultiLine" />
                        <asp:Label ID="Label9" runat="server" Width="35px"></asp:Label>
                        <asp:Label ID="Label10" runat="server" Width="110px" Text="Co-Borrower Name" />
                        <asp:TextBox ID="txtPrintViewCo_Borrower" runat="server" TabIndex="9" MaxLength="80" Height="50" Width="250px" Text="" TextMode="MultiLine" />
                        <br />
                        <asp:Label ID="Label14" runat="server" Width="615px"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="Label15" runat="server" Width="615px"></asp:Label>
                        <asp:Label ID="Label11" runat="server" Width="130px" Text=" Third Borrower Name" />
                        <asp:TextBox ID="txtPrintViewCo_Borrower3" runat="server" TabIndex="10" MaxLength="80" Height="50" Width="250px" Text="" TextMode="MultiLine" />
                        <asp:Label ID="Label12" runat="server" Width="20px"></asp:Label>
                        <asp:Label ID="Label13" runat="server" Width="125px" Text="Fourth Borrower Name" />
                        <asp:TextBox ID="txtPrintViewCo_Borrower4" runat="server" TabIndex="11" MaxLength="80" Height="50" Width="250px" Text="" TextMode="MultiLine" />
                        <br />
                        <br />
                        <br />
                        <%--Address1 Field--%>
                        <asp:Label ID="lblAddress1" runat="server" Text="Address:" Width="150px" />
                        <asp:TextBox ID="txtAddress_1" runat="server" TabIndex="6" MaxLength="80"
                            ReadOnly="False" Width="530px" Enabled="True" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                            runat="server" ControlToValidate="txtAddress_1" CssClass="error"
                            ErrorMessage="Address is a required field">*</asp:RequiredFieldValidator>
                        <br />
                        <%--Address2 Field--%>
                        <asp:Label ID="lblAddress2" runat="server" Text="Address 2:"
                            Width="150px" />
                        <asp:TextBox ID="txtAddress_2" runat="server" TabIndex="7" MaxLength="80"
                            ReadOnly="False" Width="530px" Enabled="True" />
                        <br />
                        <%--City Field--%>
                        <asp:Label ID="lblcity" runat="server" Text="City, State:"
                            Width="150px"></asp:Label>
                        <asp:TextBox ID="txtCity" runat="server" MaxLength="40" Width="150px"
                            Enabled="False"></asp:TextBox>
                        <asp:TextBox ID="txtState" runat="server" MaxLength="2" Width="40px"
                            Enabled="false"></asp:TextBox>
                        <br />
                        <%--ZipCode Field--%>
                        <asp:Label ID="lblzipcode" runat="server" Text="Zip:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtZipCode" runat="server" MaxLength="80"
                            Width="80px" Enabled="False"></asp:TextBox>
                        <br />
                         
                        <%--Mortgagor Phone field--%>
                        <asp:Label ID="lblMortgagorPhone" runat="server"
                            Text="Phone:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtMortgagorPhone" TabIndex="8" runat="server"
                            Width="130px" MaxLength="20" />
                        <cc1:MaskedEditExtender ID="MaskedEditExtenderMortgagorPhone" runat="server" TargetControlID="txtMortgagorPhone"
                                AutoComplete="false" Mask="(999)999-9999" MaskType="Number" ErrorTooltipCssClass="MaskedEditError"
                                OnInvalidCssClass="MaskedEditError" OnFocusCssClass="MaskedEditFocus" ClearMaskOnLostFocus="false" />
                        <asp:Label ID="Label16" runat="server" Width="177px"></asp:Label>
                        <%--Mortgagor Phone Date Field--%>
                        <asp:Label ID="lblMortgagorCalled" runat="server"
                            Text="Mortgagor Last Called Date:" Height="19px"></asp:Label>
                        <asp:Label ID="Label17" runat="server" Width="25px" Visible="true"></asp:Label>
                        <asp:TextBox ID="txtMortgagorCalledDate" TabIndex="9" runat="server"
                            Width="150px" MaxLength="10" />
                        <asp:ImageButton ID="ImageButton7" runat="server"
                            CausesValidation="False" Enabled="True"
                            ImageUrl="~/images/Calendar_scheduleHS.png"></asp:ImageButton>                        
                        <cc1:CalendarExtender ID="CalendarExtender7" runat="server" CssClass="RIHCalendar"
                            TargetControlID="txtMortgagorCalledDate"
                            PopupPosition="BottomRight" PopupButtonID="ImageButton7" Enabled="True"
                            Format="MM/dd/yyyy">
                        </cc1:CalendarExtender>                                    
                        <br />

                        <%--Default Date Field--%>
                        <asp:Label ID="lblDefaultdate" runat="server"
                            Text="Default Date:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtDefaultdate" TabIndex="12" runat="server"
                            Width="130px" MaxLength="10" />
                        <asp:ImageButton ID="ImageButton1" runat="server"
                            CausesValidation="False" Enabled="True"
                            ImageUrl="~/images/Calendar_scheduleHS.png"></asp:ImageButton>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                            ControlToValidate="txtDefaultdate"
                            ErrorMessage="Default Date is a required field" SetFocusOnError="true"
                            Display="Dynamic">*</asp:RequiredFieldValidator>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="RIHCalendar"
                            TargetControlID="txtDefaultdate"
                            PopupPosition="BottomRight" PopupButtonID="ImageButton1" Enabled="True"
                            Format="MM/dd/yyyy">
                        </cc1:CalendarExtender>
                        <asp:Label ID="lblSpace21" runat="server" Width="159px"></asp:Label>
                        <%--Mortgagor Account Number Field--%>
                        <asp:Label ID="lblMortgagorAccNo" runat="server" Height="20px"
                            CssClass="valign" Text="Mortgagor Account No:" Width="145px"></asp:Label>
                        <asp:Label ID="lblSpace22" runat="server" Width="30px" Visible="true"></asp:Label>
                        <asp:TextBox ID="txtMortgagorAccNo" runat="server" TabIndex="13"
                            Width="150px" onKeydown="CheckLength(this)" onKeyup="CheckLength(this)"
                            onChange="CheckLength(this)"></asp:TextBox>
                        <br />

                        <%--Notice Date Field--%>
                        <asp:Label ID="lblNoticeDate" runat="server" Text="Notice Date:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtNoticeDate" TabIndex="14" runat="server"
                            Width="130px" MaxLength="10" OnTextChanged="txtNoticeDate_TextChanged"
                            AutoPostBack="true"></asp:TextBox>
                        <asp:ImageButton ID="ImageButton2" CausesValidation="False"
                            runat="server" ImageUrl="~/images/Calendar_scheduleHS.png"></asp:ImageButton>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                            ControlToValidate="txtNoticeDate" CssClass="error"
                            ErrorMessage="Notice Date is a required field">*</asp:RequiredFieldValidator>
                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server"
                            CssClass="RIHCalendar" TargetControlID="txtNoticeDate" Enabled="True"
                            Format="MM/dd/yyyy" PopupPosition="BottomRight"
                            PopupButtonID="ImageButton2">
                        </cc1:CalendarExtender>
                        <br />
                        <asp:Label ID="lblReleaseBankruptcyStayDate" runat="server"
                            Text="Bankruptcy Stay Date:" Width="150px" Height="23px"
                            Style="margin-top: 0px"></asp:Label>
                        <asp:TextBox ID="txtReleaseBankruptcyStayDate" TabIndex="15" runat="server"
                            Width="130px" MaxLength="10"
                            OnTextChanged="txtReleaseBankruptcyStayDate_TextChanged"
                            AutoPostBack="true" Height="16px" Wrap="False" />
                        <asp:ImageButton ID="ImageButton3" runat="server"
                            CausesValidation="false" ImageUrl="~/images/Calendar_scheduleHS.png"></asp:ImageButton>
                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" CssClass="RIHCalendar"
                            TargetControlID="txtReleaseBankruptcyStayDate"
                            PopupPosition="BottomRight" PopupButtonID="ImageButton3"
                            Format="MM/dd/yyyy">
                        </cc1:CalendarExtender>
                        <asp:Label ID="lblError"
                            runat="server" Text=""></asp:Label>
                        <%--Serviceman Civil Relief Act Date--%><asp:Label ID="lblServicemanSpace"
                            runat="server" Width="159px"></asp:Label>
                        <asp:Label ID="lblServicemanCivilReliefActDate" runat="server"
                            Text="Serviceman Civil Relief Act Date:" Width="178px" Height="16px"></asp:Label>
                        <asp:TextBox ID="txtServicemanCivilReliefActDate" TabIndex="16" runat="server"
                            Width="150px" MaxLength="10"
                            OnTextChanged="txtServicemanCivilReliefActDate_TextChanged"
                            AutoPostBack="true" Wrap="False" />
                        <asp:ImageButton ID="ImageButton6" runat="server"
                            CausesValidation="false" ImageUrl="~/images/Calendar_scheduleHS.png" Style="width: 16px"></asp:ImageButton>
                        <cc1:CalendarExtender ID="CalendarExtender6" runat="server" CssClass="RIHCalendar"
                            TargetControlID="txtServicemanCivilReliefActDate"
                            PopupPosition="BottomRight" PopupButtonID="ImageButton6"
                            Format="MM/dd/yyyy">
                        </cc1:CalendarExtender>
                        <%--End of Serviceman Civil Act Date--%>&nbsp;<br />
                        <asp:Label ID="lblPenaltyDays" runat="server"
                            Text="Penalty Days:" Width="149px" Height="16px"></asp:Label>
                        <asp:TextBox ID="txtPenaltyDays" runat="server" Width="130" TabIndex="17"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                            ErrorMessage="Penalty Days is  a required field.Please hit the Penalty Button"
                            CssClass="error" ControlToValidate="txtPenaltyDays">*</asp:RequiredFieldValidator>
                        <asp:Button ID="btnCal" runat="server" Text="Get Penalty Days"
                            CssClass="navButton" align="center"
                            OnClick="btnCal_Click" CausesValidation="false"
                            UseSubmitBehavior="false" Height="19px" Width="130px" />
                        <asp:Label ID="lblSpace2" runat="server" Width="36px"
                            CssClass="button"></asp:Label>
                        <asp:Label ID="lblInitialFee" runat="server" Text="Initial Fee:"
                            Width="135px" Height="16px"></asp:Label>
                        <asp:Label ID="lblSpace23"
                            runat="server" Width="40px" Visible="true"></asp:Label>
                        <asp:TextBox ID="txtInitialFee" runat="server" TabIndex="18" Width="150px" 
                            Enabled="False" ReadOnly="True" Height="16px"></asp:TextBox>
                        <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server"
                            TargetControlID="txtInitialFee" OnInvalidCssClass="MaskedEditError"
                            OnFocusCssClass="MaskedEditFocus" MaskType="Number"
                            Mask="999.99"
                            ErrorTooltipCssClass="MaskedEditError" AutoComplete="true"
                            MessageValidatorTip="true"
                            InputDirection="RightToLeft" AcceptNegative="None"
                            DisplayMoney="Left">
                        </cc1:MaskedEditExtender>
                        <br />
                        <asp:Label ID="lblFirstLetterSentDate" runat="server"
                            Text="First Letter Sent Date:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtFirstLetterSent" TabIndex="19"
                            runat="server" Width="130px" MaxLength="10" Height="16px" />
                        <!-- Added check box for ReturnedMail  per Tricia H. _Jaheda Meman 06/22/2015 
 ***********************************************************************-->
                        <asp:Label ID="lblSpace34" runat="server" Width="200px"
                            Visible="true"></asp:Label>
                        <asp:Label ID="lblSpace33" runat="server" Width="160px" Visible="true"
                            CssClass="button"></asp:Label>
                        <asp:CheckBox ID="chkReturnedMail" runat="server" AutoPostBack="false" Visible="true"
                            Text="Returned Mail"
                            OnCheckedChanged="chkReturnedMail_CheckedChanged"></asp:CheckBox>
                        <!-- check box for ReturnedMail  per Tricia H. _Jaheda Meman 06/22/2015 
                             ***********************************************************************-->
                        <!-- Added check box for ReturnedMailDate  per Tricia H. _obd 09/11/2015 
 ***********************************************************************-->
                        <asp:Label ID="retMailDateSpacer1" runat="server" Width="60px" Visible="true"
                            CssClass="button"></asp:Label>
                        <asp:TextBox ID="txtReturnedMailDate" runat="server" TabIndex="20" Visible="False"></asp:TextBox>
                        <!-- text box for ReturnedMailDate per Tricia H. _obd 09/11/2015 
                             ***********************************************************************-->
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <br />

                        <asp:Label ID="lblSecondLetterSentDate" runat="server"
                            Text="Second Letter Sent Date:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtSecondLetterSentDate" TabIndex="21"
                            runat="server" Width="130px" MaxLength="10" />
                        <br />
                        <asp:Label ID="lblConfCallDeadlineDate" runat="server"
                            Text="Conf Call Deadline Date:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtConfCallDeadlineDate" TabIndex="22"
                            runat="server" Width="130px" MaxLength="10" Format="MM/dd/yyyy" />
                        <br />
                        <%-- NOTES TABLE TO DISPLAY NOTES TEXTBOX AND GRID --%><table
                            class="navTableNotes">
                            <tr>
                                <td>
                                    <asp:Label ID="lblNotes" runat="server" Text="Notes:" Width="146px" Height="16px"></asp:Label>

                                    <asp:TextBox ID="txtNotes" TabIndex="23" runat="server" Width="300px" Height="100px" TextMode="MultiLine" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Please hit the Add Notes" CssClass="error" ControlToValidate="txtNotes" ValidationGroup="Notes">*</asp:RequiredFieldValidator>
                                </td>
                                <asp:Label ID="lblSpace29" runat="server" Width="1px"></asp:Label>
                                <%-- NOTES GRID TO DISPLAY RECORDS FROM NOTES TABLE--%><td>
                                    <asp:GridView ID="MediationCaseNotes" OnRowCommand="MediationCaseNotes_RowCommand" runat="server" AutoGenerateColumns="False"
                                        AutoGenerateDeleteButton="False" AutoGenerateEditButton="False" Width="500px" PagerStyle-BackColor="#669966">
                                        <HeaderStyle BackColor="#669966" Font-Bold="True" ForeColor="White" />
                                        <Columns>
                                            <asp:BoundField DataField="MediationCaseInformationID" ItemStyle-HorizontalAlign="Center"
                                                HeaderText="Med-ID" HtmlEncode="false" SortExpression="update" HeaderStyle-Width="50px" />
                                            <asp:BoundField DataField="Notes" ItemStyle-HorizontalAlign="Center"
                                                HeaderText="Notes" HtmlEncode="false" SortExpression="udate" HeaderStyle-Width="300px" />
                                            <asp:BoundField DataField="TimeStamp" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:MMM d, yyyy hh:mm:tt}"
                                                HeaderText="TimeStamp" HtmlEncode="false" SortExpression="udate" HeaderStyle-Width="150px" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <%--  END Notes GRID--%><tr>
                                <asp:Label ID="lblSpace28" runat="server" Width="155px"></asp:Label>
                                <td>
                                    <asp:Button ID="btnSaveNotes" runat="server" Text="Add New Notes" CssClass="buttonSave"
                                        TabIndex="35" Width="120px" OnClick="btnSaveNotes_Click" ValidationGroup="Notes" />
                                    <asp:Label ID="lblAddNotes" runat="server" CssClass="error"></asp:Label>
                                    <%--  <asp:Label ID="lblSpace30" runat="server" Width="25px"></asp:Label>--%><asp:Button ID="btnResetNotes" runat="server" Text="Reset Notes" CssClass="button" TabIndex="36"
                                        UseSubmitBehavior="true" Width="100px" CausesValidation="false"
                                        OnClick="btnResetNotes_Click" /></td>
                            </tr>
                        </table>
                        <br />
                        <cc1:MaskedEditExtender
                            ID="MaskedEditExtenderDefDate" runat="server"
                            TargetControlID="txtDefaultdate" OnInvalidCssClass="MaskedEditError"
                            OnFocusCssClass="MaskedEditFocus" MaskType="Date" Mask="99/99/9999"
                            ErrorTooltipCssClass="MaskedEditError" AutoComplete="false">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditExtender
                            ID="MaskedEditExtenderNoticeDate" runat="server"
                            TargetControlID="txtNoticeDate" OnInvalidCssClass="MaskedEditError"
                            OnFocusCssClass="MaskedEditFocus" MaskType="Date" Mask="99/99/9999"
                            ErrorTooltipCssClass="MaskedEditError" AutoComplete="true"
                            ClearMaskOnLostFocus="true">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtenderReleaseBankruptcyStayDate"
                            runat="server" TargetControlID="txtReleaseBankruptcyStayDate" OnInvalidCssClass="MaskedEditError"
                            OnFocusCssClass="MaskedEditFocus" MaskType="Date" Mask="99/99/9999"
                            ErrorTooltipCssClass="MaskedEditError" AutoComplete="false">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditExtender
                            ID="MaskedEditExtenderFirstLetterSent" runat="server"
                            TargetControlID="txtFirstLetterSent" OnInvalidCssClass="MaskedEditError"
                            OnFocusCssClass="MaskedEditFocus" MaskType="Date" Mask="99/99/9999"
                            ErrorTooltipCssClass="MaskedEditError" AutoComplete="false">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtenderSecondLetterSentDate"
                            runat="server" TargetControlID="txtSecondLetterSentDate" OnInvalidCssClass="MaskedEditError"
                            OnFocusCssClass="MaskedEditFocus" MaskType="Date" Mask="99/99/9999"
                            ErrorTooltipCssClass="MaskedEditError" AutoComplete="false">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtenderConfCallDeadlineDate"
                            runat="server" TargetControlID="txtConfCallDeadlineDate" OnInvalidCssClass="MaskedEditError"
                            OnFocusCssClass="MaskedEditFocus" MaskType="Date" Mask="99/99/9999"
                            ErrorTooltipCssClass="MaskedEditError" AutoComplete="false">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditExtender
                            ID="MaskedEditExtenderMedCaseDate" runat="server"
                            TargetControlID="txtMedCaseDate" OnInvalidCssClass="MaskedEditError"
                            OnFocusCssClass="MaskedEditFocus" MaskType="Date" Mask="99/99/9999"
                            ErrorTooltipCssClass="MaskedEditError" AutoComplete="false">
                        </cc1:MaskedEditExtender>
                        <%--   FOR THE ERROR MESSAGE CSS. USE FOR THE REQUIRED FIELD VALIDATION--%>
                        <asp:ValidationSummary
                            ID="ValidationSummary1" runat="server" CssClass="requestPanel5" />
                    </asp:Panel>
                    <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server"
                        TargetControlID="pBody" CollapseControlID="pHeader" ExpandControlID="pHeader"
                        Collapsed="false" TextLabelID="lblText"
                        CollapsedText="Mortgagor Information Panel - Click to Show Content.." ExpandedText="Mortgagor Information Panel - Click to Hide Content.."
                        CollapsedSize="0">
                    </cc1:CollapsiblePanelExtender>
                </ContentTemplate>
            </asp:UpdatePanel>
            <%--  <!...End First panel--->--%>
            <%--...Second panel...--%>
            <asp:UpdatePanel ID="UpdatePanel" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pHeader1" runat="server" CssClass="accordionHeader">
                        <asp:Label ID="lblText1" runat="server" />
                    </asp:Panel>
                    <asp:Panel ID="pBody1" runat="server" CssClass="cpBody">
                        <asp:Label ID="lblIntialContactDate" runat="server" Text="Intial Contact Date:"
                            Width="175px"></asp:Label>
                        <asp:TextBox ID="txtInitialContactDate" TabIndex="6" runat="server" Width="130px"
                            MaxLength="10" />
                        <asp:ImageButton ID="ImageButton9" runat="server" CausesValidation="False"
                            ImageUrl="~/images/Calendar_scheduleHS.png"></asp:ImageButton>
                        <cc1:CalendarExtender ID="CalendarExtender8" runat="server" CssClass="RIHCalendar"
                            TargetControlID="txtInitialContactDate"
                            PopupPosition="BottomRight" PopupButtonID="ImageButton9" Enabled="True"
                            Format="MM/dd/yyyy">
                        </cc1:CalendarExtender>
                        <br />
                        <asp:Label ID="lblPackageSentDate" runat="server" Text="Package Sent Date:"
                            Width="175px"></asp:Label>
                        <asp:TextBox ID="txtPackageSentDate" TabIndex="6" runat="server" Width="130px"
                            MaxLength="10" />
                        <asp:ImageButton ID="ImageButton10" runat="server" CausesValidation="False"
                            ImageUrl="~/images/Calendar_scheduleHS.png"></asp:ImageButton>
                        <cc1:CalendarExtender ID="CalendarExtender9" runat="server" CssClass="RIHCalendar"
                            TargetControlID="txtPackageSentDate"
                            PopupPosition="BottomRight" PopupButtonID="ImageButton10" Enabled="True"
                            Format="MM/dd/yyyy">
                        </cc1:CalendarExtender>
                        <asp:Label ID="lblSpace4" runat="server" Width="170px" Visible="true"></asp:Label>
                        <asp:Label ID="lblCoordinatorName" runat="server" Width="150px"
                            Text="Coordinator Name:"></asp:Label>
                        <asp:DropDownList ID="lstCoordinatorName" runat="server"
                            DataSourceID="SqlDataSourceCoordinatorName" DataTextField="FullName"
                            DataMember="DefaultView" DataValueField="CoordinatorID" CssClass="valign"
                            Width="150px" AutoPostBack="True" ForeColor="#003399" Font-Bold="True">
                            <asp:ListItem Value="0">Select</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSourceCoordinatorName" runat="server" ConnectionString="<%$ ConnectionStrings:Mediation2014ConnectionString %>"
                            SelectCommand="SELECT CoordinatorID, FirstName + ', ' + LastName AS 'FullName' FROM Coordinator UNION SELECT NULL AS Expr1, '--- Select One ----' AS Expr2 ORDER BY 'FullName'"></asp:SqlDataSource>
                        <br />
                        <asp:Label ID="lblScheduledConfDate" runat="server" Text="Scheduled Conf Date:"
                            Width="175px"></asp:Label>

                        <asp:TextBox ID="txtSheduledConfDate" TabIndex="6" runat="server" Width="130px"
                            MaxLength="10" />
                        <asp:ImageButton ID="ImageButton11" runat="server" CausesValidation="False"
                            ImageUrl="~/images/Calendar_scheduleHS.png"></asp:ImageButton>
                        <cc1:CalendarExtender ID="CalendarExtender10" runat="server" CssClass="RIHCalendar"
                            TargetControlID="txtSheduledConfDate"
                            PopupPosition="BottomRight" PopupButtonID="ImageButton11" Enabled="True"
                            Format="MM/dd/yyyy">
                        </cc1:CalendarExtender>
                        <asp:Label ID="lblSpace5" runat="server" Width="170px" Visible="true"></asp:Label>
                        <asp:Label ID="lblCounselorName" runat="server" Height="20px" CssClass="valign"
                            Text="Counselor Name:" Width="150px"></asp:Label>
                        <asp:DropDownList ID="lstCounselorName" runat="server" TabIndex="7"
                            DataSourceID="SqlDataSourceCounselorName" DataTextField="FullName"
                            DataMember="DefaultView" DataValueField="CounselorID" CssClass="valign"
                            AutoPostBack="True" ForeColor="#003399" Font-Bold="True" Width="150px">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSourceCounselorName" runat="server" ConnectionString="<%$ ConnectionStrings:Mediation2014ConnectionString %>"
                            SelectCommand="SELECT [CounselorID], [FirstName]+', '+[LastName] AS 'FullName' FROM [Counselor]  union SELECT NULL, '--- Select One ----'  ORDER BY [FullName]"></asp:SqlDataSource>
                        <br />
                        <asp:Label ID="lblActualConfDate" runat="server" Text="Actual Conf Date:"
                            Width="175px"></asp:Label>
                        <asp:TextBox ID="txtActualConfDate" TabIndex="6" runat="server" Width="130px"
                            MaxLength="10" OnTextChanged="txtActualConfDate_TextChanged"
                            AutoPostBack="true" />
                        <asp:ImageButton ID="ImageButton12" runat="server" CausesValidation="False"
                            ImageUrl="~/images/Calendar_scheduleHS.png"></asp:ImageButton>
                        <cc1:CalendarExtender ID="CalendarExtender11" runat="server" CssClass="RIHCalendar"
                            TargetControlID="txtActualConfDate"
                            PopupPosition="BottomRight" PopupButtonID="ImageButton12"
                            Format="MM/dd/yyyy">
                        </cc1:CalendarExtender>
                        <asp:Label ID="lblSpace6" runat="server" Width="171px" Visible="true"></asp:Label>
                        <asp:Label ID="lblConfResult" runat="server" Height="20px" CssClass="valign"
                            Text="Conference Result:" Width="150px"></asp:Label>
                        <asp:DropDownList ID="lstConfResult" runat="server" CssClass="valign" OnTextChanged="lstConfResult_TextChanged"
                            Width="150px" DataSourceID="SqlDataSourceConferenceResult"
                            DataMember="DefaultView" DataValueField="ConferenceResultID"
                            DataTextField="ConfResult" AutoPostBack="True" ForeColor="#003399"
                            Font-Bold="True">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSourceConferenceResult" runat="server"
                            ConnectionString="<%$ ConnectionStrings:Mediation2014ConnectionString %>"
                            SelectCommand="SELECT ConferenceResultID, ConfResult FROM ConferenceResult UNION SELECT NULL AS Expr1, '--- Select One ----' AS Expr2 ORDER BY ConferenceResultID"></asp:SqlDataSource>
                        <br />
                        <asp:Label ID="lblConfResolveDeadlineDate" runat="server"
                            Text="Conf Resolve Deadline Date:" Width="175px"></asp:Label>
                        <asp:TextBox ID="txtConfResolveDeadlineDate" TabIndex="6" runat="server"
                            Width="130px" MaxLength="10" />
                        <asp:Label ID="lblSpace7"
                            runat="server" Width="189px" Visible="true"></asp:Label>
                        <asp:Label ID="lblMediationInvoiceSentTo" runat="server" Height="20px"
                            CssClass="valign" Text="Mediation Invoice Sent To:" Width="150px"></asp:Label>
                        <asp:DropDownList ID="lstMediationInvoiceSentTo" runat="server" CssClass="valign"
                            Width="150px" DataSourceID="SqlDataSourceMediationInvoiceSentTo"
                            DataMember="DefaultView" DataValueField="MediationInvoiceID"
                            DataTextField="InvoiceSentDesc" AutoPostBack="True" ForeColor="#003399"
                            Font-Bold="True">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSourceMediationInvoiceSentTo" runat="server"
                            ConnectionString="<%$ ConnectionStrings:Mediation2014ConnectionString %>"
                            SelectCommand="SELECT MediationInvoiceID, InvoiceSentDesc FROM MediationInvoice UNION SELECT NULL AS Expr1, '--- Select One ----' AS Expr2 ORDER BY MediationInvoiceID"></asp:SqlDataSource>
                        <br />
                        <asp:Label ID="lblRequestExtensionByDate" runat="server"
                            Text="Request Extension by  Date:" Width="175px"></asp:Label>
                        <asp:TextBox ID="txtRequestExtensionByDate" TabIndex="6" runat="server"
                            Width="130px" MaxLength="10" />
                        <asp:Label ID="lblSpace8"
                            runat="server" Width="340px" Visible="true"></asp:Label>
                        <asp:Button ID="btnPrintMediationInvoice" runat="server" CssClass="button"
                            Text="Print Mediation/Workout Invoice"
                            OnClick="btnPrintMediationInvoice_Click" />
                        <asp:Label ID="lblMessage" runat="server" Width="320px" Visible="false"></asp:Label>
                        <br />
                        <asp:Label ID="lblExtensionRequestDate" runat="server"
                            Text="Extension Request Date:" Width="175px"></asp:Label>
                        <asp:TextBox ID="txtExtensionRequestDate" TabIndex="6" runat="server" Width="130px"
                            MaxLength="10" />
                        <asp:ImageButton ID="ImageButton15" runat="server" CausesValidation="False"
                            ImageUrl="~/images/Calendar_scheduleHS.png"></asp:ImageButton>
                        <cc1:CalendarExtender ID="CalendarExtender14" runat="server" CssClass="RIHCalendar"
                            TargetControlID="txtExtensionRequestDate"
                            PopupPosition="BottomRight" PopupButtonID="ImageButton15" Enabled="True"
                            Format="MM/dd/yyyy">
                        </cc1:CalendarExtender>
                        <asp:Label ID="lblSpace9" runat="server" Width="170px" Visible="true"></asp:Label>
                        <asp:Label ID="lblMedInvoicePrintDate" runat="server" Height="20px"
                            CssClass="valign" Text="Med Invoice Print Date:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtMedInvoicePrintDate" TabIndex="7" runat="server" Width="150px"></asp:TextBox>
                        <br />
                        <asp:Label ID="lblExtensionExprDate" runat="server" Height="20px" CssClass="valign"
                            Text="Extension Expiration Date:" Width="175px"></asp:Label>
                        <asp:TextBox ID="txtExtensionExprDate" TabIndex="7" runat="server" MaxLength="10"
                            Width="130px"></asp:TextBox>
                        <br />
                        <asp:Label ID="lblConfResolutionDate" runat="server" Height="20px"
                            CssClass="valign" Text="Conf Resolution Date:" Width="175px"></asp:Label>
                        <asp:TextBox ID="txtConfResolutionDate" TabIndex="7" runat="server" MaxLength="10"
                            Width="130px"></asp:TextBox>
                        <asp:ImageButton ID="ImageButton19" runat="server" CausesValidation="False"
                            ImageUrl="~/images/Calendar_scheduleHS.png"></asp:ImageButton>
                        <cc1:CalendarExtender ID="CalendarExtender16" runat="server" CssClass="RIHCalendar"
                            TargetControlID="txtConfResolutionDate"
                            PopupPosition="BottomRight" PopupButtonID="ImageButton19" Enabled="True"
                            Format="MM/dd/yyyy">
                        </cc1:CalendarExtender>
                        <br />
                        <asp:Label ID="lblCounterOfferRejectedBorrower" runat="server"
                            Text="Counter Offer Rejected by Borrower:" Width="291px" />
                        <asp:CheckBox ID="chkCounterOfferRejectedBorrower" runat="server"
                            Font-Size="7pt" TabIndex="20" AutoPostBack="false"></asp:CheckBox>
                        <br />
                        <asp:Label ID="lblWO_FinancialBenefitBorrower" runat="server"
                            Text="Workout Agreement Financial Benefit to Borrower:" Width="291px" />
                        <asp:CheckBox ID="chkWO_FinancialBenefitBorrower" runat="server" Font-Size="7pt"
                            TabIndex="20" AutoPostBack="false"></asp:CheckBox>
                        <br />
                        <asp:Label ID="lblWO_AgreementInFile" runat="server"
                            Text="Workout Agreement In File ?" Width="291px" Height="22px"></asp:Label>
                        <asp:CheckBox ID="chkWO_AgreementInFile" runat="server" Font-Size="7pt"
                            TabIndex="20" AutoPostBack="false"></asp:CheckBox>
                        <asp:Label ID="lblSpace25" runat="server" Width="175px" Visible="true"></asp:Label>
                        <asp:Label ID="lblIncome" runat="server" Text="Income:" Width="150px" />
                        <asp:TextBox ID="txtIncome" TabIndex="7" runat="server" Width="150px"
                            MaxLength="10" Text="0.0"></asp:TextBox>
                        <cc1:MaskedEditExtender ID="MaskedEditExtenderIncome" runat="server"
                            TargetControlID="txtIncome" OnInvalidCssClass="MaskedEditError"
                            OnFocusCssClass="MaskedEditFocus" MaskType="Number"
                            Mask="9,999,999.99"
                            ErrorTooltipCssClass="MaskedEditError" AutoComplete="true"
                            MessageValidatorTip="true"
                            InputDirection="RightToLeft" AcceptNegative="None"
                            DisplayMoney="Left">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditExtender
                            ID="MaskedEditExtenderInitialContactDate" runat="server"
                            TargetControlID="txtInitialContactDate" OnInvalidCssClass="MaskedEditError"
                            OnFocusCssClass="MaskedEditFocus" MaskType="Date" Mask="99/99/9999"
                            ErrorTooltipCssClass="MaskedEditError" AutoComplete="false">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditExtender
                            ID="MaskedEditExtenderPackageSentDate" runat="server"
                            TargetControlID="txtPackageSentDate" OnInvalidCssClass="MaskedEditError"
                            OnFocusCssClass="MaskedEditFocus" MaskType="Date" Mask="99/99/9999"
                            ErrorTooltipCssClass="MaskedEditError" AutoComplete="false">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditExtender
                            ID="MaskedEditExtenderSheduledConfDate" runat="server"
                            TargetControlID="txtSheduledConfDate" OnInvalidCssClass="MaskedEditError"
                            OnFocusCssClass="MaskedEditFocus" MaskType="Date" Mask="99/99/9999"
                            ErrorTooltipCssClass="MaskedEditError" AutoComplete="false">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditExtender
                            ID="MaskedEditExtenderActualConfDate" runat="server"
                            TargetControlID="txtActualConfDate" OnInvalidCssClass="MaskedEditError"
                            OnFocusCssClass="MaskedEditFocus" MaskType="Date" Mask="99/99/9999"
                            ErrorTooltipCssClass="MaskedEditError" AutoComplete="false">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtenderConfResolveDeadlineDate"
                            runat="server" TargetControlID="txtConfResolveDeadlineDate" OnInvalidCssClass="MaskedEditError"
                            OnFocusCssClass="MaskedEditFocus" MaskType="Date" Mask="99/99/9999"
                            ErrorTooltipCssClass="MaskedEditError" AutoComplete="false">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtenderRequestExtensionByDate"
                            runat="server" TargetControlID="txtRequestExtensionByDate" OnInvalidCssClass="MaskedEditError"
                            OnFocusCssClass="MaskedEditFocus" MaskType="Date" Mask="99/99/9999"
                            ErrorTooltipCssClass="MaskedEditError" AutoComplete="false">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtenderExtensionRequestDate"
                            runat="server" TargetControlID="txtExtensionRequestDate" OnInvalidCssClass="MaskedEditError"
                            OnFocusCssClass="MaskedEditFocus" MaskType="Date" Mask="99/99/9999"
                            ErrorTooltipCssClass="MaskedEditError" AutoComplete="false">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtenderExtensionExprDate"
                            runat="server" TargetControlID="txtExtensionExprDate" OnInvalidCssClass="MaskedEditError"
                            OnFocusCssClass="MaskedEditFocus" MaskType="Date" Mask="99/99/9999"
                            ErrorTooltipCssClass="MaskedEditError" AutoComplete="false">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtenderConfResolutionDate"
                            runat="server" TargetControlID="txtConfResolutionDate" OnInvalidCssClass="MaskedEditError"
                            OnFocusCssClass="MaskedEditFocus" MaskType="Date" Mask="99/99/9999"
                            ErrorTooltipCssClass="MaskedEditError" AutoComplete="false">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtenderMedInvoicePrintDate"
                            runat="server" TargetControlID="txtMedInvoicePrintDate" OnInvalidCssClass="MaskedEditError"
                            OnFocusCssClass="MaskedEditFocus" MaskType="Date" Mask="99/99/9999"
                            ErrorTooltipCssClass="MaskedEditError" AutoComplete="false">
                        </cc1:MaskedEditExtender>
                    </asp:Panel>
                    <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender2" runat="server"
                        TargetControlID="pBody1" CollapseControlID="pHeader1" ExpandControlID="pHeader1"
                        Collapsed="true" TextLabelID="lblText1"
                        CollapsedText="Important Dates Panel - Click to Show Content.."
                        ExpandedText="Important Dates Panel - Click to Hide Content..">
                    </cc1:CollapsiblePanelExtender>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pHeader2" runat="server" CssClass="accordionHeader">
                        <asp:Label ID="lblText2" runat="server" />
                    </asp:Panel>
                    <asp:Panel ID="pBody2" runat="server" CssClass="cpBody">
                        <asp:Label ID="lblCertificateNoticeTypeReason" runat="server" Height="20px"
                            CssClass="valign" Text="Certificate/NoticeType&Reason:" Width="190px"></asp:Label>
                        <asp:DropDownList
                            ID="lstCertificateNoticeTypeReason" runat="server"
                            CssClass="valign" Width="350px" DataSourceID="SqlDataSourceCertificateNotice"
                            DataMember="DefaultView" DataValueField="CertificateNoticeID"
                            DataTextField="Name" AutoPostBack="True" OnTextChanged="lstCertificateNoticeTypeReason_TextChanged"
                            AppendDataBoundItems="true" ForeColor="#003399" Font-Bold="True">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSourceCertificateNotice" runat="server" ConnectionString="<%$ ConnectionStrings:Mediation2014ConnectionString %>"
                            SelectCommand="SELECT CertificateNoticeID, ISNULL(NoticeReasonDesc, '') + ISNULL(', ' + NoticeTypeDesc, '') AS Name FROM CertificateNotice WHERE CertificateNoticeID <> 9 UNION SELECT NULL AS Expr1, '--- Select One ----' AS Expr2 ORDER BY CertificateNoticeID"></asp:SqlDataSource>
                        <asp:Label ID="lblSpace10" runat="server" Width="190px"
                            Visible="true"></asp:Label>
                        <br />
                        <asp:Label ID="lblPenaltyPaidDate" runat="server"
                            Height="20px" CssClass="valign"
                            Text="Penalty Paid Date:" Width="190px"></asp:Label>
                        <asp:TextBox ID="txtPenaltyPaidDate" TabIndex="7" runat="server" Width="145px"
                            MaxLength="10"></asp:TextBox>
                        <asp:ImageButton ID="ImageButton4" runat="server" CausesValidation="False"
                            ImageUrl="~/images/Calendar_scheduleHS.png"></asp:ImageButton>
                        <cc1:CalendarExtender ID="CalendarExtender4" runat="server" CssClass="RIHCalendar"
                            TargetControlID="txtPenaltyPaidDate"
                            PopupPosition="BottomRight" PopupButtonID="ImageButton4"
                            Format="MM/dd/yyyy">
                        </cc1:CalendarExtender>
                        <asp:Label ID="lblSpace11" runat="server" Width="110px" Visible="true"></asp:Label>
                        <asp:Label ID="lblPenaltyAmount"
                            runat="server" Height="20px" CssClass="valign" Text="Penalty Amount:"
                            Width="150px"></asp:Label>
                        <asp:TextBox ID="txtPenaltyAmount" TabIndex="7" runat="server" Width="150px"
                            ReadOnly="true" Text="0.0"></asp:TextBox>
                        <cc1:MaskedEditExtender ID="MaskedEditExtenderPenaltyAmount" runat="server" TargetControlID="txtPenaltyAmount"
                            OnFocusCssClass="MaskedEditFocus" MaskType="Number"
                            Mask="9,999,999.99"
                            ErrorTooltipCssClass="MaskedEditError" AutoComplete="true"
                            MessageValidatorTip="true"
                            InputDirection="RightToLeft" AcceptNegative="None"
                            DisplayMoney="Left">
                        </cc1:MaskedEditExtender>
                        <!-- check box for waived penalty fees per Tricia H. _obd 03032015 
 ***********************************************************************-->
                        <asp:Label ID="lblPenaltyFeesWaivedSpacer" runat="server" Width="2px" Visible="true"></asp:Label>
                        <asp:CheckBox ID="chkWaived" runat="server" AutoPostBack="false" Visible="true"
                            Enabled="false" Text="Penalties Waived"></asp:CheckBox>
                        <!-- Hided by Jaheda Meman 07/08/2015
                             <!-- check box for waived penalty fees per Tricia H. _obd 03032015 
 ***********************************************************************-->
                        <br />
                        <asp:Label ID="lblMediationFeePaidDate" runat="server" Height="20px"
                            CssClass="valign" Text="Mediation Fee Paid Date:" Width="190px"></asp:Label>
                        <asp:TextBox ID="txtMediationFeePaidDate" TabIndex="7" runat="server"
                            Width="145px" MaxLength="10"></asp:TextBox>

                        <asp:ImageButton ID="ImageButton5" runat="server" CausesValidation="False"
                            ImageUrl="~/images/Calendar_scheduleHS.png"></asp:ImageButton>
                        <cc1:CalendarExtender ID="CalendarExtender5" runat="server" CssClass="RIHCalendar"
                            TargetControlID="txtMediationFeePaidDate"
                            PopupPosition="BottomRight" PopupButtonID="ImageButton5"
                            Format="MM/dd/yyyy">
                        </cc1:CalendarExtender>
                        <asp:Label ID="lblSpace12" runat="server" Width="110px" Visible="true"></asp:Label>
                        <asp:Label ID="lblMediationFeeAmount" runat="server"
                            Text="Mediation Fee Amount:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtMediationFeeAmount" runat="server" Width="149"
                            Enabled="False" ReadOnly="True"></asp:TextBox>
                        <cc1:MaskedEditExtender ID="MaskedEditExtenderMediationFeeAmount" runat="server"
                            TargetControlID="txtMediationFeeAmount" OnInvalidCssClass="MaskedEditError"
                            OnFocusCssClass="MaskedEditFocus" MaskType="Number"
                            Mask="9,999,999.99"
                            ErrorTooltipCssClass="MaskedEditError" AutoComplete="true"
                            MessageValidatorTip="true"
                            InputDirection="RightToLeft" AcceptNegative="None"
                            DisplayMoney="Left">
                        </cc1:MaskedEditExtender>
                        <br />
                        <asp:Label ID="lbCertiNoticePrintedDate" runat="server" Height="20px"
                            CssClass="valign" Text="Certificate Notice Printed Date:" Width="190px"></asp:Label>
                        <asp:TextBox ID="txtCertificateNoticePrintDate" TabIndex="7" runat="server"
                            Width="145px" MaxLength="10"></asp:TextBox>
                        <asp:Label ID="lblSpace26" runat="server" Width="284px" Visible="true"></asp:Label>
                        <asp:Button ID="btnPrintCertificate" runat="server" CssClass="button"
                            OnClick="btnPrintCertificate_Click" Text="Print Certificate/Letter"
                            ToolTip="" Height="21px" />
                        <br />
                        <asp:Label ID="lblCertificateLetterReprintDate" runat="server" Height="20px"
                            CssClass="valign" Text="Certificate Notice Reprinted Date:" Width="190px"></asp:Label>
                        <asp:TextBox ID="txtCertificateLetterReprintDate" TabIndex="7" runat="server"
                            Width="145px" MaxLength="10"></asp:TextBox>
                        <asp:Label ID="lblSpace14" runat="server" Width="284px" Visible="true"></asp:Label>
                        <asp:Button ID="btnReprintCertificate" runat="server" CssClass="button"
                            OnClick="btnReprintCertificate_Click" Text="Reprint Certificate/Letter"
                            ToolTip="Reprint Certificate " />
                        <%-- check box for Duplicate Certificate Fee Paid per Tricia H. _JahedaMeman 07/8/2015 --%><asp:Label
                            ID="lblSpaceDuplicateCertificateFeePaid" runat="server"
                            Width="10px" Visible="False"></asp:Label>
                        <asp:CheckBox ID="chkDuplicateCertificateFeePaid" runat="server" AutoPostBack="false"
                            Text="Duplicate Certificate Fee Collected" Visible="False"></asp:CheckBox>
                        <!-- check box for DuplicateCertificateFeePaid  per Tricia H. _Jaheda Meman 07/8/2015 
 ***********************************************************************-->
                        <br />
                        <br />
                        <asp:Label ID="lblCertificateLenderName" runat="server"
                            Text="Certificate Lender Name:" Width="190px"></asp:Label>
                        <asp:TextBox ID="txtCertificateLenderName" runat="server" Width="500"
                            MaxLength="500" TextMode="MultiLine"
                            TabIndex="22"></asp:TextBox>
                        <br />
                        <asp:Label ID="lblSpace24" runat="server" Width="717px" Visible="true"></asp:Label>
                        <br />
                        <cc1:MaskedEditExtender
                            ID="MaskedEditExtenderPenaltyPaidDate" runat="server"
                            TargetControlID="txtPenaltyPaidDate" OnInvalidCssClass="MaskedEditError"
                            OnFocusCssClass="MaskedEditFocus" MaskType="Date" Mask="99/99/9999"
                            ErrorTooltipCssClass="MaskedEditError" AutoComplete="false">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtenderMediationFeePaidDate"
                            runat="server" TargetControlID="txtMediationFeePaidDate" OnInvalidCssClass="MaskedEditError"
                            OnFocusCssClass="MaskedEditFocus" MaskType="Date" Mask="99/99/9999"
                            ErrorTooltipCssClass="MaskedEditError" AutoComplete="false">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtenderCertificateNoticePrintDate"
                            runat="server" TargetControlID="txtCertificateNoticePrintDate" OnInvalidCssClass="MaskedEditError"
                            OnFocusCssClass="MaskedEditFocus" MaskType="Date" Mask="99/99/9999"
                            ErrorTooltipCssClass="MaskedEditError" AutoComplete="false">
                        </cc1:MaskedEditExtender>
                        <cc1:MaskedEditExtender ID="MaskedEditExtenderCertificateLetterReprintDate"
                            runat="server" TargetControlID="txtCertificateLetterReprintDate" OnInvalidCssClass="MaskedEditError"
                            OnFocusCssClass="MaskedEditFocus" MaskType="Date" Mask="99/99/9999"
                            ErrorTooltipCssClass="MaskedEditError" AutoComplete="false">
                        </cc1:MaskedEditExtender>
                    </asp:Panel>
                    <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender3" runat="server"
                        TargetControlID="pBody2" CollapseControlID="pHeader2" ExpandControlID="pHeader2"
                        Collapsed="true" TextLabelID="lblText2" CollapsedText="Certificates & Letters Panel - Click to Show Content.."
                        ExpandedText="Certificates & Letters Panel - Click to Hide Content..">
                    </cc1:CollapsiblePanelExtender>
                </ContentTemplate>
            </asp:UpdatePanel>
            <%--  <!...End Third panel--->--%><%--  <!...Fourth panel--->--%><asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pHeader3" runat="server" CssClass="accordionHeader">
                        <asp:Label ID="lblText3" runat="server" />
                    </asp:Panel>
                    <asp:Panel ID="pBody3" runat="server" CssClass="cpBody">
                        <!-- SECOND NAVIGATION BUTTON-->
                        <table class="navTable2">
                            <tr>
                                <td align="left" style="height: 22px">
                                    <asp:Button ID="btnLenderContact" runat="server" Text="Lender Contact" CssClass="naButton"
                                        CausesValidation="False" UseSubmitBehavior="False"
                                        OnClick="btnLenderContact_Click" /></td>
                                <td align="left" style="height: 22px">
                                    <asp:Button ID="btnAttorneyContact" runat="server" Text="Attorney Contact" CssClass="naButton"
                                        CausesValidation="False" UseSubmitBehavior="False"
                                        OnClick="btnAttorneyContact_Click" /></td>
                                <td align="left" style="height: 22px">
                                    <asp:Button ID="btnCertificateLetterContact" runat="server"
                                        Text="Certificate Letter Contact" CssClass="naButton"
                                        CausesValidation="False" UseSubmitBehavior="False"
                                        OnClick="btnCertificateLetterContact_Click" />
                                </td>
                                <td align="left" style="height: 22px">
                                    <asp:Button ID="btnMediationContact" runat="server" Text="Mediation Contact" CssClass="naButton"
                                        CausesValidation="False" UseSubmitBehavior="False"
                                        OnClick="btnMediationContact_Click" />
                                </td>
                                <td align="left" style="height: 22px">
                                    <asp:Button ID="btnServiceContact" runat="server" Text="Servicer Contact" CssClass="naButton"
                                        CausesValidation="False" UseSubmitBehavior="False"
                                        OnClick="btnServiceContact_Click" />
                                </td>
                                <td align="left" valign="middle" style="height: 22px">
                                    <img src="../images/navSeperator.gif" alt="" /></td>

                                <td style="width: 100%; height: 22px;">&nbsp</td>
                            </tr>
                        </table>
                        <!-- LENDER CONTACT-->
                        <br />
                        <br />
                        <asp:Label ID="lblnamelist" runat="server" Width="133px" Text=" "></asp:Label>
                        <asp:DropDownList ID="lstName" runat="server" DataTextField="Name" Width="500px"
                            DataValueField="ID" CssClass="valign"
                            AutoPostBack="True" ForeColor="#003399" Font-Bold="True"
                            OnSelectedIndexChanged="lstName_SelectedIndexChanged">
                        </asp:DropDownList>
                        <br />
                        <asp:Label ID="lblSpace19" runat="server" Width="355px"></asp:Label>
                        <asp:Panel ID="pnlLender" runat="server">
                            <asp:Label ID="lblName" runat="server" Text="" Width="136px" /><asp:TextBox
                                ID="txtName" runat="server" MaxLength="60" Width="375px" TabIndex="21"
                                ValidationGroup="Contact"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Lender Name is a required field"
                                CssClass="error" ControlToValidate="txtName" ValidationGroup="contact">Lender name is a required field</asp:RequiredFieldValidator>
                            <br />
                            <asp:Label ID="lblContactName" runat="server" Text="" Width="134px" />
                            <asp:TextBox ID="txtContactName" runat="server" MaxLength="30" TabIndex="22" Width="250px"
                                ValidationGroup="contact"></asp:TextBox>
                            <br />
                            <asp:Label ID="lblContactTitle" runat="server" Text="Contact Title:" Width="134px" />
                            <asp:TextBox ID="txtContactTitle" runat="server" TabIndex="23" MaxLength="30"
                                Width="250px" ValidationGroup="contact"></asp:TextBox>
                            <br />
                            <asp:Label ID="Label1" runat="server" Text="Address 1:" Width="137px" /><asp:TextBox
                                ID="txtaddresscontact_1" runat="server" MaxLength="40" Width="450px" TabIndex="24"
                                ValidationGroup="contact"></asp:TextBox>
                            <br />
                            <asp:Label ID="Label2" runat="server" Text="Address 2" Width="137px"></asp:Label><asp:TextBox
                                ID="txtaddresscontact_2" runat="server" MaxLength="40" Width="450px" TabIndex="25"
                                ValidationGroup="contact"></asp:TextBox><br />
                            <asp:Label ID="Label3" runat="server" Text="City, State, Zip:" Width="137px" /><asp:TextBox
                                ID="txtcontactcity" runat="server" MaxLength="40" Width="288px" TabIndex="26"
                                ValidationGroup="contact"></asp:TextBox>
                            <asp:TextBox ID="txtContactState" runat="server" MaxLength="2" Width="40px" TabIndex="27"
                                ValidationGroup="contact"></asp:TextBox>
                            <asp:TextBox ID="txtContactZip" runat="server" MaxLength="5" Width="100px" TabIndex="28"
                                ValidationGroup="contact"></asp:TextBox>
                            <br />
                            <asp:Label ID="lblEmail" runat="server" Text="Email:" Width="137px" /><asp:TextBox
                                ID="txtEmail" runat="server" MaxLength="60" Width="300px" TabIndex="29"
                                ValidationGroup="contact"></asp:TextBox><br />
                            <asp:Label ID="lblPhone" runat="server" Text="Office Phone:" Width="137px" /><asp:TextBox
                                ID="txtPhoneNumber" runat="server" MaxLength="20" Width="89px" TabIndex="30"></asp:TextBox>
                            <cc1:MaskedEditExtender ID="MaskedEditExtenderPhone" runat="server" TargetControlID="txtPhoneNumber"
                                AutoComplete="false" Mask="(999)999-9999" MaskType="Number" ErrorTooltipCssClass="MaskedEditError"
                                OnInvalidCssClass="MaskedEditError" OnFocusCssClass="MaskedEditFocus" ClearMaskOnLostFocus="false" />
                            <asp:Label ID="Label4" runat="server" Width="125px"></asp:Label>
                            <%-- 3/19/15_obd: updated the phone extension (and the mask) to 10 characters instead of 4      --%>
                            <asp:Label ID="lblExtention" runat="server" Text="Extension:" Width="150px"></asp:Label><asp:TextBox
                                ID="txtExtension" runat="server" Width="100px" TabIndex="31" MaxLength="10" ValidationGroup="contact"></asp:TextBox>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender2" runat="server" TargetControlID="txtExtension"
                                AutoComplete="false" Mask="9999999999" MaskType="Number" ErrorTooltipCssClass="MaskedEditError"
                                OnInvalidCssClass="MaskedEditError" OnFocusCssClass="MaskedEditFocus" ClearMaskOnLostFocus="false" />
                            <br />
                            <asp:Label ID="lblFax" runat="server" Text="Fax:" Width="135px" />
                            <asp:TextBox ID="txtFaxNumber"
                                runat="server" MaxLength="10" Width="89px" TabIndex="32" ValidationGroup="contact"></asp:TextBox>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFaxNumber"
                                AutoComplete="false" Mask="(999)999-9999" MaskType="Number" ErrorTooltipCssClass="MaskedEditError"
                                OnInvalidCssClass="MaskedEditError" OnFocusCssClass="MaskedEditFocus" ClearMaskOnLostFocus="false" />
                            <asp:Label ID="Label32" runat="server" Width="125px"></asp:Label>
                            <br />
                            <asp:Label ID="lblAltPhone" runat="server" Text="Alternate Phone:" Width="137px" /><asp:TextBox
                                ID="txtAltPhone" runat="server" MaxLength="10" Width="89px" TabIndex="33"
                                ValidationGroup="contact"></asp:TextBox>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender3" runat="server" TargetControlID="txtAltPhone"
                                AutoComplete="false" Mask="(999)999-9999" MaskType="Number" ErrorTooltipCssClass="MaskedEditError"
                                OnInvalidCssClass="MaskedEditError" OnFocusCssClass="MaskedEditFocus" ClearMaskOnLostFocus="false" />
                            <asp:Label ID="Label5" runat="server" Width="125px"></asp:Label>
                            <%-- 3/19/15_obd: updated the phone extension (and the mask) to 10 characters instead of 4      --%>
                            <asp:Label ID="lblAlExtention" runat="server" Text="Alternate Extension:" Width="150px" />
                            <asp:TextBox ID="txtAlExtention" runat="server" Width="100px" TabIndex="34"
                                MaxLength="10" ValidationGroup="contact"></asp:TextBox>
                            <cc1:MaskedEditExtender ID="MaskedEditExtender4" runat="server" TargetControlID="txtAlExtention"
                                AutoComplete="false" Mask="9999999999" MaskType="Number" ErrorTooltipCssClass="MaskedEditError"
                                OnInvalidCssClass="MaskedEditError" OnFocusCssClass="MaskedEditFocus" ClearMaskOnLostFocus="false" />
                            &nbsp;<br />
                            <br />
                            <br />
                            <asp:Label ID="Label7" runat="server" Width="155px"></asp:Label>
                            <asp:Button ID="btnSaveContact" runat="server" Text="Add New Record" CssClass="buttonSave"
                                TabIndex="35" Width="120px" ValidationGroup="contact" CausesValidation="true"
                                OnClick="btnSaveContact_Click" />
                            <asp:Label ID="Label8" runat="server" Width="25px"></asp:Label>
                            <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="button" TabIndex="36"
                                UseSubmitBehavior="true" Width="100px" CausesValidation="false"
                                OnClick="btnReset_Click" />
                            <asp:Label ID="lblAddedContact" runat="server" CssClass="error"></asp:Label>
                            <%--   FOR THE ERROR MESSAGE CSS. USE FOR THE REQUIRED FIELD VALIDATION--%>
                        </asp:Panel>
                    </asp:Panel>
                    <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender4" runat="server" TargetControlID="pBody3" CollapseControlID="pHeader3" ExpandControlID="pHeader3"
                        Collapsed="true" TextLabelID="lblText3" CollapsedText="Point of Contacts Panel - Click to Show Content.." ExpandedText="Point of Contacts Panel - Click to Hide Content..">
                    </cc1:CollapsiblePanelExtender>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <%--  <!...End Fourth panel--->--%>
            <asp:Label ID="lblSpace13" runat="server" Width="152px"></asp:Label>
            <asp:Button ID="btnSave" runat="server" Text="Save" Width="100px" CausesValidation="true"
                CssClass="buttonSave" TabIndex="45"
                OnClick="btnSave_Click" />
            <br />
        </div>
        <!---Start Main Div--->
    </div>
</asp:Content>
