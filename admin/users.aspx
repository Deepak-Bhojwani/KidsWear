<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/admin_master.master" CodeFile="users.aspx.cs" Inherits="Kid_s_Garment_admin_users" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
      <div style="flex-align:center">
				<h2 class="sub-title">&nbsp;</h2>
                <h2 class="sub-title">Users</h2>
			</div>
<form runat="server">
    <br />
    <center>
 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="Both">
            <AlternatingRowStyle BackColor="White"/>
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" />
                <asp:BoundField DataField="name" HeaderText="NAME" SortExpression="name" />
                <asp:BoundField DataField="email" HeaderText="EMAIL" SortExpression="email" />
                <asp:BoundField DataField="mobile" HeaderText="MOBILE" SortExpression="mobile" />
                <asp:BoundField DataField="address" HeaderText="ADDRESS" SortExpression="address" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
            
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
           ConnectionString="<%$ ConnectionStrings:cnstr %>" SelectCommand="SELECT [id],[name], [email], [mobile], [address] FROM [registration] ORDER BY [id]">
        </asp:SqlDataSource>
    <br />
        </center>
</form> 
    
    </div>
    </asp:content>
