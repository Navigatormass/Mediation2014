<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DupeFees.aspx.cs" Inherits="SpecificTask_DuplicateCertificateReprintFee" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="df1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Duplicate Certificate Fees</title>
      <meta http-equiv="X-UA-Compatible" content="IE=Edge" />
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link rel="Stylesheet" href="App_Themes/RIHskin/StyleSheetMediation.css" type="text/css" />
    <link rel="Stylesheet" href="App_Themes/RIHskin/StyleSheet.css" type="text/css" />
      <link rel="Stylesheet" href="App_Themes/RIHskin/tabs.css" type="text/css" />
      <link rel="Stylesheet" href="App_Themes/RIHskin/Calender.css" type="text/css" />



    <style type="text/css">

        .dfForm {
            font-size: 9pt;
            color: #000000;
            /*padding-left: 10px;
            padding-right: 20px;
            vertical-align: top;*/
            height: auto;
            width: 300px;
        }

        .dfChoices {
            width: auto;
            height: auto;
            border: groove 2px;
            background-color: #FFFFFF;
            font-size: 10pt;
            padding-left: 10px;
            line-height: 10px;
        }

        .dfTitle {
            background-color:#669966;
            font-size: 9pt;
	        font-weight:bold;
            height: auto;
            padding-left: 5px;
            /*border-bottom: solid 1px #000000;
            border-left: solid 1px #000000;
            border-right: solid 1px #000000;
            border-top: solid 1px #000000;
            margin-top: 0;
            width: auto;*/
            /*margin-left:180px;*/
            font-family: Verdana, Geneva, sans-serif;
        }

        .dfIndent {
            text-indent: -1.5em;
            padding-left: 1.5em;
        }

        .dfDIV {
            width: 350px;
            height: auto;
        }

        .dfCertTitle {
            height: 0px;
        }
        .auto-style1 {
            width: 183px;
        }
        .auto-style2 {
            width: 123px;
        }
    </style>


</head>
<%--<body  onunload="window.opener.location=window.opener.location;"> --%>
<body>

    <form id="form1" runat="server" method="post">
        <div class="dfDIV">   
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>                                 
               <div class="dfTitle">
                   Who is paying to reprint this certificate? 
               </div>
            <table style="width: 100%;" border="1">
                <tr>
                    <td colspan="2">
            
          <asp:RadioButtonList ID="RadioButtonList1" runat="server"
                RepeatDirection="Horizontal" RepeatLayout="Table" ToolTip="Choose who is paying the reprint fee">
                <asp:ListItem Text="1. Lender" Value="1"></asp:ListItem>
                <asp:ListItem Text="2. RI Housing" Value="2"></asp:ListItem>
            </asp:RadioButtonList>
                       
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"> &nbsp;<asp:Label ID="lblFeeReceivedDate" runat="server" Text="Fee Received Date:  "></asp:Label>    
                    </td>
                    <td class="auto-style1"><asp:TextBox ID="txtFeeReceived" runat="server" Width="192px" ToolTip="Click to display the calendar" Height="16px" style="margin-left: 2px" />
                         <df1:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFeeReceived" Mask="99/99/9999" MaskType="Date" ClearMaskOnLostFocus="False" />
           <df1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFeeReceived" Format="MM/dd/yyyy" />

                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
            <asp:Button ID="btnDupeOK" runat="server" Text="OK" OnClick="btnDupeOK_Click" />

                    </td>
                    <td class="auto-style1">
            <asp:Button ID="btnDupeCancel" runat="server" Text="Cancel/Exit" OnClick="btnDupeCancel_Click" style="text-align:left" Width="85px" />
                    &nbsp; 
            <asp:button id="btnPrintRpt" runat="server" Text="Print Report" OnClick="btnDupePrint_Click" Visible="False" style="text-align:left" Width="85px" />
                    </td>
                </tr>
            </table>
             <br /> <br /> 
            <div style="text-align:center; font-weight:bold; background-color:lightgray;">
            <asp:Label ID="lblDupeFeeMsg" runat="server" ></asp:Label>              <br />  </div> 
            <br /> 


        </div>
        <div>
        </div>

    </form>


</body>
</html>
