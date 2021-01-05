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
using System.Xml.Serialization;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Mediation_Application;
using Common;
using BAL;
using DAL;
using System.Windows.Forms;


public partial class AddMortgagor_Default : System.Web.UI.Page
{

    commonFunctions myFunctions = new commonFunctions();
    MortgagorBAL MortgagorBALobj = new MortgagorBAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        txtFirstName.Focus();

        lblAdded.Text = "";

        lblZipError.Text = "";

        if (!IsPostBack)
        {
            IDataReader reader;
            Session["EditMortgagor"] = false;
            int MortgagorID = 0;
            if (Request.QueryString["ID"] != null)
            {
                if (int.TryParse(Request.QueryString["ID"], out MortgagorID))
                {
                    Session["MortgagorInformationID"] = MortgagorID;
                    reader = MortgagorBALobj.GetMortgagorDetails(MortgagorID);
                    if (reader.FieldCount > 0)
                    {
                        if (Request.QueryString["Edit"] != null)
                        {
                            if (Request.QueryString["Edit"] == "true")
                                Session["EditMortgagor"] = true;
                            else
                                Session["EditMortgagor"] = false;

                        }

                        if (reader.Read())
                        {
                            txtFirstName.Text = reader["FirstName"].ToString();
                            txtFirstName.Enabled = false;
                            txtMiddleInitial.Text = reader["MiddleInitial"].ToString();
                            txtMiddleInitial.Attributes.Add("readonly", "readonly");
                            txtMiddleInitial.Enabled = false;
                            txtLastName.Text = reader["LastName"].ToString();
                            txtLastName.Enabled = false;
                            lstBorrowerSuffix.SelectedValue = reader["Suffix"].ToString();
                            txtAlias.Text = reader["Alias"].ToString();
                            double PhoneNo = 0;
                            double.TryParse(reader["PrimaryPhone"].ToString(), out PhoneNo);
                            txtPhoneNumber.Text = String.Format("{0:(###)###-####}", PhoneNo);
                            double CellNo = 0;
                            double.TryParse(reader["CellPhone"].ToString(), out CellNo);
                            txtCellPhone.Text = String.Format("{0:(###)###-####}", CellNo);
                            lstRace.SelectedValue = reader["RaceID"].ToString();
                            chkHispanic.Checked = Convert.ToBoolean(reader["Hispanic"]);
                            lstGender.SelectedValue = reader["Gender"].ToString();
                            txtEmail.Text = reader["Email"].ToString();
                            txtAddress_1.Text = reader["Address_1"].ToString();
                            txtAddress_1.Attributes.Add("readonly", "readonly");
                            txtAddress_2.Text = reader["Address_2"].ToString();
                            txtAddress_2.Attributes.Add("readonly", "readonly");
                            txtZipCode.Text = reader["ZipCode"].ToString();
                            txtZipCode.Enabled = false;
                            txtZipCode.Attributes.Add("readonly", "readonly");
                            txtCity.Text = reader["City"].ToString();
                            txtCity.Attributes.Add("readonly", "readonly");
                            txtCity.Enabled = false;
                            txtState.Text = reader["State"].ToString();
                            txtState.Attributes.Add("readonly", "readonly");
                            txtState.Enabled = false;
                            txtCensusTract.Text = reader["CensusTract"].ToString();
                            txtCensusTract.Attributes.Add("readonly", "readonly");

                        }

                        if (new[] { "RIHMFC\\thebert" }.Contains(Request.ServerVariables[5]))
                        {
                            txtFirstName.Enabled = true;
                            txtFirstName.Attributes.Remove("readonly");
                            txtMiddleInitial.Enabled = true;
                            txtMiddleInitial.Attributes.Remove("readonly");
                            txtLastName.Enabled = true;
                            txtLastName.Attributes.Remove("readonly");
                            txtAddress_1.Enabled = true;
                            txtAddress_1.Attributes.Remove("readonly");
                            txtAddress_2.Enabled = true;
                            txtAddress_2.Attributes.Remove("readonly");
                            txtCity.Enabled = true;
                            txtCity.Attributes.Remove("readonly");
                            txtZipCode.Enabled = true;
                            txtZipCode.Attributes.Remove("readonly");
                            txtState.Enabled = true;
                            txtState.Attributes.Remove("readonly");
                        }
                    }
                }
            }
            GetMortgagorMediationCount(MortgagorID);
            lblReminder.Text = "REMINDER: Save request data before continuing.";
        }
        else
        {
            lblAdded.Text = "";
        }

    }

    protected void btnGetCity_Click(object sender, EventArgs e)
    {
        // Clear all city date

        txtCity.Text = "";
        {
            //MessageBox.Show("Enter City");
        }
        if (txtZipCode.Text == "")
        {
            {
                // MessageBox.Show("Enter Zipcode");
            }
        }
        else
        {
            try
            {
                string[] zipInfo = myFunctions.getZipInfo(txtZipCode.Text, "Mediation2014ConnectionString");
                if (zipInfo[0].Contains(","))
                {
                    //more than one city

                    Session["zipcode"] = txtZipCode.Text;
                    SqlDataSourceCities.DataBind();
                    txtCity.Visible = false;
                    lstCities.Visible = true;


                    lblZipError.Text = "Please select the city";
                    lstCities.Focus();
                }
                else if (zipInfo[0] == "")
                {
                    lblZipError.Text = "No Zip" + txtZipCode.Text + "found";
                    txtZipCode.Text = "";
                    txtZipCode.Focus();
                }

                else
                {
                    Session["zipcode"] = "";
                    txtCity.Visible = true;
                    lstCities.Visible = false;
                    txtCity.Text = zipInfo[0];
                }

                //reset
            }
            catch (Exception e1)
            {
                lblZipError.Text = e1.Message;
            }
        }

    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        MortgagorBAL MortgagorBALobj = new MortgagorBAL();
        MortgagorDAL MortgagorDALobj = new MortgagorDAL();

        MortgagorDALobj.FirstName = txtFirstName.Text.ToString();
        txtFirstName.ReadOnly = false;
        MortgagorDALobj.MiddleInitial = txtMiddleInitial.Text.ToString();
        MortgagorDALobj.LastName = txtLastName.Text.ToString();
        MortgagorDALobj.Suffix = lstBorrowerSuffix.SelectedValue;
        MortgagorDALobj.Alias = txtAlias.Text.ToString();
        if (chkHispanic.Checked == false)
            MortgagorDALobj.Hispanic = 0;
        else
            MortgagorDALobj.Hispanic = Convert.ToInt32(chkHispanic.Checked);
        if (lstRace.SelectedIndex == -1)
            MortgagorDALobj.RaceID = 1;
        else
            MortgagorDALobj.RaceID = Convert.ToInt32(lstRace.SelectedValue);
        if (lstGender.SelectedIndex == -1)
            MortgagorDALobj.Gender = "";
        else
            MortgagorDALobj.Gender = lstGender.SelectedValue;
            MortgagorDALobj.Email = txtEmail.Text.ToString();
            MortgagorDALobj.Address_1 = txtAddress_1.Text.ToString();
            MortgagorDALobj.Address_2 = txtAddress_2.Text.ToString();
            MortgagorDALobj.ZipCode = txtZipCode.Text.ToString();
        if (txtCity.Visible == false)
            MortgagorDALobj.City = lstCities.SelectedValue;
        else
            MortgagorDALobj.City = txtCity.Text.ToString();
            MortgagorDALobj.State = txtState.Text.ToString();
            MortgagorDALobj.CensusTract = txtCensusTract.Text.ToString();
            MortgagorDALobj.PrimaryPhone = Regex.Replace(txtPhoneNumber.Text.ToString(), @"[_()\s-]", "");
            MortgagorDALobj.CellPhone = Regex.Replace(txtCellPhone.Text.ToString(), @"[_()\s-]", "");

        // This is session to store the record here . We store the data in the session to retrive in another page.
        // Session["MortgagorInformationID"] = MortgagorBALobj.AddMortgagorDetails(MortgagorDALobj);
        // TO SAVE THE DATA AFTER SERACH . WHEN YOU SEARCH , IT WILL DISPLAY GRID, WHEN YOU EDIT IN THE GRID, IT 
        //WILL DISPLAY EDIT, CLICK ON EDIT , IT WILL BRING ON ADD MORTGAGOR PAGE THEN CLICK AND HIT SAVE.

        bool EditMode;
        bool.TryParse(Session["EditMortgagor"].ToString(), out EditMode);
        if (!EditMode)
        {
            MortgagorDALobj.MortgagorInformationID = -1;

            int retVal = MortgagorBALobj.AddMortgagorDetails(MortgagorDALobj, 0);
            if (retVal == -1)
            {
                ShowAlert("This record already Exists ");
            }
            else
            {
                Session["MortgagorInformationID"] = retVal;
                MortgagorBALobj = null;
                MortgagorDALobj = null;
                lblAdded.Text = "Mortgagor has been added.";
                Response.Redirect("../AddMediationCaseInformation/Default.aspx");
            }
        }
        else
        {
            int MortgagorInformationID;
            int.TryParse(Session["MortgagorInformationID"].ToString(), out MortgagorInformationID);
            MortgagorDALobj.MortgagorInformationID = MortgagorInformationID;
            int retVal = MortgagorBALobj.AddMortgagorDetails(MortgagorDALobj, 1);
            Session["MortgagorInformationID"] = retVal;
            MortgagorBALobj = null;
            MortgagorDALobj = null;
            lblAdded.Text = "Mortgagor has been Edited.";
        }
    }

    protected void btnGetCensusTract_Click(object sender, EventArgs e)
    {
        //Use GeoCoder to get census tract
        GeoCodeSearch myGeoCodeSearch = new GeoCodeSearch();
        string tract = "";
        if (txtCity.Visible)
            tract = myGeoCodeSearch.getGeoTractError(txtAddress_1.Text, txtCity.Text, "RI", txtZipCode.Text);
        else
            tract = myGeoCodeSearch.getGeoTractError(txtAddress_1.Text, lstCities.SelectedValue, "RI", txtZipCode.Text);
        string[] geoCoderOutput = tract.Split('|');
        if (geoCoderOutput[0] != "")
        {
            txtCensusTract.Text = geoCoderOutput[0];
            lblCensusTractError.Text = "";
        }
        else
        {
            lblCensusTractError.Text = geoCoderOutput[1];
            txtCensusTract.Text = "";
        }
    }


    private void clearFields()
    {
        txtFirstName.Text = "";
        txtMiddleInitial.Text = "";
        txtLastName.Text = "";
        lstBorrowerSuffix.SelectedIndex = -1;
        txtAddress_1.Text = "";
        txtAddress_2.Text = "";
        txtZipCode.Text = "";
        txtCity.Text = "";
        lstCities.SelectedIndex = -1;
        txtCensusTract.Text = "";
        lstRace.SelectedIndex = -1;
        lstGender.SelectedIndex = -1;
        chkHispanic.Checked = false;
        txtPhoneNumber.Text = "";
        txtCellPhone.Text = "";
        txtEmail.Text = "";
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

    public void GetMortgagorMediationCount(int MortgagorInformationID)
    {
        txtMediationCaseCount.Text = MortgagorBALobj.GetMortgagorMediationCount(MortgagorInformationID).ToString();
    }
}