using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Text.RegularExpressions;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
//using System.Windows.Forms;
using BAL;
using DAL;

public partial class AddMediationCaseInformation_Default :
System.Web.UI.Page
{
    MediationCaseContactsBAL MediationCaseContactsBALObj = new MediationCaseContactsBAL();

    MediationCaseNotesDAL MediationCaseNotesDALobj = new MediationCaseNotesDAL();
    MediationCaseNotesBAL MediationCaseNotesBAobj = new MediationCaseNotesBAL();
    MortgagorBAL MortgagorBALobj = new MortgagorBAL();
    MortgagorDAL MortgagorDALobj = new MortgagorDAL();
    MediationCaseDAL MediationCaseDALobj = new MediationCaseDAL();
    MediationCaseBAL MediationCaseBALobj = new MediationCaseBAL();
    commonFunctions myFunctions = new commonFunctions();

    bool isAdmin = false;
    bool isEdit = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //txtFirstName.Attributes.Add("OnBlur", "validate()");
            //txtMiddleInitial.Attributes.Add("OnBlur", "validate()");
            //txtLastName.Attributes.Add("OnBlur", "validate()");
            //lstBorrowerSuffix.Attributes.Add("OnBlur", "validate()");
            //txtAlias.Attributes.Add("OnBlur", "validate()");
            //End New Code Added for Co-Borrower from AddMortgagor

            txtFirstLetterSent.Enabled = false;
            txtFirstLetterSent.ReadOnly = true;
            txtSecondLetterSentDate.Enabled = false;
            txtSecondLetterSentDate.ReadOnly = true;
            if (txtActualConfDate.Text != "")
            {
                txtActualConfDate.Enabled = false;
                ImageButton12.Visible = false;

            }
            if (txtMediationFeePaidDate.Text != "")
            {
                txtMediationFeePaidDate.Enabled = false;
                ImageButton5.Visible = false;

            }
            if (txtPenaltyPaidDate.Text != "")
            {
                txtPenaltyPaidDate.Enabled = false;
                ImageButton4.Visible = false;

            }
            IDataReader datareader;
            ///   On page load event, we declare this session  "Session["EditMediation"]" by default false. 
            ///   When page load executes, it is not known if the user has selected to edit mediation case or if the
            ///   the user has selected to create a new mediation case.
            ///   
            //THIS IS THE APPLICATION WHEN IT IS IN EDIT MODE...
            Session["EditMediation"] = false;
            bool EditMode;
            Boolean.TryParse(Session["EditMediation"].ToString(), out EditMode);
            Session["MediationCaseID"] = -1;

            if (Request.QueryString["ID"] != null)
            {
                if (Request.QueryString["EditFlag"] != null)
                {
                    //06/30/15 Added _Jaheda Meman 
                    Session["EditMediation"] = true;
                    Boolean.TryParse(Session["EditMediation"].ToString(), out EditMode);                    
                }

                int MediationId;
                if (int.TryParse(Request.QueryString["ID"], out MediationId))
                {
                    Session["MediationCaseID"] = MediationId;
                    datareader = MediationCaseBALobj.GetDataByMediationID(MediationId);
                    if (datareader.FieldCount > 0)
                    {
                        if (Request.QueryString["Edit"] != null)
                        {
                            if (Request.QueryString["Edit"] == "true")
                            {
                                Session["EditMediation"] = true;
                                isEdit = true;
                            }
                            else
                            {
                                Session["EditMediation"] = false;
                                isEdit = false;
                            }
                        }

                        if (datareader.Read())
                        {
                            int MortgagorInfoID;
                            if (int.TryParse(datareader["MortgagorInformationID"].ToString(), out MortgagorInfoID))
                                Session["MortgagorInformationID"] = MortgagorInfoID;
                            else
                                Session["MortgagorInformationID"] = -1;
                            int id = 0;
                            int.TryParse(datareader["LenderContactID"].ToString(), out id);
                            Session["LenderContactID"] = id;
                            id = 0;
                            int.TryParse(datareader["AttorneyContactID"].ToString(), out id);
                            Session["AttorneyContactID"] = id;
                            id = 0;
                            int.TryParse(datareader["MediationContactID"].ToString(), out id);
                            Session["MediationContactID"] = id;
                            id = 0;
                            int.TryParse(datareader["ServicerContactID"].ToString(), out id);
                            Session["ServicerContactID"] = id;
                            id = 0;
                            int.TryParse(datareader["CertificateLetterContactID"].ToString(), out
                            id);
                            Session["CertificateLetterContactID"] = id;


                            // PP - 11/15/18: Added app setting with list of users allowed to edit certain fields of mediation case.
                            string[] adminUsers = System.Configuration.ConfigurationManager.AppSettings.Get("AdminUsers").ToString().ToLower().Split(',').Select(s => s.Trim()).ToArray();
                            
                            // ----------Below way for testing locally, does not work on test server----------
                            //string currUser = Environment.UserName.ToLower().Trim();
                            //if (adminUsers.Contains(currUser))
                            //{
                            //    isAdmin = true;
                            //}

                            foreach (string user in adminUsers)
                            {
                                if (Request.ServerVariables[5].Contains(user))
                                {
                                    isAdmin = true;
                                }
                            }

                            //All MediationField;
                            //this code to retrieve the value from the database in the Mediation case in Edit
                            //mode . So user doesn't not have to write to retrieve the data from mediation case
                            //information table in Panel 1 (in default.aspx code).

                            txtFirstName.Text = datareader["FirstName"].ToString();
                            txtFirstName.Enabled = true;
                            txtMiddleInitial.Text = datareader["MiddleInitial"].ToString();
                            txtMiddleInitial.Enabled = true;
                            txtLastName.Text = datareader["LastName"].ToString();
                            txtLastName.Enabled = true;
                            lstBorrowerSuffix.Text = datareader["Suffix"].ToString();
                            lstBorrowerSuffix.Enabled = true;
                            txtAlias.Text = datareader["Alias"].ToString();
                            txtAlias.Enabled = true;
                            txtAddress_1.Text = datareader["Address1"].ToString();
                            txtAddress_1.Enabled = true;
                            txtAddress_2.Text = datareader["Address2"].ToString();
                            txtAddress_2.Enabled = true;
                            txtCity.Text = datareader["City"].ToString();
                            txtCity.Enabled = true;
                            txtZipCode.Text = datareader["ZipCode"].ToString();
                            txtZipCode.Enabled = true;
                            txtState.Text = datareader["State"].ToString();
                            if (datareader["MortgagorPhone"] != null)
                            {
                                txtMortgagorPhone.Text = datareader["MortgagorPhone"].ToString();
                            }

                            if (datareader["MortgagorCalledDate"] != DBNull.Value)
                                txtMortgagorCalledDate.Text = Convert.ToDateTime(datareader["MortgagorCalledDate"]).ToString("MM/dd/yyyy");

                            string BName = (txtFirstName.Text.Length > 0 ? txtFirstName.Text + " " : "") +
                            (txtMiddleInitial.Text.Length > 0 ? txtMiddleInitial.Text + " " : "") +
                            (txtLastName.Text.Length > 0 ? txtLastName.Text + " " : "") +
                            (lstBorrowerSuffix.Text.Length > 0 ? lstBorrowerSuffix.Text + " " : "");


                            if (Request.QueryString["PrintViewBorrower"] != null)
                            {
                                txtPrintViewBorrower.Text = datareader["PrintViewBorrower"].ToString();
                                txtPrintViewBorrower.Enabled = true;
                            }
                            else
                            {
                                txtPrintViewBorrower.Text = BName.ToString();
                                txtPrintViewBorrower.Enabled = true;
                            }

                            //Coborrower
                            txtPrintViewCo_Borrower.Text = datareader["PrintViewCo_Borrower"].ToString();


                            //Coborrower3
                            txtPrintViewCo_Borrower3.Text = datareader["PrintViewName_3"].ToString();



                            //Coborrower4
                            txtPrintViewCo_Borrower4.Text = datareader["PrintViewName_4"].ToString();


                            txtAddress_1.Enabled = true;
                            txtAddress_2.Enabled = true;
                            txtCity.Enabled = true;
                            txtZipCode.Enabled = true;
                            txtMortgagorPhone.Enabled = true;
                            txtMortgagorCalledDate.Enabled = true;

                            if (isEdit && isAdmin)
                            {
                                txtState.Enabled = true;
                                txtDefaultdate.Enabled = true;
                                txtNoticeDate.Enabled = true;
                                txtReleaseBankruptcyStayDate.Enabled = true;
                                txtReleaseBankruptcyStayDate.ReadOnly = false;
                                ImageButton1.Visible = true;
                                ImageButton2.Visible = true;
                                ImageButton3.Visible = true;
                                txtPenaltyDays.Enabled = true;
                                btnCal.Enabled = true;
                                txtFirstLetterSent.Enabled = true;
                                txtFirstLetterSent.ReadOnly = false;
                                txtSecondLetterSentDate.Enabled = true;
                                txtSecondLetterSentDate.ReadOnly = false;
                                txtConfCallDeadlineDate.Enabled = true;
                                txtInitialFee.Enabled = true;
                                txtInitialFee.ReadOnly = false;
                            }
                            else
                            {
                                txtState.Enabled = false;
                                txtDefaultdate.Enabled = false;
                                txtNoticeDate.Enabled = false;
                                txtReleaseBankruptcyStayDate.Enabled = false;
                                txtReleaseBankruptcyStayDate.ReadOnly = true;
                                ImageButton1.Visible = false;
                                ImageButton2.Visible = false;
                                ImageButton3.Visible = false;
                                txtPenaltyDays.Enabled = false;
                                btnCal.Enabled = false;
                                txtFirstLetterSent.Enabled = false;
                                txtFirstLetterSent.ReadOnly = true;
                                txtSecondLetterSentDate.Enabled = false;
                                txtSecondLetterSentDate.ReadOnly = true;
                                txtConfCallDeadlineDate.Enabled = false;
                                txtInitialFee.Enabled = false;
                                txtInitialFee.ReadOnly = true ;
                            }

                            txtDefaultdate.Text = Convert.ToDateTime(datareader["DefaultDate"]).ToString("MM/dd/yyyy");
                            txtNoticeDate.Text = Convert.ToDateTime(datareader["NoticeDate"]).ToString("MM/dd/yyyy");
                            
                            if (datareader["ReleaseBankruptcyStayDate"] == DBNull.Value)
                            {
                                txtReleaseBankruptcyStayDate.Text = datareader["ReleaseBankruptcyStayDate"].ToString();
                                // txtReleaseBankruptcyStayDate.Text = Convert.ToDateTime(datareader["ReleaseBankruptcyStayDate"]).ToString("MM/dd/yyyy");
                                //txtReleaseBankruptcyStayDate.Enabled = false;
                                //ImageButton3.Visible = false;
                                //txtReleaseBankruptcyStayDate.ReadOnly = true;
                            }
                            //}
                            else
                            {
                                txtReleaseBankruptcyStayDate.Text = Convert.ToDateTime(datareader["ReleaseBankruptcyStayDate"]).ToString("MM/dd/yyyy");
                                //txtReleaseBankruptcyStayDate.Enabled = false;
                                //ImageButton3.Visible = false;
                                //txtReleaseBankruptcyStayDate.ReadOnly = true;
                                //    txtReleaseBankruptcyStayDate.Enabled = false;
                                ////    txtReleaseBankruptcyStayDate.Text = datareader["ReleaseBankruptcyStayDate"].ToString();
                            }

                            //9/24/15 ServicemanCivilReliefActDate _obd
                            if (datareader["ServicemanCivilReliefActDate"] == DBNull.Value)
                            {
                                txtServicemanCivilReliefActDate.Text = datareader["ServicemanCivilReliefActDate"].ToString();
                                txtServicemanCivilReliefActDate.Enabled = true;
                                ImageButton6.Visible = true;
                                txtServicemanCivilReliefActDate.ReadOnly = false;
                            }
                            else
                            {
                                txtServicemanCivilReliefActDate.Text = Convert.ToDateTime(datareader["ServicemanCivilReliefActDate"]).ToString("MM/dd/yyyy");
                                txtServicemanCivilReliefActDate.Enabled = false;
                                ImageButton6.Visible = false;
                                txtServicemanCivilReliefActDate.ReadOnly = true;
                            }


                            txtPenaltyDays.Text = datareader["PenaltyDays"].ToString();                            

                            txtInitialFee.Text = Convert.ToDecimal(datareader["InitialFee"]).ToString();
                            

                            if (datareader["FirstLetterSentDate"] != DBNull.Value)
                                txtFirstLetterSent.Text = Convert.ToDateTime(datareader["FirstLetterSentDate"]).ToString("MM/dd/yyyy");
                            
                            //7/8/15 _Jaheda meman ReturnedMail 
                            if (datareader["ReturnedMail"] != DBNull.Value)
                            {
                                chkReturnedMail.Checked = Convert.ToBoolean(datareader["ReturnedMail"]);
                                //9/14/2015 _obd -- disable field if checked and allow Tricia to uncheck if needed
                                chkReturnedMail.Enabled = false;
                                if (new[] { "RIHMFC\\thebert" }.Contains(Request.ServerVariables[5]))
                                {
                                    chkReturnedMail.Checked = Convert.ToBoolean(datareader["ReturnedMail"]);
                                    chkReturnedMail.Enabled = true;
                                }
                            }
                            //9/14/2015 _obd -- enable field if not checked
                            if (chkReturnedMail.Checked == false)
                            {
                                chkReturnedMail.Enabled = true;
                            }

                            //Returned Mail Date (not visible) _obd 9/11/15
                            if (datareader["ReturnedMailDate"] != DBNull.Value)
                            {
                                txtReturnedMailDate.Text = Convert.ToDateTime(datareader["ReturnedMailDate"]).ToString("MM/dd/yyyy");
                                txtReturnedMailDate.Enabled = false;
                                txtReturnedMailDate.ReadOnly = true;
                            }
                            //else
                            //{
                            //    txtReturnedMailDate.Text = DateTime.Today.ToShortDateString().ToString(); 
                            //}
                            if (datareader["SecondLetterSentDate"] != DBNull.Value)
                                txtSecondLetterSentDate.Text = Convert.ToDateTime(datareader["SecondLetterSentDate"]).ToString("MM/dd/yyyy");
                            
                            if (datareader["ConfCallDeadlineDate"] != DBNull.Value)
                                txtConfCallDeadlineDate.Text = Convert.ToDateTime(datareader["ConfCallDeadlineDate"]).ToString("MM/dd/yyyy");
                            
                            txtMortgagorAccNo.Text = datareader["MortgageAccountNumber"].ToString();
                            // This is the Notes detail - We can fill using notes table.
                            //  int NotesID;
                            //// if (int.TryParse(datareader["NotesID"].ToString(), out NotesID))
                            Session["NotesID"] = false;
                            if (datareader["InitialContactDate"] != DBNull.Value)
                            {
                                txtInitialContactDate.Text = Convert.ToDateTime(datareader["InitialContactDate"]).ToString("MM/dd/yyyy");
                            }
                            if (datareader["PackageSentLenderDate"] != DBNull.Value)
                            {
                                txtPackageSentDate.Text = Convert.ToDateTime(datareader["PackageSentLenderDate"]).ToString("MM/dd/yyy");
                            }
                            if (datareader["SchedConferenceDate"] != DBNull.Value)
                            {
                                txtSheduledConfDate.Text = Convert.ToDateTime(datareader["SchedConferenceDate"]).ToString("MM/dd/yyy");
                            }
                            if (datareader["ActualConferenceDate"] != DBNull.Value)
                            {
                                txtActualConfDate.Text = Convert.ToDateTime(datareader["ActualConferenceDate"]).ToString("MM/dd/yyy");
                                
                                //txtConfResolveDeadlineDate.Enabled = false;                                
                                if (isEdit && isAdmin)
                                {
                                    ImageButton12.Visible = true;
                                    txtActualConfDate.Enabled = true;
                                }
                                else
                                {
                                    ImageButton12.Visible = false;
                                    txtActualConfDate.Enabled = false;
                                }
                            }
                            if (datareader["MedInvoiceLetterDate"] != DBNull.Value)
                            {
                                txtMedInvoicePrintDate.Text = Convert.ToDateTime(datareader["MedInvoiceLetterDate"]).ToString("MM/dd/yyy");
                                //  Session["MedInvoiceLetterDate"] = txtMedInvoicePrintDate.Text;

                                if (isEdit && isAdmin)
                                {
                                    txtMedInvoicePrintDate.Enabled = true;
                                    txtMedInvoicePrintDate.ReadOnly = false;
                                }
                                else
                                {
                                    txtMedInvoicePrintDate.Enabled = false;
                                    txtMedInvoicePrintDate.ReadOnly = true;
                                }

                                //txtConfResolveDeadlineDate.Enabled = false;
                                //ImageButton12.Enabled = false;
                            }
                            //else
                            //{
                            //    txtActualConfDate.Enabled = true;
                            //}
                            if (datareader["ConfResolveDeadlineDate"] != DBNull.Value)
                            {
                                txtConfResolveDeadlineDate.Text = Convert.ToDateTime(datareader["ConfResolveDeadlineDate"]).ToString("MM/dd/yyy");
                                
                                if (isEdit && isAdmin)
                                {
                                    txtConfResolveDeadlineDate.Enabled = true;
                                }
                                else
                                {
                                    txtConfResolveDeadlineDate.Enabled = false;
                                }

                            }
                            else
                            {
                                txtConfResolveDeadlineDate.Enabled = true;
                            }
                            if (datareader["ExtensionRequestDate"] != DBNull.Value)
                            {
                                txtExtensionRequestDate.Text = Convert.ToDateTime(datareader["ExtensionRequestDate"]).ToString("MM/dd/yyy");                                

                                if (isEdit && isAdmin)
                                {
                                    txtExtensionRequestDate.Enabled = true;
                                    ImageButton15.Visible = true;
                                }
                                else
                                {
                                    txtExtensionRequestDate.Enabled = false;
                                    ImageButton15.Visible = false;
                                }
                            }
                            else
                            {
                                txtExtensionRequestDate.Enabled = true;
                            }
                            if (datareader["RequestExtensionByDate"] != DBNull.Value)
                            {
                                txtRequestExtensionByDate.Text = Convert.ToDateTime(datareader["RequestExtensionByDate"]).ToString("MM/dd/yyy");                                

                                if (isEdit && isAdmin)
                                {
                                    txtRequestExtensionByDate.Enabled = true;
                                }
                                else
                                {
                                    txtRequestExtensionByDate.Enabled = false;
                                }
                            }
                            else
                            {
                                txtRequestExtensionByDate.Enabled = true;
                            }
                            if (datareader["ExtensionExpirationDate"] != DBNull.Value)
                            {
                                txtExtensionExprDate.Text = Convert.ToDateTime(datareader["ExtensionExpirationDate"]).ToString("MM/dd/yyy");                                

                                if (isEdit && isAdmin)
                                {
                                    txtExtensionExprDate.Enabled = true;
                                }
                                else
                                {
                                    txtExtensionExprDate.Enabled = false;
                                }
                            }
                            else
                            {
                                txtExtensionExprDate.Enabled = true;
                            }
                            if (datareader["ConfResolutionDate"] != DBNull.Value)
                            {
                                txtConfResolutionDate.Text = Convert.ToDateTime(datareader["ConfResolutionDate"]).ToString("MM/dd/yyy");                                

                                if (isEdit && isAdmin)
                                {
                                    txtConfResolutionDate.Enabled = true;
                                }
                                else
                                {
                                    txtConfResolutionDate.Enabled = false;
                                }

                                //3/12/15:_obd -- per Tricia Hebert, if there's a resolution date, then don't pull down any certificates  
                                //3/26/15: _obd only hide buttons when case is either closed, inactive or exempt
                                //btnPrintMediationInvoice.Visible = false;
                                //btnPrintCertificate.Visible = false;
                                //btnReprintCertificate.Visible = false;
                                //btnPrintMediationInvoice.Visible = false;
                                //chkWaived.Enabled = false;
                                //_obd 3/12/15

                                if (new[] { 7, 8, 9 }.Contains(lstCertificateNoticeTypeReason.SelectedIndex))//_obd 3/3/15
                                {
                                    btnPrintCertificate.Visible = false;
                                    btnReprintCertificate.Visible = false;
                                    btnPrintMediationInvoice.Visible = false;
                                }
                            }
                            else
                            {
                                txtConfResolutionDate.Enabled = true;
                            }
                            //Original line(05/27/2016 jed)
                            //if (Convert.ToString(Session["MortgagorInformationID"]) != "")
                            if (Convert.ToByte(datareader["CounterOfferRejectedBorrower"]) == 0)
                            {
                                chkCounterOfferRejectedBorrower.Checked = Convert.ToBoolean(datareader["CounterOfferRejectedBorrower"]);
                                //chkCounterOfferRejectedBorrower.Checked=(datareader.GetBoolean(datareader.GetOrdinal("CounterOfferRejectedBorrower")));
                                chkCounterOfferRejectedBorrower.Checked = false;
                                chkCounterOfferRejectedBorrower.Enabled = false;
                            }
                            else
                            {
                                chkCounterOfferRejectedBorrower.Enabled = true;
                                chkCounterOfferRejectedBorrower.Checked = true;
                            }
                            //Original line (05/27/2016 jed)
                            //if (datareader["WO_FinancialBenefitBorrower"] == "0")
                            if (Convert.ToByte(datareader["WO_FinancialBenefitBorrower"]) == 0)
                            {
                                chkWO_FinancialBenefitBorrower.Checked = Convert.ToBoolean(datareader["WO_FinancialBenefitBorrower"]);
                                chkWO_FinancialBenefitBorrower.Checked = false;
                                chkWO_FinancialBenefitBorrower.Enabled = true;
                            }
                            else
                            {
                                chkWO_FinancialBenefitBorrower.Enabled = true;
                                chkWO_FinancialBenefitBorrower.Checked = true;
                            }
                            //Original Line (05/27/2016 jed)
                            //if (datareader["WO_AgreementInFile"] == "0")
                            if (Convert.ToByte(datareader["WO_AgreementInFile"]) == 0)
                            {
                                chkWO_AgreementInFile.Checked = Convert.ToBoolean(datareader["WO_AgreementInFile"]);
                                chkWO_AgreementInFile.Checked = false;
                                chkWO_AgreementInFile.Enabled = false;
                            }
                            else
                            {
                                chkWO_AgreementInFile.Checked = true;
                                chkWO_AgreementInFile.Enabled = true;
                            }

                            if (isEdit && isAdmin)
                            {
                                chkCounterOfferRejectedBorrower.Enabled = true;
                                chkWO_FinancialBenefitBorrower.Enabled = true;
                                chkWO_AgreementInFile.Enabled = true;
                            }

                            if (datareader["ConferenceResultID"] != DBNull.Value)
                            {
                                lstConfResult.SelectedValue = Convert.ToInt32(datareader["ConferenceResultID"]).ToString();
                                //disable these fields when there is a conference result --11/18/2015 _obd
                                
                                //if (lstConfResult.SelectedIndex == 4)
                                //{
                                //    txtExtensionRequestDate.Enabled = false;
                                //    ImageButton15.Visible = false;
                                //}
                                

                                if (isEdit && isAdmin)
                                {
                                    txtActualConfDate.Enabled = true;
                                    txtConfResolveDeadlineDate.Enabled = true;
                                    txtRequestExtensionByDate.Enabled = true;

                                    txtExtensionExprDate.Enabled = true;
                                    ImageButton12.Visible = true;
                                    lstConfResult.Enabled = true;
                                }
                                else
                                {
                                    txtActualConfDate.Enabled = false;
                                    txtConfResolveDeadlineDate.Enabled = false;
                                    txtRequestExtensionByDate.Enabled = false;

                                    txtExtensionExprDate.Enabled = false;
                                    ImageButton12.Visible = false;
                                    lstConfResult.Enabled = false;
                                }
                            }
                            else
                            {
                                lstConfResult.Enabled = true;
                            }
                            if (datareader["CounselorID"] != DBNull.Value)
                            {
                                lstCounselorName.SelectedValue = Convert.ToInt32(datareader["CounselorID"]).ToString();
                            }
                            else
                            {
                                lstCounselorName.Enabled = true;
                            }
                            if (datareader["CoordinatorID"] != DBNull.Value)
                            {
                                lstCoordinatorName.SelectedValue = Convert.ToInt32(datareader["CoordinatorID"]).ToString();
                            }
                            else
                            {
                                lstCoordinatorName.Enabled = true;
                            }
                            if (datareader["MediationInvoiceID"] != DBNull.Value)
                            {
                                lstMediationInvoiceSentTo.SelectedValue = Convert.ToInt32(datareader["MediationInvoiceID"]).ToString();
                            }
                            else
                            {
                                lstMediationInvoiceSentTo.Enabled = true;
                            }
                            // TO RETRIVE THE DATA FROM MEDIATION CASE INFORMATION TABLE  PANEL 3
                            //if (Convert.ToString(datareader["CertificateNoticeID"]) != "0")
                            if (datareader["CertificateNoticeID"] != DBNull.Value)
                            {
                                lstCertificateNoticeTypeReason.SelectedValue = Convert.ToInt32(datareader["CertificateNoticeID"]).ToString();
                                lstCertificateNoticeTypeReason.Enabled = false;

                                // PP - 11/16/18: Deprecated code. Use web config setting now.
                                ////3/12/15:_obd -- allow Tricia Hebert to change the notice type                              
                                //lstCertificateNoticeTypeReason.SelectedValue = Convert.ToInt32(datareader["CertificateNoticeID"]).ToString();

                                //if (new[] { "RIHMFC\\thebert" }.Contains(Request.ServerVariables[5]))
                                //{
                                //    lstCertificateNoticeTypeReason.Enabled = true;
                                //}
                                //3/25/15 -- restored 

                                if (isEdit && isAdmin)
                                {
                                    lstCertificateNoticeTypeReason.Enabled = true;
                                }                                
                            }
                            else
                            {
                                lstCertificateNoticeTypeReason.Enabled = true;
                            }

                            if (datareader["PenaltyPaidDate"] != DBNull.Value)
                            {
                                txtPenaltyPaidDate.Text = Convert.ToDateTime(datareader["PenaltyPaidDate"]).ToString("MM/dd/yyy");
                                if (isEdit && isAdmin)
                                {
                                    txtPenaltyPaidDate.Enabled = true;
                                }
                                else
                                {
                                    txtPenaltyPaidDate.Enabled = false;
                                }
                            }
                            //else
                            //{
                            //    txtPenaltyPaidDate.Enabled = true;
                            //}
                            if (datareader["MediationFeeDate"] != DBNull.Value)
                            {
                                txtMediationFeePaidDate.Text = Convert.ToDateTime(datareader["MediationFeeDate"]).ToString("MM/dd/yyy");
                                
                                //11/05/2015 _obd: added to disable the print invoice button if the fee has already been paid.
                                
                                if (isEdit && isAdmin)
                                {
                                    txtMediationFeePaidDate.Enabled = true;
                                    btnPrintMediationInvoice.Enabled = true;
                                }
                                else
                                {
                                    txtMediationFeePaidDate.Enabled = false;
                                    btnPrintMediationInvoice.Enabled = false;
                                }
                            }
                            //else
                            //{
                            //    txtMediationFeePaidDate.Enabled = true;
                            //}
                            if (datareader["CertificateNoticePrintDate"] != DBNull.Value)
                            {
                                txtCertificateNoticePrintDate.Text = Convert.ToDateTime(datareader["CertificateNoticePrintDate"]).ToString("MM/dd/yyy");
                                if (isEdit && isAdmin)
                                {
                                    txtCertificateNoticePrintDate.Enabled = true;
                                    //3/17/15 _obd -- added to disable the print certificate button if there's already a date.
                                    btnPrintCertificate.Enabled = true;
                                }
                                else
                                {
                                    txtCertificateNoticePrintDate.Enabled = false;
                                    //3/17/15 _obd -- added to disable the print certificate button if there's already a date.
                                    btnPrintCertificate.Enabled = false;
                                }                                                                
                            }
                            else
                            {
                                txtCertificateNoticePrintDate.Enabled = true;
                            }
                            if (datareader["CertificateLetterReprintDate"] != DBNull.Value)
                            {
                                txtCertificateLetterReprintDate.Text = Convert.ToDateTime(datareader["CertificateLetterReprintDate"]).ToString("MM/dd/yyy");
                                
                                if (isEdit && isAdmin)
                                {
                                    txtCertificateLetterReprintDate.Enabled = true;
                                }
                                else
                                {
                                    txtCertificateLetterReprintDate.Enabled = false;
                                }
                            }
                            else
                            {
                                //2/12/15 _OBD UPDATED TO DISABLE THE CORRECT DATE FIELD
                                //txtCertificateNoticePrintDate.Enabled = true;
                                txtCertificateLetterReprintDate.Enabled = true;
                            }
                            //7/8/15 _Jaheda meman Duplicate Certificate Fee Paid 
                            if (datareader["DuplicateCertificateFeePaid"] != DBNull.Value)
                            {
                                chkDuplicateCertificateFeePaid.Checked = Convert.ToBoolean(datareader["DuplicateCertificateFeePaid"]);
                                chkDuplicateCertificateFeePaid.Enabled = true;
                            }

                            txtIncome.Text = Convert.ToDecimal(datareader["Income"]).ToString();
                            txtPenaltyAmount.Text = Convert.ToDecimal(datareader["PenaltyAmount"]).ToString();

                            //ShowAlert("Hello, " + Request.ServerVariables[5] + " - If you are reading this, then you will also see the waived penalty checkbox.  You can also edit the mortgagor page. Have fun!!!");//Environment.UserName.ToString());                            }

                            // PP - 11/16/18: Deprecated code. Use web config setting now.
                            //3/3/15 _OBD PENALTY FEE WAIVED 
                            //3/26/15 -- Roll back 4/16/15
                            //if (new[] { "RIHMFC\\thebert" }.Contains(Request.ServerVariables[5]))
                            //{
                            //    chkWaived.Checked = Convert.ToBoolean(datareader["PenaltyFeeWaived"]);
                            //    chkWaived.Enabled = true;
                            //    //string fullName = null;
                            //    //using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
                            //    //{
                            //    //    using (UserPrincipal 
                            //    //            = UserPrincipal.FindByIdentity(context,
                            //    //                                            User.Identity.Name))
                            //    //    {
                            //    //        if (user != null)
                            //    //        {
                            //    //            fullName = user.DisplayName;
                            //    //        }
                            //    //    }
                            //    //}
                            //}
                            //else
                            //{
                            //    chkWaived.Checked = Convert.ToBoolean(datareader["PenaltyFeeWaived"]);
                            //    chkWaived.Enabled = false;
                            //}
                            
                            chkWaived.Checked = Convert.ToBoolean(datareader["PenaltyFeeWaived"]);
                            if (isEdit && isAdmin)
                            {
                                chkWaived.Enabled = true;
                                txtMediationFeeAmount.ReadOnly = false;
                                txtMediationFeeAmount.Enabled = true;
                            }
                            else
                            {
                                chkWaived.Enabled = false;
                            }

                            txtMediationFeeAmount.Text = Convert.ToDecimal(datareader["MediationFeeAmount"]).ToString();
                            txtCertificateLenderName.Text = datareader["CertificateLenderName"].ToString();
                            txtMedCaseID.ReadOnly = true;
                            txtMedCaseID.Enabled = false;
                            txtMedCaseID.Text = datareader["MediationCaseInformationID"].ToString();
                            txtMedCaseDate.ReadOnly = true;
                            txtMedCaseDate.Enabled = false;
                            txtMedCaseDate.Text = Convert.ToDateTime(datareader["CreateDate"]).ToString
                            ("MM/dd/yyyy");
                        }
                        BindNotesData();
                        datareader.Close();
                    }
                }
            }
            else
            {
                if
                  (Request.QueryString["ID"] == null)

                //THIS IS THE END OF THE EDIT MODE AND NOW IF THE USER DID NOT SELECT TO BE IN EDIT MODE, THE FOLLOWING CODE WILL NOW RUN BASED
                //ON THE USER ACTUALLY HAVING CHOSEN TO CREATE NEW RECORD.
                {
                    Session["LenderContactID"] = 0;
                    Session["AttorneyContactID"] = 0;
                    Session["MediationContactID"] = 0;
                    Session["ServicerContactID"] = 0;
                    Session["CertificateLetterContactID"] = 0;
                }
                if (Convert.ToInt16(Session["MortgagorInformationID"]) != -1)
                {
                    //Retrieves the data from the table["MortgagorInformation"] 
                    IDataReader reader = MortgagorBALobj.GetMortgagorDetails(Convert.ToInt16(Session["MortgagorInformationID"]));
                    if (reader.Read())
                    {
                        txtFirstName.Text = reader["FirstName"].ToString();
                        txtMiddleInitial.Text = reader["MiddleInitial"].ToString();
                        txtLastName.Text = reader["LastName"].ToString();
                        lstBorrowerSuffix.Text = reader["Suffix"].ToString();
                        txtAlias.Text = reader["Alias"].ToString();
                        txtAddress_1.Text = reader["Address_1"].ToString();
                        txtAddress_2.Text = reader["Address_2"].ToString();
                        txtCity.Text = reader["City"].ToString();
                        txtZipCode.Text = reader["ZipCode"].ToString();
                        txtState.Text = reader["State"].ToString();


                        //This is the concatenate process so the PrintViewBorrower text field gets populated with
                        //the 'first name', 'middle name', 'last name' and 'suffix'
                        string BName = (txtFirstName.Text.Length > 0 ? txtFirstName.Text + " " : "") + (txtMiddleInitial.Text.Length > 0 ? txtMiddleInitial.Text + " " : "")
                            + (txtLastName.Text.Length > 0 ? txtLastName.Text + " " : "") + (lstBorrowerSuffix.Text.Length > 0 ? lstBorrowerSuffix.Text + " " : "");

                        //This code will read from the above declared variable 'BName' and 
                        //populate the txtPrintViewBorrower text field as a concatenated string.
                        txtPrintViewBorrower.Text = BName.ToString();
                        txtPrintViewBorrower.Enabled = true;

                    }
                    //close the connection to the MortgagorDALobj thus closing the SQL connection
                    reader.Close();
                }
                InitialiseContact(1);//Initially Lender Contact
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        chkBorrBox();
        SaveMediationCase(false);

    }
    protected void chkBorrBox()
    {
        string BName = (txtFirstName.Text.Length > 0 ? txtFirstName.Text + " " : "") + (txtMiddleInitial.Text.Length > 0 ? txtMiddleInitial.Text + " " : "") +
            (txtLastName.Text.Length > 0 ? txtLastName.Text + " " : "") + (lstBorrowerSuffix.Text.Length > 0 ? lstBorrowerSuffix.Text + " " : "");
        if (txtPrintViewBorrower.Text.Contains(BName.ToString()) == true)
        {

        }
        else
        {
            string input = txtPrintViewBorrower.ToString();
            txtPrintViewBorrower.Text = input.Replace(txtPrintViewBorrower.ToString(), BName.ToString());
        }
    }
    protected void txtNoticeDate_TextChanged(object sender, EventArgs e)
    {
        // PP - 11/16/18: Added edit check now that admin can edit prev. locked fields.
        if (Request.QueryString["Edit"] == "true")
        {
            isEdit = true;
        }
        else
        {
            isEdit = false;
        }

        if (!isEdit)
        {
            txtConfCallDeadlineDate.Text = DateTime.Today.AddDays(60).ToShortDateString();
        }
    }



    /// <summary>
    /// This is the Date difference to get penalty days.
    /// </summary>
    private void GetPenaltyDays()
    {
        DateTime Noticedate, Defaultdate, ReleaseBankruptcyStayDate, ServicemanCivilReliefActDate;
        DateTime.TryParse(txtDefaultdate.Text.ToString(), out Defaultdate);
        DateTime.TryParse(txtNoticeDate.Text.ToString(), out Noticedate);
        DateTime.TryParse(txtReleaseBankruptcyStayDate.Text.ToString(), out ReleaseBankruptcyStayDate);
        DateTime.TryParse(txtServicemanCivilReliefActDate.Text.ToString(), out ServicemanCivilReliefActDate);
        //09/24/15 ServicemanCivilReliefActDate _obd

        if (ServicemanCivilReliefActDate > ReleaseBankruptcyStayDate)
        {
            ReleaseBankruptcyStayDate = ServicemanCivilReliefActDate;
            //DateTime.TryParse(txtServicemanCivilReliefActDate.Text.ToString(), out ReleaseBankruptcyStayDate);  //ServicemanCivilReliefActDate);
        }
        int days = 0;
        if ((txtServicemanCivilReliefActDate.Text == "") && (txtReleaseBankruptcyStayDate.Text == ""))
        {
            txtPenaltyDays.Text = Convert.ToInt32((Noticedate - Defaultdate).TotalDays - 120).ToString();

            if (int.TryParse(txtPenaltyDays.Text, out days))
                if (days < 0)
                {
                    txtPenaltyDays.Text = "0";
                    txtPenaltyAmount.Text = "0.0";
                }
        }
        else
        {
            txtPenaltyDays.Text = Convert.ToInt32((Noticedate - ReleaseBankruptcyStayDate).TotalDays - 60).ToString();
            //int days;
            if (int.TryParse(txtPenaltyDays.Text, out days))
                if (days < 0)
                {
                    txtPenaltyDays.Text = "0";
                    txtPenaltyAmount.Text = "0.0";
                }
        }
        ///Penalty Amount

        double cPenaltyAmount = 0.00;
        double intPenaltyAmountDays = Math.Ceiling(days / 30f);
        if (intPenaltyAmountDays > 0f)
        {
            cPenaltyAmount = intPenaltyAmountDays * 1000;
            //    txtPenaltyAmount.Text =  Convert.ToDouble (cPenaltyAmount.ToString()).ToString();
            txtPenaltyAmount.Text = (cPenaltyAmount.ToString("0.00"));
        }
        btnCal.Enabled = false;
    }

    public void ShowAlert(string msg)
    {
        string jScript = "alert('" + msg + "');";
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), jScript, true);
    }

    protected void btnCal_Click(object sender, EventArgs e)
    {
        GetPenaltyDays();
    }

    protected void btnLenderContact_Click(object sender, EventArgs e)
    {
        {
            lblAddedContact.Text = "";
            InitialiseContact(1);//Lender contact
        }
    }
    protected void btnCertificateLetterContact_Click(object sender, EventArgs e)
    {
        lblAddedContact.Text = "";
        InitialiseContact(3);//Cerificate Latter
    }
    protected void btnMediationContact_Click(object sender, EventArgs e)
    {
        InitialiseContact(4);//Mediation Contact
    }
    protected void btnServiceContact_Click(object sender, EventArgs e)
    {
        lblAddedContact.Text = "";
        InitialiseContact(5);//Service contact
    }

    protected void btnAttorneyContact_Click(object sender, EventArgs e)
    {
        lblAddedContact.Text = "";
        InitialiseContact(2);//Attorney

    }
    /// <summary>
    /// To give the label or name on the tab in the panel forth .
    /// </summary>
    /// <param name="i"></param>
    void InitialiseContact(int i)
    {
        Session["Contact"] = i;
        Session["ContactEdit"] = false;
        int selectedindex = 0;
        int currselected = i;
        if (currselected == 1)
        {
            lblnamelist.Text = "Select Lender :";
            lblName.Text = "Lender Name";
            lblContactName.Text = "Contact Name";
            changecolor(btnLenderContact);
            int.TryParse(Session["LenderContactID"].ToString(), out selectedindex);
        }
        else if (currselected == 2)
        {
            lblnamelist.Text = "Select LawFirm:";
            lblName.Text = "LawFirm Name";
            lblContactName.Text = "Attorney Name";
            changecolor(btnAttorneyContact);
            int.TryParse(Session["AttorneyContactID"].ToString(), out selectedindex);
        }
        else if (currselected == 3)
        {
            lblnamelist.Text = "Select Agency:";
            lblName.Text = "Agency Name";
            lblContactName.Text = "Contact Name";
            changecolor(btnCertificateLetterContact);
            int.TryParse(Session["CertificateLetterContactID"].ToString(), out selectedindex);
        }
        else if (currselected == 4)
        {
            lblnamelist.Text = "Select Agency:";
            lblName.Text = "Agency Name";
            lblContactName.Text = "MediationContact Name";
            changecolor(btnMediationContact);
            int.TryParse(Session["MediationContactID"].ToString(), out selectedindex);
        }
        else if (currselected == 5)
        {
            lblnamelist.Text = "Select Agency:";
            lblName.Text = "Agency Name";
            lblContactName.Text = "Servicer Name";
            changecolor(btnServiceContact);
            int.TryParse(Session["ServicerContactID"].ToString(), out selectedindex);
        }
        // MEDIATION CONTACT DETAIL DROP DOWN BOX WE FILL OUT HERE
        lstName.DataSource = MediationCaseContactsBALObj.GetMediationContactsDetails(currselected);
        lstName.DataBind();
        lstName.Items.Insert(0, new ListItem("Select", "0"));
        lstName.SelectedValue = selectedindex.ToString();
        BindContactData();
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Session["ContactEdit"] = false;
        Session["LenderContactID"] = 0;
        Session["AttorneyContactID"] = 0;
        Session["MediationContactID"] = 0;
        Session["ServicerContactID"] = 0;
        Session["CertificateLetterContactID"] = 0;
        ResetContact();
        lstName.SelectedIndex = 0;
    }
    /// <summary>
    /// The BindContactData method refers to Panel#pBody3 in the Default.aspx starting at line 1040 and ending at line 1226 as of 05112016.
    /// Bind the data in all mediation contacts here. Drop down name is lstName. 
    /// </summary>
    public void BindContactData()
    {
        ResetContact();
        int curr = 0;
        Session["ContactEdit"] = false;
        btnSaveContact.Text = "Add New Record";
        int.TryParse(Session["Contact"].ToString(), out curr);
        setCurrValue(int.Parse(lstName.SelectedValue));

        // PP - 11/15/18: Added app setting with list of users allowed to edit certain fields of mediation case.
        string[] adminUsers = System.Configuration.ConfigurationManager.AppSettings.Get("AdminUsers").ToString().ToLower().Split(',').Select(s => s.Trim()).ToArray();

        // ----------Below way for testing locally, does not work on test server----------
        //string currUser = Environment.UserName.ToLower().Trim();
        //if (adminUsers.Contains(currUser))
        //{
        //    isAdmin = true;
        //}

        foreach (string user in adminUsers)
        {
            if (Request.ServerVariables[5].Contains(user))
            {
                isAdmin = true;
            }
        }

        if (curr > 0 && lstName.SelectedIndex > 0)
        {
            IDataReader reader = MediationCaseContactsBALObj.GetMediationContactDetailsByID(curr, int.Parse(lstName.SelectedValue));

            if (reader.Read())
            {
                Session["ContactEdit"] = true;
                btnSaveContact.Text = "Update";
                txtContactName.Text = reader["ContactName"].ToString();                

                txtName.Text = reader["Name"].ToString();
                
                txtContactTitle.Text = reader["Title"].ToString();
                
                txtaddresscontact_1.Text = reader["Address_1"].ToString();
                
                txtaddresscontact_2.Text = reader["Address_2"].ToString();
                
                double AltExtensionNo = 0;
                double.TryParse(reader["AltExtension"].ToString(), out AltExtensionNo);
                txtAlExtention.Text = String.Format("{0:####}", AltExtensionNo);
                // txtAlExtention.Text = reader["AltExtension"].ToString();
                //txtAlExtention.Enabled = false;
                double AltPhoneNumber = 0;
                double.TryParse(reader["AltPhoneNumber"].ToString(), out AltPhoneNumber);
                // txtPhoneNumber.Text = Convert.try("{0:(###)###-####}", 
                txtAltPhone.Text = String.Format("{0:(###)###-####}", AltPhoneNumber);
                //txtAltPhone.Text = reader["AltPhoneNumber"].ToString();
                // txtAltPhone.Enabled = false;
                txtcontactcity.Text = reader["City"].ToString();
                
                txtEmail.Text = reader["Email"].ToString();
                // txtEmail.ReadOnly = true;
                double ExtensionNo = 0;
                double.TryParse(reader["Extension"].ToString(), out ExtensionNo);
                txtExtension.Text = String.Format("{0:####}", ExtensionNo);
                //txtExtension.Text = reader["Extension"].ToString();
                //txtExtention.ReadOnly = true;
                double FaxNo = 0;
                double.TryParse(reader["FaxNumber"].ToString(), out FaxNo);
                // txtPhoneNumber.Text = Convert.try("{0:(###)###-####}", 
                txtFaxNumber.Text = String.Format("{0:(###)###-####}", FaxNo);

                // txtFaxNumber.Text = reader["FaxNumber"].ToString();
                // txtFaxNumber.ReadOnly = true;
                double PhoneNo = 0;
                double.TryParse(reader["OfficePhone"].ToString(), out PhoneNo);
                // txtPhoneNumber.Text = Convert.try("{0:(###)###-####}", 
                txtPhoneNumber.Text = String.Format("{0:(###)###-####}", PhoneNo);
                //  txtPhoneNumber.Text = reader["OfficePhone"].ToString();
                //  txtPhoneNumber.ReadOnly = true;
                txtContactState.Text = reader["State"].ToString();
                
                txtContactZip.Text = reader["ZipCode"].ToString();
                

                if (!isAdmin)
                {
                    txtContactName.Enabled = false;
                    txtName.Enabled = false;
                    txtContactTitle.Enabled = false;
                    txtaddresscontact_1.Enabled = false;
                    txtaddresscontact_2.Enabled = false;
                    txtcontactcity.Enabled = false;
                    txtContactState.Enabled = false;
                    txtContactZip.Enabled = false;
                }
            }

            reader.Close();
        }
    }//End BindContactdata method


    private void ResetContact()
    {
        txtContactName.Text = "";
        txtContactName.Enabled = true;
        txtName.Text = "";
        txtName.Enabled = true;
        txtContactTitle.Text = "";
        txtContactTitle.Enabled = true;
        txtaddresscontact_1.Text = "";
        txtaddresscontact_1.Enabled = true;
        txtaddresscontact_2.Text = "";
        txtaddresscontact_2.Enabled = true;
        txtcontactcity.Text = "";
        txtcontactcity.Enabled = true;
        txtContactState.Text = "";
        txtContactState.Enabled = true;
        txtContactZip.Text = "";
        txtContactZip.Enabled = true;
        txtAlExtention.Text = "";
        txtAlExtention.Enabled = true;
        txtAltPhone.Text = "";
        txtAltPhone.Enabled = true;
        txtcontactcity.Text = "";
        txtcontactcity.Enabled = true;
        txtEmail.Text = "";
        txtEmail.Enabled = true;
        txtExtension.Text = "";
        txtExtension.Enabled = true;
        txtFaxNumber.Text = "";
        txtFaxNumber.Enabled = true;
        txtPhoneNumber.Text = "";
        txtPhoneNumber.Enabled = true;
        txtAltPhone.Text = "";
        // txtAltPhone.Enabled = true;
        txtAlExtention.Text = "";
        // txtAlExtention.Enabled = true;

        //btnAttorneyContact.Text = "Add New Record";

    }
    protected void lstName_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindContactData();
    }
    // Here we can save the all contact for the mediation case. It does enter in the individual table and medicationcasetable.
    protected void btnSaveContact_Click(object sender, EventArgs e)
    {

        //add the underscore in the list for regex.replace to keep the underscore from 
        //saving to the DB when empty. //_obd 2/24/15
        int curr = 0;
        int.TryParse(Session["Contact"].ToString(), out curr);
        bool EditMode;
        Boolean.TryParse(Session["ContactEdit"].ToString(), out EditMode);
        MediationCaseContactsDAL MediationCaseContactsDALobj = new MediationCaseContactsDAL();
        MediationCaseContactsDALobj.ContactName = txtContactName.Text.ToString();
        MediationCaseContactsDALobj.ContactTitle = txtContactTitle.Text.ToString();
        MediationCaseContactsDALobj.Address_1 = txtaddresscontact_1.Text.ToString();
        MediationCaseContactsDALobj.Address_2 = txtaddresscontact_2.Text.ToString();
        MediationCaseContactsDALobj.AltExtension = Regex.Replace(txtAlExtention.Text.ToString(), @"[_()\s-]", "");
        MediationCaseContactsDALobj.AltPhoneNumber = Regex.Replace(txtAltPhone.Text.ToString(), @"[_()\s-]", "");
        MediationCaseContactsDALobj.City = txtcontactcity.Text.ToString();
        MediationCaseContactsDALobj.Email = txtEmail.Text.ToString();
        //MediationCaseContactsDALobj.Extension = txtExtension.Text.ToString();
        MediationCaseContactsDALobj.Extension = Regex.Replace(txtExtension.Text.ToString(), @"[_()\s-]", "");
        MediationCaseContactsDALobj.FaxNumber = Regex.Replace(txtFaxNumber.Text.ToString(), @"[_()\s-]", "");
        MediationCaseContactsDALobj.Name = txtName.Text.ToString();
        MediationCaseContactsDALobj.OfficePhone = Regex.Replace(txtPhoneNumber.Text.ToString(), @"[_()\s-]", "");
        MediationCaseContactsDALobj.State = txtContactState.Text.ToString();
        MediationCaseContactsDALobj.ZipCode = txtContactZip.Text.ToString();

        MediationCaseContactsDALobj.ContactID = int.Parse(lstName.SelectedValue);
        int retval = MediationCaseContactsBALObj.AddMediationCaseContactsDetails(MediationCaseContactsDALobj, curr, EditMode ? 1 : 0);
        if (EditMode && retval == MediationCaseContactsDALobj.ContactID)
        {
            lblAddedContact.Text = "Record successully updated";
        }
        else if (!EditMode)
        {
            lblAddedContact.Text = "Record successully added";
        }
        btnSaveContact.Text = "Update";
        setCurrValue(retval);
        InitialiseContact(curr);

    }
    /// <summary>
    /// to select current value for the lender
    /// </summary>
    /// <param name="val"></param>
    public void setCurrValue(int val)
    {
        int curr = 0;
        int.TryParse(Session["Contact"].ToString(), out curr);

        if (curr == 1)
            Session["LenderContactID"] = val;
        else if (curr == 2)
            Session["AttorneyContactID"] = val;
        else if (curr == 3)
            Session["CertificateLetterContactID"] = val;
        else if (curr == 4)
            Session["MediationContactID"] = val;
        else if (curr == 5)
            Session["ServicerContactID"] = val;
    }
    /// <summary>
    /// This method we made for the tab color for the mediation contacts. We can change the color of the all mediation contacts to recongnise which is selected.
    /// </summary>
    /// <param name="b"></param>
    void changecolor(Button b)
    {
        btnAttorneyContact.CssClass = "navButton";
        btnCertificateLetterContact.CssClass = "navButton";
        btnLenderContact.CssClass = "navButton";
        btnMediationContact.CssClass = "navButton";
        btnServiceContact.CssClass = "navButton";
        b.CssClass = "navButtonclick";
        //lblAddedcontact.Text = "";
    }
    protected void txtActualConfDate_TextChanged(object sender, EventArgs e)
    {
        // PP - 11/15/18: Added app setting with list of users allowed to edit certain fields of mediation case.
        string[] adminUsers = System.Configuration.ConfigurationManager.AppSettings.Get("AdminUsers").ToString().ToLower().Split(',').Select(s => s.Trim()).ToArray();

        // ----------Below way for testing locally, does not work on test server----------
        //string currUser = Environment.UserName.ToLower().Trim();
        //if (adminUsers.Contains(currUser))
        //{
        //    isAdmin = true;
        //}

        foreach (string user in adminUsers)
        {
            if (Request.ServerVariables[5].Contains(user))
            {
                isAdmin = true;
            }
        }

        DateTime NewDate;
        DateTime NewFeeDate = new DateTime(2018, 6, 28);
        if (DateTime.TryParse(txtActualConfDate.Text.ToString(), out NewDate))
        {
            txtConfResolveDeadlineDate.Text = NewDate.AddDays(14).ToShortDateString();
            txtExtensionExprDate.Text = NewDate.AddDays(21).ToShortDateString();
            txtRequestExtensionByDate.Text = NewDate.AddDays(7).ToShortDateString();

            if (!isAdmin)
            {
                txtConfResolveDeadlineDate.Enabled = false;
                txtConfResolveDeadlineDate.ReadOnly = true;
                ImageButton19.Visible = false;

                txtExtensionExprDate.Enabled = false;
                txtExtensionExprDate.ReadOnly = true;
                ImageButton15.Visible = false;

                txtRequestExtensionByDate.Enabled = false;
                txtRequestExtensionByDate.ReadOnly = true;
            }
        }

        if (txtActualConfDate.Text != "" && (NewDate.Date >= NewFeeDate && txtInitialFee.Text == "100.00"))
        {
            txtMediationFeeAmount.Text = "400.00";
            btnPrintMediationInvoice.Enabled = true;
            btnPrintMediationInvoice.Visible = true;
        }
        else
        {
            if (txtActualConfDate.Text != "" && (NewDate.Date >= NewFeeDate && txtInitialFee.Text == "150.00"))
            {
                txtMediationFeeAmount.Text = "350.00";
                btnPrintMediationInvoice.Enabled = true;
                btnPrintMediationInvoice.Visible = true;
            }
            else
            {
                if (txtActualConfDate.Text != "" && (NewDate.Date <= NewFeeDate && txtInitialFee.Text == "150.00"))
                {
                    txtMediationFeeAmount.Text = "350.00";
                    btnPrintMediationInvoice.Enabled = true;
                    btnPrintMediationInvoice.Visible = true;
                }
            }
        }                
    }

    /// <summary>
    /// To print 14 DAY letter
    /// </summary>

    private DataTable Get14DayLetterPrintDetails
    {
        get
        {
            MediationCaseBAL Mediationobj = new MediationCaseBAL();
            return Mediationobj.Get14DayLetterPrintDetail(MediationCaseInformationID);
        }
    }

    /// <summary>
    /// This is for 14day letter
    /// </summary>
    /// <param name="crystalReport"></param>
    private void BindReport(ReportDocument crystalReport)
    {
        //_obd 11/3/2015: print workout invoice if conference result is #4
        if (lstConfResult.SelectedIndex == 4)
        {
            crystalReport.Load(Server.MapPath("~/Reports/CrystalReports/WorkoutInvoice.rpt"));
            //the following two lines allows the reports to logon to the db using the code in crystalfunctions.cs file. _obd
            CrystalFunctions cf = new CrystalFunctions();
            cf.ReportsLogonToDatabase(crystalReport);
            MediationCaseBAL Mediationobj = new MediationCaseBAL();
            DataTable data = Mediationobj.GetWorkoutInvoiceDetail(Convert.ToInt32(Session["MediationCaseID"].ToString()));
            crystalReport.SetDataSource(data);
            Session["myReport"] = crystalReport;
        }
        else
        {
            // SaveMediationCase();
            crystalReport.Load(Server.MapPath("~/Reports/CrystalReports/14DayLetterFinalAndInvoice.rpt"));
            CrystalFunctions cf = new CrystalFunctions();
            cf.ReportsLogonToDatabase(crystalReport);
            MediationCaseBAL Mediationobj = new MediationCaseBAL();
            DataTable data = Mediationobj.Get14DayLetterPrintDetail(Convert.ToInt32(Session["MediationCaseID"].ToString()));
            crystalReport.SetDataSource(data);

            Session["myReport"] = crystalReport;
        }
    }

    /// <summary>
    /// This is for 14day letter button print. Here we check the condition and call the save procedure
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPrintMediationInvoice_Click(object sender, EventArgs e)
    {
        //11/05/2015 _obd: added to disable the print invoice button if the fee has already been paid.
        if (txtMediationFeePaidDate.Text != "")
        {
            ShowAlert("The Mediation and/or Workout fees have already been paid.  No invoice will be printed!");
            btnPrintMediationInvoice.Enabled = false;
            return;
        }

        if (txtActualConfDate.Text == "" && lstConfResult.SelectedIndex != 4)
        {
            ShowAlert("Please Select Actual conference Date. You can not print 14Day Letter");
            return;
        }
        if (lstCoordinatorName.SelectedIndex == 0)
        {
            ShowAlert("Please select Coordinator Name. You can not print 14Day Letter");
            return;
        }
        if (lstMediationInvoiceSentTo.SelectedIndex == 0)
        {
            ShowAlert("Please select MediationInvoiceSentTo. You can not print 14Day Letter");
            return;
        }
        if (txtMedInvoicePrintDate.Text == "")
        {
            txtMedInvoicePrintDate.Text = DateTime.Today.ToShortDateString().ToString();
            txtMedInvoicePrintDate.ReadOnly = true;
            txtMedInvoicePrintDate.Enabled = false;
        }
        SaveMediationCase(true);
    }

    public void PrintMediationInvoice()
    {
        ReportDocument crystalReport = new ReportDocument();
        BindReport(crystalReport);
        string fileName = "report";
        string filePath = @"~/tmpStorage/" + fileName;
        // crystalReport.PrintToPrinter(2, true, 1, 2);
        //crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Crystal");
        crystalReport.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath(filePath + ".pdf"));
        Session["reportDocument"] = crystalReport;
        string script = "<script language='javascript'> window.open('OpenFile.aspx?action=401&filepath=" + filePath + "&filename=" + fileName + "');</script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "PopupCP", script, false);
        //Response.End();
    }

    public int MediationCaseInformationID
    {
        get;
        set;
    }
    /// <summary>
    /// bool LetterPrint=false . LetterPrint is variable. Data type of this variable is bool.
    /// When we print 14Dayletter , we do not have any required information such as actual conference date , User can go application , select requried application and then hit 14day print button, User can pull the data.
    /// </summary>
    ///  ///LetterPrint = 14 day letter print temporary varaible
    /// <param name="LetterPrint"></param>
    private void SaveMediationCase(bool LetterPrint)
    {
        //if(Session["MortgagorInformationID"] != "")
        if (Convert.ToString(Session["MortgagorInformationID"]) != "")
        {
            if (Request.QueryString["Edit"] == "true")
            {
                isEdit = true;
            }
            else
            {
                isEdit = false;
            }

            // PP - 11/15/18: Added app setting with list of users allowed to edit certain fields of mediation case.
            string[] adminUsers = System.Configuration.ConfigurationManager.AppSettings.Get("AdminUsers").ToString().ToLower().Split(',').Select(s => s.Trim()).ToArray();

            // ----------Below way for testing locally, does not work on test server----------
            //string currUser = Environment.UserName.ToLower().Trim();
            //if (adminUsers.Contains(currUser))
            //{
            //    isAdmin = true;
            //}

            foreach (string user in adminUsers)
            {
                if (Request.ServerVariables[5].Contains(user))
                {
                    isAdmin = true;
                }
            }

            MediationCaseDALobj.MortgagorInformationID = (int)Session["MortgagorInformationID"];
            MediationCaseDALobj.MortgageAccountNumber = txtMortgagorAccNo.Text.ToString();

            //MediationCaseDALobj.DefaultDate = DateTime.Parse(txtDefaultdate.Text.ToString());
            //INSERT MEDIATION CASE FIELDS -PANEL 1 IN MEDIATION CASE FORM
            //Begin New code additions, added on 05/19/2016_jed
            MediationCaseDALobj.FirstName = txtFirstName.Text.ToString();
            MediationCaseDALobj.MiddleInitial = txtMiddleInitial.Text.ToString();
            MediationCaseDALobj.LastName = txtLastName.Text.ToString();
            MediationCaseDALobj.Suffix = lstBorrowerSuffix.Text.ToString();
            MediationCaseDALobj.Alias = txtAlias.Text.ToString();


            MediationCaseDALobj.PrintViewBorrower = txtPrintViewBorrower.Text.ToString();
            MediationCaseDALobj.PrintViewCo_Borrower = txtPrintViewCo_Borrower.Text.ToString();
            MediationCaseDALobj.PrintViewName_3 = txtPrintViewCo_Borrower3.Text.ToString();
            MediationCaseDALobj.PrintViewName_4 = txtPrintViewCo_Borrower4.Text.ToString();
            MediationCaseDALobj.Address_1 = txtAddress_1.Text.ToString();
            MediationCaseDALobj.Address_2 = txtAddress_2.Text.ToString();
            MediationCaseDALobj.City = txtCity.Text.ToString();
            MediationCaseDALobj.State = txtState.Text.ToString();
            MediationCaseDALobj.ZipCode = txtZipCode.Text.ToString();
            MediationCaseDALobj.MortgagorPhone = txtMortgagorPhone.Text.ToString();
            //End New code additions, added on 05/19/2016_jed

            DateTime MortgagorCalledDate;
            if (DateTime.TryParse(txtMortgagorCalledDate.Text.ToString().Trim(), out MortgagorCalledDate))
                MediationCaseDALobj.MortgagorCalledDate = MortgagorCalledDate;

            DateTime DefaultDate;
            if (DateTime.TryParse(txtDefaultdate.Text.ToString().Trim(), out DefaultDate))
                MediationCaseDALobj.DefaultDate = DefaultDate;
            //else
            //    MediationCaseDALobj.DefaultDate = null;
            MediationCaseDALobj.NoticeDate = DateTime.Parse(txtNoticeDate.Text.ToString());
            int penaltydays = 0;
            int.TryParse(txtPenaltyDays.Text.ToString(), out penaltydays);
            MediationCaseDALobj.PenaltyDays = penaltydays;
            GetPenaltyDays();

            //Decimal InitialFee = 0;
            DateTime NoticeDate;
            DateTime NewFeeDate = new DateTime(2018, 6, 28);
            DateTime.TryParse(txtNoticeDate.Text.ToString().Trim(), out NoticeDate);

            if (isEdit && isAdmin)
            {
                MediationCaseDALobj.InitialFee = Convert.ToDecimal(txtInitialFee.Text);
            }
            else
            {
                if (NoticeDate < NewFeeDate)
                {
                    txtInitialFee.Text = "150.00";
                    //txtInitialFee.Text = InitialFee.ToString();
                    MediationCaseDALobj.InitialFee = Convert.ToDecimal(txtInitialFee.Text);
                }
                else

                if (NoticeDate >= NewFeeDate)
                {
                    txtInitialFee.Text = "100.00";
                    //txtInitialFee.Text = InitialFee.ToString();
                    MediationCaseDALobj.InitialFee = Convert.ToDecimal(txtInitialFee.Text);
                }
            }
                    

            //MediationCaseDALobj.ReleaseBankruptcyStayDate = DateTime.Parse(txtReleaseBankruptcyStayDate.Text.ToString());

            DateTime ReleaseBankruptcyStayDate;
            if (DateTime.TryParse(txtReleaseBankruptcyStayDate.Text.ToString(), out ReleaseBankruptcyStayDate))
                MediationCaseDALobj.ReleaseBankruptcyStayDate = ReleaseBankruptcyStayDate;
            else
                MediationCaseDALobj.ReleaseBankruptcyStayDate = null;

            //MediationCaseDALobj.ServicemanCivilReliefActDate 09/24/15 _obd
            DateTime ServicemanCivilReliefActDate;
            if (DateTime.TryParse(txtServicemanCivilReliefActDate.Text.ToString(), out ServicemanCivilReliefActDate))
                MediationCaseDALobj.ServicemanCivilReliefActDate = ServicemanCivilReliefActDate;
            else
                MediationCaseDALobj.ServicemanCivilReliefActDate = null;

            //MediationCaseDALobj.FirstLetterSentDate = DateTime.Parse(txtFirstLetterSent.Text.ToString());
            DateTime FirstLetterSentDate;
            if (DateTime.TryParse(txtFirstLetterSent.Text.ToString(), out FirstLetterSentDate))
                MediationCaseDALobj.FirstLetterSentDate = FirstLetterSentDate;
            else
                MediationCaseDALobj.FirstLetterSentDate = null;
            //chkReturnedMail _Jaheda meman 7/8/15
            if (chkReturnedMail.Checked == false)
                MediationCaseDALobj.ReturnedMail = false;
            else
                MediationCaseDALobj.ReturnedMail = Convert.ToBoolean(chkReturnedMail.Checked);
            //ReturnedMailDate _obd 09/11/15 

            DateTime ReturnedMailDate;
            if (DateTime.TryParse(txtReturnedMailDate.Text.ToString(), out ReturnedMailDate))
                MediationCaseDALobj.ReturnedMailDate = ReturnedMailDate;
            else
                MediationCaseDALobj.ReturnedMailDate = null;

            //MediationCaseDALobj.SecondLetterSentDate = DateTime.Parse(txtSecondLetterSentDate.Text.ToString());
            DateTime SecondLetterSentDate;
            if (DateTime.TryParse(txtSecondLetterSentDate.Text.ToString(), out SecondLetterSentDate))
                MediationCaseDALobj.SecondLetterSentDate = SecondLetterSentDate;
            else
                MediationCaseDALobj.SecondLetterSentDate = null;

            DateTime ConfCallDeadlineDate;
            if (DateTime.TryParse(txtConfCallDeadlineDate.Text.ToString(), out ConfCallDeadlineDate))
                MediationCaseDALobj.ConfCallDeadlineDate = ConfCallDeadlineDate;
            else
                MediationCaseDALobj.ConfCallDeadlineDate = null;

            DateTime MedInvoiceLetterDate;
            if (DateTime.TryParse(txtMedInvoicePrintDate.Text.ToString(), out MedInvoiceLetterDate))
                MediationCaseDALobj.MedInvoiceLetterDate = MedInvoiceLetterDate;
            else
                MediationCaseDALobj.MedInvoiceLetterDate = null;
            // MediationCaseDALobj.InitialContactDate = DateTime.Parse(txtIntialContactDate.Text.ToString());

            //INSERT MEDIATION CASE FIELDS -PANEL 2 IN MEDIATION CASE FORM
            DateTime InitialContactDate;
            if (DateTime.TryParse(txtInitialContactDate.Text.ToString(), out InitialContactDate))
                MediationCaseDALobj.InitialContactDate = InitialContactDate;
            else
                MediationCaseDALobj.InitialContactDate = null;

            DateTime PackageSentLenderDate;
            if (DateTime.TryParse(txtPackageSentDate.Text.ToString(), out PackageSentLenderDate))
                MediationCaseDALobj.PackageSentLenderDate = PackageSentLenderDate;
            else
                MediationCaseDALobj.PackageSentLenderDate = null;

            DateTime SchedConferenceDate;
            if (DateTime.TryParse(txtSheduledConfDate.Text.ToString(), out SchedConferenceDate))
                MediationCaseDALobj.SchedConferenceDate = SchedConferenceDate;
            else
                MediationCaseDALobj.SchedConferenceDate = null;

            DateTime ActualConferenceDate;
            if (DateTime.TryParse(txtActualConfDate.Text.ToString(), out ActualConferenceDate))
                MediationCaseDALobj.ActualConferenceDate = ActualConferenceDate;
            else
                MediationCaseDALobj.ActualConferenceDate = null;

            DateTime ConfResolveDeadlineDate;
            if (DateTime.TryParse(txtConfResolveDeadlineDate.Text.ToString(), out ConfResolveDeadlineDate))
                MediationCaseDALobj.ConfResolveDeadlineDate = ConfResolveDeadlineDate;
            else
                MediationCaseDALobj.ConfResolveDeadlineDate = null;

            DateTime ExtensionRequestDate;
            if (DateTime.TryParse(txtExtensionRequestDate.Text.ToString(), out ExtensionRequestDate))
                MediationCaseDALobj.ExtensionRequestDate = ExtensionRequestDate;
            else
                MediationCaseDALobj.ExtensionRequestDate = null;

            DateTime RequestExtensionByDate;
            if (DateTime.TryParse(txtRequestExtensionByDate.Text.ToString(), out RequestExtensionByDate))
                MediationCaseDALobj.RequestExtensionByDate = RequestExtensionByDate;
            else
                MediationCaseDALobj.RequestExtensionByDate = null;

            DateTime ExtensionExpirationDate;
            if (DateTime.TryParse(txtExtensionExprDate.Text.ToString(), out ExtensionExpirationDate))
                MediationCaseDALobj.ExtensionExpirationDate = ExtensionExpirationDate;
            else
                MediationCaseDALobj.ExtensionExpirationDate = null;

            DateTime ConfResolutionDate;
            if (DateTime.TryParse(txtConfResolutionDate.Text.ToString(), out ConfResolutionDate))
                MediationCaseDALobj.ConfResolutionDate = ConfResolutionDate;
            else
                MediationCaseDALobj.ConfResolutionDate = null;
            if (chkCounterOfferRejectedBorrower.Checked == false)
                MediationCaseDALobj.CounterOfferRejectedBorrower = 0;
            else
                MediationCaseDALobj.CounterOfferRejectedBorrower = Convert.ToInt32(chkCounterOfferRejectedBorrower.Checked);
            if (chkWO_FinancialBenefitBorrower.Checked == false)

                MediationCaseDALobj.WO_FinancialBenefitBorrower = 0;
            else
                MediationCaseDALobj.WO_FinancialBenefitBorrower = Convert.ToInt32(chkWO_FinancialBenefitBorrower.Checked);

            if (chkWO_AgreementInFile.Checked == false)

                MediationCaseDALobj.WO_AgreementInFile = 0;
            else
                MediationCaseDALobj.WO_AgreementInFile = Convert.ToInt32(chkWO_AgreementInFile.Checked);

            int CoordinatorID;
            if (int.TryParse(lstCoordinatorName.SelectedValue.ToString(), out CoordinatorID))

                MediationCaseDALobj.CoordinatorID = CoordinatorID;
            else
                MediationCaseDALobj.CoordinatorID = null;

            int CounselorID;
            if (int.TryParse(lstCounselorName.SelectedValue.ToString(), out CounselorID))
                MediationCaseDALobj.CounselorID = CounselorID;
            else
                MediationCaseDALobj.CounselorID = null;

            int ConferenceResultID;
            if (int.TryParse(lstConfResult.SelectedValue.ToString(), out ConferenceResultID))
                MediationCaseDALobj.ConferenceResultID = ConferenceResultID;
            else
                MediationCaseDALobj.ConferenceResultID = null;

            int MediationInvoiceID;
            if (int.TryParse(lstMediationInvoiceSentTo.SelectedValue.ToString(), out MediationInvoiceID))
                //if (MediationInvoiceID == -1)
                MediationCaseDALobj.MediationInvoiceID = MediationInvoiceID;
            else
                MediationCaseDALobj.MediationInvoiceID = null;

            Decimal Income = 0;
            Decimal.TryParse(txtIncome.Text.Trim().ToString(), out Income);
            //Income=Convert.ToDecimal(txtIncome.Text.ToString()== string.Empty);
            MediationCaseDALobj.Income = Income;
            int CertificateNoticeID;
            if (int.TryParse(lstCertificateNoticeTypeReason.SelectedValue.ToString(), out CertificateNoticeID))

                MediationCaseDALobj.CertificateNoticeID = CertificateNoticeID;
            else

                MediationCaseDALobj.CertificateNoticeID = null;
            Decimal PenaltyAmount = 0;

            //  if (int.TryParse(txtPenaltyAmount.Text.ToString().Trim(), out PenaltyAmount))
            Decimal.TryParse(txtPenaltyAmount.Text.ToString(), out PenaltyAmount);
            MediationCaseDALobj.PenaltyAmount = PenaltyAmount;
            Decimal MediationFeeAmount = 0;
            Decimal.TryParse(txtMediationFeeAmount.Text.ToString(), out MediationFeeAmount);
            MediationCaseDALobj.MediationFeeAmount = MediationFeeAmount;

            DateTime CertificateNoticePrintDate;
            if (DateTime.TryParse(txtCertificateNoticePrintDate.Text.ToString(), out CertificateNoticePrintDate))
                MediationCaseDALobj.CertificateNoticePrintDate = CertificateNoticePrintDate;
            else
                MediationCaseDALobj.CertificateNoticePrintDate = null;
            DateTime CertificateLetterReprintDate;
            if (DateTime.TryParse(txtCertificateLetterReprintDate.Text.ToString(), out CertificateLetterReprintDate))
                MediationCaseDALobj.CertificateLetterReprintDate = CertificateLetterReprintDate;
            else
                MediationCaseDALobj.CertificateLetterReprintDate = null;
            //chkDuplicateCertificateFeePaid _Jaheda meman 8/7/15
            if (chkDuplicateCertificateFeePaid.Checked == false)
                MediationCaseDALobj.DuplicateCertificateFeePaid = false;
            else
                MediationCaseDALobj.DuplicateCertificateFeePaid = Convert.ToBoolean(chkDuplicateCertificateFeePaid.Checked);
            DateTime PenaltyPaidDate;
            if (DateTime.TryParse(txtPenaltyPaidDate.Text.ToString(), out PenaltyPaidDate))
                MediationCaseDALobj.PenaltyPaidDate = PenaltyPaidDate;
            else
                MediationCaseDALobj.PenaltyPaidDate = null;
            //chkWaived _obd 3/3/15
            if (chkWaived.Checked == false)
                MediationCaseDALobj.PenaltyFeeWaived = false;
            else
                MediationCaseDALobj.PenaltyFeeWaived = Convert.ToBoolean(chkWaived.Checked);

            DateTime MediationFeeDate;
            if (DateTime.TryParse(txtMediationFeePaidDate.Text.ToString(), out MediationFeeDate))
                MediationCaseDALobj.MediationFeeDate = MediationFeeDate;
            else
                MediationCaseDALobj.MediationFeeDate = null;
            MediationCaseDALobj.CertificateLenderName = txtCertificateLenderName.Text.ToString();

            // INSERT MEDIATION CASE FIELDS -PANEL 4 IN MEDIATION CASE FORM These are Mediation contacts details
            MediationCaseDALobj.MediationContactID = int.Parse(Session["MediationContactID"].ToString());
            MediationCaseDALobj.CertificateLetterContactID = int.Parse(Session["CertificateLetterContactID"].ToString());
            MediationCaseDALobj.ServicerContactID = int.Parse(Session["ServicerContactID"].ToString());
            MediationCaseDALobj.AttorneyContactID = int.Parse(Session["AttorneyContactID"].ToString());
            MediationCaseDALobj.LenderContactID = int.Parse(Session["LenderContactID"].ToString());

            bool EditMode;
            Boolean.TryParse(Session["EditMediation"].ToString(), out EditMode);
            if (EditMode == false)
            {
                Session["EditMediation"] = true;
                //the negative 1 (-1) is a placeholder
                MediationCaseDALobj.MediationCaseInformationID = -1;

                Session["MediationCaseID"] = MediationCaseBALobj.AddMediationCaseDetails(MediationCaseDALobj, EditMode ? 1 : 0);

                //Response.Write("New Mediation Case has been added");
                lblAdded.Text = "Mediation Case has been added";
                /// this is Mediation case ID and Date to display after the mediation case save.
                txtMedCaseID.Text = Session["MediationCaseID"].ToString();
                //  txtMedInvoicePrintDate.Text = Convert.ToDateTime(Session["MedInvoiceLetterDate"]).ToString(); 
                txtMedCaseDate.Text = DateTime.Today.ToShortDateString().ToString();


                //New code addition as of 05/19/2016 
                txtFirstName.Enabled = true;
                txtMiddleInitial.Enabled = true;
                txtLastName.Enabled = true;
                lstBorrowerSuffix.Enabled = true;
                txtAlias.Enabled = true;
                txtPrintViewBorrower.Enabled = true;
                txtPrintViewCo_Borrower.Enabled = true;
                txtPrintViewCo_Borrower3.Enabled = true;
                txtPrintViewCo_Borrower4.Enabled = true;
                txtAddress_1.Enabled = false;
                txtAddress_2.Enabled = false;
                txtCity.Enabled = false;
                txtState.Enabled = false;
                txtZipCode.Enabled = false;
                txtMortgagorPhone.Enabled = false;
                txtMortgagorCalledDate.Enabled = false;
                //New code addition as of 05/19/2016

                txtDefaultdate.Enabled = false;
                txtNoticeDate.Enabled = false;
                ImageButton1.Visible = false;
                ImageButton2.Visible = false;
                ImageButton3.Visible = false;
                txtPenaltyDays.Enabled = false;
                txtPenaltyDays.Enabled = false;
                txtReleaseBankruptcyStayDate.Enabled = false;
                //txtServicemanCivilReliefActDate.Enabled = false;
                txtPenaltyAmount.Enabled = false;
                lblError.Visible = false;
                txtRequestExtensionByDate.ReadOnly = true;
                txtExtensionExprDate.ReadOnly = true;
                // txtConfResolveDeadlineDate.ReadOnly = true;
                if (txtMedInvoicePrintDate.Text != "")
                {
                    // txtMedInvoicePrintDate.ReadOnly = true;
                    txtMedInvoicePrintDate.Enabled = false;
                    ImageButton5.Visible = false;
                }

                if (txtActualConfDate.Text != "")
                {
                    txtActualConfDate.Enabled = false;

                    ImageButton12.Visible = false;
                    txtActualConfDate.ReadOnly = true;

                }
                if (txtExtensionRequestDate.Text != "")
                {
                    txtExtensionRequestDate.Enabled = false;
                    ImageButton15.Visible = false;
                }
                if (txtConfResolveDeadlineDate.Text != "")
                {
                    txtConfResolveDeadlineDate.Enabled = false;

                }
                if (txtPenaltyPaidDate.Text != "")
                {
                    txtPenaltyPaidDate.Enabled = false;
                    ImageButton4.Visible = false;

                }
                if (txtRequestExtensionByDate.Text != "")
                {
                    txtRequestExtensionByDate.Enabled = false;
                    //ImageButton4.Visible = false;

                }
                if (txtConfCallDeadlineDate.Text != "")
                {
                    txtConfCallDeadlineDate.Enabled = false;

                }
                if (txtCertificateNoticePrintDate.Text != "")
                {
                    txtCertificateNoticePrintDate.Enabled = false;

                }
                if (txtMediationFeePaidDate.Text != "")
                {
                    txtMediationFeePaidDate.Enabled = false;
                    ImageButton5.Visible = false;
                }

                //Response.Redirect("../SearchMortgagor/Default.aspx");
            }
            else
            {
                MediationCaseDALobj.MediationCaseInformationID = int.Parse(Session["MediationCaseID"].ToString());
                Session["MediationCaseID"] = MediationCaseBALobj.AddMediationCaseDetails(MediationCaseDALobj, EditMode ? 1 : 0);
                lblAdded.Text = "New Mediation Case has been Updated";

            }

            if (LetterPrint)
            {
                //call print method here
                // This is the 14 day print letter method . To print  14 day letter , we use this method.
                PrintMediationInvoice();
            }
        }
    }

    //Once user has entered notes, the following will execute once the user
    //has selected the save button for notes. This save button does not affect the overall data being 
    //data being entered at the same time.
    protected void btnSaveNotes_Click(object sender, EventArgs e)
    {
        //bool EditMode;
        //Boolean.TryParse(Session["NotesEdit"].ToString(), out EditMode);
        MediationCaseNotesDAL MediationCaseNotesDALobj = new MediationCaseNotesDAL();
        MediationCaseNotesBAL MediationCaseNotesBALobj = new MediationCaseNotesBAL();
        bool EditMode;
        Boolean.TryParse(Session["EditMediation"].ToString(), out EditMode);
        if (EditMode == false)
        {
            SaveMediationCase(false);
        }
        MediationCaseNotesDALobj.Notes = txtNotes.Text.ToString();
        MediationCaseNotesDALobj.MediationCaseInformationID = (Convert.ToInt16(Session["MediationCaseID"]));
        MediationCaseNotesBALobj.AddMediationCaseNotes(MediationCaseNotesDALobj);

        lblAddNotes.Text = "Notes successfully added";
        txtNotes.Text = "";
        BindNotesData();
    }

    protected void MediationCaseNotes_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    private void BindNotesData()
    {
        DataView dv = new DataView(dt);
        MediationCaseNotes.DataSource = dv;
        MediationCaseNotes.DataBind();
        dv = null;
    }
    private DataTable dt
    {
        get
        {
            int MediationID = 0;
            int.TryParse(Session["MediationCaseID"].ToString(), out MediationID);
            return MediationCaseNotesBAobj.GetMediationCaseNotesDetails(MediationID);
        }
    }
    protected void btnResetNotes_Click(object sender, EventArgs e)
    {
        txtNotes.Text = "";
    }

    protected void btnPrintCertificate_Click(object sender, EventArgs e)
    {
        double PenaltyAmount = 0.0;
        double MediationFeeAmount = 0.0;
        string ConfResolution = txtConfResolutionDate.Text;
        double.TryParse(txtPenaltyAmount.Text, out PenaltyAmount);
        double.TryParse(txtMediationFeeAmount.Text, out MediationFeeAmount);

        //04/09/2015 _obd: added to check that there's a confResolution Date before printing the non financial benefit certificate
        if (lstCertificateNoticeTypeReason.SelectedIndex == 5 && txtConfResolutionDate.Text == "")//txtConfResolutionDate.Text == null)
        {
            ShowAlert("Please enter the conference resolution date. You can not issue the certificate");
            return;
        }
        // ShowAlert(lstCertificateNoticeTypeReason.SelectedIndex.ToString());
        //   return;
        if (lstCertificateNoticeTypeReason.SelectedIndex == 0)
        {
            ShowAlert("Please select Certificate Notice Type & Reason. You can not issue the certificate");
            return;
        }
        //03/03/2015 _obd -- UPDATED TO LOOK FOR WAIVED PENALTIES PER TRICIA H.
        if (PenaltyAmount > 0 && txtPenaltyPaidDate.Text == "" && chkWaived.Checked == false)
        {
            ShowAlert("Penalty Fee Not Paid. You can not issue the certificate");
            return;
        }
        if (MediationFeeAmount > 0 && txtMediationFeePaidDate.Text == "")
        {
            ShowAlert("MediationFeeAmount Fee Not Paid. You can not issue the certificate");
            return;
        }

        if (txtCertificateNoticePrintDate.Text == "" && lstCertificateNoticeTypeReason.SelectedIndex != 2)
        {
            printReport();
        }
        else if (lstCertificateNoticeTypeReason.SelectedIndex == 2)
        {
            ResponseHelper.Redirect("~/Reports/ReportPages/GoodFaith.aspx?MediationCaseInformationId=" + Session["MediationCaseID"].ToString(), "_blank", "menubar=0,resizable=yes,width=840em,height=600em");
        }
    }

    protected void btnReprintCertificate_Click(object sender, EventArgs e)
    {
        double PenaltyAmount = 0.0;
        double MediationFeeAmount = 0.0;

        double.TryParse(txtPenaltyAmount.Text, out PenaltyAmount);
        double.TryParse(txtMediationFeeAmount.Text, out MediationFeeAmount);
        //set date when the reprint btn is clicked instead of the print btn. 
        //will not reprint unless previously printed (ie, no notice print date) _obd 2/23/15

        //03/16/2015 _obd -- UPDATED TO CHECK FOR THESE CRITERIA BEFORE REPRINTING A CERTIFICATE.
        if (PenaltyAmount > 0 && txtPenaltyPaidDate.Text == "" && chkWaived.Checked == false)
        {
            ShowAlert("Penalty Fee Not Paid. You cannot re-issue the certificate");
            return;
        }
        //04/09/2015 _obd: added to check that there's a confResolution Date before printing the non financial benefit certificate
        if (lstCertificateNoticeTypeReason.SelectedIndex == 5 && txtConfResolutionDate.Text == "")
        {
            ShowAlert("Please enter the conference resolution date. You can not re-issue the certificate");
            return;
        }
        if (MediationFeeAmount > 0 && txtMediationFeePaidDate.Text == "")
        {
            ShowAlert("MediationFeeAmount Fee Not Paid. You cannot re-issue the certificate");
            return;
        }

        if (txtCertificateNoticePrintDate.Text != "")
        {
            //calling the duplicate fee screen to process the reprint of all certificates per Tricia. _obd 10/13/2015
            ResponseHelper.Redirect("~/SpecificTask/dupefees.aspx?CaseId=" + txtMedCaseID.Text + "&CertID=" + lstCertificateNoticeTypeReason.SelectedIndex, "_blank", "menubar=0,resizable=yes,width=363em,height=220em");
        }
        else
        {
            ShowAlert("There is no certificate to reprint. Use the Print Certificate/Letter button to print the original report first.");
            return;
        }
        //printReport();
    }


    void printReport()
    {
        ReportDocument crystalReport = new ReportDocument();
        crystalReport.Load(Server.MapPath("~/Reports/Certificates/" + lstCertificateNoticeTypeReason.SelectedIndex + ".rpt"));

        CrystalFunctions cf = new CrystalFunctions();
        cf.ReportsLogonToDatabase(crystalReport);

        MediationCaseBAL Mediationobj = new MediationCaseBAL();

        DataTable data = Mediationobj.GetAllCertificatesDetails(Convert.ToInt32(Session["MediationCaseID"].ToString()), lstCertificateNoticeTypeReason.SelectedIndex);
        crystalReport.SetDataSource(data);
        lstCertificateNoticeTypeReason.Enabled = false;
        if (txtCertificateNoticePrintDate.Text == "")
        {
            txtCertificateNoticePrintDate.Text = DateTime.Today.ToShortDateString();
            txtCertificateNoticePrintDate.Enabled = false;
            btnPrintCertificate.Enabled = false;
        }
        Session["myReport"] = crystalReport;

        string fileName = "report";
        string filePath = @"~/tmpStorage/" + fileName;

        crystalReport.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath(filePath + ".pdf"));
        Session["reportDocument"] = crystalReport;

        string script = "<script language='javascript'> window.open('OpenFile.aspx?action=401&filepath=" + filePath + "&filename=" + fileName + "');</script>";


        ScriptManager.RegisterStartupScript(this, typeof(Page), "PopupCP", script, false);
    }

    protected void lstCertificateNoticeTypeReason_TextChanged(object sender, EventArgs e)
    {
        /*
         * //03/03/2015 _obd -- UPDATED TO DROP NOTICE PRINT DATE FOR CLOSED & INACTIVE CASE PER TRICIA H.
         * //DROP THE PRINT DATE IF THE LIST INDEX IS EITHER 7, 8, OR 9, then disable the field.
         * //WILL NOT WORK IF THE LIST IS SORTED IN ALPHABETICAL ORDER
         * //03/10/2015 _obd -- updated to fill the conf. resolution date for cases where the noticereason is either 7, 8, or 9 per Pam P.
         * // also check the waived penalty field and disable the print buttons and the print dates. _obd
         */
        ////if (lstCertificateNoticeTypeReason.SelectedIndex == 2)
        ////{
        ////    ResponseHelper.Redirect("~/Reports/ReportPages/GoodFaith.aspx", "_blank", "menubar=0,width=500,height=500");
        ////}

        if (new[] { 7, 8, 9 }.Contains(lstCertificateNoticeTypeReason.SelectedIndex))//_obd 3/3/15
        {
            txtConfResolutionDate.Text = DateTime.Today.ToShortDateString().ToString();
            txtConfResolutionDate.Enabled = false;
            btnPrintCertificate.Visible = false;
            btnReprintCertificate.Visible = false;
            btnPrintMediationInvoice.Visible = false;
            waivepenalties(1);
        }
        else
        {//_obd added else clause to refresh field if user changes their mind(before hitting save) //3/5/15
            //the waived penalty box have to be unchecked manually by Tricia. _obd
            //the confresolutiondate is enabled so the user can restore the date if needed
            txtConfResolutionDate.Enabled = true;
            btnPrintCertificate.Visible = true;
            btnReprintCertificate.Visible = true;
            btnPrintMediationInvoice.Visible = true;
        }
        //previous code commented on 3/3/15 _obd
        //if (lstCertificateNoticeTypeReason.SelectedIndex == 7)
        //{
        //    txtCertificateNoticePrintDate.Text = DateTime.Today.ToShortDateString().ToString();
        //}
    }

    void waivepenalties(int a)
    {
        //created on 3/10/15 _obd
        //check the penalty waived box if a case is set to close with an unpaid penalty
        double PenaltyAmount = 0.0;
        double.TryParse(txtPenaltyAmount.Text, out PenaltyAmount);
        if (PenaltyAmount > 0 && txtPenaltyPaidDate.Text == "" && a == 1)
        {
            chkWaived.Checked = true;
            chkWaived.Enabled = false;
        }
    }
    
   
    //created on 06/29/15 _Jaheda Meman
    protected void lstConfResult_TextChanged(object sender, EventArgs e)
    {
        if (Request.QueryString["Edit"] == "true")
        {
            isEdit = true;
        }
        else
        {
            isEdit = false;
        }

        // PP - 11/15/18: Added app setting with list of users allowed to edit certain fields of mediation case.
        string[] adminUsers = System.Configuration.ConfigurationManager.AppSettings.Get("AdminUsers").ToString().ToLower().Split(',').Select(s => s.Trim()).ToArray();

        // ----------Below way for testing locally, does not work on test server----------
        //string currUser = Environment.UserName.ToLower().Trim();
        //if (adminUsers.Contains(currUser))
        //{
        //    isAdmin = true;
        //}

        foreach (string user in adminUsers)
        {
            if (Request.ServerVariables[5].Contains(user))
            {
                isAdmin = true;
            }
        }

        //11/18/2015 _obd: updated to change the value of the mediation fee fields based on the conference result
        DateTime NewDate;
        DateTime NewFeeDate = new DateTime(2018, 6, 28);
        if (DateTime.TryParse(txtActualConfDate.Text.ToString(), out NewDate))
        {
            if ((lstConfResult.SelectedIndex == 2) && (txtActualConfDate.Text != "" && (NewDate.Date >= NewFeeDate && txtInitialFee.Text == "100.00")))
            {
                txtMediationFeeAmount.Text = "400.00";
                if (!isAdmin)
                {
                    txtActualConfDate.Enabled = false;
                    ImageButton12.Visible = false;
                    lstConfResult.Enabled = false;
                }                
                return;
            }
            else if ((lstConfResult.SelectedIndex == 2) && (txtActualConfDate.Text != "" && (NewDate.Date >= NewFeeDate && txtInitialFee.Text == "150.00")))
            {
                txtMediationFeeAmount.Text = "350.00";
                if (!isAdmin)
                {
                    txtActualConfDate.Enabled = false;
                    ImageButton12.Visible = false;
                    lstConfResult.Enabled = false;
                }
                return;
            }
        }

        if ((lstConfResult.SelectedIndex == 4) && (txtActualConfDate.Text == ""))
        {
            txtMediationFeeAmount.Text = "150.00";
            if (!isAdmin)
            {                
                txtActualConfDate.Enabled = false;
                txtConfResolveDeadlineDate.Enabled = false;
                txtRequestExtensionByDate.Enabled = false;
                txtExtensionRequestDate.Enabled = false;
                txtExtensionExprDate.Enabled = false;
                ImageButton12.Visible = false;
                ImageButton15.Visible = false;
                lstConfResult.Enabled = false;
            }
            return;
        }
    }

    protected void chkReturnedMail_CheckedChanged(object sender, EventArgs e)
    {
        if (chkReturnedMail.Checked == true)
        {
            txtReturnedMailDate.Text = DateTime.Today.ToShortDateString().ToString();
            //9/14/15 _obd -- added to disable field after save is executed without additional screen refresh
            chkReturnedMail.Enabled = false;
        }
        else
        {
            txtReturnedMailDate.Text = null;
            //  chkReturnedMail.Enabled = true;
        }
    }
    protected void txtServicemanCivilReliefActDate_TextChanged(object sender, EventArgs e)
    {
        if (txtServicemanCivilReliefActDate.Text != "")
        {
            btnCal.Enabled = true;
            // this is the reminder to save the penalty days 
            //    ScriptManager.RegisterStartupScript(this, GetType(),
            //"alertMessage", "alert('Please Click on Penalty Button!');", true);
            //  lblError.Text = "Please Click on Penalty Button!";
            ShowAlert("Please Click on Penalty Button!");
        }
    }

    protected void txtReleaseBankruptcyStayDate_TextChanged(object sender, EventArgs e)
    // THIS IS CODE WHEN WE WANT TO MAKE EDIT BankruptcyStayDat IN EDIT MODE. DO NOT DELETE THIS CODE. KEEP HERE FOR THE FUTURE PURPOSE
    {
        if (txtReleaseBankruptcyStayDate.Text != "")
        {
            btnCal.Enabled = true;
            // this is the reminder to save the penalty days 
            //    ScriptManager.RegisterStartupScript(this, GetType(),
            //"alertMessage", "alert('Please Click on Penalty Button!');", true);
            //  lblError.Text = "Please Click on Penalty Button!";
            ShowAlert("Please Click on Penalty Button!");
        }
    }

    public void BorrowerName()
    {
        //if (Convert.ToInt32(e.KeyChar) == 9)
        //{
        //    MessageBox.Show("Enter pressed");
        //}
        //lstPrefix.SelectedItem.ToString() + " " +
        Session["BorrowerName"] = txtFirstName.Text + " " + txtMiddleInitial.Text + " " + txtLastName.Text + "," + lstBorrowerSuffix.SelectedItem.ToString() + " ";

        //BN ="+lstPrefix.text+","+txtFirstName.text+" ;
        // Session["BorrowerName"] = BN;
        if (Session["BorrowerName"].ToString() != null)
            txtPrintViewBorrower.Text = Session["BorrowerName"].ToString();

        //    Session["BorrowerName"] = lstPrefix.SelectedItem.ToString() + " " + txtFirstName.Text + " " + txtMidddleInitial.Text + " " + txtLastName.Text + "," + lstBorrowerSuffix.SelectedItem.ToString() + " ";
    }
}