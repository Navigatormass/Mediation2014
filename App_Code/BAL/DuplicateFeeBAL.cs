using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using DAL;


namespace BAL
{
    /// <summary>
    /// Summary description for DuplicateFeesBAL
    /// </summary>
    public class DuplicateFeeBAL
    {
        public DuplicateFeeBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        DuplicateFeeDAL DuplicateFeeDALObj = new DuplicateFeeDAL();

        public DataTable GetDuplicateFee()
        {
            return DuplicateFeeDALObj.GetDuplicateFee();
        }

        public DataTable GetDuplicateFeeReport()
        {

            return DuplicateFeeDALObj.GetDuplicateFeeReport();
        }

        public int AddDuplicateFee(DuplicateFeeDAL dupeFeeDALObj)
        {
            return DuplicateFeeDALObj.AddDuplicateFee(dupeFeeDALObj);
        }

    }
}