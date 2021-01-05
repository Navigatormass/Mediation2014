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
    /* Start code for Mediation case grid display:
     *  This second grid, which is a sub-grid 
     * to the mortgagor grid, displays the Mediation Case details for each mortgagor.*/
    protected void MediationCaseManager_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if ((e.CommandName == "EditMediationCase"))
        {

            int MediationInformationId = int.Parse(e.CommandArgument.ToString());


            Response.Redirect("~/AddMediationCaseInformation/Default.aspx?ID=" + MediationInformationId + "&Edit=true");
        }
    }//End code for Mediation case grid display.

    protected void MortgagorManager_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        /* Start code for "Edit Mortgagor" choice:
         * After doing a search, using "Search Mortgagor" and the data is returned in the grid view. If
         * the user selects the "Edit Mortgagor" feature, then the following code gets executed.*/
        
        /*if e.CommandName equals the value of "EditMortgagor" which is CommandName on the SearchMortgagor form
          for the EditImgButton. Then using the e.CommandArgument, we parse the value from CommandName and get what is the MortgagorInformationId and the MortgagorId (int) get that MortgagorInformationId from the e.CommandArgument.*/
        if ((e.CommandName == "EditMortgagor"))
        {
            
            int MortgagorId = int.Parse(e.CommandArgument.ToString());

            /*The MortgagorId now holds the MortgagorInformationId and is appended to the URL and the value "true" is assigned to the "Edit" variable and it is also appended to the URL. The Response.Redirect calls the AddMortgagor/Default.aspx along with the appended values.*/
            Response.Redirect("~/AddMortgagor/Default.aspx?ID=" + MortgagorId + "&Edit=true");
        }// End Code for "Edit Mortgagor" choice

        /* Start code for "Edit Mediation" choice:
         * After doing a search, using "Search Mortgagor" and the data is returned in the grid view. If
         * the user instead of selecting "Edit Mortgagor" feature chooses instead the "Edit Mediation" 
         * feature then the following code gets executed.*/
        else if (e.CommandName == "AddMediation")
        {
            int MortgagorId = int.Parse(e.CommandArgument.ToString());
            Session["MortgagorInformationID"] = MortgagorId;

            Response.Redirect("~/AddMediationCaseInformation/Default.aspx");
        }//End Code for "Edit Mediation" choice 

        /* Start code for "Show" choice:
         * After doing a search, using "Search Mortgagor" and the data is returned in the grid view. If
         * the user instead of selecting any of the above choices, the grid view will simply default to
         * the display of returned data in the grid view and the far right part of the window will allow 
         * the user to expand or decrease the view of all Mediation cases that exist for each client. This
         * display is a header showing just the Med-ID, Default Date, Notice Date, Create Date.*/
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

    }//End Code for "Show" choice
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