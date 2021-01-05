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
    /// Summary description for MediationCaseNotesBAL
    /// </summary>
    public class MediationCaseNotesBAL
    {
        public MediationCaseNotesBAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        MediationCaseNotesDAL MediationCaseNotesDALobj = new MediationCaseNotesDAL();
     
        public int AddMediationCaseNotes(MediationCaseNotesDAL MediationCaseNotesDALobj)
        {

            return MediationCaseNotesDALobj.AddMediationCaseNotes(MediationCaseNotesDALobj);
        }

        public DataTable GetMediationCaseNotesDetails(int MedationID)
        {
            return MediationCaseNotesDALobj.GetMediationCaseNotesDetails(MedationID);
        }
       
    }
}