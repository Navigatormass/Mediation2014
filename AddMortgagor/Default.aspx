<%@ Page Title="Add a new Mortgagor" Language="C#" MasterPageFile="~/MediationMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="AddMortgagor_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!---Start Main Div--->
    <div>
        <table class="navTable">
            <tr>
                <td>&nbsp; 
                </td>
            </tr>
        </table>
        <br />
        <div id="header">
            Add Mortgagor
              <asp:Label ID="lblSpace8" runat="server" Width="600px" Text=""></asp:Label><asp:Label ID="lblMediationCaseCount" runat="server" Text="Mediation Case Count:" Width="250px">
              </asp:Label>
            <asp:TextBox ID="txtMediationCaseCount" runat="server" Width="150px" MaxLength="4" ReadOnly="true" Enabled="False"></asp:TextBox><br />
        </div>
        <asp:Label ID="lblSpace2" runat="server" Width="30px" Text=""></asp:Label><br />
        <asp:Label ID="lblSpace10" runat="server" Width="30px" Text=""></asp:Label><asp:Label ID="lblReminder" runat="server" Text="Reminder" CssClass="error" Width="500px"></asp:Label>
        <br />
        <!---Start Form Div--->
        <div class="form">
            <asp:Panel ID="pnlBorrower" runat="server" CssClass="Brpanel">
                <br />
                <br />
                <asp:Label ID="lblFirstName" runat="server" Text="First Name" Width="150px"></asp:Label>
                <asp:TextBox ID="txtFirstName" runat="server" Width="150px" MaxLength="35" TabIndex="1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName"
                    CssClass="error" ErrorMessage="First Name is a required field">*</asp:RequiredFieldValidator>
                <asp:Label ID="lblSpace3" runat="server" Width="153px" />
                <br />
                <br />
                <asp:Label ID="lblMiddleInitial" runat="server" Text="Middle Initial:"
                    Width="150px"></asp:Label>
                <asp:TextBox ID="txtMiddleInitial" runat="server" MaxLength="35" Width="150px" TabIndex="2" />
                <asp:Label ID="lblSpace4" runat="server" Width="166px" />
                <br />
                <br />
                <asp:Label ID="lblLastName" runat="server" Text="Last Name:" Width="150px"></asp:Label>
                <asp:TextBox ID="txtLastName" runat="server" MaxLength="35" Width="150px" TabIndex="3" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName"
                    CssClass="error" ErrorMessage="Last Name is a required field">*</asp:RequiredFieldValidator>
                <asp:Label ID="lblSpace5" runat="server" Width="481px" />
                <br />
                <br />
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
                <br />
                <asp:Label ID="lblAlias" runat="server" Text="Alias:" Width="150px"></asp:Label>
                <asp:TextBox ID="txtAlias" runat="server" TabIndex="5" MaxLength="70" Width="150px"></asp:TextBox>
                <asp:Label ID="lblSpace14" runat="server" Width="167px" />
                <asp:Label ID="lblSpace7" runat="server" Width="480px" />
                <br />
                <br />
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblAddress1" runat="server" Text="Address:" Width="150px" />
                        <asp:TextBox ID="txtAddress_1" runat="server" MaxLength="80" TabIndex="6" Width="530px" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAddress_1" CssClass="error" ErrorMessage="Address is a required field">*</asp:RequiredFieldValidator>
                        <br />
                        <br />
                        <asp:Label ID="lblAddress2" runat="server" Text="Address 2:" Width="150px" />
                        <asp:TextBox ID="txtAddress_2" runat="server" MaxLength="80" TabIndex="7" Width="530px" />
                        <br />
                        <br />
                        <asp:Label ID="lblzipcode" runat="server" Text="Zip:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtZipCode" runat="server" MaxLength="5" TabIndex="8" Width="80px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtZipCode" CssClass="error" ErrorMessage="Mailing Zip is a required feild">*</asp:RequiredFieldValidator>
                        <asp:Button ID="btnGetCity" runat="server" TabIndex="-1" CausesValidation="False" CssClass="button" Height="20px" OnClick="btnGetCity_Click" Text="Get City Info" />
                        <br />
                        <br />
                        <asp:Label ID="lblcity" runat="server" Text="City, State:" Width="150px"></asp:Label>
                        <asp:TextBox ID="txtCity" runat="server" MaxLength="40" TabIndex="9" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCity"
                            CssClass="error" ErrorMessage="City Name is a required field">*</asp:RequiredFieldValidator>
                        <%--Start City List by Name--%>
                        <asp:DropDownList ID="lstCities" runat="server" DataSourceID="SqlDataSourceCities" DataTextField="City" DataValueField="City" Visible="False"> <%--OnSelectedIndexChanged="lstCities_SelectedIndexChanged"--%>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSourceCities" runat="server" ConnectionString="<%$ ConnectionStrings:Mediation2014ConnectionString %>" SelectCommand="SELECT [City] FROM [RI_ZipCodes] WHERE ([ZipCode] = @ZipCode) ORDER BY City DESC">
                            <SelectParameters>
                                <asp:SessionParameter Name="ZipCode" SessionField="zipCode" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <%--End City List by Name--%>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtState" CssClass="error" ErrorMessage="Please enter a City">*</asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtState" runat="server" TabIndex="-1" MaxLength="2" Text="RI" Width="40px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtState" CssClass="error" ErrorMessage="Please enter a State">*</asp:RequiredFieldValidator>
                        <asp:Label ID="lblZipError" runat="server" CssClass="error"></asp:Label>
                        <br />
                        <br />
                        <asp:Label ID="lblCensusTract" runat="server" Text="Census Tract:" Width="150px"></asp:Label>
                        <asp:Button ID="btnGetCensusTract" runat="server" TabIndex="-1" CausesValidation="False" CssClass="button" Height="20px" OnClick="btnGetCensusTract_Click" Text="Get Census Tract" Width="150px" />
                        <asp:TextBox ID="txtCensusTract" runat="server" Enabled="False" MaxLength="5" Width="90px"></asp:TextBox>
                        &nbsp;<asp:Label ID="lblCensusTractError" runat="server" CssClass="error"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
                <asp:UpdatePanel ID="UpdatePanelRace" runat="server">
                    <ContentTemplate>
                        <asp:Label ID="lblRace" runat="server" Text="Race:" Width="150px"></asp:Label>
                        <asp:DropDownList ID="lstRace" runat="server" TabIndex="10" DataTextField="RaceDesc" DataSourceID="SqlDataSourceRace" DataValueField="RaceID" DataMember="DefaultView" AutoPostBack="True" ForeColor="#003399" Font-Bold="True" Height="22px"></asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSourceRace" runat="server" ConnectionString="<%$ ConnectionStrings:Mediation2014ConnectionString %>" SelectCommand="SELECT [RaceID], [RaceDesc] FROM [Race]"></asp:SqlDataSource>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
                <br />
                <asp:Label ID="lblGender" runat="server" Text="Gender:" Width="150px"></asp:Label>
                <asp:DropDownList ID="lstGender" runat="server" TabIndex="11" AutoPostBack="false" ForeColor="#003399" Font-Bold="True">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem Value="M">Male</asp:ListItem>
                    <asp:ListItem Value="F">Female</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                <asp:Label ID="lblHispanic" runat="server" Text="Hispanic ?" Width="150px"></asp:Label>
                <asp:CheckBox ID="chkHispanic" runat="server" Font-Size="7pt" TabIndex="12" AutoPostBack="false"></asp:CheckBox>
                <br />
                <br />
                <asp:Label ID="lblPhone" runat="server" Text="Primary Phone:" Width="150px"></asp:Label>
                <asp:TextBox ID="txtPhoneNumber" runat="server" TabIndex="13" Width="150px" />
                <cc1:MaskedEditExtender ID="MaskedEditExtenderPhoneNumber" runat="server" TargetControlID="txtPhoneNumber" AutoComplete="false" Mask="(999)999-9999" MaskType="Number" ErrorTooltipCssClass="MaskedEditError"
                    OnInvalidCssClass="MaskedEditError" OnFocusCssClass="MaskedEditFocus" ClearMaskOnLostFocus="false" />
                <br />
                <br />
                <asp:Label ID="lblCellPhone" runat="server" Text="Cell Phone:" Width="150px"></asp:Label>
                <asp:TextBox ID="txtCellPhone" runat="server" TabIndex="14" Width="150px" />
                <cc1:MaskedEditExtender ID="MaskedEditExtenderCellPhone" runat="server" AutoComplete="false" ErrorTooltipCssClass="MaskedEditError" Mask="(999)999-9999" MaskType="Number" OnFocusCssClass="MaskedEditFocus" OnInvalidCssClass="MaskedEditError" TargetControlID="txtCellPhone" ClearMaskOnLostFocus="false" />
                <br />
                <br />
                <asp:Label ID="lblEmail" runat="server" Text="Email:" Width="150px"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" MaxLength="60" TabIndex="15" Width="300"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="btnSubmit" runat="server" CssClass="buttonSave" OnClick="btnSubmit_Click" PostBackUrl="Default.aspx" CausesValidation="true" TabIndex="16" Text="Save" Width="100px" />
                <asp:Label ID="lblspace" runat="server" Visible="False" Width="30px"></asp:Label>
                &nbsp;
                <asp:Label ID="lblAdded" runat="server" CssClass="error"></asp:Label>
                <%--   FOR THE ERROR MESSAGE CSS. USE FOR THE REQUIRED FIELD VALIDATION--%>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="requestPanel2"
                    Width="479px" />
            </asp:Panel>
        </div>
        <!---End Main Div--->
    </div>
</asp:Content>

