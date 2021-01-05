using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using CrystalDecisions.CrystalReports.Engine;
using Mediation_Application;
using Common;
using BAL;
using DAL;

public partial class Mediation2014Reports : System.Web.UI.Page
    {
    ReportDocument theLetter = new ReportDocument();
    commonFunctions myFunctions = new commonFunctions();
    protected void Page_Init(object sender, EventArgs e)
        {
        if (Session["myReport"] == null)
            {
            //The report hasn't been created yet, continue
            BindReport(theLetter);
            }
        else
            {
            //The report has already been created.
            //Load it from the Session to avoid page reloading
            theLetter = (ReportDocument)Session["myReport"];
            }

        dailyReportViewer.ReportSource = theLetter;
        }

    protected void Page_Load(object sender, EventArgs e)
        {
        }

    private void BindReport(ReportDocument crystalReport)
        {
        crystalReport.Load(Server.MapPath("~/Reports/CrystalReports/ProgramOverviewReportToDateManagerRevised.rpt"));

        //the following two lines allows the reports to logon to the db using the code in crystalfunctions.cs file. _obd
        CrystalFunctions cf = new CrystalFunctions();
        cf.ReportsLogonToDatabase(crystalReport);
        //MediationCaseBAL Mediationobj = new MediationCaseBAL();

        //DataTable data = Mediationobj.GetMediation2014Reports();
        //crystalReport.SetDataSource(data);
        Session["myReport"] = crystalReport;
        }


    private void Page_UnLoad(object sender, EventArgs e)
        {
        //clean up
        Session["myReport"] = null;
        theLetter.Close();
        theLetter.Dispose();
        GC.Collect();
        }
    }