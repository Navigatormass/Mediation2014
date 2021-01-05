<%@ Page Language="C#" MasterPageFile="../MediationMasterPage.master" AutoEventWireup="true"
    CodeFile="NoAccess.aspx.cs" Inherits="Errors_NoAccess" Title="No Permisions Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>
        <table class="navTable">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div id="form">
        <table width="600">
            <tr>
                <td align="center" valign="top">
                    <img src="../images/mainlogo.gif" alt="Rhode Island Housing" class="logo" />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <div id="header2">
                        Sorry, but you do not have permissions to view the page you requested.</div>
                </td>
            </tr>
            <tr>
                <td style="height: 200px;">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
