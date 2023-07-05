<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.master" AutoEventWireup="true" CodeFile="add_cat.aspx.cs" Inherits="Kid_s_Garment_admin_add_cat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
<div>
<div>
			
			<div style="flex-align:center">
				<h2 class="sub-title">ADD CATEGORY</h2>
			</div>
			<div>
<center>
    <form id="form1" runat="server">

    <asp:DropDownList ID="cat" runat="server" AppendDataBoundItems="True" CssClass="contact" Font-Size="Medium" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="cat_name" DataValueField="cat_name" OnSelectedIndexChanged="cat_SelectedIndexChanged">
        <asp:ListItem>Select Category </asp:ListItem>
    </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DB_KGConnectionString %>" SelectCommand="SELECT [cat_name] FROM [category]"></asp:SqlDataSource>
        <br />
        <br />
        <br />
        <asp:TextBox CssClass="contact" placeholder="Enter Sub-Category" ID="sub_category" TabIndex="2" runat="server" BorderStyle="Solid"></asp:TextBox>
        <br />
        <br />
        <br />

        <asp:Button ID="submit" class="btn-submit" TabIndex="3" runat="server" Text="Submit" OnClick="submit_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;          
        <asp:Button ID="clear" class="btn-cancle" TabIndex="4" runat="server" Text="clear" OnClick="clear_Click" />
        <br />
        <br />
        
        
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" Width="70%" Height="70%" BackColor="White" BorderColor="Black" AutoGenerateColumns="False"  BorderStyle="None" BorderWidth="1px" GridLines="Vertical" HorizontalAlign="Center" 
        OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" >
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />            <Columns>
                <asp:TemplateField HeaderText="ID" >
                  <ItemTemplate>
               <asp:Label ID="lblid" runat="server" Text='<% #Eval("sub_id") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                <asp:TemplateField HeaderText="CATEGORY">
                    <ItemTemplate>
                        <asp:Label Text='<% #Eval("cat_name") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    <EditItemTemplate>
                        <asp:TextBox ID="edcat" Text='<% #Eval("cat_name") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SUB-CATEGORY">
                    <ItemTemplate>
                        <asp:Label Text='<% #Eval("sub_name") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtsubname" Text='<% #Eval("sub_name") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="EDIT">
                    <ItemTemplate>
                        <asp:Button runat="server" Text="EDIT" CommandName="Edit"/>
                    </ItemTemplate>
                     <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    <EditItemTemplate>
                        <asp:Button runat="server" Text="UPDATE" CommandName="Update"/>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DELETE">
                    <ItemTemplate>
                        <asp:Button runat="server" Text="DELETE"  CommandName="Delete"/>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    <EditItemTemplate>
                        <asp:Button runat="server" Text="CANCLE" CommandName="Cancle"/> 
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        
        <br />
        <br />
    </form>

 </center>
</div>
</div>
</div>
	<!-- //contact -->
    
    </div>
</asp:Content>


