using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class SpecificTask_NoPenaltyPayment : System.Web.UI.Page
{
    /// <summary>
    /// constant fields for constants that will never change.
    /// </summary>
    private const string ASCENDING = " ASC";
    private const string DESCENDING = " DESC";

    public int MediationCaseInformationID { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
        }
    }

    private void BindData()
    {
        //DataView dv = new DataView(dt);
        DataView dv = new DataView(GetPrintLetterDetails);
        MediationCaseManager.DataSource = dv;
        MediationCaseManager.DataBind();
        dv = null;
    }

    protected void MediationCaseManager_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if ((e.CommandName == "EditPage"))
        {
            string[] CommandArgsEdit = e.CommandArgument.ToString().Split(new char[] { ',' });
            int MediationCaseInformationID = int.Parse(CommandArgsEdit[0].ToString());
            Response.Redirect("EditPage.aspx?Pageid=" + MediationCaseInformationID);
        }

    }

    protected void MediationCaseManager_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //First, make sure we're not dealing with a Header or Footer row
        if (e.Row.RowType == DataControlRowType.DataRow)
        //Data row mouseover changecolor
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#669966'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffffff'");

        }
    }

    public System.Web.UI.WebControls.SortDirection GridViewSortDirection
    {
        get
        {
            if (ViewState["sortDirection"] == null)
                ViewState["sortDirection"] = System.Web.UI.WebControls.SortDirection.Ascending;
            return (System.Web.UI.WebControls.SortDirection)ViewState["sortDirection"];
        }
        set
        {
            ViewState["sortDirection"] = value;
        }
    }

    /// <summary>
    /// This is grid view sorting.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// 
    private void SortListView(string sortExpression, string direction)
    {
        DataView dv = new DataView(GetPrintLetterDetails);
        dv.Sort = sortExpression + direction;
        MediationCaseManager.DataSource = dv;
        MediationCaseManager.DataBind();
        dv = null;
    }

    protected void MediationCaseManager_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = e.SortExpression;

        if (GridViewSortDirection == System.Web.UI.WebControls.SortDirection.Ascending)
        {
            GridViewSortDirection = System.Web.UI.WebControls.SortDirection.Descending;
            SortListView(sortExpression, DESCENDING);


        }

        else
        {
            GridViewSortDirection = System.Web.UI.WebControls.SortDirection.Ascending;
            SortListView(sortExpression, ASCENDING);
        }
    }

    private DataTable GetPrintLetterDetails
    {
        get
        {
            MediationCaseBAL Mediationobj = new MediationCaseBAL();
            return Mediationobj.GetPenaltyPaymentLetterPrintDetails(MediationCaseInformationID);
        }
    }

    protected void MediationCaseManager_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        MediationCaseManager.PageIndex = e.NewPageIndex;
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        {
            List<int> selectIndex = new List<int>();
            foreach (GridViewRow row in MediationCaseManager.Rows)
            {
                CheckBox check = (CheckBox)row.FindControl("chk");
                if (check.Checked == true)
                {
                    Label SelectedID = (Label)row.FindControl("MediationCaseInformationID");
                    selectIndex.Add(int.Parse(SelectedID.Text.ToString()));
                }
            }
            string arrayString = string.Join(",", selectIndex.Select(n => n.ToString()).ToArray());
            MediationCaseBAL MediationCaseBALobj = new MediationCaseBAL();
            MediationCaseBALobj.UpdateMediationCasePenaltyPaymentDate(arrayString);
            BindData();
        }

    }

    private void BindReport(ReportDocument crystalReport)
    {
        // ShowAlert("This record   already Exists ");
        crystalReport.Load(Server.MapPath("~/Reports/CrystalReports/MediationPenaltyPayment.rpt"));
        CrystalFunctions cf = new CrystalFunctions();
        cf.ReportsLogonToDatabase(crystalReport);
        DataTable data = null;
        DataRow datarw = null;
        data = new DataTable();
        List<int> selectedIndex = new List<int>();

        foreach (GridViewRow row in MediationCaseManager.Rows)
        {
            CheckBox check = (CheckBox)row.FindControl("chk");

            if (check.Checked == true)
            {
                Label SelectedId = (Label)row.FindControl("MediationCaseInformationID");
                selectedIndex.Add(int.Parse(SelectedId.Text.ToString()));
            }
        }
        // for (int i = 0; i < dt.Columns.Count; i++)
        for (int i = 0; i < GetPrintLetterDetails.Columns.Count; i++)
        {
            data.Columns.Add(GetPrintLetterDetails.Columns[i].ColumnName);
        }

        // Paul Piacitelli: Added code and commented out for loop below to increase speed of function.
        // Change prevents all results from being looped through, only looping though selected cases
        foreach(int si in selectedIndex)
        {
            DataRow[] dr = GetPrintLetterDetails.Select("MediationCaseInformationID = " + si.ToString());
            if (dr.Length > 0)
            {
                data.Rows.Add(dr[0].ItemArray);
            }
        }

        //for (int i = 0; i < GetPrintLetterDetails.Rows.Count; i++)
        //{
        //    datarw = GetPrintLetterDetails.Rows[i];
        //    if (selectedIndex.Contains(int.Parse(datarw["MediationCaseInformationID"].ToString())))
        //    {

        //        data.Rows.Add(datarw.ItemArray);
        //    }
        //}

        crystalReport.SetDataSource(data);
        CrystalReportViewer1.ReportSource = crystalReport;
        Session["myReport"] = crystalReport;
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        // ShowAlert("Here 0");
        ReportDocument crystalReport = new ReportDocument();
        // ShowAlert("Here 1");
        BindReport(crystalReport);
        // ShowAlert("Here 2");
        //PrintOptions myPrintOptions = crystalReport.PrintOptions;
        //crystalReport.PrintToPrinter(2, true, 1, 2);
        //crystalReport.PrintToPrinter(1, true, 0, 0);

        crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Crystal");
        //ShowAlert("Here 3");
        //crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Crystal");
        // CrystalReportViewer1.ReportSource = crystalReport;
        Response.End();
        Response.Close();
        crystalReport.Dispose();
        crystalReport.Close();
        GC.Collect();
        //ShowAlert(Server.MapPath("~\\Reports\\CrystalReports\\MediationFirstLetter.rpt"));
    }

    private void Page_UnLoad(object sender, EventArgs e)
    {
        ReportDocument crystalReport = new ReportDocument();
        //clean up
        this.CrystalReportViewer1.Dispose();
        this.CrystalReportViewer1 = null;
        {
            if (crystalReport != null)
            {
                // crystalReport.Close();
                //crystalReport.Dispose();
                GC.Collect();
            }
        }
        //crystalReport.Close();
    }
    public void ShowAlert(string msg)
    {

        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        sb.Append("<script type = 'text/javascript'>");

        sb.Append("window.onload=function(){");

        sb.Append("alert('");

        sb.Append(msg);

        sb.Append("')};");

        sb.Append("</script>");

        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
    }
}