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

public partial class SpecificTask_FirstSentLetter : System.Web.UI.Page
{
    /// <summary>
    /// constant fields for constants that will never change.
    /// </summary>
    private const string ASCENDING = " ASC";
    private const string DESCENDING = " DESC";

    protected void Page_Load(object sender, EventArgs e)
    /// postback, autopostback and callback
    /// A postback is initiated by the browser, and reloads the whole page, usually when a control on the page (e.g. a button) is changed.
    /// With some controls (e.g. Checkboxes), you choose if changing the control should result in a postback. This property is called AutoPostback.
    /// A callback is initiated by java script in the page, and can load/update parts of the page, e.g. by manipulating the DOM.
    {
        if (!IsPostBack)
        {
            BindData();
        }

    }
    /// <summary>
    /// Object Sender is a parameter called Sender that contains a reference to the control/object that raised the event.
    /// EventArgs e is a parameter called e that contains the event data, see the EventArgs MSDN page for more information.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //BindData();
    }

    /// <summary>
    /// to fill the first letter sent grid on the specific task first letter sent page
    /// </summary>
    private void BindData()
    {
        //DataView dv = new DataView(dt);
        DataView dv = new DataView(GetPrintFirstLetterDetails);
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
    /// <summary>
    /// This is gridview 669966 formatting
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
        DataView dv = new DataView(GetPrintFirstLetterDetails);
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

    // To fill out the data in grid .Search by Date . Not in page load.
    //private DataTable dt
    //{

    //    get
    //    {
    //        MediationCaseBAL Mediationobj = new MediationCaseBAL();

    //        if (txtFromNoticeDate.Text != "" && txtToNoticeDate.Text != "")

    //            return Mediationobj.GetAllNoticebyNoticeDate(DateTime.Parse(txtFromNoticeDate.Text.ToString()), DateTime.Parse(txtToNoticeDate.Text.ToString()));
    //        else
    //            return Mediationobj.GetAllNoticebyNoticeDate(DateTime.MinValue, DateTime.MinValue);
    //    }
    //}
    /// <summary>
    /// To fill out the grid on page load when first letter sent is null
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    private DataTable GetPrintFirstLetterDetails
    {
        get
        
        {
            MediationCaseBAL Mediationobj = new MediationCaseBAL();

           return Mediationobj.GetFirstLetterPrintDetails(MediationCaseInformationID);

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
            MediationCaseBALobj.UpdateMediationCaseFirstLetterDate(arrayString);
            BindData();
        }

    }

    /// <summary>
    ///  To print the first letter .
    /// </summary>
    /// <param name="crystalReport"></param>
    //private void BindReport(ReportDocument crystalReport)
    //{
    //    crystalReport.Load(Server.MapPath("~/Report/MediationFirstLetter.rpt"));
    //    DataTable data = null;
    //    DataRow datarw = null;
    //    data = new DataTable();
    //    List<int> selectedIndex = new List<int>();


    //    foreach (GridViewRow row in MediationCaseManager.Rows)
    //    {
    //        CheckBox check = (CheckBox)row.FindControl("chk");

    //        if (check.Checked == true)
    //        {
    //            Label SelectedId = (Label)row.FindControl("MediationCaseInformationID");
    //            selectedIndex.Add(int.Parse(SelectedId.Text.ToString()));
    //        }
    //    }
    //    for (int i = 0; i < dt.Columns.Count; i++)
    //    {
    //        data.Columns.Add(dt.Columns[i].ColumnName);
    //    }

    //    for (int i = 0; i < dt.Rows.Count; i++)
    //    {
    //        datarw = dt.Rows[i];
    //        if (selectedIndex.Contains(int.Parse(datarw["MediationCaseInformationID"].ToString())))
    //        {

    //            data.Rows.Add(datarw.ItemArray);
    //        }
    //    }
    //    crystalReport.SetDataSource(data);
    //    CrystalReportViewer1.ReportSource = crystalReport;
    //}
private void BindReport(ReportDocument crystalReport)
    {
        // ShowAlert("This record   already Exists ");
        crystalReport.Load(Server.MapPath("~/Reports/CrystalReports/MediationFirstLetter.rpt"));
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
            for(int i = 0;i< GetPrintFirstLetterDetails.Columns.Count;i++)

        {
            data.Columns.Add(GetPrintFirstLetterDetails.Columns[i].ColumnName);
        }

            for (int i = 0; i < GetPrintFirstLetterDetails.Rows.Count; i++)
        {
            datarw = GetPrintFirstLetterDetails.Rows[i];
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

    public int MediationCaseInformationID { get; set; }

    //protected void Page_Init(object sender,EventArgs e)

    //{
    //    if Session["myReport"]==null)
    //    {
    //        BindReport()
    //    }
    //    else
    //    {
    //        crystalReport=ReportDocument)Session["myReport"];
    //    }
    

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