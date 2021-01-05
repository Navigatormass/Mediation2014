using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Net;
using System.Xml;

/// Returm as XML Document with Census Tract Info using GeoCodeer web server lisening on port 8080

public class GeoCodeSearch
{
    public GeoCodeSearch()
    {
    }
    public XmlDocument Search(string p_Street, string p_City, string p_State, string p_Zip, string p_County, string p_matchChoices, string p_scoreThreshold, string p_searchLevel, string p_ID)
    {
        string result = "";
        XmlDocument resultXML = new XmlDocument();
        try
        {
            //p_searchLevel = Simple, Extended, or Enhanced no difference so leave blank for now
            string body = "<IGSearch>";
            body += "<Address>";
            body += "<Street>" + p_Street + "</Street>";
            body += "<City>" + p_City + "</City>";
            body += "<State>" + p_State + "</State>";
            body += "<Zipcode>" + p_Zip + "</Zipcode>";
            body += "<County>" + p_County + "</County>";
            body += "<ID>" + p_ID + "</ID>";
            body += "</Address>";
            body += "<SearchOptions>";
            body += "<ScoreThreshold>" + p_scoreThreshold + "</ScoreThreshold>";
            body += "<SearchLevel>" + p_searchLevel + "</SearchLevel>";
            body += "<ReturnMatchChoices>" + p_matchChoices + "</ReturnMatchChoices>";
            body += "<PlusSelections></PlusSelections>";
            body += "</SearchOptions>";
            body += "</IGSearch>";

            string soapReq = "<?xml version=\"1.0\" encoding=\"ISO-8859-1\" ?>";
            soapReq += "<SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\" ";
            soapReq += "SOAP-ENV:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\">";
            soapReq += "<SOAP-ENV:Body>";
            soapReq += body;
            soapReq += "</SOAP-ENV:Body>";
            soapReq += "</SOAP-ENV:Envelope>";

            string uri = ConfigurationManager.AppSettings.Get("GeoCoderPath");

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.ContentLength = soapReq.Length;
            request.ContentType = "text/xml";
            request.Method = "POST";

            StreamWriter sw = new StreamWriter(request.GetRequestStream());
            sw.Write(soapReq);
            sw.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            result = sr.ReadToEnd();
            sr.Close();
            //delete prefixes
            result = result.Replace("SOAP-ENV:", "").Replace("ig:", "");

            resultXML.LoadXml(result);

        }
        catch (Exception ex)
        {
            string error = ex.Message;
            resultXML.LoadXml("<?xml version=\"1.0\" encoding=\"ISO-8859-1\"?><Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\" encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\"><Body><IGSearchResponse><Result><ResultCode>999</ResultCode><ErrorDetail>" + error + "</ErrorDetail><ErrorDescription>GeoCoder Error</ErrorDescription></Result></IGSearchResponse></Body></Envelope>");
        }
        return resultXML;
    }

    public string getGeoTractError(string strStreet, string strCity, string strState, string strZip)
    {
        //Returns GeoCode and Error separated by a pipe
        XmlDocument searchResultsXML = Search(strStreet, strCity, strState, strZip, "", "True", "100", "Simple", "");
        string ReturnError = "";
        string tract = "";
        int score = 0;
        string resultCode = searchResultsXML.SelectSingleNode("Envelope/Body/IGSearchResponse/Result/ResultCode").InnerXml;
        string ErrorCode = searchResultsXML.SelectSingleNode("Envelope/Body/IGSearchResponse/Result/ErrorDetail").InnerXml;
        string ErrorDescription = searchResultsXML.SelectSingleNode("Envelope/Body/IGSearchResponse/Result/ErrorDescription").InnerXml;
        try
        {
            if (resultCode == "999")
            {
                ReturnError = ErrorDescription + " (" + ErrorCode + ") call IT";
            }
            else
            {
                if (resultCode == "0")
                {
                    tract = searchResultsXML.SelectSingleNode("Envelope/Body/IGSearchResponse/Geocodes/TRACT").InnerXml;
                }
                else if (resultCode == "-1")
                {
                    if (ErrorCode != "0")
                        if (ErrorDescription == "Zipcode is not in this state volume file.")
                            ReturnError = "Address not found - make sure street number is all numeric.";
                        else if (ErrorDescription == "State not licensed.")
                            ReturnError = "ERROR: Zip " + strZip + " in Rhode Island.";
                        else
                            ReturnError = "ERROR: " + ErrorDescription;
                    else
                    {
                        score = Convert.ToInt16(searchResultsXML.SelectSingleNode("Envelope/Body/IGSearchResponse/MatchInfo/MatchChoices/Record/Score").InnerXml);
                        if (score > 85)
                            tract = searchResultsXML.SelectSingleNode("Envelope/Body/IGSearchResponse/MatchInfo/MatchChoices/Record/TRACT").InnerXml;
                        else
                            ReturnError = "Address not found - make sure street number is all numeric.";
                    }
                }
                else if (resultCode == "-2")
                {
                    if (ErrorCode != "0")
                        if (ErrorDescription == "Zipcode is not in this state volume file.")
                            ReturnError = "ERROR: Zipcode not in Rhode Island.";
                        else if (ErrorDescription == "State not licensed.")
                            ReturnError = "ERROR: Zip " + strZip + " in Rhode Island.";
                        else
                            ReturnError = "ERROR: " + ErrorDescription;
                    else
                    {
                        score = Convert.ToInt16(searchResultsXML.SelectSingleNode("Envelope/Body/IGSearchResponse/MatchInfo/MatchChoices/Record/Score").InnerXml);

                        if (score > 85)
                            tract = searchResultsXML.SelectSingleNode("Envelope/Body/IGSearchResponse/MatchInfo/MatchChoices/Record/TRACT").InnerXml;
                        else
                            ReturnError = "Address not found - make sure street number is all numeric.";
                    }
                }
                else
                {
                    if (ErrorCode != "0")
                        ReturnError = "GEOCODER ERROR: " + ErrorDescription;
                    else
                    {
                        score = Convert.ToInt16(searchResultsXML.SelectSingleNode("Envelope/Body/IGSearchResponse/MatchInfo/MatchChoices/Record/Score").InnerXml);

                        if (score > 85)
                            tract = searchResultsXML.SelectSingleNode("Envelope/Body/IGSearchResponse/MatchInfo/MatchChoices/Record/TRACT").InnerXml;
                        else
                            ReturnError = "ERROR: Address not found.";
                    }
                }
            }
        }
        catch
        {
            ReturnError = "ERROR: Address not found.";
        }
        return tract + "|" + ReturnError;
    }
}
