<%@ Page Title="" Language="C#" MasterPageFile="~/MediationMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="SearchMortgagor_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <table class="navTable">
            <tr>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <br />
    <div id="header2">
        Search for a Medation case to begin entering the Application&nbsp;&nbsp;&nbsp;<asp:Label
            ID="lblIdError" runat="server" Text="" CssClass="error" /><br />
    </div>
    <div class="left" style="vertical-align:top; " >
        <asp:Table ID="Table1" runat="server" Width="871px"  >
            <asp:TableRow>
                <asp:TableCell>
                    Search by Med ID:
                    <asp:TextBox ID="txtMediationCaseID" runat="server" Width="50px" TabIndex="1" />
                </asp:TableCell><asp:TableCell>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            Search by:&nbsp; 
                               <asp:Label ID="lblLastName" runat="server" Text="LastName or Address or Zipcode" ></asp:Label>
                              <asp:TextBox ID="txtsearchName" runat="server" MaxLength="30" TabIndex="4"   />
                            <%-- <asp:Label ID="lblAddress" runat="server" Text="Address:" ></asp:Label>
                            <asp:TextBox ID="txtAddress" runat="server" MaxLength="30" TabIndex="4" />
                            <asp:Label ID="lblZipcode" runat="server" Text="Zipcode:" ></asp:Label>
                            <asp:TextBox ID="txtZipcode" runat="server" MaxLength="30" TabIndex="4" />--%>
                   
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:TableCell><asp:TableCell>
                  
                     <asp:Button ID="btnSearch" runat="server" CssClass="buttonSave" 
                     OnClick="btnSearch_Click" PostBackUrl="Default.aspx" 
        TabIndex="24" Text="Search" 
                     Width="100px" />
                      <asp:Label ID="lblspace" runat="server" Width="30px" Visible="False"></asp:Label>
                <asp:Button ID="btnReset" runat="server" Text="Reset"  Width="100px"
                    CssClass="button" CausesValidation="False" TabIndex="25" OnClick="btnReset_Click" />&nbsp;
            

                </asp:TableCell></asp:TableRow></asp:Table></div><br /><br /><br />
       <%-- GridViewSearchDetails / To display the record in grid after search--%>
         <div   class="left" style="vertical-align:top; height:700px; "  >
     
        
           <asp:Label id="lbltest" runat="server"  />
             <asp:Label ID="lblNoRecords" runat="server" Text="This record  does not Exist." Font-Bold="true" ForeColor="Red" ></asp:Label><%--  </asp:GridView>--%><%-- START FIRST GRID TO DISPLAY RECORDS FROM MortgagorINFORMATION --%><asp:GridView ID="MortgagorManager"  runat="server" AllowPaging="true"  AllowSorting="true" AutoGenerateColumns="false"   
            BorderStyle="none"  cellpadding="5" CssClass="navButton"   Width="800px" DataKeyNames="MortgagorInformationID" 
           HorizontalAlign="Left"  OnRowCommand="MortgagorManager_RowCommand" OnRowDataBound="MortgagorManager_RowDataBound" OnPageIndexChanging="NewPage"
           OnSorting="MortgagorManager_Sorting" PageSize="5"  PagerStyle-BackColor="#669966" >
              <HeaderStyle BackColor="#669966"   Font-Bold="True"  ForeColor="White" />
         
           
            <Columns>
              <asp:TemplateField  ItemStyle-HorizontalAlign="Center" HeaderText="E/C">

        <ItemTemplate>
         <asp:Label ID="hidden" runat="server"  Text="Collapse" Visible="false"></asp:Label><asp:Label ID="lblID" runat="server" Text='<%#Eval("MortgagorInformationID") %>' Visible="false"></asp:Label><asp:ImageButton  ID="btnShow" runat="server" CommandArgument='<%# ((GridViewRow)Container).RowIndex %>' CommandName="Show" ImageUrl="~/images/collapse_blue.jpg" ToolTip="Expand "  />
         
        </ItemTemplate>
        </asp:TemplateField>
       
            <asp:TemplateField  ItemStyle-HorizontalAlign="Center" HeaderText="Edit Mortgagor" >
            
                <ItemTemplate >
                    
                    <asp:ImageButton ID="EditImgButton" runat="server" 
                        CommandArgument='<%# Eval("MortgagorInformationID")   %>' 
                        CommandName="EditMortgagor" ImageUrl="../images/icon_edit.gif" 
                        ToolTip="Edit this Mortgagor"  ></asp:ImageButton>
                         
                </ItemTemplate>
            </asp:TemplateField>
                   <asp:boundfield DataField="FullName" HeaderText="Mortgagor Name"  ItemStyle-HorizontalAlign="Center" 
               htmlencode="false" />
            <asp:boundfield DataField="Address_1"  ItemStyle-HorizontalAlign="Center"  HeaderText="Address"   />
                               <asp:boundfield DataField="city" HeaderText="City"    />
              
                  <asp:TemplateField  ItemStyle-HorizontalAlign="Center" HeaderText="Add Med Case" >
                   
                     <ItemTemplate  >
                    <asp:ImageButton ID="ADDImgButton" runat="server" 
                        CommandArgument='<%# Eval("MortgagorInformationID")   %>' 
                        CommandName="AddMediation" ImageUrl="../images/icon_add.gif" 
                        ToolTip="Add New Mediation Case For this Mortgagor"  />
                </ItemTemplate>
            </asp:TemplateField>
                  <asp:TemplateField HeaderText="Mediation Case Details">
            <ItemTemplate>
               <%-- SECOND GRID TO DISPLAY RECORDS FROM MediationCaseINFORMATION TABLE--%>
                 <asp:GridView ID="MediationCaseManager" OnRowCommand="MediationCaseManager_RowCommand" runat="server" AutoGenerateColumns="False" 
        AutoGenerateDeleteButton="False" AutoGenerateEditButton="False" Width="400px" PagerStyle-BackColor="#669966" >
              <HeaderStyle BackColor="#669966"   Font-Bold="True"  ForeColor="White" />
        <Columns>
            
             <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Edit Mediation" >
                <ItemTemplate>
                    <asp:ImageButton ID="EditImgButton" runat="server" 
                        CommandArgument='<%# Eval("MediationCaseInformationID")   %>' 
                        CommandName="EditMediationCase" ImageUrl="../images/icon_edit.gif" 
                        ToolTip="Edit this MedationCase"  />
                </ItemTemplate>
            </asp:TemplateField>
              <asp:BoundField DataField="MediationCaseInformationID"  ItemStyle-HorizontalAlign="Center"
               HeaderText ="Med-ID" HtmlEncode="false" SortExpression="update" />
         <asp:boundfield DataField="DefaultDate"  ItemStyle-HorizontalAlign="Center"  dataformatstring="{0:MMM d, yyyy}" 
                HeaderText="Default Date" htmlencode="false" SortExpression="udate" />
         <asp:boundfield DataField="NoticeDate"  ItemStyle-HorizontalAlign="Center" dataformatstring="{0:MMM d, yyyy}" 
                HeaderText="Notice Date" htmlencode="false" SortExpression="udate" />
         <asp:boundfield DataField="CreateDate"  ItemStyle-HorizontalAlign="Center" dataformatstring="{0:MMM d, yyyy}" 
                HeaderText="Create Date" htmlencode="false" SortExpression="udate" />
                      
               
            
            </Columns>
    <%--  END SECOND GRID--%>
    </asp:GridView>
   
            </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
       <%-- <PagerStyle CssClass="content12" />--%>
          <%--  END FIRST GRID--%>
    </asp:GridView>
    <br />
                 
</asp:Content>