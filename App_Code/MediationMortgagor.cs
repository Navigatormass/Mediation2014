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
using System.Collections.Generic;
using Mediation_Application;

namespace Mediation_Application
{

/// <summary>
/// Summary description for MediationMortgagor
/// </summary>
public class MediationMortgagor
{
    private SqlConnection conn=new SqlConnection
    (ConfigurationManager.ConnectionStrings["Mediation2014ConnectionString"].ConnectionString);
    commonFunctions myFunctions = new commonFunctions();
	public MediationMortgagor()
	{
		//
		// TODO: Add constructor logic here
		//
	}
   


}
}