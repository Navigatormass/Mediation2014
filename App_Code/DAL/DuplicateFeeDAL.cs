using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Common;
using System.Configuration;


/// <summary>
/// Summary description for DuplicateFees
/// </summary>
namespace DAL
{
    public class DuplicateFeeDAL
    {
        public DuplicateFeeDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region class Variables
        ///<summary>DuplicateFeeID</summary>
        protected int _DuplicateFeeID;
        ///<summary>MediationCaseInformationID</summary>
        protected int _MediationCaseInformationID;
        ///<summary>DuplicateFeePaymentTypeID</summary>
        protected int _DuplicateFeePaymentTypeID;
        ///<summary>FeeReceivedDate</summary>
        protected DateTime? _FeeReceivedDate;
        ///<summary>DuplicateFeeAmount</summary>
        protected decimal _DuplicateFeeAmount;
        ///<summary>UserID</summary>
        protected string _UserID;

        #endregion
        #region Properties -Get and Set Accessor
        public int DuplicateFeeID
        {
            get { return _DuplicateFeeID; }
            set { _DuplicateFeeID = value; }
        }

        public int MediationCaseInformationID
        {
            get { return _MediationCaseInformationID; }
            set { _MediationCaseInformationID = value; }
        }

        public int DuplicateFeePaymentTypeID

        {
            get { return _DuplicateFeePaymentTypeID; }
            set { _DuplicateFeePaymentTypeID = value; }
        }

        public DateTime? FeeReceivedDate
        {
            get { return _FeeReceivedDate; }
            set { _FeeReceivedDate = value; }
        }

        public decimal FeeAmount
        {
            get { return _DuplicateFeeAmount; }
            set { _DuplicateFeeAmount = value; }
        }

        public String UserID
        {
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

        #endregion

        public DataTable GetDuplicateFee()
        {
            return DataAccess.GetFromDataTable("uspGetDuplicateFee");
        }

        public DataTable GetDuplicateFeeReport()
        {
            //SqlParameter prmCaseID = new SqlParameter("@MediationCaseInformationID", SqlDbType.Int);
            //prmCaseID.Value = MediationCaseInformationID;

            return DataAccess.GetFromDataTable("uspGetDuplicateFeeReport");
        }

        public int AddDuplicateFee(DuplicateFeeDAL dupeFeeDALObj)
        {
            //SqlParameter prmDuplicateFeeID = new SqlParameter("@DuplicateFeeInputID", SqlDbType.Int);
            //prmDuplicateFeeID.Value = dupeFeeDALObj.DuplicateFeeID;

            SqlParameter prmMediationCaseInformationID = new SqlParameter("@MediationCaseInformationID", SqlDbType.Int);
            prmMediationCaseInformationID.Value = dupeFeeDALObj.MediationCaseInformationID;

            SqlParameter prmDupePaidBy = new SqlParameter("@DuplicateFeePaymentTypeID ", SqlDbType.VarChar);
            prmDupePaidBy.Value = dupeFeeDALObj.DuplicateFeePaymentTypeID;

            SqlParameter prmFeeReceivedDate = new SqlParameter("@FeeReceivedDate", SqlDbType.SmallDateTime);
            prmFeeReceivedDate.Value = dupeFeeDALObj.FeeReceivedDate;

            SqlParameter prmDupeFee = new SqlParameter("@FeeAmount", SqlDbType.Decimal);
            prmDupeFee.Value = dupeFeeDALObj.FeeAmount;

            SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.VarChar);
            prmUserID.Value = dupeFeeDALObj.UserID;

            //SqlParameter prmdufeeID = new SqlParameter("@DuplicateFeeID", SqlDbType.Int);
            //prmdufeeID.Direction = ParameterDirection.Output;

             //return DataAccess.Execute("uspAddDuplicateFeeToLog",prmDuplicateFeeID, prmMediationCaseInformationID, prmDupePaidBy, prmFeeReceivedDate, prmDupeFee, prmUserID, prmdufeeID);               
            return DataAccess.Execute("uspAddDuplicateFeeToLog", prmMediationCaseInformationID, prmDupePaidBy, prmFeeReceivedDate, prmDupeFee, prmUserID);              

       }
    }
}