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
/// Summary description for MediationCaseNotesDAL
/// </summary>
public class MediationCaseNotesDAL
{
	public MediationCaseNotesDAL()
	{
		//
		// TODO: Add constructor logic here
		//
    }
    #region Class Varibles
    ///<summary>NotesID</summary>
    protected int _NotesID;
    ///<summary>MediationCaseInformationID</summary>
    protected int _MediationCaseInformationID;
    ///<summary>Notes</summary>
    protected string _Notes;
    ///<summary>Notes</summary>
    /// ///<summary>UserID</summary>
    protected string _UserID;
    ///<summary>TimeStamp</summary>
    protected DateTime? _TimeStamp;

    #endregion

    /// Properties
    #region Properties  -Get and Set Accessor
    public int NotesID
    {
        get { return _NotesID; }
        set { _NotesID = value; }
    }
    public int MediationCaseInformationID
    {
        get { return _MediationCaseInformationID; }
        set { _MediationCaseInformationID = value; }
    }
    public string Notes
    {
            get { return _Notes; }
            set { _Notes = value; }
    }
    public string UserID
    {    //3/13/15 _obd   
        get { return HttpContext.Current.User.Identity.Name; }//_UserID; }
        set { _UserID = value; }
    }
    //public string UserID
    //{
    //        get { return UserID; }
    //        set { _UserID = value; }
    //}
    //public DateTime? TimeStamp
    //{
    //        get { return TimeStamp; }
    //        set { _TimeStamp = value; }
    //}
       


    #endregion

 public int AddMediationCaseNotes(MediationCaseNotesDAL MediationNotesobj)

{
          
            SqlParameter prmMediationCaseInformationID = new SqlParameter("@MediationCaseInformationID", SqlDbType.Int);
            prmMediationCaseInformationID.Value = MediationNotesobj.MediationCaseInformationID;
            SqlParameter prmNotes = new SqlParameter("@Notes", SqlDbType.VarChar);
            prmNotes.Value = MediationNotesobj.Notes;
        //_obd 3/13/15
            SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.VarChar);
            prmUserID.Value = MediationNotesobj.UserID;
            //SqlParameter prmUserID = new SqlParameter("@UserID",SqlDbType.VarChar);
            //prmUserID.Value = MediationNotesobj.UserID;
            //SqlParameter prmTimeStamp =new SqlParameter("@TimeStamp",SqlDbType.SmallDateTime);
            //prmTimeStamp.Value=MediationNotesobj.TimeStamp;
            //SqlParameter prmEdit = new SqlParameter("@Edit", SqlDbType.Int);
            //prmEdit.Value = EditMode;
            //SqlParameter prmoutputNotesID = new SqlParameter("@outputNotesID", SqlDbType.Int);
            //prmoutputNotesID.Direction = ParameterDirection.Output;

            return DataAccess.Execute("uspAddMediationNotes2", prmMediationCaseInformationID, prmNotes, prmUserID);

}
 public DataTable GetMediationCaseNotesDetails(int MedationID)

        {
            SqlParameter prmMedationID = new SqlParameter("@MediationCaseInformationID", SqlDbType.Int);
            prmMedationID.Value = MedationID;
            return DataAccess.GetFromDataTable("uspGetMediationCaseNotesDetails", prmMedationID);

        }
 

}

}
