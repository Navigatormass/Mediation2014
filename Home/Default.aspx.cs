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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool TestEnvironment = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("TestEnvironment"));
        if (TestEnvironment)
        {
            imgLogo.PostBackUrl = "http://homebasetest/";
        }
        else
        {
            imgLogo.PostBackUrl = "http://homebase/";
        } 
    }


  
    protected void AddMortgagor_Click(object sender, EventArgs e)
    {
        Response.Redirect("../AddMortgagor/Default.aspx");
    }
    protected void SearchMortgagor_Click(object sender, EventArgs e)
    {
        Response.Redirect("../SearchMortgagor/Default.aspx");
    }
    protected void SpecificTask_Click(object sender, EventArgs e)
    {
        Response.Redirect("../SpecificTask/Default.aspx");
    }
    protected void MaintainLink_Click(object sender, EventArgs e)
    {
        Response.Redirect("../MaintainLink/Default.aspx");
    }
    protected void ReportLink_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Reports/Default.aspx");
    }
}
