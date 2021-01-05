using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using DAL;

/// <summary>
/// Summary description for MortgagorBAL
/// </summary>

namespace BAL
{

    public class MortgagorBAL
    {
        public MortgagorBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        MortgagorDAL MortgagorDALobj = new MortgagorDAL();
        // To ADD the data in to table using search grid and direct. I did editmode for the adding record using search
        public int AddMortgagorDetails(MortgagorDAL MortgagorDALobj,int EditMode)
        {
            //return MortgagorDALobj.AddMortgagorDetails(MortgagorDALobj);
            return MortgagorDALobj.AddMortgagorDetails(MortgagorDALobj, EditMode);
        }

        // to retrive the data from the database-table name " MortgagorInformation".
        //The IDataReader is an Interface. This means that it only contains a signature of the class structure. Every class which implements this interface need to implement the same methods.
        public IDataReader GetMortgagorDetails(int MortgagorInformationID)

        {
            return MortgagorDALobj.GetMortgagorDetails(MortgagorInformationID);

        }
        // To UPDATE the data into table-table name" MortgagorInformation"
     
        public int UpdateMortgagorDetails(MortgagorDAL Mortgagorobj)
        {
            return MortgagorDALobj.UpdateMortgagorDetails(Mortgagorobj);
        }
     /// <summary>
     /// To serach by Mortgagor using lastname, propertyaddress, zipcode
     /// </summary>
     /// <param name="searchtext"></param>
     /// <param name="mediationCaseId"></param>
     /// <returns></returns>
        public DataTable SearchMortgagorDetails(string searchtext, int mediationCaseId)
        {
            return MortgagorDALobj.SearchMortgagorDetails(searchtext, mediationCaseId);
        }

        /// <summary>
        /// To search by Mortgagor using  Medication Case Id
        /// </summary>
        /// <param name="MortgagorInformationID"></param>
        /// <returns></returns>
        public DataTable SearchByMediationCaseID(int MortgagorInformationID)
        {
            return MortgagorDALobj.SearchByMediationCaseID(MortgagorInformationID);
        }
        /// <summary>
        /// Get MediationCase Count for Mortgagor
        /// </summary>
        /// <returns></returns>

          public int  GetMortgagorMediationCount(int MortgagorInformationID)

         {
             return MortgagorDALobj.GetMortgagorMediationCount(MortgagorInformationID);
            
         }

         
    }
}