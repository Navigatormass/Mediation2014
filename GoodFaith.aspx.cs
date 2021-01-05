//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.IO;
//using System.Data;
//using System.Configuration;
//using System.Data.SqlClient;
//using Common;
//using BAL;
//using DAL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text.RegularExpressions;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Mediation_Application;
using Common;
using BAL;
using DAL;
using System.IO;
using System.Text;


public partial class Reports_ReportPages_GoodFaith : System.Web.UI.Page
{
    GoodFaithDAL GoodFaithDALObj = new GoodFaithDAL();
    GoodFaithBAL GoodFaithBALObj = new GoodFaithBAL();
    public bool _IsPageRefreshed;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
         // BindData();

        }

    }
   

    private DataTable GetGoodFaithDetermination
    {
        get
        
        {

            GoodFaithBAL GoodFaithBALObj = new GoodFaithBAL();

            return GoodFaithBALObj.GetGoodFaithDetermination();

        }
    }

    





    protected void btnPrint_Click(object sender, EventArgs e)
    {
        int mediationCaseId;
        int.TryParse(Session["MediationCaseID"].ToString(),out mediationCaseId);
        GoodFaithDALObj.MediationCaseInformationID = mediationCaseId;
        GoodFaithDALObj.AC_Question_1 = chkQuestion1.Checked ? 1 : 0;
        GoodFaithDALObj.AC_Question_2 = chkQuestion2.Checked ? 1 : 0;
        GoodFaithDALObj.AC_Question_3 = chkQuestion3.Checked ? 1 : 0;
        GoodFaithDALObj.Question_1 = chkQuestion4.Checked ? 1 : 0;
        GoodFaithDALObj.Question_2 = chkQuestion5.Checked ? 1 : 0;
        GoodFaithDALObj.Question_3 = chkQuestion6.Checked ? 1 : 0;
        GoodFaithDALObj.Question_4 = chkQuestion7.Checked ? 1 : 0;
        GoodFaithDALObj.Question_5 = chkQuestion8.Checked ? 1 : 0;
        GoodFaithDALObj.Question_6 = chkQuestion9.Checked ? 1 : 0;
        GoodFaithDALObj.Question_7= chkQuestion10.Checked ? 1 : 0;
        GoodFaithDALObj.Question_7_Note = txtdetermination.Text.ToString();
        //GoodFaithDALObj.Document_Name = txtdetermination.Text.ToString();
        GoodFaithBALObj.AddGoodFaithDetermination(GoodFaithDALObj);
     
        printReport();
    }
  
    void printReport()
    {
         MediationCaseBAL Mediationobj = new MediationCaseBAL();
        ReportDocument crystalReport = new ReportDocument();
       
        crystalReport.Load(Server.MapPath("~/Reports/Certificates/2.rpt"));

        CrystalFunctions cf = new CrystalFunctions();
        cf.ReportsLogonToDatabase(crystalReport);

        DataTable data = Mediationobj.GetAllCertificatesDetails(Convert.ToInt32(Session["MediationCaseID"].ToString()), 2);
        crystalReport.SetDataSource(data);
       
        Session["myReport"] = crystalReport;

        string fileName = "report";
        string filePath = @"~/tmpStorage/" + fileName;

        crystalReport.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath(filePath + ".pdf"));
        Session["reportDocument"] = crystalReport;

        string script = "<script language='javascript'> window.open('OpenFile.aspx?action=401&filepath=" + filePath + "&filename=" + fileName + "');</script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "PopupCP", script, false);
       
    }

    protected void btnExit_Click(object sender, EventArgs e)
    {
        //06/30/15 Added [EditFlag=true] _Jaheda Meman to remove dublicate case after print certificate

        string rURL = "../../AddMediationCaseInformation/Default.aspx?EditFlag=true&ID=" + Session["MediationCaseID"].ToString();
        ClientScript.RegisterStartupScript(GetType(), "closePage", "<script type=\"text/JavaScript\">window.opener.location.href='" + rURL + "'; window.close();</script>");
        
}
   
}

