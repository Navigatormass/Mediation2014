using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BAL;
public partial class SearchMortgagor_Default : System.Web.UI.Page
{
    private const string ASCENDING = " ASC";
    private const string DESCENDING = " DESC";
    MortgagorBAL MortgagorBALobj = new MortgagorBAL();

    protected void Page_Load(object sender, EventArgs e)
  
    {
        lblNoRecords.Visible = false;

        //if (!IsPostBack)
        //{
        //    //BindData();
        //    lblNoRecords.Visible = false;
        //}
        //else

        //    lblNoRecords.Visible = true;
    }
    protected void NewPage(object sender, GridViewPageEventArgs e)
    {
        MortgagorManager.PageIndex = e.NewPageIndex;
        BindData();
    }
    // Mediaiton Grid. This second grid which display the Mediation Case Details
    protected void MediationCaseManager_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if ((e.CommandName == "EditMediationCase"))
        {

            int MediationInformationId = int.Parse(e.CommandArgument.ToString());


            Response.Redirect("~/AddMediationCaseInformation/Default.aspx?ID=" + MediationInformationId + "&Edit=true");
        }
    }
    protected void MortgagorManager_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if ((e.CommandName == "EditMortgagor"))
        {

            int MortgagorId = int.Parse(e.CommandArgument.ToString());


            Response.Redirect("~/AddMortgagor/Default.aspx?ID=" + MortgagorId + "&Edit=true");
        }
        else if (e.CommandName == "AddMediation")
        {
            int MortgagorId = int.Parse(e.CommandArgument.ToString());
            Session["MortgagorInformationID"] = MortgagorId;

            Response.Redirect("~/AddMediationCaseInformation/Default.aspx");
        }
        else if (e.CommandName == "Show")
        {
            int index = 0;


            index = Convert.ToInt32(e.CommandArgument.ToString());
            int RowIndex = Convert.ToInt32((e.CommandArgument).ToString());
            ImageButton btn = (ImageButton)MortgagorManager.Rows[RowIndex].FindControl("btnShow");
            Label hidden = (Label)MortgagorManager.Rows[RowIndex].FindControl("hidden");
            // Label lblID = (Label)GridView1.Rows[RowIndex - 1].FindControl("Label1");
            // int row = Convert.ToInt32(lblID.Text);
            if (hidden.Text == "Expand")
            {

                //  Label lblID = (Label)gvDiscMaster.Rows[RowIndex].FindControl("lblID");
                GridView gv = (GridView)MortgagorManager.Rows[RowIndex].FindControl("MediationCaseManager");

                int id = int.Parse(((Label)MortgagorManager.Rows[RowIndex].FindControl("lblID")).Text);


                gv.DataSource = MortgagorBALobj.SearchByMediationCaseID(id);
                gv.DataBind();
                btn.ImageUrl = "../images/collapse_blue.jpg";
                hidden.Text = "Collapse";
            }
            else if (hidden.Text == "Collapse")
            {
                GridView gv = (GridView)MortgagorManager.Rows[RowIndex].FindControl("MediationCaseManager");

                int id = int.Parse(e.CommandArgument.ToString());
                btn.ImageUrl = "../images/expand_blue.jpg";
                gv.DataSource = null;
                gv.DataBind();
                hidden.Text = "Expand";
            }


        }

            }
    public SortDirection GridViewSortDirection
    {
        get
        {
            if (ViewState["sortDirection"] == null)
                ViewState["sortDirection"] = SortDirection.Ascending;

            return (SortDirection)ViewState["sortDirection"];
        }

        set { ViewState["sortDirection"] = value; }
    }
    protected void MortgagorManager_Sorting(object sender, GridViewSortEventArgs e)
    {
        string sortExpression = e.SortExpression;

        if (GridViewSortDirection == SortDirection.Ascending)
        {
            GridViewSortDirection = SortDirection.Descending;
            SortListView(sortExpression, DESCENDING);
        }
        else
        {
            GridViewSortDirection = SortDirection.Ascending;
            SortListView(sortExpression, ASCENDING);
        }
    }
    //Data binding
    private void BindData()
    {
        DataView dv = new DataView(dt);
        if (dv.Count > 0)
        {
            lblNoRecords.Visible = false;
          
        }
        else
        {
            lblNoRecords.Visible = true;
        }
        MortgagorManager.DataSource = dv;
        MortgagorManager.DataBind();
        dv = null;

    }
    private void SortListView(string sortExpression, string direction)
    {
        DataView dv = new DataView(dt);

        dv.Sort = sortExpression + direction;
        if (dv.Count > 0)
        {
            lblNoRecords.Visible = false;
        

        }
        else
        {
            lblNoRecords.Visible = true;
        }
        MortgagorManager.DataSource = dv;
        MortgagorManager.DataBind();
        dv = null;
    }
    private DataTable dt
    {
        get
        {

            int mediationid = 0;
            if (int.TryParse(txtMediationCaseID.Text.ToString(), out mediationid))
            {
                return MortgagorBALobj.SearchMortgagorDetails(txtsearchName.Text, mediationid);
            }
            else
            {
                return MortgagorBALobj.SearchMortgagorDetails(txtsearchName.Text, -1);
            }
        }
    }


    protected void MortgagorManager_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //First, make sure we're not dealing with a Header or Footer row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            GridView gv = (GridView)e.Row.FindControl("MediationCaseManager");

            int id = int.Parse(MortgagorManager.DataKeys[e.Row.RowIndex].Value.ToString());


            gv.DataSource = MortgagorBALobj.SearchByMediationCaseID(id);
            gv.DataBind();

            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#669966'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#ffffff'");
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindData();
       MortgagorManager.Visible = true;

    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtMediationCaseID.Text = "";
        txtsearchName.Text = "";
       // lblNoRecords.Text = "";
        lblNoRecords.Visible = false;
       
       MortgagorManager.Visible = false;
      

   
    }
    protected void MortgagorManager_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}