using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using DAL;

/// <summary>
/// Summary description for MediationCaseBAL
/// </summary>
/// 
namespace BAL
{

    public class MediationCaseBAL
    {
        public MediationCaseBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        MediationCaseDAL MediationCaseDALobj = new MediationCaseDAL();

        public int AddMediationCaseDetails(MediationCaseDAL MediationCaseDALobj,int EditMode)
        {
            return MediationCaseDALobj.AddMediationCaseDetails(MediationCaseDALobj,EditMode);
        }
        /// <summary>
        /// Summary to get date in Search Grid--SearchMortgagor Folder
        /// </summary>
        /// 
        public DataTable GetMediationDataByMortgagorID(int MortgagorInformationID)

        {
            return MediationCaseDALobj.GetMediationDataByMortgagorID(MortgagorInformationID);
        }
        public IDataReader GetDataByMediationID(int MediationCaseId)
        {
            return MediationCaseDALobj.GetDataByMediationID(MediationCaseId);
        }
        /// <summary>
        /// We are not using this method
        /// </summary>
        /// <param name="FromNoticeDate"></param>
        /// <param name="ToNoticeDate"></param>
        /// <returns></returns>
        public DataTable GetAllNoticebyNoticeDate(DateTime FromNoticeDate, DateTime ToNoticeDate)
        {

            return MediationCaseDALobj.GetAllNoticebyNoticeDate(FromNoticeDate, ToNoticeDate);
        }
        /// <summary>
        ///   /// To print First letter . We made method to fill out the data in grid to print first letter which is first sent letter date is null.
        /// You will se first letter sent  is in the specific task.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public DataTable GetFirstLetterPrintDetails(int MediationCaseInformationID)
        {
            return MediationCaseDALobj.GetFirstLetterPrintDetails(MediationCaseInformationID);
        }
        /// <summary>
        ///   /// To print Second letter . We made method to fill out the data in grid to print Second letter which is first sent letter date is null.
        /// You will se first letter sent  is in the specific task.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public DataTable GetSecondLetterPrintDetails(int MediationCaseInformationID)
        {
            return MediationCaseDALobj.GetSecondLetterPrintDetails(MediationCaseInformationID);
        }
        /// <summary>
        /// After print the Non Response Certificate , we clear the grid and update the No Response  date in Database
        /// </summary>

        /// <returns></returns>
        public DataTable GetNoResponsePrintDetails(int MediationCaseInformationID)
        {
           //return MediationCaseDALobj.GetNoResponsePrintDetails(MediationCaseInformationID, CoordinatorID);
            return MediationCaseDALobj.GetNoResponsePrintDetails(MediationCaseInformationID);
        }

        public DataTable GetPenaltyPaymentLetterPrintDetails(int MediationCaseInformationID)
        {
            return MediationCaseDALobj.GetPenaltyPaymentLetterPrintDetails(MediationCaseInformationID);
        }

        /// <summary>
        /// After print All Certificate , we clear the grid and update the No Response  date in Database
        /// </summary>
        public DataTable GetAllCertificatesDetails(int MediationCaseInformationID, int ReportID)
       {
            return MediationCaseDALobj.GetAllCertificatesDetails(MediationCaseInformationID, ReportID);
       }
        /// <returns></returns>
        /// <summary>
        /// After print the First Letter , we clear the grid and update the First Letter date in Database. The date will display on the medication screen.
        /// </summary>

        /// <returns></returns>


        public int UpdateMediationCaseFirstLetterDate(string array)
        {
            return MediationCaseDALobj.UpdateMediationCaseFirstLetterDate(array);
        }

        public int UpdateMediationCasePenaltyPaymentDate(string array)
        {
            return MediationCaseDALobj.UpdateMediationCasePenaltyPaymentDate(array);
        }

        /// <summary>
        ///  print the 14Day letter 
        /// </summary>       
        /// <returns></returns>
        public DataTable Get14DayLetterPrintDetail(int MediationCaseInformationID)
        {
            return MediationCaseDALobj.Get14DayLetterPrintDetails(MediationCaseInformationID);
        }
        //11/04/2015 _obd
        public DataTable GetWorkoutInvoiceDetail(int MediationCaseInformationID)
        {
            return MediationCaseDALobj.GetWorkoutInvoicePrintDetails(MediationCaseInformationID);
        }
        /// <summary>
        /// After print the Second Letter , we clear the grid and update the Second Letter date in Database. The date will display on the medication screen.
        /// </summary>

        /// <returns></returns>
        public int UpdateMediationCaseSecondLetterDate(string array)
        {
            return MediationCaseDALobj.UpdateMediationCaseSecondLetterDate(array);
        }
        /// <summary>
        /// After print the Certificate Notice , we clear the grid and update the Second Letter date in Database. The date will display on the medication screen.
        /// </summary>

        /// <returns></returns>
        public int UpdateCertificateNoticePrintDate(string array)
        {
            return MediationCaseDALobj.UpdateCertificateNoticePrintDate(array);
        }
        public DataTable GetNoResponseCertificateDetails(string MediationCaseIdList)
        {
            return MediationCaseDALobj.GetNoResponseCertificateDetails(MediationCaseIdList);
        }
        //public int UpdateCoordinatorID(int MediationCaseInformationID, int CoordinatorID)
        //{
        //    return MediationCaseDALobj.UpdateCoordinatorID(MediationCaseInformationID, CoordinatorID);
        //}
        public int UpdateCoordinatorID(string array, int CoordinatorID)
        {
            return MediationCaseDALobj.UpdateCoordinatorID(array, CoordinatorID);
        }
        //public int UpdateCertificateNoticeReason(int CertificateNoticeID)
        //{

  
        //    return MediationCaseDALobj.UpdateCertificateNoticeReason(CertificateNoticeID);
        //}

        /// <summary>
        ///  To update the mediation 14day letter print date after print and clear the grid in specific task.
        /// </summary>
        /// <param name="MediationCaseInformationID"></param>
        /// <returns></returns>

        public int Update14DayLetterPrintDate(int MediationCaseInformationID)
        {


            return MediationCaseDALobj.Update14DayLetterPrintDate(MediationCaseInformationID);
        }
       
        /// <summary>
        /// This is to search Mediation notice on first letter
        /// </summary>
        /// <param name="CertificateNoticeID"></param>
        /// <returns></returns>
        public DataTable GetMediationCertificateNoticeDetails(int CertificateNoticeID)
        {
            return MediationCaseDALobj.GetMediationCertificateNoticeDetails(CertificateNoticeID);
        }

    }
}