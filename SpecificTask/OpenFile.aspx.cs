using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using DAL;
using System.Data;
using System.Text.RegularExpressions;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class AddMediationCaseInformation_OpenFile : System.Web.UI.Page
{

    MediationCaseNotesDAL MediationCaseNotesDALobj = new MediationCaseNotesDAL();
    MediationCaseNotesBAL MediationCaseNotesBAobj = new MediationCaseNotesBAL();
    MortgagorBAL MortgagorBALobj = new MortgagorBAL();
    MortgagorDAL MortgagorDALobj = new MortgagorDAL();
    MediationCaseDAL MediationCaseDALobj = new MediationCaseDAL();
    MediationCaseBAL MediationCaseBALobj = new MediationCaseBAL();

    private ReportDocument rd;
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Unload += new EventHandler(OpenFile_Unload);

        string action = string.Empty;
        if (Request["action"] != null)
            action = Request["action"];

        if (action == "401")
            CreatePdfResponseFor401();
    }

    void OpenFile_Unload(object sender, EventArgs e)
    {
        //remember to clean up
        if (rd != null)
        {
            rd.Close();
            rd.Dispose();
            Session["reportDocument"] = null;
            GC.Collect();
        }
    }

    private void CreatePdfResponseFor401()
    {
        string filePath = Request["filepath"];
        string fileName = Request["filename"];

        if (filePath == null)
            throw new ArgumentNullException("error message");

        if (fileName == null)
            throw new ArgumentNullException("error message");

        rd = Session["reportDocument"] as ReportDocument;

        if (rd == null)
        {
            throw new ArgumentNullException("error message");
        }
//   rd.SetParameterValue("MediationCaseInformationID", Convert.ToInt32(Session["MediationCaseID"].ToString()));
        rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, fileName);
       // Update14DayLetterPrintDate();

    } 

       // no use
    private void Update14DayLetterPrintDate()

    {
        {
      
            MediationCaseBAL MediationCaseBALobj = new MediationCaseBAL();
             int Mediationid=0;
            int.TryParse(Session["MediationCaseID"].ToString(),out Mediationid);
            
             MediationCaseBALobj.Update14DayLetterPrintDate(Mediationid);
           
        }
    }


}