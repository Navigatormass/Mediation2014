using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Common;
using System.Configuration;


/// <summary>
/// Summary description for AddMediationCaseInformationDAL
/// </summary>
namespace DAL
    {
    public class MediationCaseDAL
        {
        public MediationCaseDAL ()
            {
            //
            // TODO: Add Mediation case logic here
            //
            }
        #region Class Varibles
        /*Variables copied out of MortgagorDAL.cs for the purpose of Name and Address modification
         * and placement into the Mediation Case information table and also the new Mediation Case
         * history table to track changes to each case
         * Begin list of new variables added */
        ///<summary>FirstName</summary>
        protected string _FirstName;
        ///<summary>MiddleInitial</summary>
        protected string _MiddleInitial;
        ///<summary>LastName</summary>
        protected string _LastName;

        ///<summary>Suffix</summary>
        protected string _Suffix;
        ///<summary>Alias</summary>
        protected string _Alias;

        ///<summary>PrintViewBorrower</summary>
        protected string _PrintViewBorrower;

        ///<summary>PrintViewCo_Borrower</summary>
        protected string _PrintViewCo_Borrower;

        ///<summary>PrintViewName_3</summary>
        protected string _PrintViewName_3;

        ///<summary>PrintViewName_4</summary>
        protected string _PrintViewName_4;

        ///<summary>Address_1</summary>
        protected string _Address_1;
        ///<summary>Address_2</summary>
        protected string _Address_2;
        ///<summary>City</summary>
        protected string _City;
        ///<summary>ZipCode</summary>
        protected string _ZipCode;
        ///<summary>State</summary>
        protected string _State;
        ///<summary>MortgagorPhone</summary>
        protected string _MortgagorPhone;

        //End List of new variables added

        // INSERT MEDIATION CASE FIELDS -PANEL 1 IN MEDIATION CASE FORM
        ///<summary>MediationCaseInformationID</summary>
        protected int _MediationCaseInformationID;
        ///<summary>MediationCaseInformationID</summary>
        protected int _MortgagorInformationID;
        ///<summary>MortgageAccountNumber</summary>
        protected string _MortgageAccountNumber;
        ///<summary>DefaultDate</summary>
        protected DateTime? _DefaultDate;
        ///<summary>NoticeDate</summary>
        protected DateTime? _NoticeDate;
        ///<summary>PenaltyDays</summary>
        protected int _PenaltyDays;
        ///<summary>InitialFee</summary>
        protected decimal _InitialFee;
        ///<summary>ReleaseBankruptcyStayD</summary>
        protected DateTime? _ReleaseBankruptcyStayDate;
        ///<summary>ServicemanCivilReliefActDate</summary>
        protected DateTime? _ServicemanCivilReliefActDate;
        ///<summary>FirstLetterSentDate</summary>
        protected DateTime? _FirstLetterSentDate;
        ///<summary>SecondLetterSentDate</summary>
        protected DateTime? _SecondLetterSentDate;
        //INSERT ReturnedMail  _Jaheda Meman 06/23/15 
        ///<summary>_ReturnedMail</summary> 
        protected bool _ReturnedMail;
        //INSERT ReturnedMailDate _obd 09/11/15
        ///<summary>ReturnedMaidDate</summary>
        protected DateTime? _ReturnedMailDate;
        ///<summary>MortgagorCalledDate</summary>
        protected DateTime? _MortgagorCalledDate;

        /////<summary>PenaltyFeeCalcDate</summary>
        //protected DateTime? _PenaltyFeeCalcDate;

        ///<summary>ConfCallDeadlineDate</summary>
        protected DateTime? _ConfCallDeadlineDate;
        ///INSERT MEDIATION Notes FIELDS -PANEL 1 IN MEDIATION CASE FORM USING NOTES TABLE
        ///<summary>NotesID</summary>
        // protected int _NotesID;


        ///INSERT MEDIATION CASE FIELDS -PANEL 2 IN MEDIATION CASE FORM
        ///<summary>InitialContactDate</summary>
        protected DateTime? _InitialContactDate;
        ///<summary>PackageSentLenderDate</summary>
        protected DateTime? _PackageSentLenderDate;
        ///<summary>SchedConferenceDate</summary>
        protected DateTime? _SchedConferenceDate;
        ///<summary>ActualConferenceDate</summary>
        protected DateTime? _ActualConferenceDate;
        ///<summary>ConfResolveDeadlineDate</summary>
        protected DateTime? _ConfResolveDeadlineDate;
        ///<summary>ExtensionRequestDate</summary>
        protected DateTime? _ExtensionRequestDate;
        ///<summary>RequestExtensionByDate</summary>
        protected DateTime? _RequestExtensionByDate;
        ///<summary>ExtensionExpirationDate</summary>
        protected DateTime? _ExtensionExpirationDate;
        ///<summary>CounterOfferRejectedBorrower</summary>
        protected int _CounterOfferRejectedBorrower;
        ///<summary>WO_FinancialBenefitBorrower</summary>
        protected int _WO_FinancialBenefitBorrower;
        ///<summary>WO_AgreementInFile</summary>
        protected int _WO_AgreementInFile;
        ///<summary>Income</summary> 
        protected decimal? _Income;
        ///<summary>CoordinatorID</summary>
        protected int? _CoordinatorID;
        ///<summary>CounselorID</summary>
        protected int? _CounselorID;
        ///<summary>ConferenceResultID</summary>
        protected int? _ConferenceResultID;
        ///<summary>MediationInvoiceID</summary>
        protected int? _MediationInvoiceID;
        ///<summary>MedInvoiceLetterDate</summary>
        protected DateTime? _MedInvoiceLetterDate;
        ///<summary>ConfResolutionDate</summary>
        protected DateTime? _ConfResolutionDate;
        ///INSERT MEDIATION CASE FIELDS -PANEL 2 IN MEDIATION CASE FORM
        ///<summary>CertificateNoticeID</summary>
        protected int? _CertificateNoticeID;
        ///<summary>CertificateNoticeReasonID</summary>
        protected int? _CertificateNoticeReasonID;
        ///<summary>MediationFeeDate</summary>
        protected DateTime? _MediationFeeDate;
        ///<summary>PenaltyPaidDate</summary>
        protected DateTime? _PenaltyPaidDate;
        ///<summary>PenaltyAmount</summary> 
        protected decimal? _PenaltyAmount;

        ///PENALTY FEE WAIVED 03/03/2015 _obd
        ///<summary>_PenaltyFeeWaived</summary> 
        protected bool _PenaltyFeeWaived;

        ///<summary>MediationFeeAmount</summary> 
        protected decimal? _MediationFeeAmount;
        ///<summary>CertificateNoticePrintDate</summary>
        protected DateTime? _CertificateNoticePrintDate;
        ///<summary>CertificateLetterReprintDate</summary>
        protected DateTime? _CertificateLetterReprintDate;
        //INSERT Duplicate Certificate Fee Paid_Jaheda Meman 06/24/15 
        ///<summary>DuplicateCertificateFeePaid</summary> 
        protected bool _DuplicateCertificateFeePaid;
        ///<summary>CertificateLenderName</summary>
        protected string _CertificateLenderName;
        //Added by Jaheda Meman May11 2015
        ///<summaryUserID</summary>
        protected string _UserID;





        //START MEDIATTION CASE CONTACTS VARIABLES
        //INSERT MEDIATION CASE FIELDS -PANEL 4 IN MEDIATION CASE FORM
        ///<summary>LenderContactID</summary>
        protected int? _LenderContactID;
        ///<summary>MediationContactID</summary>
        protected int? _MediationContactID;
        ///<summary>ServicerContactID</summary>
        protected int? _ServicerContactID;
        ///<summary>AttorneyContactID</summary>
        protected int? _AttorneyContactID;
        ///<summary>CertificateLetterContactID</summary>
        protected int? _CertificateLetterContactID;

        // END MEDIATTION CASE LOGIC

        //START 5 ContactS Varaibles

        // TODO:1 Lender Contact Varaibles


        #endregion

        #region Properties  -Get and Set Accessor

        /*Begin new additions of Get & Set methods that are being added
         * from MortgagorDAL.cs. This is for the Name & Address modifications
         * as they are being associated with the Mediation Case information and
         * the new History table for the Case information.*/
        //Begin of list of added Accessor methods from the MortgagorDal.cs file.

        public String FirstName
            {
            get
                {
                return _FirstName;
                }
            set
                {
                _FirstName = value;
                }
            }

        public String MiddleInitial
            {
            get
                {
                return _MiddleInitial;
                }
            set
                {
                _MiddleInitial = value;
                }
            }

        public String LastName
            {
            get
                {
                return _LastName;
                }
            set
                {
                _LastName = value;
                }
            }

        public String Suffix
            {
            get
                {
                return _Suffix;
                }
            set
                {
                _Suffix = value;
                }
            }
        public String Alias
            {
            get
                {
                return _Alias;
                }
            set
                {
                _Alias = value;
                }
            }
        public String PrintViewBorrower
            {
            get
                {
                return _PrintViewBorrower;
                }
            set
                {
                _PrintViewBorrower = value;
                }
            }
        public String PrintViewCo_Borrower
            {
            get
                {
                return _PrintViewCo_Borrower;
                }
            set
                {
                _PrintViewCo_Borrower = value;
                }
            }

        /* The PrintViewBorrower_3 * PrintViewBorrower_4 are utilized
        * for added Co-Borrowers when they number more than two*/

        //Co-Borrower 3 (three)
        public String PrintViewName_3
            {
            get
                {
                return _PrintViewName_3;
                }
            set
                {
                _PrintViewName_3 = value;
                }
            }

        //Co-Borrower 4 (four)
        public String PrintViewName_4
            {
            get
                {
                return _PrintViewName_4;
                }
            set
                {
                _PrintViewName_4 = value;
                }
            }

        public String Address_1
            {
            get
                {
                return _Address_1;
                }
            set
                {
                _Address_1 = value;
                }
            }

        public String Address_2
            {
            get
                {
                return _Address_2;
                }
            set
                {
                _Address_2 = value;
                }
            }

        public String City
            {
            get
                {
                return _City;
                }
            set
                {
                _City = value;
                }
            }
        public String ZipCode
            {
            get
                {
                return _ZipCode;
                }
            set
                {
                _ZipCode = value;
                }
            }
        public String State
            {
            get
                {
                return _State;
                }
            set
                {
                _State = value;
                }
            }
        public String MortgagorPhone
        {
            get
            {
                return _MortgagorPhone;
            }
            set
            {
                _MortgagorPhone = value;
            }
        }

        //INSERT MEDIATION CASE FIELDS -PANEL 1 IN MEDIATION CASE FORM
        public int MediationCaseInformationID
            {
            get
                {
                return _MediationCaseInformationID;
                }
            set
                {
                _MediationCaseInformationID = value;
                }
            }
        public int MortgagorInformationID
            {
            get
                {
                return _MortgagorInformationID;
                }
            set
                {
                _MortgagorInformationID = value;
                }
            }
        public String MortgageAccountNumber
            {
            get
                {
                return _MortgageAccountNumber;
                }
            set
                {
                _MortgageAccountNumber = value;
                }
            }
        public DateTime? DefaultDate
            {
            get
                {
                return _DefaultDate;
                }
            set
                {
                _DefaultDate = value;
                }
            }
        public DateTime? NoticeDate
            {
            get
                {
                return _NoticeDate;
                }
            set
                {
                _NoticeDate = value;
                }
            }

        public int PenaltyDays
            {
            get
                {
                return _PenaltyDays;
                }
            set
                {
                _PenaltyDays = value;
                }
            }
        public decimal InitialFee
            {
            get
                {
                return _InitialFee;
                }
            set
                {
                _InitialFee = value;
                }
            }
        public DateTime? ReleaseBankruptcyStayDate
            {
            get
                {
                return _ReleaseBankruptcyStayDate;
                }
            set
                {
                _ReleaseBankruptcyStayDate = value;
                }
            }
        //Insert ServicemanCivilReliefActDate 9/24/15 _obd
        public DateTime? ServicemanCivilReliefActDate
            {
            get
                {
                return _ServicemanCivilReliefActDate;
                }
            set
                {
                _ServicemanCivilReliefActDate = value;
                }
            }
        public DateTime? FirstLetterSentDate
            {
            get
                {
                return _FirstLetterSentDate;
                }
            set
                {
                _FirstLetterSentDate = value;
                }
            }
        public DateTime? SecondLetterSentDate
            {
            get
                {
                return _SecondLetterSentDate;
                }
            set
                {
                _SecondLetterSentDate = value;
                }
            }
        //INSERT ReturnedMail _Jaheda Meman 06/23/15 
        public bool ReturnedMail
            {
            get
                {
                return _ReturnedMail;
                }
            set
                {
                _ReturnedMail = value;
                }
            }
        //INSERT ReturnedMailDate _OBD 9/11/15
        public DateTime? ReturnedMailDate
            {
            get
                {
                return _ReturnedMailDate;
                }
            set
                {
                _ReturnedMailDate = value;
                }
            }
        //public DateTime? PenaltyFeeCalcDate
        //{
        //    get { return _PenaltyFeeCalcDate; }
        //    set { _PenaltyFeeCalcDate = value; }
        //}
        public DateTime? ConfCallDeadlineDate
            {
            get
                {
                return _ConfCallDeadlineDate;
                }
            set
                {
                _ConfCallDeadlineDate = value;
                }
            }
        ///INSERT MEDIATION Notes FIELDS -PANEL 1 IN MEDIATION CASE FORM USING NOTES TABLE
        //public int NotesID
        //{
        //    get { return _NotesID; }
        //    set { _NotesID = value; }
        //}
        //INSERT MEDIATION CASE FIELDS -PANEL 2 IN MEDIATION CASE FORM
        public DateTime? InitialContactDate
            {
            get
                {
                return _InitialContactDate;
                }
            set
                {
                _InitialContactDate = value;
                }
            }
        public DateTime? PackageSentLenderDate
            {
            get
                {
                return _PackageSentLenderDate;
                }
            set
                {
                _PackageSentLenderDate = value;
                }
            }
        public DateTime? SchedConferenceDate
            {
            get
                {
                return _SchedConferenceDate;
                }
            set
                {
                _SchedConferenceDate = value;
                }
            }
        public DateTime? ActualConferenceDate
            {
            get
                {
                return _ActualConferenceDate;
                }
            set
                {
                _ActualConferenceDate = value;
                }
            }
        public DateTime? ConfResolveDeadlineDate
            {
            get
                {
                return _ConfResolveDeadlineDate;
                }
            set
                {
                _ConfResolveDeadlineDate = value;
                }
            }
        public DateTime? ExtensionRequestDate
            {
            get
                {
                return _ExtensionRequestDate;
                }
            set
                {
                _ExtensionRequestDate = value;
                }
            }
        public DateTime? RequestExtensionByDate
            {
            get
                {
                return _RequestExtensionByDate;
                }
            set
                {
                _RequestExtensionByDate = value;
                }
            }
        public DateTime? ExtensionExpirationDate
            {
            get
                {
                return _ExtensionExpirationDate;
                }
            set
                {
                _ExtensionExpirationDate = value;
                }
            }
        public DateTime? ConfResolutionDate
            {
            get
                {
                return _ConfResolutionDate;
                }
            set
                {
                _ConfResolutionDate = value;
                }
            }
        public DateTime? MortgagorCalledDate
        {
            get
            {
                return _MortgagorCalledDate;
            }
            set
            {
                _MortgagorCalledDate = value;
            }
        }
        public int CounterOfferRejectedBorrower
            {
            get
                {
                return _CounterOfferRejectedBorrower;
                }
            set
                {
                _CounterOfferRejectedBorrower = value;
                }
            }
        public int WO_FinancialBenefitBorrower
            {
            get
                {
                return _WO_FinancialBenefitBorrower;
                }
            set
                {
                _WO_FinancialBenefitBorrower = value;
                }
            }
        public int WO_AgreementInFile
            {
            get
                {
                return _WO_AgreementInFile;
                }
            set
                {
                _WO_AgreementInFile = value;
                }
            }

        public decimal? Income
            {
            get
                {
                return _Income;
                }
            set
                {
                _Income = value;
                }
            }
        public DateTime? MedInvoiceLetterDate
            {
            get
                {
                return _MedInvoiceLetterDate;
                }
            set
                {
                _MedInvoiceLetterDate = value;
                }
            }
        public int? CoordinatorID
            {
            get
                {
                return _CoordinatorID;
                }
            set
                {
                _CoordinatorID = value;
                }
            }
        public int? CounselorID
            {
            get
                {
                return _CounselorID;
                }
            set
                {
                _CounselorID = value;
                }
            }
        public int? ConferenceResultID
            {
            get
                {
                return _ConferenceResultID;
                }
            set
                {
                _ConferenceResultID = value;
                }
            }
        public int? MediationInvoiceID
            {
            get
                {
                return _MediationInvoiceID;
                }
            set
                {
                _MediationInvoiceID = value;
                }
            }
        //INSERT MEDIATION CASE FIELDS -PANEL 3 IN MEDIATION CASE FORM
        public int? CertificateNoticeID
            {
            get
                {
                return _CertificateNoticeID;
                }
            set
                {
                _CertificateNoticeID = value;
                }
            }
        public int? CertificateNoticeReasonID
            {
            get
                {
                return _CertificateNoticeReasonID;
                }
            set
                {
                _CertificateNoticeReasonID = value;
                }

            }
        //INSERT DuplicateCertificateFeePaid _Jaheda Meman 06/24/15 
        public bool DuplicateCertificateFeePaid
            {
            get
                {
                return _DuplicateCertificateFeePaid;
                }
            set
                {
                _DuplicateCertificateFeePaid = value;
                }
            }
        //INSERT MEDIATION CASE FIELDS -PANEL 4 IN MEDIATION CASE FORM
        public int? LenderContactID
            {
            get
                {
                return _LenderContactID;
                }
            set
                {
                _LenderContactID = value;
                }
            }
        public int? MediationContactID
            {
            get
                {
                return _MediationContactID;
                }
            set
                {
                _MediationContactID = value;
                }
            }
        public int? ServicerContactID
            {
            get
                {
                return _ServicerContactID;
                }
            set
                {
                _ServicerContactID = value;
                }
            }
        public int? AttorneyContactID
            {
            get
                {
                return _AttorneyContactID;
                }
            set
                {
                _AttorneyContactID = value;
                }
            }
        public int? CertificateLetterContactID
            {
            get
                {
                return _CertificateLetterContactID;
                }
            set
                {
                _CertificateLetterContactID = value;
                }
            }

        public DateTime? PenaltyPaidDate
            {
            get
                {
                return _PenaltyPaidDate;
                }
            set
                {
                _PenaltyPaidDate = value;
                }
            }

        public DateTime? MediationFeeDate
            {
            get
                {
                return _MediationFeeDate;
                }
            set
                {
                _MediationFeeDate = value;
                }
            }
        public DateTime? CertificateNoticePrintDate
            {
            get
                {
                return _CertificateNoticePrintDate;
                }
            set
                {
                _CertificateNoticePrintDate = value;
                }
            }
        public DateTime? CertificateLetterReprintDate
            {
            get
                {
                return _CertificateLetterReprintDate;
                }
            set
                {
                _CertificateLetterReprintDate = value;
                }
            }
        public decimal? PenaltyAmount
            {
            get
                {
                return _PenaltyAmount;
                }
            set
                {
                _PenaltyAmount = value;
                }
            }
        //INSERT PENALTY FEE WAIVED _obd 3/3/15 
        public bool PenaltyFeeWaived
            {
            get
                {
                return _PenaltyFeeWaived;
                }
            set
                {
                _PenaltyFeeWaived = value;
                }
            }
        public decimal? MediationFeeAmount
            {
            get
                {
                return _MediationFeeAmount;
                }
            set
                {
                _MediationFeeAmount = value;
                }
            }
        public String CertificateLenderName
            {
            get
                {
                return _CertificateLenderName;
                }
            set
                {
                _CertificateLenderName = value;
                }
            }
        public String UserID
            {
            //5/11/15 _Jaheda Meman updated to capture the windows authenticated user. 
            // get { return HttpContext.Current.User.Identity.Name; }//_UserID; }
            get
                {
                if (_UserID != null)
                    {
                    return _UserID;
                    }
                else
                    {
                    return HttpContext.Current.User.Identity.Name;
                    }
                }
            set
                {
                _UserID = value;
                }
            }
        #endregion


        /// <summary>
        /// Add Mediation Case Information Detail
        /// </summary>
        /// <returns></returns>


        public int AddMediationCaseDetails (MediationCaseDAL Mortgagorobj, int EditMode)
            {

            //New SQL Parameters added from MortgagorDAL.cs to represent the Name & Address fields being
            //included in the add / edit process for the Mediation Case Table and the Case History Table
            // TO SAVE MEDIATION  DETAILS  PANEL 1
            /*Begin New Items List on 05/10/2016 by jdixon*/

            SqlParameter prmFirstName = new SqlParameter ("@FirstName", SqlDbType.VarChar);
            prmFirstName.Value = Mortgagorobj.FirstName;

            SqlParameter prmMiddleInitial = new SqlParameter ("@MiddleInitial", SqlDbType.VarChar);
            prmMiddleInitial.Value = Mortgagorobj.MiddleInitial;

            SqlParameter prmLastName = new SqlParameter ("@LastName", SqlDbType.VarChar);
            prmLastName.Value = Mortgagorobj.LastName;

            SqlParameter prmSuffix = new SqlParameter ("@Suffix", SqlDbType.VarChar);
            prmSuffix.Value = Mortgagorobj.Suffix;

            SqlParameter prmAlias = new SqlParameter ("@Alias", SqlDbType.VarChar);
            prmAlias.Value = Mortgagorobj.Alias;

            SqlParameter prmPrintViewBorrower = new SqlParameter ("@PrintViewBorrower", SqlDbType.VarChar);
            prmPrintViewBorrower.Value = Mortgagorobj.PrintViewBorrower;

            SqlParameter prmPrintViewCo_Borrower = new SqlParameter ("@PrintViewCo_Borrower", SqlDbType.VarChar);
            prmPrintViewCo_Borrower.Value = Mortgagorobj.PrintViewCo_Borrower;

            SqlParameter prmPrintViewName_3 = new SqlParameter ("@PrintViewName_3", SqlDbType.VarChar);
            prmPrintViewName_3.Value = Mortgagorobj.PrintViewName_3;

            SqlParameter prmPrintViewName_4 = new SqlParameter ("@PrintViewName_4", SqlDbType.VarChar);
            prmPrintViewName_4.Value = Mortgagorobj.PrintViewName_4;

            SqlParameter prmAddress_1 = new SqlParameter ("@Address_1", SqlDbType.VarChar);
            prmAddress_1.Value = Mortgagorobj.Address_1;

            SqlParameter prmAddress_2 = new SqlParameter ("@Address_2", SqlDbType.VarChar);
            prmAddress_2.Value = Mortgagorobj.Address_2;

            SqlParameter prmCity = new SqlParameter ("@City", SqlDbType.VarChar);
            prmCity.Value = Mortgagorobj.City;

            SqlParameter prmZipCode = new SqlParameter ("@ZipCode", SqlDbType.Char);
            prmZipCode.Value = Mortgagorobj.ZipCode;

            SqlParameter prmState = new SqlParameter ("@State", SqlDbType.Char);
            prmState.Value = Mortgagorobj.State;

            SqlParameter prmMortgagorPhone = new SqlParameter("@MortgagorPhone", SqlDbType.Char);
            prmMortgagorPhone.Value = Mortgagorobj.MortgagorPhone;

            //End List of New SQL parameters from MortgagorDAL.cs

            SqlParameter prmMortgagorInformationID = new SqlParameter ("@MortgagorInformationID", SqlDbType.Int);
            prmMortgagorInformationID.Value = Mortgagorobj.MortgagorInformationID;

            SqlParameter prmMortgageAccountNumber = new SqlParameter ("@MortgageAccountNumber", SqlDbType.Char);
            prmMortgageAccountNumber.Value = Mortgagorobj.MortgageAccountNumber;

            SqlParameter prmDefaultDate = new SqlParameter ("@DefaultDate", SqlDbType.SmallDateTime);
            prmDefaultDate.Value = Mortgagorobj.DefaultDate;
            //if (Mortgagorobj.DefaultDate == null)
            //{
            //    prmDefaultDate = new SqlParameter("@DefaultDate", DBNull.Value);
            //}
            //else
            //{
            //    prmDefaultDate = new SqlParameter("@DefaultDate", Mortgagorobj.DefaultDate);
            //}

            SqlParameter prmNoticeDate = new SqlParameter ("@NoticeDate", SqlDbType.SmallDateTime);
            prmNoticeDate.Value = Mortgagorobj.NoticeDate;

            //if (Mortgagorobj.NoticeDate == null)
            //{
            //    prmNoticeDate = new SqlParameter("@NoticeDate", Mortgagorobj.NoticeDate);
            //}
            //else
            //{
            //    prmNoticeDate = news SqlParameter("@NoticeDate", Mortgagorobj.NoticeDate);
            //}

            SqlParameter prmPenaltyDays = new SqlParameter ("@PenaltyDays", SqlDbType.Int);
            prmPenaltyDays.Value = Mortgagorobj.PenaltyDays;

            SqlParameter prmInitialFee = new SqlParameter ("@InitialFee", SqlDbType.Decimal);
            prmInitialFee.Value = Mortgagorobj.InitialFee;

            SqlParameter prmReleaseBankruptcyStayDate = new SqlParameter ("@ReleaseBankruptcyStayDate", SqlDbType.SmallDateTime);
            //prmReleaseBankruptcyStayDate.Value = Mortgagorobj.ReleaseBankruptcyStayDate;
            if (Mortgagorobj.ReleaseBankruptcyStayDate == null)
                {
                prmReleaseBankruptcyStayDate = new SqlParameter ("@ReleaseBankruptcyStayDate", DBNull.Value);

                }
            else
                {
                prmReleaseBankruptcyStayDate = new SqlParameter ("@ReleaseBankruptcyStayDate", Mortgagorobj.ReleaseBankruptcyStayDate);
                }

            //Parameter for ServicemanCivilReliefActDate 09/24/15 _obd

            SqlParameter prmServicemanCivilReliefActDate = new SqlParameter ("@ServicemanCivilReliefActDate", SqlDbType.SmallDateTime);
            if (Mortgagorobj.ServicemanCivilReliefActDate == null)
                {
                prmServicemanCivilReliefActDate = new SqlParameter ("@ServicemanCivilReliefActDate", DBNull.Value);
                }
            else
                {
                prmServicemanCivilReliefActDate = new SqlParameter ("@ServicemanCivilReliefActDate", Mortgagorobj.ServicemanCivilReliefActDate);
                }
            //_obd

            SqlParameter prmFirstLetterSentDate = new SqlParameter ("@FirstLetterSentDate", SqlDbType.SmallDateTime);
            // prmFirstLetterSentDate.Value = Mortgagorobj.FirstLetterSentDate;
            if (Mortgagorobj.FirstLetterSentDate == null)
                {
                prmFirstLetterSentDate = new SqlParameter ("@FirstLetterSentDate", DBNull.Value);

                }
            else
                {
                prmFirstLetterSentDate = new SqlParameter ("@FirstLetterSentDate", Mortgagorobj.FirstLetterSentDate);
                }

            SqlParameter prmSecondLetterSentDate = new SqlParameter ("@SecondLetterSentDate", SqlDbType.SmallDateTime);
            //prmSecondLetterSentDate.Value = Mortgagorobj.SecondLetterSentDate;
            if (Mortgagorobj.SecondLetterSentDate == null)
                {
                prmSecondLetterSentDate = new SqlParameter ("@SecondLetterSentDate", DBNull.Value);

                }
            else
                {
                prmSecondLetterSentDate = new SqlParameter ("@SecondLetterSentDate", Mortgagorobj.SecondLetterSentDate);
                }

            //PARAMETER ReturnedMail _Jaheda Meman 06/23/15
            SqlParameter prmReturnedMail = new SqlParameter ("@ReturnedMail", SqlDbType.Bit);
            prmReturnedMail.Value = Mortgagorobj.ReturnedMail;

            //PARAMETER for Returned Mail Date _obd 9/11/15 
            SqlParameter prmReturnedMailDate = new SqlParameter ("@ReturnedMailDate", SqlDbType.SmallDateTime);
            prmReturnedMailDate.Value = Mortgagorobj.ReturnedMailDate;
            if (Mortgagorobj.ReturnedMailDate == null)
                {
                prmReturnedMailDate = new SqlParameter ("@ReturnedMailDate", DBNull.Value);

                }
            else
                {
                prmReturnedMailDate = new SqlParameter ("@ReturnedMailDate", Mortgagorobj.ReturnedMailDate);
                }

            //PARAMETER for MortgagorCalledDate
            SqlParameter prmMortgagorCalledDate = new SqlParameter("@MortgagorCalledDate", SqlDbType.SmallDateTime);
            prmMortgagorCalledDate.Value = Mortgagorobj.MortgagorCalledDate;
            if (Mortgagorobj.MortgagorCalledDate == null)
            {
                prmMortgagorCalledDate = new SqlParameter("@MortgagorCalledDate", DBNull.Value);

            }
            else
            {
                prmMortgagorCalledDate = new SqlParameter("@MortgagorCalledDate", Mortgagorobj.MortgagorCalledDate);
            }


            // SqlParameter prmPenaltyFeeCalcDate = new SqlParameter("@PenaltyFeeCalcDate", SqlDbType.SmallDateTime);
            //// prmPenaltyFeeCalcDate.Value = Mortgagorobj.PenaltyFeeCalcDate;
            // if (Mortgagorobj.PenaltyFeeCalcDate == null)
            // {
            //     prmPenaltyFeeCalcDate = new SqlParameter("@PenaltyFeeCalcDate",   DBNull.Value);

            // }
            // else
            // {
            //     prmPenaltyFeeCalcDate = new SqlParameter("@PenaltyFeeCalcDate", Mortgagorobj.PenaltyFeeCalcDate);
            // }

            SqlParameter prmConfCallDeadlineDate = new SqlParameter ("@ConfCallDeadlineDate", SqlDbType.SmallDateTime);
            // prmConfCallDeadlineDate.Value = Mortgagorobj.ConfCallDeadlineDate;
            if (Mortgagorobj.ConfCallDeadlineDate == null)
                {
                prmConfCallDeadlineDate = new SqlParameter ("@ConfCallDeadlineDate", DBNull.Value);

                }
            else
                {
                prmConfCallDeadlineDate = new SqlParameter ("@ConfCallDeadlineDate", Mortgagorobj.ConfCallDeadlineDate);
                }

            //TO SAVE MEDIATION Notes DETAILS  PANEL 1
            //SqlParameter prmNotesID = new SqlParameter("@NotesID", SqlDbType.Int);
            //prmNotesID.Value = Mortgagorobj.NotesID;

            // TO SAVE MEDIATION DATES DETAILS  PANEL 2
            SqlParameter prmInitialContactDate = new SqlParameter ("@InitialContactDate", SqlDbType.SmallDateTime);

            //prmInitialContactDate.Value = Mortgagorobj.InitialContactDate;
            if (Mortgagorobj.InitialContactDate == null)
                {
                prmInitialContactDate = new SqlParameter ("@InitialContactDate", DBNull.Value);

                }
            else
                {
                prmInitialContactDate = new SqlParameter ("@InitialContactDate", Mortgagorobj.InitialContactDate);
                }

            SqlParameter prmPackageSentLenderDate = new SqlParameter ("@PackageSentLenderDate", Mortgagorobj.PackageSentLenderDate);
            if (Mortgagorobj.PackageSentLenderDate == null)
                {
                prmPackageSentLenderDate = new SqlParameter ("@PackageSentLenderDate", DBNull.Value);

                }
            else
                {
                prmPackageSentLenderDate = new SqlParameter ("@PackageSentLenderDate", Mortgagorobj.PackageSentLenderDate);
                }

            SqlParameter prmSchedConferenceDate = new SqlParameter ("@SchedConferenceDate", Mortgagorobj.SchedConferenceDate);
            if (Mortgagorobj.SchedConferenceDate == null)
                {
                prmSchedConferenceDate = new SqlParameter ("@SchedConferenceDate", DBNull.Value);

                }
            else
                {
                prmSchedConferenceDate = new SqlParameter ("@SchedConferenceDate", Mortgagorobj.SchedConferenceDate);
                }

            SqlParameter prmActualConferenceDate = new SqlParameter ("@ActualConferenceDate", Mortgagorobj.ActualConferenceDate);

            if (Mortgagorobj.ActualConferenceDate == null)
                {
                prmActualConferenceDate = new SqlParameter ("@ActualConferenceDate", DBNull.Value);

                }
            else
                {
                prmActualConferenceDate = new SqlParameter ("@ActualConferenceDate", Mortgagorobj.ActualConferenceDate);
                }

            SqlParameter prmConfResolveDeadlineDate = new SqlParameter ("@ConfResolveDeadlineDate", Mortgagorobj.ConfResolveDeadlineDate);

            if (Mortgagorobj.ConfResolveDeadlineDate == null)
                {
                prmConfResolveDeadlineDate = new SqlParameter ("@ConfResolveDeadlineDate", DBNull.Value);

                }
            else
                {
                prmConfResolveDeadlineDate = new SqlParameter ("@ConfResolveDeadlineDate", Mortgagorobj.ConfResolveDeadlineDate);
                }

            SqlParameter prmExtensionRequestDate = new SqlParameter ("@ExtensionRequestDate", Mortgagorobj.ExtensionRequestDate);

            if (Mortgagorobj.ExtensionRequestDate == null)
                {
                prmExtensionRequestDate = new SqlParameter ("@ExtensionRequestDate", DBNull.Value);

                }
            else
                {
                prmExtensionRequestDate = new SqlParameter ("@ExtensionRequestDate", Mortgagorobj.ExtensionRequestDate);
                }

            SqlParameter prmRequestExtensionByDate = new SqlParameter ("@RequestExtensionByDate", Mortgagorobj.RequestExtensionByDate);

            if (Mortgagorobj.RequestExtensionByDate == null)
                {
                prmRequestExtensionByDate = new SqlParameter ("@RequestExtensionByDate", DBNull.Value);
                }
            else
                {
                prmRequestExtensionByDate = new SqlParameter ("@RequestExtensionByDate", Mortgagorobj.RequestExtensionByDate);
                }

            SqlParameter prmExtensionExpirationDate = new SqlParameter ("@ExtensionExpirationDate", Mortgagorobj.RequestExtensionByDate);
            if (Mortgagorobj.ExtensionExpirationDate == null)
                {
                prmExtensionExpirationDate = new SqlParameter ("@ExtensionExpirationDate", DBNull.Value);
                }
            else
                {
                prmExtensionExpirationDate = new SqlParameter ("@ExtensionExpirationDate", Mortgagorobj.ExtensionExpirationDate);
                }

            SqlParameter prmCounterOfferRejectedBorrower = new SqlParameter ("@CounterOfferRejectedBorrower", SqlDbType.TinyInt);
            prmCounterOfferRejectedBorrower.Value = Mortgagorobj.CounterOfferRejectedBorrower;

            SqlParameter prmWO_FinancialBenefitBorrower = new SqlParameter ("@WO_FinancialBenefitBorrower", SqlDbType.TinyInt);
            prmWO_FinancialBenefitBorrower.Value = Mortgagorobj.WO_FinancialBenefitBorrower;

            SqlParameter prmWO_AgreementInFile = new SqlParameter ("@WO_AgreementInFile", SqlDbType.TinyInt);
            prmWO_AgreementInFile.Value = Mortgagorobj.WO_AgreementInFile;

            SqlParameter prmIncome = new SqlParameter ("@Income", SqlDbType.Decimal);
            if (Mortgagorobj.Income == null)
                {
                prmIncome = new SqlParameter ("@Income", DBNull.Value);
                }
            else
                {
                prmIncome = new SqlParameter ("@Income", Mortgagorobj.Income);
                }

            SqlParameter prmMedInvoiceLetterDate = new SqlParameter ("@MedInvoiceLetterDate", Mortgagorobj.MedInvoiceLetterDate);
            if (Mortgagorobj.MedInvoiceLetterDate == null)
                {
                prmMedInvoiceLetterDate = new SqlParameter ("@MedInvoiceLetterDate", DBNull.Value);
                }
            else
                {
                prmMedInvoiceLetterDate = new SqlParameter ("@MedInvoiceLetterDate", Mortgagorobj.MedInvoiceLetterDate);
                }

            SqlParameter prmConfResolutionDate = new SqlParameter ("@ConfResolutionDate", Mortgagorobj.MedInvoiceLetterDate);
            if (Mortgagorobj.ConfResolutionDate == null)
                {
                prmConfResolutionDate = new SqlParameter ("@ConfResolutionDate", DBNull.Value);
                }
            else
                {
                prmConfResolutionDate = new SqlParameter ("@ConfResolutionDate", Mortgagorobj.ConfResolutionDate);
                }

            SqlParameter prmCoordinatorID = new SqlParameter ("@CoordinatorID", SqlDbType.SmallInt);
            if (Mortgagorobj.CoordinatorID == null)
                {
                prmCoordinatorID = new SqlParameter ("CoordinatorID", DBNull.Value);
                }
            else
                {

                prmCoordinatorID = new SqlParameter ("CoordinatorID", Mortgagorobj.CoordinatorID);
                }

            SqlParameter prmCounselorID = new SqlParameter ("@CounselorID", SqlDbType.SmallInt);
            if (Mortgagorobj.CounselorID == null)
                {

                prmCounselorID = new SqlParameter ("CounselorID", DBNull.Value);
                }
            else
                {
                prmCounselorID = new SqlParameter ("CounselorID", Mortgagorobj.CounselorID);
                }

            SqlParameter prmConferenceResultID = new SqlParameter ("@ConferenceResultID", SqlDbType.SmallInt);
            if (Mortgagorobj.ConferenceResultID == null)
                {
                prmConferenceResultID = new SqlParameter ("ConferenceResultID", DBNull.Value);
                }
            else
                {
                prmConferenceResultID = new SqlParameter ("ConferenceResultID", Mortgagorobj.ConferenceResultID);
                }

            //prmConferenceResultID.Value = Mortgagorobj.ConferenceResultID;
            SqlParameter prmMediationInvoiceID = new SqlParameter ("@MediationInvoiceID", SqlDbType.SmallInt);
            if (Mortgagorobj.MediationInvoiceID == null)
                {
                prmMediationInvoiceID = new SqlParameter ("@MediationInvoiceID", DBNull.Value);
                }
            else
                {
                prmMediationInvoiceID = new SqlParameter ("MediationInvoiceID", Mortgagorobj.MediationInvoiceID);
                }

            //TO SAVE MEDIATION  DETAILS  PANEL 3

            SqlParameter prmCertificateNoticeID = new SqlParameter ("@CertificateNoticeID", SqlDbType.SmallInt);
            if (Mortgagorobj.CertificateNoticeID == null)
                {
                prmCertificateNoticeID = new SqlParameter ("@CertificateNoticeID", DBNull.Value);
                }
            else
                {
                prmCertificateNoticeID = new SqlParameter ("CertificateNoticeID", Mortgagorobj.CertificateNoticeID);
                }

            //SqlParameter prmCertificateNoticeReasonID = new SqlParameter("@CertificateNoticeReasonID", SqlDbType.SmallInt);
            //if (Mortgagorobj.CertificateNoticeReasonID == null)
            //{
            //    prmCertificateNoticeReasonID = new SqlParameter("@CertificateNoticeReasonID", DBNull.Value);
            //}
            //else
            //{
            //    prmCertificateNoticeReasonID = new SqlParameter("CertificateNoticeReasonID", Mortgagorobj.CertificateNoticeReasonID);
            //}

            SqlParameter prmPenaltyAmount = new SqlParameter ("@PenaltyAmount", SqlDbType.Decimal);
            if (Mortgagorobj.PenaltyAmount == null)
                {
                prmPenaltyAmount = new SqlParameter ("@PenaltyAmount", DBNull.Value);
                }
            else
                {
                prmPenaltyAmount = new SqlParameter ("@PenaltyAmount", Mortgagorobj.PenaltyAmount);
                }

            SqlParameter prmMediationFeeAmount = new SqlParameter ("@MediationFeeAmount", SqlDbType.Decimal);
            if (Mortgagorobj.MediationFeeAmount == null)
                {
                prmMediationFeeAmount = new SqlParameter ("@MediationFeeAmount", DBNull.Value);
                }
            else
                {
                prmMediationFeeAmount = new SqlParameter ("@MediationFeeAmount", Mortgagorobj.MediationFeeAmount);
                }

            SqlParameter prmCertificateNoticePrintDate = new SqlParameter ("@CertificateNoticePrintDate", Mortgagorobj.CertificateNoticePrintDate);
            if (Mortgagorobj.CertificateNoticePrintDate == null)
                {
                prmCertificateNoticePrintDate = new SqlParameter ("@CertificateNoticePrintDate", DBNull.Value);
                }
            else
                {
                prmCertificateNoticePrintDate = new SqlParameter ("@CertificateNoticePrintDate", Mortgagorobj.CertificateNoticePrintDate);
                }

            SqlParameter prmCertificateLetterReprintDate = new SqlParameter ("@CertificateLetterReprintDate", Mortgagorobj.CertificateNoticePrintDate);
            if (Mortgagorobj.CertificateLetterReprintDate == null)
                {
                prmCertificateLetterReprintDate = new SqlParameter ("@CertificateLetterReprintDate", DBNull.Value);
                }
            else
                {
                prmCertificateLetterReprintDate = new SqlParameter ("@CertificateLetterReprintDate", Mortgagorobj.CertificateLetterReprintDate);
                }

            //PARAMETER DuplicateCertificateFeePaid _Jaheda Meman 06/24/15
            SqlParameter prmDuplicateCertificateFeePaid = new SqlParameter ("@DuplicateCertificateFeePaid", SqlDbType.Bit);
            prmDuplicateCertificateFeePaid.Value = Mortgagorobj.DuplicateCertificateFeePaid;

            SqlParameter prmPenaltyPaidDate = new SqlParameter ("@PenaltyPaidDate", Mortgagorobj.PenaltyPaidDate);
            if (Mortgagorobj.PenaltyPaidDate == null)
                {
                prmPenaltyPaidDate = new SqlParameter ("@PenaltyPaidDate", DBNull.Value);
                }
            else
                {
                prmPenaltyPaidDate = new SqlParameter ("@PenaltyPaidDate", Mortgagorobj.PenaltyPaidDate);
                }

            //PARAMETER PENALTY FEE WAIVED _obd 3/3/15
            SqlParameter prmPenaltyFeeWaived = new SqlParameter ("@PenaltyFeeWaived", SqlDbType.Bit);
            prmPenaltyFeeWaived.Value = Mortgagorobj.PenaltyFeeWaived;

            SqlParameter prmMediationFeeDate = new SqlParameter ("@MediationFeeDate", Mortgagorobj.MediationFeeDate);
            if (Mortgagorobj.MediationFeeDate == null)
                {
                prmMediationFeeDate = new SqlParameter ("@MediationFeeDate", DBNull.Value);
                }
            else
                {
                prmMediationFeeDate = new SqlParameter ("@MediationFeeDate", Mortgagorobj.MediationFeeDate);
                }

            SqlParameter prmCertificateLenderName = new SqlParameter ("@CertificateLenderName", SqlDbType.VarChar);
            prmCertificateLenderName.Value = Mortgagorobj.CertificateLenderName;

            //TO SAVE MEDIATION CONTACT DETAILS  PANEL 4
            SqlParameter prmLenderContactID = new SqlParameter ("@LenderContactID", SqlDbType.Int);
            if (Mortgagorobj.LenderContactID == 0)
                {
                prmLenderContactID = new SqlParameter ("@LenderContactID", DBNull.Value);
                }
            else
                {
                prmLenderContactID = new SqlParameter ("@LenderContactID", Mortgagorobj.LenderContactID);
                }

            SqlParameter prmMediationContactID = new SqlParameter ("@MediationContactID", SqlDbType.Int);
            if (Mortgagorobj.MediationContactID == 0)
                {
                prmMediationContactID = new SqlParameter ("@MediationContactID", DBNull.Value);
                }
            else
                {
                prmMediationContactID = new SqlParameter ("@MediationContactID", Mortgagorobj.MediationContactID);
                }

            SqlParameter prmServicerContactID = new SqlParameter ("@ServicerContactID", SqlDbType.Int);
            if (Mortgagorobj.ServicerContactID == 0)
                {
                prmServicerContactID = new SqlParameter ("@ServicerContactID", DBNull.Value);
                }
            else
                {
                prmServicerContactID = new SqlParameter ("@ServicerContactID", Mortgagorobj.ServicerContactID);
                }

            SqlParameter prmCertificateLetterContactID = new SqlParameter ("@CertificateLetterContactID", SqlDbType.Int);
            if (Mortgagorobj.CertificateLetterContactID == 0)
                {
                prmCertificateLetterContactID = new SqlParameter ("@CertificateLetterContactID", DBNull.Value);
                }
            else
                {
                prmCertificateLetterContactID = new SqlParameter ("@CertificateLetterContactID", Mortgagorobj.CertificateLetterContactID);
                }

            SqlParameter prmAttorneyContactID = new SqlParameter ("@AttorneyContactID", SqlDbType.Int);
            if (Mortgagorobj.AttorneyContactID == 0)
                {
                prmAttorneyContactID = new SqlParameter ("@AttorneyContactID", DBNull.Value);
                }
            else
                {
                prmAttorneyContactID = new SqlParameter ("@AttorneyContactID", Mortgagorobj.AttorneyContactID);
                }

            //5/11/15 _JahedaMeman uncommented to pass the windows authenticated user. Need to uncomment it in the SQL SP as well
            SqlParameter prmUserID = new SqlParameter ("@UserID", SqlDbType.VarChar);
            prmUserID.Value = Mortgagorobj.UserID;

            SqlParameter prmEdit = new SqlParameter ("@Edit", SqlDbType.Int);
            prmEdit.Value = EditMode;

            SqlParameter prmMediationCaseInformationInputID = new SqlParameter ("@MediationCaseInformationInputID", SqlDbType.Int);
            prmMediationCaseInformationInputID.Value = Mortgagorobj.MediationCaseInformationID;

            //Must be last parameter
            SqlParameter prmMediationCaseInformationID = new SqlParameter ("@MediationCaseInformationID", SqlDbType.Int);
            prmMediationCaseInformationID.Direction = ParameterDirection.Output;

            return DataAccess.Execute ("uspAddMediationCaseDetails",
              prmFirstName, prmMiddleInitial, prmLastName, prmSuffix, prmAlias, prmPrintViewBorrower, prmPrintViewCo_Borrower, prmPrintViewName_3,
              prmPrintViewName_4, prmAddress_1, prmAddress_2, prmCity, prmZipCode, prmState, prmMortgagorPhone, prmMortgagorCalledDate, prmMortgagorInformationID, prmMortgageAccountNumber,
              prmDefaultDate, prmNoticeDate, prmPenaltyDays, prmInitialFee, prmReleaseBankruptcyStayDate, prmServicemanCivilReliefActDate, prmFirstLetterSentDate,
              prmSecondLetterSentDate, prmReturnedMail, prmReturnedMailDate, prmConfCallDeadlineDate, prmInitialContactDate, prmPackageSentLenderDate,
              prmSchedConferenceDate, prmActualConferenceDate, prmConfResolveDeadlineDate, prmExtensionRequestDate, prmRequestExtensionByDate,
              prmExtensionExpirationDate, prmConfResolutionDate, prmCounterOfferRejectedBorrower, prmWO_FinancialBenefitBorrower, prmWO_AgreementInFile,
              prmCoordinatorID, prmCounselorID, prmConferenceResultID, prmMediationInvoiceID, prmMedInvoiceLetterDate, prmIncome, prmCertificateNoticeID,
              prmPenaltyAmount, prmPenaltyPaidDate, prmPenaltyFeeWaived, prmMediationFeeAmount, prmCertificateNoticePrintDate, prmCertificateLetterReprintDate,
              prmDuplicateCertificateFeePaid, prmMediationFeeDate, prmCertificateLenderName, prmAttorneyContactID, prmCertificateLetterContactID,
              prmMediationContactID, prmLenderContactID, prmServicerContactID, prmUserID, prmEdit, prmMediationCaseInformationInputID, prmMediationCaseInformationID);
            }
        public DataTable GetMediationDataByMortgagorID (int MortgagorInformationID)
            {
            SqlParameter prmMortgagorInformationID = new SqlParameter ("@MortgagorInformationID", SqlDbType.Int);
            prmMortgagorInformationID.Value = MortgagorInformationID;

            return DataAccess.GetFromDataTable ("uspGetMediationDataByMortgagorID", prmMortgagorInformationID);
            }
        /// <summary>
        /// To search by ID
        /// </summary>
        /// <param name="MediationCaseId"></param>
        /// <returns></returns>
        public IDataReader GetDataByMediationID (int MediationCaseId)
            {
            SqlParameter prmMediationCaseID = new SqlParameter ("@MediationCaseInformationID", SqlDbType.Int);
            prmMediationCaseID.Value = MediationCaseId;

            return DataAccess.GetFromReader ("uspGetMediationCasebyID", prmMediationCaseID);
            }
        /// <summary>
        /// for the first letter in search . We are not using now. 
        /// </summary>
        /// <param name="FromNoticeDate"></param>
        /// <param name="ToNoticeDate"></param>
        /// <returns></returns>
        public DataTable GetAllNoticebyNoticeDate (DateTime? FromNoticeDate, DateTime? ToNoticeDate)
            {
            SqlParameter prmFromNoticeDate = new SqlParameter ("@FromNoticeDate", SqlDbType.DateTime);
            prmFromNoticeDate.Value = FromNoticeDate;

            SqlParameter prmToNoticeDate = new SqlParameter ("@ToNoticeDate", SqlDbType.DateTime);
            prmToNoticeDate.Value = ToNoticeDate;
            return DataAccess.GetFromDataTable ("uspGetMediationCaseByNoticeDate", prmFromNoticeDate, prmToNoticeDate);
            }
        /// <summary>
        /// After clear the grid from First letter specific task, We update firstlettersent date in database by below method
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public int UpdateMediationCaseFirstLetterDate (string array)
        {
            SqlParameter prmMediationCaseIdList = new SqlParameter ("@MediationCaseIdList", SqlDbType.VarChar);
            prmMediationCaseIdList.Value = array;
            return DataAccess.Execute ("uspUpdateMediationCaseFirstLetterDate", prmMediationCaseIdList);
        }

        public int UpdateMediationCasePenaltyPaymentDate(string array)
        {
            SqlParameter prmMediationCaseIdList = new SqlParameter("@MediationCaseIdList", SqlDbType.VarChar);
            prmMediationCaseIdList.Value = array;
            return DataAccess.Execute("uspUpdatePenaltyPaymentPrintDate", prmMediationCaseIdList);
        }

        /// <summary>
        /// After clear the grid from Second letter specific task, We update Secondlettersent date in database by below method
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public int UpdateMediationCaseSecondLetterDate (string array)
        {
            SqlParameter prmMediationCaseIdList = new SqlParameter ("@MediationCaseIdList", SqlDbType.VarChar);
            prmMediationCaseIdList.Value = array;
            return DataAccess.Execute ("uspUpdateMediationCaseSecondLetterDate", prmMediationCaseIdList);
        }
        /// <summary>
        /// After clear the grid from Second letter specific task, We update Secondlettersent date in database by below method
        /// Updated 05/12/2015 by Jaheda Meman -added CoordinatorID 
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public int UpdateCertificateNoticePrintDate (string array)
        {
            SqlParameter prmMediationCaseIdList = new SqlParameter ("@MediationCaseIdList", SqlDbType.VarChar);
            prmMediationCaseIdList.Value = array;
            //SqlParameter prmCoordinatorID = new SqlParameter("@CoordinatorID", SqlDbType.Int);
            //prmCoordinatorID.Value = CoordinatorID;
            ////SqlParameter prmCertificateNoticeID = new SqlParameter("@CertificateNoticeID", SqlDbType.Int);
            //prmCertificateNoticeID.Value = CertificateNoticeID;

            return DataAccess.Execute ("uspUpdateCertificateNoticePrintDate", prmMediationCaseIdList);
        }
        public int UpdateCoordinatorID (string array, int CoordinatorID)
            {
            SqlParameter prmMediationCaseInformationID = new SqlParameter ("@MediationCaseIdList", SqlDbType.VarChar);
            prmMediationCaseInformationID.Value = array;

            SqlParameter prmCoordinatorID = new SqlParameter ("@CoordinatorID", SqlDbType.Int);
            prmCoordinatorID.Value = CoordinatorID;
            //SqlParameter prmCertificateNoticeID = new SqlParameter("@CertificateNoticeID", SqlDbType.Int);
            //prmCertificateNoticeID.Value = CertificateNoticeID;

            return DataAccess.Execute ("uspUpdateCoordinatorID", prmMediationCaseInformationID, prmCoordinatorID);
            }

        //public int UpdateCoordinatorID(int MediationCaseInformationID, int CoordinatorID)
        //{
        //    SqlParameter prmMediationCaseInformationID = new SqlParameter("@MediationCaseInformationID", SqlDbType.Int);
        //    prmMediationCaseInformationID.Value = MediationCaseInformationID;

        //    SqlParameter prmCoordinatorID = new SqlParameter("@CoordinatorID", SqlDbType.Int);
        //    prmCoordinatorID.Value = CoordinatorID;
        //    //SqlParameter prmCertificateNoticeID = new SqlParameter("@CertificateNoticeID", SqlDbType.Int);
        //    //prmCertificateNoticeID.Value = CertificateNoticeID;

        //    return DataAccess.Execute("uspUpdateCoordinatorID", prmMediationCaseInformationID, prmCoordinatorID);
        //}
        // public int UpdateCertificateNoticeReason(int CertificateNoticeID)
        // {

        //SqlParameter prmCertificateNoticeID = new SqlParameter("@CertificateNoticeID", SqlDbType.Int);
        //prmCertificateNoticeID.Value = CertificateNoticeID;
        //return DataAccess.Execute("uspUpdateCertificateNoticeReason", prmCertificateNoticeID);
        // }
        /// <summary>
        /// To fill the data which does not have first letter sent date in the specific task
        /// </summary>
        /// <param name="CertificateNoticeID"></param>
        /// <returns></returns>
        public DataTable GetMediationCertificateNoticeDetails (int CertificateNoticeID)

            {
            SqlParameter prmCertificateNoticeID = new SqlParameter ("@CertificateNoticeID", SqlDbType.Int);
            prmCertificateNoticeID.Value = CertificateNoticeID;
            return DataAccess.GetFromDataTable ("uspGetMediationCaseByNoticeDate", prmCertificateNoticeID);


            }
        /// <summary>
        /// To print First letter . We made method to fill out the data in grid to print first letter which is first sent letter date is null.
        /// You will se first letter sent  is in the specific task.
        /// </summary>
        /// <param name="MediationCaseInformationID"></param>
        /// <returns></returns>
        public DataTable GetFirstLetterPrintDetails (int MediationCaseInformationID)

            {
            SqlParameter prmMediationCaseInformationID = new SqlParameter ("@MediationCaseInformationID", SqlDbType.Int);
            prmMediationCaseInformationID.Value = MediationCaseInformationID;
            //SqlParameter prmCoordinatorID = new SqlParameter("@CoordinatorID", SqlDbType.Int);
            //prmCoordinatorID.Value = CoordinatorID;
            return DataAccess.GetFromDataTable ("uspPrintFirstLetter", prmMediationCaseInformationID);

            }
        //Added by jaheda meman 05/20/2015 to print noresponse certificate from specific task using drop downbox
        public DataTable GetNoResponseCertificateDetails (string MediationCaseIdList)
        {
            SqlParameter prmMediationCaseInformationIDList = new SqlParameter ("@MediationCaseIdList", SqlDbType.VarChar);
            prmMediationCaseInformationIDList.Value = MediationCaseIdList;
            return DataAccess.GetFromDataTable ("uspPrintNoResponseBatch", prmMediationCaseInformationIDList);
        }
        /// <summary>
        /// To print no response from mediation case. Not specific task.
        /// </summary>
        /// <param name="MediationCaseInformationID"></param>
        /// <returns></returns>
        public DataTable GetNoResponsePrintDetails (int MediationCaseInformationID)
        {
            SqlParameter prmMediationCaseInformationID = new SqlParameter ("@MediationCaseInformationID", SqlDbType.Int);
            prmMediationCaseInformationID.Value = MediationCaseInformationID;
            return DataAccess.GetFromDataTable ("uspPrintNoResponse", prmMediationCaseInformationID);
        }
        public DataTable GetSecondLetterPrintDetails (int MediationCaseInformationID)
        {
            SqlParameter prmMediationCaseInformationID = new SqlParameter ("@MediationCaseInformationID", SqlDbType.Int);
            prmMediationCaseInformationID.Value = MediationCaseInformationID;
            return DataAccess.GetFromDataTable ("uspPrintSecondLetter", prmMediationCaseInformationID);
        }

        public DataTable GetPenaltyPaymentLetterPrintDetails(int MediationCaseInformationID)
        {
            SqlParameter prmMediationCaseInformationID = new SqlParameter("@MediationCaseInformationID", SqlDbType.Int);
            prmMediationCaseInformationID.Value = MediationCaseInformationID;
            return DataAccess.GetFromDataTable("uspPrintPenaltyPaymentNotReceived", prmMediationCaseInformationID); //uspPrintPenaltyPaymentLetter
        }

        /// <summary>
        /// To print No response Certificate . We made method to fill out the data in grid to print  No response Certificate  YOu can issue after 60 days of Mediation case date  date is null.
        /// You will see No response Certificate  is in the specific task.
        /// </summary>
        /// <param name="MediationCaseInformationID"></param>
        /// <returns></returns>
        //public DataTable GetNoResponsePrintDetails(int MediationCaseInformationID)
        //{
        //    //SqlParameter prmMediationCaseInformationID = new SqlParameter("@MediationCaseInformationID", SqlDbType.Int);
        //    //prmMediationCaseInformationID.Value = MediationCaseInformationID;
        //    //SqlParameter prmCoordinatorID = new SqlParameter("@CoordinatorID", SqlDbType.Int);
        //    //prmCoordinatorID.Value = CoordinatorID;
        //    return DataAccess.GetFromDataTable("uspPrintNoResponse");
        //   // return DataAccess.GetFromDataTable("uspPrintNoResponse", prmMediationCaseInformationID, prmCoordinatorID);

        //}

        /// <summary>
        /// To print No response Certificate . We made method to fill out the data in grid to print  No response Certificate  YOu can issue after 60 days of Mediation case date  date is null.
        /// You will see No response Certificate  is in the specific task.
        /// </summary>
        /// <param name="MediationCaseInformationID"></param>
        /// <returns></returns>
        public DataTable GetAllCertificatesDetails (int MediationCaseInformationID, int ReportID)
            {
            SqlParameter prmMediationCaseInformationID = new SqlParameter ("@MediationCaseInformationID", SqlDbType.Int);
            prmMediationCaseInformationID.Value = MediationCaseInformationID;
            SqlParameter prmReportID = new SqlParameter ("@ReportID", SqlDbType.Int);
            prmReportID.Value = ReportID;
            return DataAccess.GetFromDataTable ("uspPrinAllCertificates", prmMediationCaseInformationID, prmReportID);

            }
        /// <summary>
        /// Print 14Day letter
        /// </summary>
        /// <param name="MediationCaseInformationID"></param>
        /// <returns></returns>
        public DataTable Get14DayLetterPrintDetails (int MediationCaseInformationID)
            {
            SqlParameter prmMediationCaseInformationID = new SqlParameter ("@MediationCaseInformationID", SqlDbType.Int);
            prmMediationCaseInformationID.Value = MediationCaseInformationID;
            return DataAccess.GetFromDataTable ("uspPrint14DayLetter", prmMediationCaseInformationID);
            }
        /// <summary>
        /// Update 14Day letter
        /// </summary>
        /// <param name="MediationCaseInformationID"></param>
        /// <returns></returns>
        public int Update14DayLetterPrintDate (int MediationCaseInformationID)
            {
            SqlParameter prmMediationCaseInformationID = new SqlParameter ("@MediationCaseInformationID", SqlDbType.Int);
            prmMediationCaseInformationID.Value = @MediationCaseInformationID;
            //SqlParameter prmRecordsAffected = new SqlParameter("@RecordsAffected", SqlDbType.Int);
            //prmRecordsAffected.Value = @RecordsAffected;
            return DataAccess.Execute ("uspUpdate14DayLetterPrintDate", prmMediationCaseInformationID);
            }

        //11/04/2015 _obd get workout invoice
        public DataTable GetWorkoutInvoicePrintDetails (int MediationCaseInformationID)
            {
            SqlParameter prmCaseID = new SqlParameter ("@caseID", SqlDbType.Int);
            prmCaseID.Value = MediationCaseInformationID;
            return DataAccess.GetFromDataTable ("uspMediation2014WorkoutInvoice", prmCaseID);
            }


        }

    }