<%@ Page Language="C#" MasterPageFile="~/MediationMasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="dailyReports" Title="Mediation 2014 Reports" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">

        //function checkEntryDate()
        //{
        //   var fromDate = document.getElementById("ctl00_ContentPlaceHolder1_txtFrEntryDate").value;
        //   var toDate = document.getElementById("ctl00_ContentPlaceHolder1_txtToEntryDate").value;
        //   if(fromDate=="")
        //   {
        //        fromDate = "01/01/2000";
        //   }
        //   if(toDate=="")
        //   {
        //        alert("You must have a to date selected");           
        //   }
        //   else
        //   {
        //        location.href = "~../../ReportPages/ProgramOverview.aspx?entryDate=" + fromDate + "&entryDate=" + toDate;
        //   }
        //}  
    </script>

    <div style="width: 840px;">

        <asp:Panel runat="server" ID="rptList" Width="840px">
            <table border="0"
                style="margin-left: 40px; margin-right: 40px; width: 744px; margin-top: 0px;"
                cellpadding="5">
                <tr>
                    <td valign="top" colspan="4">
                        <h3>Mediation 2014 Reports</h3>
                        <p style="width: 750px">
                            <asp:Label ID="Label3" runat="server" Text="Please click on the report you want to view, then click on the Go Back link or the report tab to come back to this report page."
                                Width="350px"></asp:Label>
                        </p>
                        <div>
                            <asp:LinkButton ID="lnkACL0" runat="server" OnClick="lnkDFPAll_Click">Duplicate Fees Paid -- All systems</asp:LinkButton>
                            <br />
                        </div>
                        <asp:Panel ID="pnlEntryDate" runat="server" CssClass="rptDateRangePanel" Style="display: block; width: 375px; height: 101px;"
                            Direction="LeftToRight"
                            HorizontalAlign="Right" BorderStyle="None">
                            <div style="text-align: left;">
                                <asp:Label ID="Label21" runat="server" Style="text-align: left;" Text="Please select the dates range you would like to view for this report."
                                    Width="336px"></asp:Label>
                                <br />
                                <br />
                                From:&nbsp;<asp:TextBox ID="txtFrEntryDate" runat="server" Width="100px"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="txtFrEntryDate_MaskedEditExtender" runat="server" Enabled="True"
                                    Mask="99/99/9999" MaskType="Date" TargetControlID="txtFrEntryDate">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="txtFrEntryDate_CalendarExtender" runat="server" CssClass="RIHCalendar"
                                    Enabled="True" PopupButtonID="Image1" TargetControlID="txtFrEntryDate">
                                </cc1:CalendarExtender>
                                &nbsp;<asp:Image ID="Image1" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" />
                                &nbsp; To:&nbsp;<asp:TextBox ID="txtToEntryDate" runat="server" Width="100px"></asp:TextBox>
                                <cc1:MaskedEditExtender ID="txtToEntryDate_MaskedEditExtender" runat="server" Enabled="True"
                                    Mask="99/99/9999" MaskType="Date" TargetControlID="txtToEntryDate">
                                </cc1:MaskedEditExtender>
                                <cc1:CalendarExtender ID="txtToEntryDate_CalendarExtender" runat="server" CssClass="RIHCalendar"
                                    Enabled="True" PopupButtonID="Image2" TargetControlID="txtToEntryDate">
                                </cc1:CalendarExtender>
                                &nbsp;<asp:Image ID="Image2" runat="server" ImageUrl="~/images/Calendar_scheduleHS.png" />
                                <br />
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnYesButton" runat="server" CssClass="button" Text="Enter"
                            Width="75px" />
                                <asp:Label ID="Label6" runat="server" Text="" Width="50px"></asp:Label>
                                <asp:Button ID="Button2" runat="server" CssClass="button" Text="Cancel" />
                                <br />
                            </div>
                        </asp:Panel>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="Label23" runat="server" Font-Bold="True" Text="Daily Reports"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 33%">
                        <asp:LinkButton ID="lnkCRNC" runat="server" OnClick="lnkCRNC_Click">Case 
                Resolved No Cert. Issued</asp:LinkButton>
                    </td>
                    <td style="width: 33%">
                        <asp:LinkButton ID="lnkIF" runat="server" OnClick="lnkInitialFee_Click">Daily 
                Initial Fees</asp:LinkButton>
                    </td>
                    <td style="width: 34%">
                        <asp:LinkButton ID="lnkACL" runat="server" OnClick="lnkACL_Click">Expired Non 
                Response Listing</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="width: 33%">
                        <asp:LinkButton ID="lnkCWCC" runat="server" OnClick="lnkCWCC_Click">Cases without 
                 Certificate Contacts</asp:LinkButton>
                    </td>
                    <td style="width: 33%">
                        <asp:LinkButton ID="lnkPF" runat="server" OnClick="lnkPenaltyFee_Click">Daily 
                 Penalty Fees</asp:LinkButton>
                    </td>
                    <td style="width: 34%">
                        <asp:LinkButton ID="lnkMFL" runat="server" OnClick="lnkMFL_Click">Missing First 
                Letter Sent Date</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="width: 33%">
                        <asp:LinkButton ID="lnkCWSC" runat="server" OnClick="lnkCWSC_Click">Cases 
                without Servicer Contacts</asp:LinkButton>
                    </td>
                    <td style="width: 33%">
                        <asp:LinkButton ID="lnkMF" runat="server" OnClick="lnkMediationFee_Click">Daily 
                Mediation Fees</asp:LinkButton>
                    </td>
                    <td style="width: 34%">
                        <asp:LinkButton ID="lnkMSL" runat="server" OnClick="lnkMSL_Click">Missing Second 
                Letter Sent Date</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="width: 33%">
                        <asp:LinkButton ID="lnkDCF" runat="server" OnClick="lnkDCF_Click">Duplicate Certificate Fee</asp:LinkButton>
                    </td>
                    <td style="width: 33%">
                        <asp:LinkButton ID="lnkDWMF" runat="server" OnClick="lnkDWMF_Click">Daily Workout Mediation Fees</asp:LinkButton>
                    </td>
                    <td style="width: 34%">
                        <asp:LinkButton ID="lnkPSMC" runat="server" OnClick="lnkPSMC_Click">Pending 
                Scheduling Mediation by Counselor</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="width: 33%">
                        <asp:LinkButton ID="lnkSMNC" runat="server" OnClick="lnkSMNC_Click">Scheduled 
                 Mediation No Conference</asp:LinkButton>
                    </td>
                    <td style="width: 33%">
                        <asp:LinkButton ID="lnkUMF0" runat="server" OnClick="lnkUMF_Click">Unpaid 
                 Mediation Fees</asp:LinkButton>
                    </td>
                    <td style="width: 34%">
                        <asp:LinkButton ID="lnkPDCR" runat="server" OnClick="lnkPDCR_Click">Past Due 
                Conference Results</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <br />
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Non-Daily Reports"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width: 33%">
                        <%--                <asp:LinkButton ID="lnkGF" runat="server" OnClick="lnkGF_Click">Appendix C Good 
                Faith</asp:LinkButton>--%>
                        <asp:LinkButton ID="lnkCPP" runat="server" OnClick="lnkCPP_Click">Capped 
                 Penalties Paid by Servicer</asp:LinkButton>
                    </td>
                    <td style="width: 33%">
                        <asp:LinkButton ID="lnkPFW" runat="server" OnClick="lnkPFW_Click">Penalty Fees 
                Waived</asp:LinkButton>
                    </td>
                    <td style="width: 34%">
                        <asp:LinkButton ID="lnkMCNC" runat="server" OnClick="lnkMCNC_Click">Mediation 
                Conference No Certificates</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="width: 33%">
                        <asp:LinkButton ID="lnkCEI" runat="server" OnClick="lnkCEI_Click">Closed/Exempt/Inactive 
                Cases</asp:LinkButton>
                    </td>
                    <td style="width: 33%">
                        <asp:LinkButton ID="lnkPOS" runat="server" OnClick="lnkPOS_Click">Penalties Owed 
                by Servicer</asp:LinkButton>
                    </td>
                    <td style="width: 34%">
                        <asp:LinkButton ID="lnkMLbL" runat="server" OnClick="lnkMLbL_Click">Mediation 
                Listing by Lastname</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <%--<td style="width: 34%">
                <asp:LinkButton ID="lnkPO" runat="server" Enabled="False" >Program Overview</asp:LinkButton>
                    <cc1:ModalPopupExtender ID="lnkPO_Ext" 
                        runat="server" DynamicServicePath="" Enabled="True" 
                    TargetControlID="lnkPO" OkControlID="btnYesButton" 
                    OnOkScript="checkEntryDate()" PopupControlID="pnlEntryDate" 
                    BackgroundCssClass="modalBackground2"  > 
                    modalBackground2 in stylesheetmediation.css _obd 6/23/15
                    </cc1:ModalPopupExtender>
            </td>--%>

                    <td style="width: 34%">
                        <asp:LinkButton ID="lnkMFO" runat="server" OnClick="lnkMFO_Click">Mediation Owed 
                 by Servicer</asp:LinkButton>
                    </td>

                    <td style="width: 34%">
                        <asp:LinkButton ID="lnkCDO6F" runat="server" OnClick="lnkCDO6F_Click">Cases Default Over 60</asp:LinkButton>
                    </td>


                    <td style="width: 34%">
                        <asp:LinkButton ID="lnkPPBS" runat="server" OnClick="lnkPPBS_Click">Penalties Paid By Servicer</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td style="width: 34%">
                        <asp:LinkButton ID="lnkPORTDMR" runat="server" OnClick="lnkPORTDMR_Click">Program Overview Report to Date Manager Revised</asp:LinkButton>
                    </td>

                    <td style="width: 33%">
                        <asp:LinkButton ID="LinkButton4" runat="server" OnClick="lnkPORTDMT_Click">Program Overview Report to Date Manager RPT2</asp:LinkButton>
                    </td>

                    <td style="width: 33%">
                        <asp:LinkButton ID="lnkMCasesConfDtes" runat="server" OnClick="lnkMCasesConfDtes_Click">Mediation Cases with Conference Call Dates</asp:LinkButton>
                    </td>

                </tr>
            </table>
        </asp:Panel>
        <br />
        <br />
    </div>


</asp:Content>
