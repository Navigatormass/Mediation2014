using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


namespace Mediation_Application
{

    /// <summary>
    /// Summary description for MediationObject
    /// </summary>
    public class AddMortgagor
    {
        public AddMortgagor()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        commonFunctions myFunctions = new commonFunctions();
        private int mortgagorInformationID;
        public int MortgagorInformationID
        {
            get { return mortgagorInformationID; }
            set { mortgagorInformationID = value;}
        }

        private String firstName;
        public String FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        private String middleInitial;
        public String MiddleInitial
        {
            get { return middleInitial; }
            set { middleInitial = value; }
        }
        private String lastName;
        public String LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        private String phone_1;
        public String Phone_1
        {
            get { return phone_1; }
            set { phone_1 = value; }
        }
        private String phone_2;
        public String Phone_2
        {
            get { return phone_2; }
            set { phone_2 = value; }
        }
        private string address_1;
        public string Address_1
        {
            get { return address_1; }
            set { address_1 = value; }
        }
        private string address_2;
        public string Address_2
        {
            get { return address_2; }
            set { address_2 = value; }
        }
        private string city;
        public string City
        {
            get { return city; }
            set { city = value; }
        }
        private string state;
        public string State
        {
            get { return state; }
            set { state = value; }
        }
        private string zipCode;
        public string ZipCode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }
        private string demographics;
        public string Demographics
        {
            get { return demographics; }
            set { demographics = value; }
        }
        private string notes;
        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }

    }
}