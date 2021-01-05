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
using System.Text.RegularExpressions;
//using System.Windows.Forms;
public partial class SpecificTask_NoResponse : System.Web.UI.Page
{
    /// <summary>
    /// constant fields for constants that will never change.
    /// </summary>
    private const string ASCENDING = " ASC";
    private const string DESCENDING = " DESC";
    public int MediationCaseInformationID { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    /// postback, autopostback and callback
    /// A postback is initiated by the browser, and reloads the whole page, usually when a control on the page (e.g. a button) is changed.
    /// With some controls (e.g. Checkboxes), you choose if changing the control should result in a postback. This property is called AutoPostback.
    /// A callback is initiated by java script in the page, and can load/update parts of the page, e.g. by manipulating the DOM.
    {
        if (!IsPostBack)
        {
            BindData();
          
            //lstCoordinatorName.Attributes.Add("OnBlur", "validate()");
           // btnPrint.Attributes.Add("Onclick", "Coordinator()");
      

         
           
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
        DataView dv = new DataView(GetNoResponsePrintDetails);
        MediationCaseManager.DataSource = dv;
        MediationCaseManager.DataBind();
        dv = null;
    }
    private DataTable GetNoResponsePrintDetails
    {
        get
        {
            MediationCaseBAL Mediationobj = new MediationCaseBAL();


            return Mediationobj.GetNoResponseCertificateDetails("");

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
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#ffffff'");
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
        DataView dv = new DataView(GetNoResponsePrintDetails);
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

    /// <summary>
    /// Update CertificateNoticePrintDate for all record not selected record in grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
          //  MediationCaseBALobj.UpdateMediationCaseFirstLetterDate(arrayString);
            //int CoordinatorID= 0;
            //int.TryParse(lstCoordinatorName.SelectedValue,out CoordinatorID);
            MediationCaseBALobj.UpdateCertificateNoticePrintDate(arrayString);
            
            BindData();

        }
       
    }

    
    private void BindReport(ReportDocument crystalReport)
    {
        crystalReport.Load(Server.MapPath("~/Reports/CrystalReports/Non-response.rpt"));
      
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
        //// for (int i = 0; i < dt.Columns.Count; i++)
        //for (int i = 0; i < GetNoResponsePrintDetails.Columns.Count; i++)
        //{
        //    data.Columns.Add(GetNoResponsePrintDetails.Columns[i].ColumnName);
        //}

        //for (int i = 0; i < GetNoResponsePrintDetails.Rows.Count; i++)
        //{
        //    datarw = GetNoResponsePrintDetails.Rows[i];
        //    if (selectedIndex.Contains(int.Parse(datarw["MediationCaseInformationID"].ToString())))
        //    {

        //        data.Rows.Add(datarw.ItemArray);
              
        //      // data.Rows[i]["StaffName"] = lstCoordinatorName.Text;
              
        //       //MediationCaseBALobj.GetNoResponsePrintDetails(MediationCaseInformationID, CoordinatorID);
        //      // MessageBox.Show("Enter pressed");
        //    // BindData();
        //      // crystalReport.Refresh();
        //      // MediationCaseBALobj.UpdateCoordinatorID(array,CoordinatorID);

              
                                        
        //        }
        //}
        string arrayString = string.Join(",", selectedIndex.Select(n => n.ToString()).ToArray());
        if (arrayString.Length > 0)
        {
            MediationCaseBAL MediationCaseBALobj = new MediationCaseBAL();
            int CoordinatorID = 0;
            int.TryParse(lstCoordinatorName.SelectedValue, out CoordinatorID);
            MediationCaseBALobj.UpdateCoordinatorID(arrayString, CoordinatorID);
            crystalReport.SetDataSource(MediationCaseBALobj.GetNoResponseCertificateDetails(arrayString));
        }
       // crystalReport.SetParameterValue("@MediationCaseInformationID", selectedIndex.ToArray<int>());
       


        CrystalReportViewer1.ReportSource = crystalReport;
        Session["myReport"] = crystalReport;
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
       // BindData();
       
        CrystalReportViewer1.ParameterFieldInfo.Clear();
        ReportDocument crystalReport = new ReportDocument();
        
        BindReport(crystalReport);
        // crystalReport.PrintToPrinter(2, true, 1, 2);
        //crystalReport.Refresh();
        crystalReport.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Crystal");
        CrystalReportViewer1.ReportSource = crystalReport;
        Response.End();
        
        Response.Close();
        crystalReport.Dispose();
        crystalReport.Close();
        GC.Collect();
    }
   
   


   


    private void Page_UnLoad(object sender, EventArgs e)
    {
        //clean up
        this.CrystalReportViewer1.Dispose();
        this.CrystalReportViewer1 = null;

    }





    protected void btnPrint_Click1(object sender, EventArgs e)
    {

    }
}
 


   
