using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Common;
using System.Configuration;


/// <summary>
/// Summary description for MortgagorDAL
/// </summary>
namespace DAL
{
    public class MortgagorDAL
    {
        public MortgagorDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region Class Varibles

        ///<summary>this is tempraory MortgagorInformationInputID. You do not see in database</summary>
        protected int _MortgagorInformationInputID;
        ///<summary>MortgagorInformationID</summary>
        protected int _MortgagorInformationID;
         //04/27/15 _Jaheda meman updated. 
        ///<summary>EstateOf</summary>
        ///protected int _EstateOf;
        /// -- 04/27/15 _Jaheda meman added new. 
        ///<summary>PrintViewBorrower</summary>
        //----05112016----
        //protected string _PrintViewBorrower;
        //----05112016----
        //Updated by Jaheda Meman 04/30/15
        /////<summary>Prefix</summary>
        //protected string _Prefix;
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
       ///<summary>RaceID</summary>
        protected int _RaceID;
        ///<summary>hispanic</summary>
        protected int _Hispanic;
        ///<summary>Email</summary>
        protected string _Email;
        ///<summary>Gender</summary>
        protected string _Gender;
        /// -- 04/27/15 _Jaheda meman added new. 
        /// 
        //----05112016----
        ///<summary>PrintViewCo_Borrower</summary>
        //protected string _PrintViewCo_Borrower;
        ///<summary>Prefix</summary>
        //protected string _Co_Prefix;
        /////<summary>Co_FirstName</summary>
        //protected string _Co_FirstName;
        ///<summary>Co_MiddleInitial</summary>
        //protected string _Co_MiddleInitial;
        ///<summary>Co_LastName</summary>
        //protected string _Co_LastName;
        ///<summary>Co_Suffix</summary>
        //protected string _Co_Suffix;
        ///<summary>Co_Alias</summary>
        //protected string _Co_Alias;
        ///<summary>Co_Phone</summary>
        //protected string _Co_Phone;
        //----05112016----
        ///<summary>PrimaryPhone</summary>
        protected string _PrimaryPhone;
        ///<summary>CellPhone</summary>
        protected string _CellPhone;
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
        ///<summary>CensusTract</summary>
        protected string _CensusTract;
        /// -- 04/27/15 _Jaheda meman added new.
        ///<summaryPrintViewName_3</summary>
        //protected string _PrintViewName_3;
        ///<summaryPrintViewName_4</summary>
        //protected string _PrintViewName_4;
        ///<summaryUserID</summary>
        protected string _UserID;
        ///<summaryCreateDate</summary>
        protected DateTime _CreateDate;

        #endregion

        #region Properties -Get and Set Accessor
        /// <summary>
        ///  MortgagorInformationInputID is temporary  varible. It is not in Database.
        /// </summary>
        public int MortgagorInformationInputID
        {
            get { return MortgagorInformationInputID; }
            set { _MortgagorInformationInputID = value; }
        }
        public int MortgagorInformationID
        {
            get { return _MortgagorInformationID; }
            set { _MortgagorInformationID = value; }
        }
       
        //public int EstateOf
        //{
        //    get { return _EstateOf; }
        //    set { _EstateOf = value; }
        //}
      
        //public String Prefix
        //{
        //    get { return _Prefix; }
        //    set { _Prefix = value; }
        //}

            //----05112016----
        //public String PrintViewBorrower
        //{
        //    get { return _PrintViewBorrower; }
        //    set { _PrintViewBorrower = value; }
        //}
        //----05112016----
        public String FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }
        public String MiddleInitial
        {
            get { return _MiddleInitial; }
            set { _MiddleInitial = value; }
        }
        public String LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }
        public String Suffix
        {
            get { return _Suffix; }
            set { _Suffix = value; }
        }
        public String Alias
        {
            get { return _Alias; }
            set { _Alias = value; }
        }
        public int RaceID
        {
            get { return _RaceID; }
            set { _RaceID = value; }
        }
        public int Hispanic
        {
            get { return _Hispanic; }
            set { _Hispanic = value; }
        }
        public String Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public String Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        //----05112016----
        //public String PrintViewCo_Borrower
        //{
        //    get { return _PrintViewCo_Borrower; }
        //    set { _PrintViewCo_Borrower = value; }
        //}
        //public String Co_Prefix
        //{
        //    get { return _Co_Prefix; }
        //    set { _Co_Prefix = value; }
        //}
        //public String Co_FirstName
        //{
        //    get { return _Co_FirstName; }
        //    set { _Co_FirstName = value; }
        //}
        //public String Co_MiddleInitial
        //{
        //    get { return _Co_MiddleInitial; }
        //    set { _Co_MiddleInitial = value; }
        //}
        //public String Co_LastName
        //{
        //    get { return _Co_LastName; }
        //    set { _Co_LastName = value; }
        //}
        //public String Co_Suffix
        //{
        //    get { return _Co_Suffix; }
        //    set { _Co_Suffix = value; }
        //}
        //public String Co_Alias
        //{
        //    get { return _Co_Alias; }
        //    set { _Co_Alias = value; }
        //}
        //public String Co_Phone
        //{
        //    get { return _Co_Phone; }
        //    set { _Co_Phone = value; }
        //} ----05112016----
        public String PrimaryPhone
        {
            get { return _PrimaryPhone; }
            set { _PrimaryPhone = value; }
        }
        public String CellPhone
        {
            get { return _CellPhone; }
            set { _CellPhone = value; }
        }
        public String Address_1
        {
            get { return _Address_1; }
            set { _Address_1 = value; }
        }
        public String Address_2
        {
            get { return _Address_2; }
            set { _Address_2 = value; }
        }
        public String City
        {
            get { return _City; }
            set { _City = value; }
        }
        public String ZipCode
        {
            get { return _ZipCode; }
            set { _ZipCode = value; }
        }
        public String State
        {
            get { return _State; }
            set { _State = value; }
        }
        public String CensusTract
        {
            get { return _CensusTract; }
            set { _CensusTract = value; }
        }
        //4/27/15 _Jaheda Meman added new field.

            //----05112016----
        //public String PrintViewName_3
        //{
        //    get { return _PrintViewName_3; }
        //    set { _PrintViewName_3 = value; }
        //}
        //public String PrintViewName_4
        //{
        //    get { return _PrintViewName_4; }
        //    set { _PrintViewName_4 = value; }
        //} ----05112016----
        public String UserID
        {
            //3/10/15 _obd. updated to capture the windows authenticated user. 
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
            set { _UserID = value; }
        }
        //4/27/15 _Jaheda Meman. updated to capture the windows authenticated user. 
        //public String UserID
        //{
        //    get { return _UserID; }
        //    set { _UserID = value; }
        //}
        public DateTime CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }
        #endregion
        #region Function
        /// <summary>
        /// Add Mortgagor Details
        /// </summary>
        /// <returns></returns>
        public int AddMortgagorDetails(MortgagorDAL Mortgagorobj,int EditMode)
        {

            //SqlParameter prmEstateOf = new SqlParameter("@EstateOf", SqlDbType.TinyInt);
            //prmEstateOf.Value = Mortgagorobj.EstateOf;

            //SqlParameter prmPrintViewBorrower = new SqlParameter("@PrintViewBorrower", SqlDbType.VarChar); 05112016
            //prmPrintViewBorrower.Value = Mortgagorobj.PrintViewBorrower; 05112016
            
            //SqlParameter prmPrefix = new SqlParameter("@Prefix", SqlDbType.VarChar);
            //prmPrefix.Value = Mortgagorobj.Prefix;

            SqlParameter prmFirstName = new SqlParameter("@FirstName", SqlDbType.VarChar);
            prmFirstName.Value = Mortgagorobj.FirstName;

            SqlParameter prmMiddleInitial = new SqlParameter("@MiddleInitial", SqlDbType.VarChar);
            prmMiddleInitial.Value = Mortgagorobj.MiddleInitial;

            SqlParameter prmLastName = new SqlParameter("@LastName", SqlDbType.VarChar);
            prmLastName.Value = Mortgagorobj.LastName;

            SqlParameter prmSuffix = new SqlParameter("@Suffix", SqlDbType.VarChar);
            prmSuffix.Value = Mortgagorobj.Suffix;

            SqlParameter prmAlias=new SqlParameter("@Alias",SqlDbType.VarChar);
            prmAlias.Value=Mortgagorobj.Alias;

            SqlParameter prmRaceID = new SqlParameter("@RaceID", SqlDbType.Int);
            prmRaceID.Value = Mortgagorobj.RaceID;

            SqlParameter prmHispanic = new SqlParameter("@Hispanic", SqlDbType.TinyInt);
            prmHispanic.Value = Mortgagorobj.Hispanic;

            SqlParameter prmEmail = new SqlParameter("@Email", SqlDbType.VarChar);
            prmEmail.Value = Mortgagorobj.Email;

            SqlParameter prmGender = new SqlParameter("@Gender", SqlDbType.Char);
            prmGender.Value = Mortgagorobj.Gender;

            //SqlParameter prmPrintViewCo_Borrower = new SqlParameter("@PrintViewCo_Borrower", SqlDbType.VarChar);05112016
            //prmPrintViewCo_Borrower.Value = Mortgagorobj.PrintViewCo_Borrower; 05112016

            //SqlParameter prmCo_Prefix = new SqlParameter("@Co_Prefix", SqlDbType.VarChar); 05112016
            //prmCo_Prefix.Value = Mortgagorobj.Co_Prefix; 05112016

            //SqlParameter prmCo_FirstName = new SqlParameter("@Co_FirstName", SqlDbType.VarChar); 05112016
            //prmCo_FirstName.Value = Mortgagorobj.Co_FirstName; 05112016

            //SqlParameter prmCo_MiddleInitial = new SqlParameter("@Co_MiddleInitial", SqlDbType.VarChar); 05112016
            //prmCo_MiddleInitial.Value = Mortgagorobj.Co_MiddleInitial; 05112016

            //SqlParameter prmCo_LastName = new SqlParameter("@Co_LastName", SqlDbType.VarChar); 05112016
            //prmCo_LastName.Value = Mortgagorobj.Co_LastName; 05112016

            //SqlParameter prmCo_Suffix = new SqlParameter("@Co_Suffix", SqlDbType.VarChar); 05112016
            //prmCo_Suffix.Value = Mortgagorobj.Co_Suffix; 05112016

            //SqlParameter prmCo_Alias=new SqlParameter("@Co_Alias",SqlDbType.VarChar); 05112016
            //prmCo_Alias.Value=Mortgagorobj.Co_Alias; 05112016

            //SqlParameter prmCo_BorrowerPhone = new SqlParameter("Co_BorrowerPhone", SqlDbType.VarChar); 05112016
            //prmCo_BorrowerPhone.Value = Mortgagorobj.Co_Phone; 05112016

            SqlParameter prmPrimaryPhone = new SqlParameter("@PrimaryPhone", SqlDbType.Char);
            prmPrimaryPhone.Value = Mortgagorobj.PrimaryPhone;

            SqlParameter prmCellPhone = new SqlParameter("@CellPhone", SqlDbType.Char);
            prmCellPhone.Value = Mortgagorobj.CellPhone;

            SqlParameter prmAddress_1 = new SqlParameter("@Address_1", SqlDbType.VarChar);
            prmAddress_1.Value = Mortgagorobj.Address_1;

            SqlParameter prmAddress_2 = new SqlParameter("@Address_2", SqlDbType.VarChar);
            prmAddress_2.Value = Mortgagorobj.Address_2;

            SqlParameter prmCity = new SqlParameter("@City", SqlDbType.VarChar);
            prmCity.Value = Mortgagorobj.City;

            SqlParameter prmZipCode = new SqlParameter("@ZipCode", SqlDbType.Char);
            prmZipCode.Value = Mortgagorobj.ZipCode;

            SqlParameter prmState = new SqlParameter("@State", SqlDbType.Char);
            prmState.Value = Mortgagorobj.State;

            SqlParameter prmCensusTract = new SqlParameter("@CensusTract", SqlDbType.VarChar);
            prmCensusTract.Value = Mortgagorobj.CensusTract;
            
            //SqlParameter prmPrintViewName_3 = new SqlParameter("@PrintViewName_3", SqlDbType.VarChar); 05112016
            //prmPrintViewName_3.Value = Mortgagorobj.PrintViewName_3; 05112016
            
            //SqlParameter prmPrintViewName_4 = new SqlParameter("@PrintViewName_4", SqlDbType.VarChar); 05112016
            //prmPrintViewName_4.Value = Mortgagorobj.PrintViewName_4; 05112016

            //3/10/15 _obd. uncommented to pass the windows authenticated user. Need to uncomment it in the SQL SP as well
            SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.VarChar);
            prmUserID.Value = Mortgagorobj.UserID;

            //SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.VarChar);
            //prmUserID.Value = Mortgagorobj.UserID;
            
            /// <summary>
            /// This if condition  to check the record by search grid , If Mortgagor is created , it will update otherwise it will insert as new record
            /// </summary>
            /// <returns></returns>
            
          //SqlParameter prmCreateDate = new SqlParameter("@CreateDate", DBNull.Value);
          //  SqlParameter prmCreateDate;
          //  if (Mortgagorobj.CreateDate==null)
           
          //          {
          //        prmCreateDate=new SqlParameter("@CreateDate", DBNull.Value);
          //          }
          //else

          //          {
          //      prmCreateDate=new SqlParameter("@CreateDate",Mortgagorobj.CreateDate);
          //          }
            //SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.VarChar);
            //prmUserID.Value = Mortgagorobj.UserID;
            
            /// this is temporary storage area. Edit mode is declared in Add mortgagor detail
           
            SqlParameter prmMortgagorInformationInputID = new SqlParameter("@MortgagorInformationInputID", SqlDbType.Int);
            prmMortgagorInformationInputID.Value = Mortgagorobj.MortgagorInformationID;

            SqlParameter prmEdit = new SqlParameter("@Edit", SqlDbType.Int);
            prmEdit.Value = EditMode;

            //prmCreateDate.Value = Mortgagorobj.CreateDate;
            SqlParameter prmMortgagorInformationID = new SqlParameter("@MortgagorInformationID", SqlDbType.Int);
            prmMortgagorInformationID.Direction = ParameterDirection.Output;

            //3/10/15 _obd. updated to add the user id as a parameter
            /// -- 04/27/15 _Jaheda meman added new parameter
            //return DataAccess.Execute("uspAddMortgagorDetails", prmEstateOf, prmPrefix, prmFirstName, prmMiddleInitial, prmLastName, prmSuffix, prmAlias, prmRaceID, prmHispanic, prmEmail, prmGender, prmCo_Prefix, prmCo_FirstName, prmCo_MiddleInitial, prmCo_LastName, prmCo_Suffix, prmCo_Alias, prmCo_BorrowerPhone, prmPrimaryPhone, prmCellPhone, prmAddress_1, prmAddress_2, prmCity, prmZipCode, prmState, prmCensusTract, prmEdit,prmMortgagorInformationInputID, prmMortgagorInformationID);
            /// -- 04/30/15 _Jaheda meman Updared new parameter -remove prmPrefix, prmCo_Prefix,
            /// 
            return DataAccess.Execute("uspAddMortgagorDetails", prmFirstName, prmMiddleInitial, prmLastName, prmSuffix, prmAlias, prmRaceID, prmHispanic, prmEmail, prmGender, prmPrimaryPhone, prmCellPhone, prmAddress_1, prmAddress_2, prmCity, prmZipCode, prmState, prmCensusTract, prmUserID, prmEdit, prmMortgagorInformationInputID, prmMortgagorInformationID);
            //----05112016---- 
            //prmPrintViewBorrower,prmPrintViewCo_Borrower, prmCo_FirstName, prmCo_MiddleInitial, prmCo_LastName, prmCo_Suffix,
            //prmCo_Alias, ..prmCo_BorrowerPhone, ---prmPrintViewName_3,prmPrintViewName_4, 
            //----05112016----

        }

        /// <summary>
        /// To get Mortgagor details only for read or display on the mediation page when we search by Id or zipcode,address.
        /// We use this method to retrive the data from Database readonly purpose.
        /// </summary>
        /// <param name="MortgagorInformationID"></param>
        /// <returns></returns>

        public IDataReader GetMortgagorDetails(int MortgagorInformationID)
        {
            SqlParameter prmMortgagorInformationID = new SqlParameter("@MortgagorInformationID", SqlDbType.Int);
            prmMortgagorInformationID.Value = MortgagorInformationID;
            return DataAccess.GetFromReader("uspGetMorgagorDetails", prmMortgagorInformationID);
        }
        /// <summary>
        /// Update Mortgagor Details FOR THE MEDIATION CASE
        /// </summary>
        /// <returns></returns>
        public int UpdateMortgagorDetails(MortgagorDAL Mortgagorobj)
        {
            //SqlParameter prmPrintViewBorrower = new SqlParameter("@PrintViewBorrower", SqlDbType.VarChar); 05112016
            //prmPrintViewBorrower.Value = Mortgagorobj.PrintViewBorrower; 05112016
            //SqlParameter prmPrefix = new SqlParameter("@Prefix", SqlDbType.VarChar);
            //prmPrefix.Value = Mortgagorobj.Prefix;
            SqlParameter prmFirstName = new SqlParameter("@FirstName", SqlDbType.VarChar);
            prmFirstName.Value = Mortgagorobj.FirstName;
            SqlParameter prmMiddleInitial = new SqlParameter("@MiddleInitial", SqlDbType.VarChar);
            prmMiddleInitial.Value = Mortgagorobj.MiddleInitial;
            SqlParameter prmLastName = new SqlParameter("@LastName", SqlDbType.VarChar);
            prmLastName.Value = Mortgagorobj.LastName;
            //SqlParameter prmPrintViewCo_Borrower = new SqlParameter("@PrintViewCo_Borrower", SqlDbType.VarChar); 05112016
            //prmPrintViewCo_Borrower.Value = Mortgagorobj.PrintViewCo_Borrower; 05112016
            //SqlParameter prmCo_FirstName = new SqlParameter("@Co_FirstName", SqlDbType.VarChar); 05112016
            //prmCo_FirstName.Value = Mortgagorobj.Co_FirstName; 05112016
            //SqlParameter prmCo_MiddleInitial = new SqlParameter("@Co_MiddleInitial", SqlDbType.VarChar); 05112016
            //prmCo_MiddleInitial.Value = Mortgagorobj.Co_MiddleInitial; 05112016
            //SqlParameter prmCo_LastName = new SqlParameter("@Co_LastName", SqlDbType.VarChar); 05112016
            //prmCo_LastName.Value = Mortgagorobj.Co_LastName; 05112016
            SqlParameter prmAddress_1 = new SqlParameter("@Address_1", SqlDbType.VarChar);
            prmAddress_1.Value = Mortgagorobj.Address_1;
            SqlParameter prmAddress_2 = new SqlParameter("@Address_2", SqlDbType.VarChar);
            prmAddress_2.Value = Mortgagorobj.Address_2;
            SqlParameter prmCity = new SqlParameter("@City", SqlDbType.VarChar);
            prmCity.Value = Mortgagorobj.City;
            SqlParameter prmZipCode = new SqlParameter("@ZipCode", SqlDbType.Char);
            prmZipCode.Value = Mortgagorobj.ZipCode;
            SqlParameter prmState = new SqlParameter("@State", SqlDbType.Char);
            prmState.Value = Mortgagorobj.State;
            /// -- 04/27/15 _Jaheda meman added new parameter
            //SqlParameter prmPrintViewName_3 = new SqlParameter("@PrintViewName_3", SqlDbType.VarChar); 05112016
            //prmPrintViewName_3.Value = Mortgagorobj.PrintViewName_3;05112016
            //SqlParameter prmPrintViewName_4 = new SqlParameter("@PrintViewName_4", SqlDbType.VarChar); 05112016
            //prmPrintViewName_4.Value = Mortgagorobj.PrintViewName_4; 05112016
            SqlParameter prmMortgagorInformationID = new SqlParameter("@MortgagorInformationID", SqlDbType.Int);
            prmMortgagorInformationID.Value = Mortgagorobj.MortgagorInformationID;
            return DataAccess.Execute("uspUpdateMortgagorDetails", prmFirstName, prmMiddleInitial, prmLastName, prmAddress_1, prmAddress_2, prmCity, prmZipCode, prmState, prmMortgagorInformationID);
        }
        //----05112016---- 
        //prmPrintViewBorrower,prmPrintViewCo_Borrower, prmCo_FirstName, prmCo_MiddleInitial, prmCo_LastName, --prmPrintViewName_3,prmPrintViewName_4, 
        //----05112016----

        /// <summary>PrintViewBorrower
        /// Search  Mortgagor Details by last name, property address and zipcode
        /// </summary>
        /// <returns></returns>
        
        public DataTable SearchMortgagorDetails(string searchtext, int mediationCaseId)
        {
            SqlParameter prmSearchtext = new SqlParameter("@searchtext", SqlDbType.VarChar);
            prmSearchtext.Value = searchtext;

            SqlParameter prmMediationCaseId = new SqlParameter("@MediationCaseId", SqlDbType.Int);
            prmMediationCaseId.Value = mediationCaseId;


            return DataAccess.GetFromDataTable("uspSearchMortgargorDetails", prmSearchtext, prmMediationCaseId);
        }
        /// <summary>
        /// Search  Mortgagor by Mediation case ID
        /// </summary>
        /// <returns></returns>
        /// 
        public DataTable SearchByMediationCaseID(int MortgagorInformationID)
        {


            SqlParameter prmMortgagorInformationID = new SqlParameter("@MortgagorInformationID", SqlDbType.Int);
            prmMortgagorInformationID.Value = MortgagorInformationID;


            return DataAccess.GetFromDataTable("uspSearchByMediationCaseID", prmMortgagorInformationID);
        }

        /// <summary>
        ///  Get   Mediation case ID for Morgagor
        /// </summary>
        /// <returns></returns>

        public int GetMortgagorMediationCount(int MortgagorInformationID)

        {
            SqlParameter prmMortgagorInformationID=new SqlParameter("@MortgagorInformationID",SqlDbType.Int);
            prmMortgagorInformationID.Value = MortgagorInformationID;
            IDataReader reader = DataAccess.GetFromReader("uspMortgagorMediationCaseCount", prmMortgagorInformationID);
            int val = 0;
            if (reader.Read())
            {
                int.TryParse(reader[0].ToString(), out val);
            }
            return val;
        }
    }
        #endregion
       
    }
  