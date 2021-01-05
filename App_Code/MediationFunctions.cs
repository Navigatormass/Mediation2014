using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Linq;

/// <summary>
/// Summary description for MediationFunctions
/// </summary>
public class MediationFunctions
{
    SqlConnection conn= new SqlConnection(ConfigurationManager.ConnectionStrings["Mediation2014ConnectionString"].ConnectionString);
	public MediationFunctions()
	{
		//
		// TODO: Add constructor logic here
		//
	}
   

     public string MediationIdentification(string MortgagorInformationID)
        {
            string strIdentifier;
            SqlCommand cmd = conn.CreateCommand();
             cmd.CommandText ="SELECT  MortgagorInformation.FirstName + ' ' + MortgagorInformation.LastName AS Name,  MortgagorInformation.Address_1 AS Address, MortgagorInformation.City AS City FROM MortgagorInformation INNER JOIN MediationCaseInformation ON MortgagorInformation.MortgagorInformationID = MediationCaseInformation.MortgagorInformationID  ORDER BY MortgagorInformation.MortgagorInformationID";
            if (conn.State.ToString() == "Closed")
            {
                conn.Open();
            }
            SqlDataReader rd = cmd.ExecuteReader();
            if (MortgagorInformationID == "")
            {
                strIdentifier = null;
            }
            else
            {
                strIdentifier = "";
                while (rd.Read())
                {
                    if (rd["FirstName"].ToString() == "")
                    {
                   strIdentifier = strIdentifier + MortgagorInformationID.ToString();
                        strIdentifier = strIdentifier + " " + rd["Name"].ToString();
                    }
                    
                    if (rd["Address"].ToString() != "")
                    {
                        strIdentifier = strIdentifier + " at " + rd["Address"].ToString() + ", " + rd["City"].ToString();
                    }
                    if (rd["Approved"].ToString() == "")
                    {
                        strIdentifier = strIdentifier + "|sessionRed";
                    }
                    else
                    {
                        strIdentifier = strIdentifier + "|sessionGreen";
                    }
                }
            }
            rd.Close();
            conn.Close();
            return strIdentifier;
        }

}