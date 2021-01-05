<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GoodFaith.aspx.cs" Inherits="Reports_ReportPages_GoodFaith" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Good Faith Certificate</title>
      <meta http-equiv="X-UA-Compatible" content="IE=Edge" />
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link rel="shortcut icon" href="images/favicon.ico" type="image/x-icon" />
    <link rel="Stylesheet" href="App_Themes/RIHskin/StyleSheetMediation.css" type="text/css" />
    <link rel="Stylesheet" href="App_Themes/RIHskin/StyleSheet.css" type="text/css" />
      <link rel="Stylesheet" href="App_Themes/RIHskin/tabs.css" type="text/css" />
      <link rel="Stylesheet" href="App_Themes/RIHskin/Calender.css" type="text/css" />

 

</head>
<%--<body  onunload="window.opener.location=window.opener.location;"> --%>
    <body >
    <form id="form1" runat="server">
  <%--  <div >--%>
     <table class="bd" >
            <tr>
                <td>
                 <div  class="header3" >
                     Good Faith Certificate Result           
                    <asp:Label  ID="lblGoodFaithCerti" runat="server" Text="" /></div>

                              
   <div>
      
         <div><table class="navTable3"><tr><td>Select Forclosure Authorization Reason </td> </tr></table> </div>
        <table class="dt" ><tr><td>
    <%-- <asp:DataList ID="dlGFD" runat="server" RepeatLayout="Table"  >
         <ItemTemplate>--%>
           
                       <%--  <asp:CheckBox ID="chkGFD" runat="server" />
                         <%#Eval("FirstName")%>
                        <%--  <%#Eval("Question_1")%>--%>
                         <br /><br /><asp:CheckBox ID="chkQuestion1" runat="server" Text="After two attempts by the Agency to contact the Mortgagor, the Mortgagor failed to respond to the request of the Agency to appear for the Mediation Conference or otherwise participate in the Mediation Conference" /><br /><br />
                         <asp:CheckBox ID="chkQuestion2" runat="server" text="The Mortgagor failed to comply with the requirements of R.I. Gen. Laws § 34-27-3.2."/><br /><br />
                         <asp:CheckBox ID="chkQuestion3" runat="server" text="The parties been unable to reach an agreement to renegotiate the loan in order to avoid a foreclosure through the Mediation Conference, despite the Mortgagee’s good faith efforts as noted on Attachment 1."/><br /><br />
                            
                  
                     </td></tr> </table>
        <div><table class="navTable3"><tr><td>Select Good Faith Determination </td> </tr></table> </div>
        <table class="dt" ><tr><td>
    <%-- <asp:DataList ID="dlGFD" runat="server" RepeatLayout="Table"  >
         <ItemTemplate>--%>
            
                       <%--  <asp:CheckBox ID="chkGFD" runat="server" />
                         <%#Eval("FirstName")%>
                        <%--  <%#Eval("Question_1")%>--%>
<br /><br /><asp:CheckBox ID="chkQuestion4" runat="server" Text="Mortgagee provided the Notice of Mediation Conference to the Mortgagor as required by R.I. Gen. Laws § 34-27-3.2." /><br /><br />
 <asp:CheckBox ID="chkQuestion5" runat="server" Text="Mortgagee designated an agent authorized to participate in the Mediation Conference on its behalf, and with authority to agree to a Workout Agreement on behalf of Mortgagee." /><br /><br />
 <asp:CheckBox ID="chkQuestion6" runat="server" Text="Mortgagee made reasonable efforts to respond in a timely manner to requests for information from the Mediation Coordinator, Mortgagor, or counselor assisting the Mortgagor."/><br /><br />
 <asp:CheckBox ID="chkQuestion7" runat="server" Text="Mortgagee analyzed and responded to the Workout Agreement submitted by the Mortgagor and/or Mediation Coordinator within fourteen days of the Workout Agreement."/><br /><br />
<asp:CheckBox ID="chkQuestion8" runat="server" Text="If the Mortgagee declines to accept the Mortgagor’s Workout Agreement, the Mortgagee provided written, detailed statement of its reasons for rejecting the proposal within fourteen (14) days."/><br /><br />
<asp:CheckBox ID="chkQuestion9" runat="server" Text="If the Mortgagee declines to accept the Mortgagor’s Workout Agreement, the Mortgagee offered, in writing within fourteen (14) days, to enter into an alternative work-out/disposition resolution proposal that would result in a material net financial benefit to the Mortgagor as compared to the terms of the Mortgage.
"/><br /><br />
  <asp:CheckBox ID="chkQuestion10" runat="server" Text="Other facts demonstrating Mortgagee’s good-faith [please specify]:"/><br /><br />     
                 
                     </td></tr> </table>

   </div>
                 
      
             
     <%--    </ItemTemplate>
     </asp:DataList>--%>
           </td> </tr></table>
                
                <div>
                    <table class="navTable3" >
                        <tr>
                            <td width="350px">If another determination type here:</td>
                            <td ><asp:TextBox ID="txtdetermination" runat="server" TextMode="MultiLine" Width="600px"></asp:TextBox></td>
                        </tr>
                    </table>

                </div>
                 <br />
                <div >
                     
               <asp:Button ID="btnPrint" runat="server" Text="Save & Print" OnClick ="btnPrint_Click" CssClass="bt"  />
                   
                   <asp:Button ID="btnExit" runat="server" Text="Exit" CssClass="bt" OnClick="btnExit_Click" />
              
                </div>  
      
<%--           
    </div>--%>
    </form>
    
</body>
    <%-- <asp:Button ID="Button1" runat="server" Text="Print Good Faith Certificate"  Width="300px"
                    CssClass="buttonGF" CausesValidation="False" TabIndex="25"  />--%>
     
</html>
