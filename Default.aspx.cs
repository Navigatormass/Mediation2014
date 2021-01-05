using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Linq;
using System.Xml.Linq;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Mediation_Application;
using Common;
using BAL;
using DAL;



public partial class dailyReports : System.Web.UI.Page
{
    ReportDocument theLetter = new ReportDocument();
    commonFunctions myFunctions = new commonFunctions();
    CrystalFunctions cf = new CrystalFunctions();
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime now = DateTime.Now;
        string today = now.Month + "/" + now.Day + "/" + now.Year;
        string v1;
        string v2;

        if (!IsPostBack)
        {
            txtFrEntryDate.Text = "10/06/2014";
            txtToEntryDate.Text = today;
            if (Request.QueryString.Count > 0)
            {
                v1 = Request.QueryString.Get(0);
                v2 = Request.QueryString.Get(1);
                //if (Request.QueryString.Get(1) == "Q")
                //{
                //    string url = "ReportPages/" + Request.QueryString.Get(0);
                //    Response.Redirect(url);
                //}
                
            }
        }
        else
        {
            txtFrEntryDate.Text = txtFrEntryDate.Text;
            txtToEntryDate.Text = txtToEntryDate.Text;
        }
    }
    //}
    protected void lnkDFPAll_Click(object sender, EventArgs e)
    {
        Response.Redirect("~../../ReportPages/DuplicateFeesAll.aspx");
    }
    protected void lnkACL_Click(object sender, EventArgs e)
    {
        Response.Redirect("~../../ReportPages/AppendClisting.aspx");
    }
    protected void lnkMLbL_Click(object sender, EventArgs e)
    {
        Response.Redirect("~../../ReportPages/MediationListingByLastName.aspx");
    }
    protected void lnkCPP_Click(object sender, EventArgs e)
    {
        Response.Redirect("~../../ReportPages/CappedPenaltiesPaidByServicer.aspx");
    }
    protected void lnkPFW_Click(object sender, EventArgs e)
    {
        Response.Redirect("~../../ReportPages/PenaltyFeesWaived.aspx");
    }
    protected void lnkPOS_Click(object sender, EventArgs e)
    {
        Response.Redirect("~../../ReportPages/PenaltiesOwedbyServicer.aspx");
    }
    protected void lnkInitialFee_Click(object sender, EventArgs e)
    {
        Response.Redirect("~../../ReportPages/DailyInitialFeeBalancing.aspx");
    }
    protected void lnkPenaltyFee_Click(object sender, EventArgs e)
    {
        Response.Redirect("~../../ReportPages/DailyPenaltyFee.aspx");
    }
    protected void lnkMediationFee_Click(object sender, EventArgs e)
    {
        Response.Redirect("~../../ReportPages/DailyMediationFee.aspx");
    }
    protected void lnkMFO_Click(object sender, EventArgs e)
    {
        Response.Redirect("~../../ReportPages/MediationFeesOwed.aspx");
    }
    protected void lnkGF_Click(object sender, EventArgs e)
    {
        Response.Redirect("~../../ReportPages/AppendCgoodFaith.aspx");
    }
    protected void lnkMFL_Click(object sender, EventArgs e)
    {
        Response.Redirect("~../../ReportPages/MissingFirstLetter.aspx");
    }
    protected void lnkMSL_Click(object sender, EventArgs e)
    {
        Response.Redirect("~../../ReportPages/MissingSecondLetter.aspx");
    }
    protected void lnkPDCR_Click(object sender, EventArgs e)
    {
        Response.Redirect("~../../ReportPages/PastDueConferenceResults.aspx");
    }
    protected void lnkCRNC_Click(object sender, EventArgs e)
    {
        Response.Redirect("~../../ReportPages/CaseResolvedNoCert.aspx");
    }
    protected void lnkPSMC_Click(object sender, EventArgs e)
    {
        Response.Redirect("~../../ReportPages/PendingSchedulingMediationByCoordinator.aspx");
    }
    protected void lnkCWCC_Click(object sender, EventArgs e)
    {
        Response.Redirect("~../../ReportPages/CasesNoCertificateContacts.aspx");
    }
    protected void lnkCWSC_Click(object sender, EventArgs e)
    {
        Response.Redirect("~../../ReportPages/CasesNoServicerContacts.aspx");
    }
    protected void lnkMCNC_Click(object sender, EventArgs e)
    {
        Response.Redirect("~../../ReportPages/MediationNoCertificate.aspx");
    }
    protected void lnkSMNC_Click(object sender, EventArgs e)
    {
        Response.Redirect("~../../ReportPages/ScheduledNoConference.aspx");
    }
    protected void lnkCEI_Click(object sender, EventArgs e)
    {
        Response.Redirect("~../../ReportPages/ExemptClosedInactive.aspx");
    }
    protected void lnkUMF_Click(object sender, EventArgs e)
    {
        Response.Redirect("~../../ReportPages/UnpaidMediationFee.aspx");
    }
    protected void lnkPO_Click(object sender, EventArgs e)
    {
       // Response.Redirect("~../../ReportPages/ProgramOverview.aspx");
    }
//10/2015: _obd - added link for Duplicate Cert fee report
   protected void lnkDCF_Click(object sender, EventArgs e)
    {
        Response.Redirect("~../../ReportPages/DailyDuplicateCertificateFee.aspx");
    }
//11/2015: _obd - added link for Workout Outside of Mediation fee report
   protected void lnkDWMF_Click(object sender, EventArgs e) 
    {
        Response.Redirect("~../../ReportPages/DailyWorkoutMediationFee.aspx");
    }

    protected void lnkCDO6F_Click(object sender, EventArgs e)
        {
        Response.Redirect("~../../ReportPages/CasesDefaultOver60.aspx");
        }

    protected void lnkPPBS_Click(object sender, EventArgs e)
        {
        Response.Redirect("~../../ReportPages/PenaltiesPaidByServicer.aspx");
        }

    protected void lnkPORTDMR_Click(object sender, EventArgs e)
        {
        Response.Redirect("~../../ReportPages/ProgramOverviewReportToDateManagerRevised.aspx");
        }

    protected void lnkPORTDMT_Click(object sender, EventArgs e)
        {
        Response.Redirect("~../../ReportPages/ProgramOverviewReportToDateManagerTwo.aspx");
        }
    protected void lnkMCasesConfDtes_Click(object sender, EventArgs e)
    {
        Response.Redirect("~../../ReportPages/Med14ActualConfDates.aspx");
    }


    private void Page_UnLoad(object sender, EventArgs e)
    {
        ////clean up
        Session["myReport"] = null;
        theLetter.Close();
        theLetter.Dispose();
        GC.Collect();
    }
}
