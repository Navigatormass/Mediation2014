using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Mediation2014Reports : System.Web.UI.MasterPage//Daily_ReportsMasterPage : System.Web.UI.MasterPage
{ 

    protected void Page_Load(object sender, EventArgs e)
    {
        string theURL = Convert.ToString(Request.Url);
        string[] arrURL = theURL.Split('/');
        string theFolder = arrURL[arrURL.Length - 2];
        bool TestEnvironment = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings.Get("TestEnvironment"));
        DateTime now = DateTime.Now;
        lblCopyRight.Text = now.Year + " Rhode Island Housing";
        if (TestEnvironment)
        {
            lblTESTEnv.Visible = true;
        }
        if (theFolder == "SearchMortgagor")
        {
            HomeContainerTab.ActiveTabIndex = 1;
        }

        else if (theFolder == "AddMortgagor")
        {
            HomeContainerTab.ActiveTabIndex = 2;
        }
        else if (theFolder == "AddMediationCaseInformation")
        {
            HomeContainerTab.ActiveTabIndex = 3;
        }

        else if (theFolder == "SpecificTask")
        {
            HomeContainerTab.ActiveTabIndex = 4;
        }
        else if (theFolder == "Maintain")
        {
            HomeContainerTab.ActiveTabIndex = 5;
        }
        else if (theFolder == "Reports")
        {
            HomeContainerTab.ActiveTabIndex = 6;
        }
        else
        {
            //HomeContainerTab.ActiveTabIndex = 0; 4/3/15 _obd
            HomeContainerTab.ActiveTabIndex = 6;
        }
    }

    protected void checkFields()
    {
        //NOT USEING AT THIS TIME
        foreach (Control c in Page.Controls)
        {
            if (c is TextBox)
            {

            }
        }
    }
}
/// <summary>
/// ////////////////////////////_obd 4/3/2015///////////////////////////////
/// </summary>
