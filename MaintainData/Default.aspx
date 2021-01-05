<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="MaintainData_Default" %>


 
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>CollapsiblePanelExtender Tips </title>  
     <link rel="Stylesheet" href="App_Themes/RIHskin/StyleSheetMediation.css" type="text/css" />
    <link rel="Stylesheet" href="App_Themes/RIHskin/StyleSheet.css" type="text/css" /> 
   

   
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pHeader" runat="server" CssClass="cpHeader">
                <asp:Label ID="lblText" runat="server" />
            </asp:Panel>
 
            <asp:Panel ID="pBody" runat="server" CssClass="cpBody">
            <asp:Label ID="lblPrefix" runat="server" Text="Prefix"   Width="150px" />
                <asp:DropDownList ID="lstPrefix" runat="server" TabIndex="1" CssClass="Brlable">
                    <asp:ListItem>Mr.</asp:ListItem>
                    <asp:ListItem>Mrs.</asp:ListItem>
                    <asp:ListItem>Ms.</asp:ListItem>
                    <asp:ListItem>Dr.</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Label Id="lblFristName" runat="server" Text="FirstName" Width="150px"></asp:Label>
                <asp:TextBox ID="txtFirstName" runat="server"  Width="150px" MaxLength="30" TabIndex="2"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName"
                    CssClass="error" ErrorMessage="First Name is a required field">*</asp:RequiredFieldValidator><br />
                 <asp:Label ID="lblMiddleInitial" runat="server" Text="Middle Initial:" 
                    Width="150px"></asp:Label>
                <asp:TextBox ID="txtMidddleInitial" runat="server" MaxLength="4" Width="150px" TabIndex="3" />
                <br />
                <asp:Label ID="lblLastName" runat="server" Text="Last Name:" Width="150px"></asp:Label>
                <asp:TextBox ID="txtLastName" runat="server" MaxLength="30" Width="150px" TabIndex="4" />

                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName"
                    CssClass="error" ErrorMessage="Last Name is a required field">*</asp:RequiredFieldValidator><br />
             
            </asp:Panel>
 
<cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" TargetControlID="pBody" CollapseControlID="pHeader" ExpandControlID="pHeader"
Collapsed="true" TextLabelID="lblText" CollapsedText="Click to Show Content.." ExpandedText="Click to Hide Content.."
CollapsedSize="0">
            </cc1:CollapsiblePanelExtender>
          
</ContentTemplate>
</asp:UpdatePanel>
      
    </div>
    </form>
</body>
</html>