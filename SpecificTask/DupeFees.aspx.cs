//10/1/2015 _obd: created to capture choice for duplicate fees 
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

public partial class SpecificTask_DuplicateCertificateReprintFee : System.Web.UI.Page
{
  
    DuplicateFeeDAL DuplicateFeeDALObj = new DuplicateFeeDAL();
    DuplicateFeeBAL DuplicateFeeBALObj = new DuplicateFeeBAL();

    public bool _IsPageRefreshed;
    static string prevPage = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (txtFeeReceived.Text == "")
            txtFeeReceived.Text = DateTime.Now.ToShortDateString();
        lblDupeFeeMsg.Visible = false;
        btnPrintRpt.Visible = false;

        if (!IsPostBack)
        {
            // BindData();
        }
    }
    private DataTable GetDuplicateFees
    {
        get
        {
            DuplicateFeeBAL DuplicateFeeBALObj = new DuplicateFeeBAL();
            return DuplicateFeeBALObj.GetDuplicateFee();
        }
    }

    public void ShowAlert(string msg)
    {
        string jScript = "alert('" + msg + "');";
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), jScript, true);
    }

    protected void btnDupeOK_Click(object sender, EventArgs e)
    {
        int dfAddReturnValue, mediationCaseId, certificateid, selectedChoice = 0; //paymenttypeid
        decimal feeAmt = 0;  //fee amount 

       if (Request.Form["RadioButtonList1"] != null)
        {
         //   string selectedPayee = Request.Form["RadioButtonList1"].ToString();
            int.TryParse(Request.Form["RadioButtonList1"].ToString(), out selectedChoice);
            //    lblDupeFeeMsg.Text = selectedPayee;
           if (selectedChoice == 1)
               feeAmt = 25;
         }

       if (selectedChoice == 0)
       {
           ShowAlert("Please select who is paying before reprinting the certificate.");
           return;
        }
       int.TryParse(Request.QueryString["certID"], out certificateid);
       int.TryParse(Request.QueryString["caseID"], out mediationCaseId);
       // int.TryParse(Session["MediationCaseID"].ToString(), out mediationCaseId);
        DuplicateFeeDALObj.MediationCaseInformationID = mediationCaseId;
        DuplicateFeeDALObj.DuplicateFeePaymentTypeID = selectedChoice;
        DuplicateFeeDALObj.FeeReceivedDate = DateTime.Parse(txtFeeReceived.Text);
        DuplicateFeeDALObj.FeeAmount = feeAmt;
        dfAddReturnValue = DuplicateFeeBALObj.AddDuplicateFee(DuplicateFeeDALObj);
        
        lblDupeFeeMsg.Visible = true;

        if (dfAddReturnValue == 1)
        {
            //            btnPrintRpt.Visible = true;
            //            lblDupeFeeMsg.Text = ("Fee Recorded! Click on Print Report to reprint the certificate.").ToString();
            lblDupeFeeMsg.Text = ("Fee Recorded! ").ToString();
            printReport(int.Parse(Request.QueryString["caseID"]), int.Parse(Request.QueryString["certID"]));      
            //11/30/2015: refresh the parent window
            ClientScript.RegisterStartupScript(typeof(Page), "refreshPage", "window.opener.location.href = window.opener.location.href;", true);
        }
        else
        {
            lblDupeFeeMsg.Text = ("A fee has already been recorded for this date and a certificate re-issued. To collect a new fee, enter a different date. If the reissued certificate was misplaced, click on the Print Report button to reprint one.").ToString();
            btnPrintRpt.Visible = true;
            return;
        }
    }

    protected void btnDupePrint_Click(object sender, EventArgs e)
    {
        printReport(int.Parse(Request.QueryString["caseID"]), int.Parse(Request.QueryString["certID"]));
    }

    void printReport(int id1, int id2)
    {
        ReportDocument crystalReport = new ReportDocument();
        crystalReport.Load(Server.MapPath("~/Reports/Certificates/" + id2 + ".rpt"));

        CrystalFunctions cf = new CrystalFunctions();
        cf.ReportsLogonToDatabase(crystalReport);

        MediationCaseBAL Mediationobj = new MediationCaseBAL();

        DataTable data = Mediationobj.GetAllCertificatesDetails(id1, id2);
        crystalReport.SetDataSource(data);        
     
        Session["myReport"] = crystalReport;

        string fileName = "report";
        string filePath = @"~/tmpStorage/" + fileName;

        crystalReport.ExportToDisk(ExportFormatType.PortableDocFormat, Server.MapPath(filePath + ".pdf"));
        Session["reportDocument"] = crystalReport;
        ClientScript.RegisterStartupScript(typeof(Page), "PopupCP", "window.open('OpenFile.aspx?action=401&filepath=" + filePath + "&filename=" + fileName + "');", true);        
    }

    protected void btnDupeCancel_Click(object sender, EventArgs e)
    {
        //close the dupe fee screen
        ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
    }
}

