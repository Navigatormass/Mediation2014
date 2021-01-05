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
using System.Xml.Serialization;
using System.Web.Services;


/// <summary>
/// Summary description for commonFunctions
/// </summary>
public class commonFunctions
{
	public commonFunctions()
	{
		//
		// TODO: Add constructor logic here
		//
	}
     public string[] getZipInfo(string ZipCode, string sqlConn)
    {
        string[] zipInfo = new string[3];
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[sqlConn].ConnectionString);

        try
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            if (ZipCode.Substring(0, 3) == "028" || ZipCode.Substring(0, 3) == "029")
            {
                cmd.CommandText = "SELECT City  FROM  RI_ZipCodes  WHERE (RI_ZipCodes.ZipCode = '" + ZipCode + "') ORDER BY RI_ZipCodes.City DESC";
               // cmd.CommandText = "SELECT RI_ZipCodes.City,  'RI' as State FROM RI_ZipCodes INNER JOIN RI_ZipCodes ON ZipCodes = RI_ZipCodes.ZipCode WHERE (RI_ZipCodes.ZipCode = '" + ZipCode + "') ORDER BY RI_ZipCodes.City DESC";

            }
            else
            {
                cmd.CommandText = "SELECT ZIPCodes.City, '' as County, States.StateAbbreviation as State FROM States RIGHT OUTER JOIN ZIPCodes ON States.StateCode = ZIPCodes.StateCode WHERE (ZIPCodes.ZIPCode = '" + ZipCode + "') ";
            }
            SqlDataReader rd = cmd.ExecuteReader();
            string City = "";
            //string State = "";
            int i = 0;
            if (rd.HasRows)
            {
                i = 1;
                while (rd.Read())
                {
                    if (i == 1)
                    {
                        City = rd.GetString(0);
                    }
                    else
                    {
                        City = City + "," +  rd.GetString(0);
                    }
                   
                    ////State = rd.GetString(1);
                    i = i + 1;
                }
            rd.Close();
            }
            zipInfo[0] = City;
            //zipInfo[1] = State;
        }
        catch
        {
        }
        finally
        {
            conn.Close();
        }
        return zipInfo;
    }

    public string formatDate(DateTime SQLsmalldatetime)
    {
        if (String.Format("{0:yyyy}", SQLsmalldatetime) == "1900")
        {
            return "";
        }
        else
        {
            return String.Format("{0:MM}", SQLsmalldatetime) + "/" + String.Format("{0:dd}", SQLsmalldatetime) + "/" + String.Format("{0:yyyy}", SQLsmalldatetime);
        }
    }

    public string formatPhone(string Phone)
    {
        if (Phone == null || Phone.Trim() == "")
        {
            return "";
        }
        else
        {
            return "(" + Phone.Substring(0, 3) + ")" + Phone.Substring(3, 3) + "-" + Phone.Substring(6, 4);
        }
    }

    public string checkForNULLs(string inString)
    {
        if (inString == null)
        {
            return "";
        }
        else
        {
            inString = inString.Trim();
            return inString.Replace("'", "");
        }
    }

    public bool isYearValid(string[] inDates)
    {
        //Checking date on mask for sql parameters
        bool isValid = true;
        foreach (string s in inDates)
        {
            if (s.Trim() == "")
            {
                //no need to check
            }
            else
            {
                string[] strDate;
                strDate = s.Split('/');
                DateTime dtToday = DateTime.Now;
                DateTime dtFuture = dtToday.AddYears(20);
                string futureYear = String.Format("{0:yyyy}", dtFuture);
                int intFutureYear = Convert.ToInt16(futureYear);
                //Changed the year from 1900 to 2000 no loads will be older than that and a problem like putting in 09 and getting 1909 will be caught.
                if (Convert.ToInt16(strDate[2]) < 2000 || Convert.ToInt16(strDate[2]) > intFutureYear)
                {
                    isValid = false;
                }
            }
        }
        return isValid;
    }

    public int[,] createRaceIDarray(CheckBoxList lstRaceID, CheckBox declined)
    {
        int[,] raceIds = new int[lstRaceID.Items.Count + 1, 2];
        int i;
        for (i = 0; i < lstRaceID.Items.Count; i++)
        {
            raceIds[i, 0] = Convert.ToInt16(lstRaceID.Items[i].Value);
            raceIds[i, 1] = Convert.ToInt16(lstRaceID.Items[i].Selected);
        }
        //Check to make sure atleast declined checked
        int y;
        bool isChecked = false;
        for (y = 0; y < raceIds.Length / 2; y++)
        {
            if (raceIds[y, 1] == 1)
                isChecked = true;
        }
        if (isChecked)
        {
            //not declined
            raceIds[lstRaceID.Items.Count, 0] = 1;
            raceIds[lstRaceID.Items.Count, 1] = 0;
        }
        else
        {
            //declined
            raceIds[lstRaceID.Items.Count, 0] = 1;
            raceIds[lstRaceID.Items.Count, 1] = 1;
        }
        return raceIds;
    }


    public string capitalizeString(string inString)
    {
        string theString = inString.Trim();
        theString = theString.Replace("'", "").ToLower();
        string[] capString = theString.Split(' ');
        string outString = "";
        if (capString.Length > 0)
        {
            for (int i = 0; i < capString.Length; i++)
            {
                outString = outString + capString[i].Substring(0, 1) + capString[i].Substring(1, capString[i].Length - 1).ToLower() + " ";
            }
        }
        return outString.Trim();
    }

     

        public string getMonth(int month)
        {
            string theMonth = "";
            switch (month)
            {
                case 1:
                    theMonth = "January";
                    break;
                case 2:
                    theMonth = "February";
                    break;
                case 3:
                    theMonth = "March";
                    break;
                case 4:
                    theMonth = "April";
                    break;
                case 5:
                    theMonth = "May";
                    break;
                case 6:
                    theMonth = "June";
                    break;
                case 7:
                    theMonth = "July";
                    break;
                case 8:
                    theMonth = "August";
                    break;
                case 9:
                    theMonth = "September";
                    break;
                case 10:
                    theMonth = "October";
                    break;
                case 11:
                    theMonth = "November";
                    break;
                case 12:
                    theMonth = "December";
                    break;
                default:
                    break;
            }
            return theMonth;
        }
  
}

