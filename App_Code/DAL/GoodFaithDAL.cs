using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using Common;
using System.Configuration;


/// <summary>
/// Summary description for GoodFaith
/// </summary>
namespace DAL
{
    public class GoodFaithDAL
    {
        public GoodFaithDAL()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region class Vairbales
         ///<summary>CoordinatorID</summary>
        protected int? _CoordinatorID;
        ///<summary>GoodFaithDetermination_A1ID</summary>
        protected int _GoodFaithDetermination_A1ID;
        ///<summary>MediationCaseInformationID</summary>
        protected int _MediationCaseInformationID;
        ///<summary>Question_1</summary> 
        protected int _AC_Question_1;
        ///<summary>Question_2</summary> 
        protected int _AC_Question_2;
        ///<summary>Question_3</summary> 
        protected int _AC_Question_3;
        ///<summary>Question_1</summary> 
        protected int _Question_1;
        ///<summary>Question_2</summary> 
        protected int _Question_2;
        ///<summary>Question_3</summary> 
        protected int _Question_3;
        ///<summary>Question_4</summary> 
        protected int _Question_4;
        ///<summary>Question_5</summary> 
        protected int _Question_5;
        ///<summary>Question_6</summary> 
        protected int _Question_6;
        ///<summary>Question_7</summary> 
        protected int _Question_7;
        ///<summary>Question_7_Note</summary>
        protected string _Question_7_Note;
        ///<summary>Document_Name</summary>
       // protected string _Document_Name;
        ///<summary>UserID</summary>
        protected string _UserID;
        ///<summary>CreateDate</summary>
        protected DateTime? _CreateDate;

        #endregion
        #region Properties -Get and Set Accessor
        public int GoodFaithDetermination_A1ID
        {
            get { return _GoodFaithDetermination_A1ID; }
            set { _GoodFaithDetermination_A1ID = value; }
        }
        public int MediationCaseInformationID
        {
            get { return _MediationCaseInformationID; }
            set { _MediationCaseInformationID = value; }
        }
        public int? CoordinatorID
         {
             get { return _CoordinatorID; }
             set { _CoordinatorID = value; }
         }
        public int AC_Question_1
        {
            get { return _AC_Question_1; }
            set { _AC_Question_1 = value; }
        }
        public int AC_Question_2
        {
            get { return _AC_Question_2; }
            set { _AC_Question_2 = value; }
        }
        public int AC_Question_3
        {
            get { return _AC_Question_3; }
            set { _AC_Question_3 = value; }
        }
        public int Question_1
        {
            get { return _Question_1; }
            set { _Question_1 = value; }
        }
        public int Question_2
        {
            get { return _Question_2; }
            set { _Question_2 = value; }
        }
      
        public int Question_3
        {
            get { return _Question_3; }
            set { _Question_3 = value; }
        }

        public int Question_4
        {
            get { return _Question_4; }
            set { _Question_4 = value; }
        }
        public int Question_5
        {
            get { return _Question_5; }
            set { _Question_5 = value; }
        }
        public int Question_6
        {
            get { return _Question_6; }
            set { _Question_6 = value; }
        }
        public int Question_7
        {
            get { return _Question_7; }
            set { _Question_7 = value; }
        }
        public String Question_7_Note
        {
            get { return _Question_7_Note; }
            set { _Question_7_Note = value; }
        }
        //public String Document_Name
        //{
        //    get { return _Document_Name; }
        //    set { _Document_Name = value; }
        //}
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
        ///<summary>Question_7_Note</summary>

        public DateTime? CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }

        #endregion

        public DataTable GetGoodFaithDetermination()
        {
            //SqlParameter prmGoodFaithDetermination_A1ID = new SqlParameter("@GoodFaithDetermination_A1ID", SqlDbType.Int);
            //prmGoodFaithDetermination_A1ID.Value = GoodFaithDetermination_A1ID;
            //return DataAccess.GetFromDataTable("uspGetGoodFaithDetermination", prmGoodFaithDetermination_A1ID);
            // SqlParameter prmCoordinatorID = new SqlParameter("@CoordinatorID", SqlDbType.Int);
            //prmCoordinatorID.Value =  CoordinatorID;
            return DataAccess.GetFromDataTable("uspGetGoodFaithDetermination");
        }
        public int AddGoodFaithDetermination(GoodFaithDAL goodFaithDALObj)

        {
            //SqlParameter prmGoodFaithDetermination_A1ID = new SqlParameter("@GoodFaithDetermination_A1ID", SqlDbType.Int);

            //prmGoodFaithDetermination_A1ID.Value = GoodFaithDetermination_A1ID;

            SqlParameter prmMediationCaseInformationID = new SqlParameter("@MediationCaseInformationID", SqlDbType.Int);
            prmMediationCaseInformationID.Value = goodFaithDALObj.MediationCaseInformationID;

            SqlParameter prmAC_Question_1 = new SqlParameter("@AC_Question_1 ", SqlDbType.Bit);
            prmAC_Question_1.Value = goodFaithDALObj.AC_Question_1;
            SqlParameter prmAC_Question_2 = new SqlParameter("@AC_Question_2 ", SqlDbType.Bit);
            prmAC_Question_2.Value = goodFaithDALObj.AC_Question_2;
            SqlParameter prmAC_Question_3 = new SqlParameter("@AC_Question_3 ", SqlDbType.Bit);
            prmAC_Question_3.Value = goodFaithDALObj.AC_Question_3;
            SqlParameter prmQuestion_1 = new SqlParameter("@Question_1 ", SqlDbType.Bit);
            prmQuestion_1.Value = goodFaithDALObj.Question_1;

            SqlParameter prmQuestion_2 = new SqlParameter("@Question_2 ", SqlDbType.Bit);
            prmQuestion_2.Value = goodFaithDALObj.Question_2;

            SqlParameter prmQuestion_3 = new SqlParameter("@Question_3 ", SqlDbType.Bit);
            prmQuestion_3.Value = goodFaithDALObj.Question_3;

            SqlParameter prmQuestion_4 = new SqlParameter("@Question_4 ", SqlDbType.Bit);
            prmQuestion_4.Value =goodFaithDALObj.Question_4;

            SqlParameter prmQuestion_5 = new SqlParameter("@Question_5 ", SqlDbType.Bit);
            prmQuestion_5.Value = goodFaithDALObj.Question_5;

            SqlParameter prmQuestion_6 = new SqlParameter("@Question_6 ", SqlDbType.Bit);
            prmQuestion_6.Value = goodFaithDALObj.Question_6;

            SqlParameter prmQuestion_7 = new SqlParameter("@Question_7 ", SqlDbType.Bit);
            prmQuestion_7.Value = goodFaithDALObj.Question_7;

            SqlParameter prmQuestion_7_Note = new SqlParameter("@Question_7_Note ", SqlDbType.VarChar);
            prmQuestion_7_Note.Value = goodFaithDALObj.Question_7_Note;

            SqlParameter prmUserID = new SqlParameter("@UserID", SqlDbType.VarChar);
            prmUserID.Value = goodFaithDALObj.UserID;

            //SqlParameter prmDocument_Name = new SqlParameter("@Document_Name", SqlDbType.VarChar);
            //prmDocument_Name.Value = goodFaithDALObj.Document_Name;
            return DataAccess.Execute("uspAddGoodFaithDetermination", prmMediationCaseInformationID, prmAC_Question_1, prmAC_Question_2, prmAC_Question_3, prmQuestion_1, prmQuestion_2, prmQuestion_3, prmQuestion_4, prmQuestion_5, prmQuestion_6, prmQuestion_7, prmQuestion_7_Note,prmUserID);
                

        }

        //public DataTable GetRePrintGoodFaithDetermination(GoodFaithDAL goodFaithDALObj)
        //{
        //    SqlParameter prmMediationCaseInformationID = new SqlParameter("@MediationCaseInformationID", SqlDbType.Int);
        //    prmMediationCaseInformationID.Value = goodFaithDALObj.MediationCaseInformationID;

        //    SqlParameter prmQuestion_1 = new SqlParameter("@Question_1 ", SqlDbType.Bit);
        //    prmQuestion_1.Value = goodFaithDALObj.Question_1;

        //    SqlParameter prmQuestion_2 = new SqlParameter("@Question_2 ", SqlDbType.Bit);
        //    prmQuestion_2.Value = goodFaithDALObj.Question_2;

        //    SqlParameter prmQuestion_3 = new SqlParameter("@Question_3 ", SqlDbType.Bit);
        //    prmQuestion_3.Value = goodFaithDALObj.Question_3;

        //    SqlParameter prmQuestion_4 = new SqlParameter("@Question_4 ", SqlDbType.Bit);
        //    prmQuestion_4.Value = goodFaithDALObj.Question_4;

        //    SqlParameter prmQuestion_5 = new SqlParameter("@Question_5 ", SqlDbType.Bit);
        //    prmQuestion_5.Value = goodFaithDALObj.Question_5;

        //    SqlParameter prmQuestion_6 = new SqlParameter("@Question_6 ", SqlDbType.Bit);
        //    prmQuestion_6.Value = goodFaithDALObj.Question_6;

        //    SqlParameter prmQuestion_7 = new SqlParameter("@Question_7 ", SqlDbType.Bit);
        //    prmQuestion_7.Value = goodFaithDALObj.Question_7;

        //    SqlParameter prmDocument_Name = new SqlParameter("@Document_Name", SqlDbType.VarChar);
        //    prmDocument_Name.Value = goodFaithDALObj.Document_Name;

        //   // return DataAccess.Execute("uspAddGoodFaithDetermination", prmMediationCaseInformationID, prmQuestion_1, prmQuestion_2, prmQuestion_3, prmQuestion_4, prmQuestion_5, prmQuestion_6, prmQuestion_7, prmDocument_Name);
        //    return DataAccess.GetFromDataTable("uspRePrintGoodFaithDetermination", prmMediationCaseInformationID, prmQuestion_1, prmQuestion_2, prmQuestion_3, prmQuestion_4, prmQuestion_5, prmQuestion_6, prmQuestion_7, prmDocument_Name);
        //}

    }
}