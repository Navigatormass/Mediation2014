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

public partial class SpecificTask_SecondSentLetter : System.Web.UI.Page
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
        DataView dv = new DataView(GetPrintSecondLetterDetails);
        MediationCaseManager.DataSource = dv;
        MediationCaseManager.DataBind();
        dv = null;
    }
    private DataTable GetPrintSecondLetterDetails
    {
        get
        {
            MediationCaseBAL Mediationobj = new MediationCaseBAL();

            return Mediationobj.GetSecondLetterPrintDetails(MediationCaseInformationID);

        }
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
        DataView dv = new DataView(GetPrintSecondLetterDetails);
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
      
            MediationCaseBALobj.UpdateMediationCaseSecondLetterDate(arrayString);
          
            BindData();
        }

    }
    private void BindReport(ReportDocument crystalReport)
    {
        //updated by Odette on 2/10/15 @ 3:04 pm to call the second letter instead of the first one 
        //crystalReport.Load(Server.MapPath("~/Reports/CrystalReports/MediationFirstLetter.rpt"));
        crystalReport.Load(Server.MapPath("~/Reports/CrystalReports/MediationSecondLetter.rpt"));//_obd. 2/10/15
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
        for (int i = 0; i < GetPrintSecondLetterDetails.Columns.Count; i++)
        {
            data.Columns.Add(GetPrintSecondLetterDetails.Columns[i].ColumnName);
        }

        for (int i = 0; i < GetPrintSecondLetterDetails.Rows.Count; i++)
        {
            datarw = GetPrintSecondLetterDetails.Rows[i];
            if (selectedIndex.Contains(int.Parse(datarw["MediationCaseInformationID"].ToString())))
            {

                data.Rows.Add(datarw.ItemArray);
            }
        }
        crystalReport.SetDataSource(data);
        CrystalReportViewer1.ReportSource = crystalReport;
        Session["myReport"] = crystalReport;
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        ReportDocument crystalReport = new ReportDocument();
        BindReport(crystalReport);
        // crystalReport.PrintToPrinter(2, true, 1, 2);
        crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Crystal");
        CrystalReportViewer1.ReportSource = crystalReport;
        Response.End();
    }
    private void Page_UnLoad(object sender, EventArgs e)
    {
        //clean up
        this.CrystalReportViewer1.Dispose();
        this.CrystalReportViewer1 = null;

    }
   
}