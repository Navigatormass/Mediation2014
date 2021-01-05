using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Common;
using System.Configuration;
namespace DAL
{

    /// <summary>
    /// Summary description for MediationCaseContactsDAL
    /// </summary>
    public class MediationCaseContactsDAL
    {
        public MediationCaseContactsDAL()
        {

            // TODO: Add constructor logic here
            //
        }
        #region Class Varibles
        ///<summary>LenderContactID</summary>
        protected int _ContactID;
        ///<summary>LenderName</summary>
        protected string _Name;
        ///<summary>ContactName</summary>
        protected string _ContactName;
        ///<summary>ContactTitle</summary>
        protected string _ContactTitle;
        ///<summary>Address_1</summary>
        protected string _Address_1;
        ///<summary>Address_2</summary>
        protected string _Address_2;
        ///<summary>City</summary>
        protected string _City;
        ///<summary>State</summary>
        protected string _State;
        ///<summary>ZipCode</summary>
        protected string _ZipCode;
        ///<summary>Email</summary>
        protected string _Email;
        ///<summary>OfficePhone</summary>
        protected string _OfficePhone;
        ///<summary>Extension</summary>
        protected string _Extension;
        ///<summary>FaxNumber</summary>
        protected string _FaxNumber;
        ///<summary>AltPhoneNumber</summary>
        protected string _AltPhoneNumber;
        ///<summary>AltExtension</summary>
        protected string _AltExtension;
        //3/16/15 _obd. updated to capture the windows authenticated user for the point of contacts. 
        ///<summaryUserID</summary>
        protected string _UserID;
    
        #endregion
        #region Properties  -Get and Set Accessor

        public int ContactID
        {
            get { return _ContactID; }
            set { _ContactID = value; }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string ContactName
       {
            get { return  _ContactName; }
            set { _ContactName = value; }
        }

        public string ContactTitle
        {
            get { return _ContactTitle; }
            set { _ContactTitle = value; }
        }

        public string Address_1
        {
            get { return _Address_1; }
            set { _Address_1 = value; }
        }
        public string Address_2
        {
            get { return _Address_2; }
            set { _Address_2 = value; }
        }
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
        public string State
        {
            get { return _State; }
            set { _State = value; }
        }

        public string ZipCode
        {
            get { return _ZipCode; }
            set { _ZipCode = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public string OfficePhone
        {
            get { return _OfficePhone; }
            set { _OfficePhone = value; }
        }

        public string Extension
        {
            get { return _Extension; }
            set { _Extension = value; }
        }
        public string FaxNumber
        {
            get { return _FaxNumber; }
            set { _FaxNumber = value; }
        }
        public string AltPhoneNumber
        {
            get { return _AltPhoneNumber; }
            set { _AltPhoneNumber = value; }
        }
        public string AltExtension
        {
            get { return _AltExtension; }
            set { _AltExtension = value; }
        }
        public string UserID
        {
            //3/16/15 _obd. updated to capture the windows authenticated user. 

            get { return HttpContext.Current.User.Identity.Name; }//_UserID; }
            set { _UserID = value; }
        }           
           

        #endregion

        public int AddMediationCaseContactsDetails(MediationCaseContactsDAL MediationContactsobj,int selecteid,int EditMode)

        {
            SqlParameter prmContactID = new SqlParameter("@ContactID", SqlDbType.Int);
            prmContactID.Value = MediationContactsobj.ContactID;
            SqlParameter prmName = new SqlParameter("@Name",SqlDbType.VarChar);
            prmName.Value = MediationContactsobj.Name;
            SqlParameter prmContactName = new SqlParameter("@ContactName", SqlDbType.VarChar);
            prmContactName.Value = MediationContactsobj.ContactName;
            SqlParameter prmContactTitle = new SqlParameter("@ContactTitle", SqlDbType.VarChar);
            prmContactTitle.Value = MediationContactsobj.ContactTitle;
            SqlParameter prmAddress_1 = new SqlParameter("@Address_1", SqlDbType.VarChar);
            prmAddress_1.Value = MediationContactsobj.Address_1;
            SqlParameter prmAddress_2 = new SqlParameter("@Address_2", SqlDbType.VarChar);
            prmAddress_2.Value = MediationContactsobj.Address_2;
            SqlParameter prmCity = new SqlParameter("@City", SqlDbType.VarChar);
            prmCity.Value = MediationContactsobj.City;
            SqlParameter prmState=new SqlParameter("@State", SqlDbType.Char);
            prmState.Value = MediationContactsobj.State;
            SqlParameter prmZipCode=new SqlParameter("@ZipCode", SqlDbType.Char);
            prmZipCode.Value = MediationContactsobj.ZipCode;
            SqlParameter prmEmail = new SqlParameter("@Email", SqlDbType.VarChar);
            prmEmail.Value = MediationContactsobj.Email;
            SqlParameter prmOfficePhone = new SqlParameter("@OfficePhone", SqlDbType.Char);
            prmOfficePhone.Value = MediationContactsobj.OfficePhone;
            SqlParameter prmExtension = new SqlParameter("@Extension", SqlDbType.VarChar);
            prmExtension.Value = MediationContactsobj.Extension;
            SqlParameter prmFaxNumber = new SqlParameter("@FaxNumber", SqlDbType.Char);
            prmFaxNumber.Value = MediationContactsobj.FaxNumber;
            SqlParameter prmAltPhoneNumber = new SqlParameter("@AltPhoneNumber", SqlDbType.Char);
            prmAltPhoneNumber.Value = MediationContactsobj.AltPhoneNumber;
            SqlParameter prmAltExtension = new SqlParameter("@AltExtension", SqlDbType.VarChar);
            prmAltExtension.Value = MediationContactsobj.AltExtension;
            SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.VarChar);
            prmUserID.Value =MediationContactsobj.UserID;
            SqlParameter prmEdit = new SqlParameter("@Edit", SqlDbType.Int);
            prmEdit.Value = EditMode;
            SqlParameter prmID = new SqlParameter("@ID", SqlDbType.Int);
            prmID.Value = selecteid;
            SqlParameter prmoutputContactId = new SqlParameter("@outputContactID", SqlDbType.Int);
            prmoutputContactId.Direction = ParameterDirection.Output;
            return DataAccess.Execute("uspAddMediationContacts2", prmContactID, prmName, prmContactName, prmContactTitle, prmAddress_1, prmAddress_2, prmCity, prmState, prmZipCode, prmEmail, prmOfficePhone, prmExtension, prmAltPhoneNumber, prmAltExtension, prmUserID, prmEdit, prmID,prmFaxNumber, prmoutputContactId);                       
        }
        /// <summary>
        /// When we search by zipcode,Address,city , we use the below code.
        /// </summary>
        /// <param name="selectedid"></param>
        /// <returns></returns>
        public DataTable GetMediationContactsDetails(int selectedid)
        {
            SqlParameter prmId = new SqlParameter("@ID", SqlDbType.Int);
            prmId.Value = selectedid;

            return DataAccess.GetFromDataTable("uspGetMediationContactsDetails", prmId);
        }

        /// <summary>
        /// When we search by ID, we use the below code.
        /// </summary>
        /// <param name="selectedid"></param>
        /// <param name="contactid"></param>
        /// <returns></returns>
        public IDataReader GetMediationContactDetailsByID(int selectedid, int contactid)
        {
            SqlParameter prmId = new SqlParameter("@ID", SqlDbType.Int);
            prmId.Value = selectedid;

            SqlParameter prmcontactid = new SqlParameter("@Contactid", SqlDbType.Int);
            prmcontactid.Value = contactid;

            return DataAccess.GetFromReader("uspGetMediationContactDetailsByID", prmId, prmcontactid);
        }
           

    }
}