using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using DAL;



/// <summary>
/// Summary description for MediationCaseContactsBAL
/// </summary>
namespace BAL
{
    public class MediationCaseContactsBAL
    {
        public MediationCaseContactsBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        
        MediationCaseContactsDAL MediationContactDALsobj = new MediationCaseContactsDAL();

        public int AddMediationCaseContactsDetails(MediationCaseContactsDAL MediationContactsobj, int selecteid, int EditMode)


        {
            return MediationContactDALsobj.AddMediationCaseContactsDetails(MediationContactsobj, selecteid, EditMode);
        }
        // This method is used for Drop down box . To fill out drop down box, using store procedure.
        public DataTable GetMediationContactsDetails(int selectedid)
        {
            return MediationContactDALsobj.GetMediationContactsDetails(selectedid);
        }
        public IDataReader GetMediationContactDetailsByID(int selectedid, int contactid)

        {
            return MediationContactDALsobj.GetMediationContactDetailsByID(selectedid,contactid);
        }
            
  
    }
}
