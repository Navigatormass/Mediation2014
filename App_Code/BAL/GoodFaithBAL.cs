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
    /// Summary description for GoodFaithBAL
    /// </summary>
    public class GoodFaithBAL
    {
        public GoodFaithBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        GoodFaithDAL GoodFaithDALObj = new GoodFaithDAL();


        //public DataTable GetGoodFaithDetermination(int GoodFaithDetermination_A1ID)
        //{

        //    return GoodFaithDALObj.GetGoodFaithDetermination(GoodFaithDetermination_A1ID);
        
        //}

        public DataTable GetGoodFaithDetermination()
        {

            return GoodFaithDALObj.GetGoodFaithDetermination();

        }
        public int AddGoodFaithDetermination(GoodFaithDAL goodFaithDALObj)
        {
            return GoodFaithDALObj.AddGoodFaithDetermination(goodFaithDALObj);
        }
        //public DataTable GetRePrintGoodFaithDetermination(GoodFaithDAL goodFaithDALObj)

        //{
        //    return goodFaithDALObj.GetRePrintGoodFaithDetermination(goodFaithDALObj);
        //}
        
//public DataTable GetRePrintGoodFaithDetermination()
//{
//    throw new NotImplementedException();
//}
    }
}