using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CrystalDecisions.CrystalReports.Engine;


///  Crystal Functions
///  
public class CrystalFunctions
{
    public CrystalFunctions()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void ReportsLogonToDatabase(ReportDocument crystalReport)
    {
        string userID = ConfigurationSettings.AppSettings.Get("databaseUserID");
        string password = ConfigurationSettings.AppSettings.Get("databasePassword");
        string serverName = ConfigurationSettings.AppSettings.Get("databaseServerName");
        string databaseName = ConfigurationSettings.AppSettings.Get("databaseName");
        CrystalDecisions.Shared.TableLogOnInfo databaseLogon;
        CrystalDecisions.Shared.ConnectionInfo databaseConnInfo = new CrystalDecisions.Shared.ConnectionInfo();
        databaseConnInfo.ServerName = serverName;
        databaseConnInfo.DatabaseName = databaseName;
      databaseConnInfo.UserID = userID;
        databaseConnInfo.Password = password;
        //apply the conn to report
        
        Tables  Mediation2014;
        Mediation2014 = crystalReport.Database.Tables;
        foreach (CrystalDecisions.CrystalReports.Engine.Table table in Mediation2014)
        {
            databaseLogon = table.LogOnInfo;
            databaseLogon.ConnectionInfo = databaseConnInfo;
            table.ApplyLogOnInfo(databaseLogon);
        }
    }
}
