<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.master" AutoEventWireup="true" CodeFile="show_product.aspx.cs" Inherits="Kid_s_Garment_admin_show_product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<center>
    <form id="form1" runat="server">
        <asp:DropDownList ID="cat" runat="server" AppendDataBoundItems="true" AutoPostBack="true" Width="200px" TabIndex="6" Font-Size="Medium" Font-Strikeout="False" Font-Underline="False" OnSelectedIndexChanged="cat_SelectedIndexChanged1" >
            <%--<asp:ListItem Selected="True">category</asp:ListItem>--%>
        </asp:DropDownList><br /><br />
        
        <asp:DropDownList ID="sub" runat="server" AppendDataBoundItems="true" Width="200px" AutoPostBack="True" TabIndex="7"  Font-Size="Large" Font-Strikeout="False" Font-Underline="False" OnSelectedIndexChanged="sub_SelectedIndexChanged">
            <asp:ListItem Selected="True">sub-category</asp:ListItem>
        </asp:DropDownList><br /><br />
        <br />

        <asp:GridView ID="GridView1" runat="server" CellPadding="4" Width="70%" Height="70%" AutoGenerateColumns="False" HorizontalAlign="Center" BackColor="White" BorderColor="Black" BorderStyle="Solid"
            OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" >
            <FooterStyle BackColor="White" ForeColor="#000066" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
            <RowStyle ForeColor="#000066" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />
            <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="ID">
                    <ItemTemplate>
                        <asp:Label ID="proid" runat="server" Text='<%# Eval("product_id") %>'></asp:Label>
                    </ItemTemplate>
                    <%--<EditItemTemplate>
                        <asp:Label ID="txtproid" runat="server" Text='<%# Eval("product_id") %>'></asp:Label>
                    </EditItemTemplate>--%>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
               <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="NAME">
                    <ItemTemplate>
                        <asp:Label ID="proname" Text='<% #Eval("product_name") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtname" Text='<%# Eval("product_name") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                
                    <asp:TemplateField HeaderText="IMAGE">
                        <ItemTemplate>
                            <asp:Image ID="img" runat="server" Width="150px" Height="150px" ImageUrl='<% #Eval("product_img") %>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:FileUpload ID="fu" runat="server" ImageUrl='<% #Eval("product_img") %>' />
                        </EditItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="PRICE">
                    <ItemTemplate>
                        RS.<asp:Label ID="proprice" Text='<% #Eval("product_price") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        RS.<asp:TextBox ID="txtprice" Text='<% #Eval("product_price") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="DESCRIPTION">
                    <ItemTemplate>
                        <asp:Label ID="prodisc" Text='<% #Eval("product_description") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtdisc" Text='<% #Eval("product_description") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="QUANTITY">
                    <ItemTemplate>
                        <asp:Label ID="proqty" Text='<% #Eval("product_quantity") %>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtqty" Text='<% #Eval("product_quantity") %>' runat="server"></asp:TextBox>
                    </EditItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                
                <asp:CommandField ButtonType="Button" ItemStyle-HorizontalAlign="Center" HeaderText="EDIT" ShowEditButton="True" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:CommandField>
                <asp:CommandField ButtonType="Button" ItemStyle-HorizontalAlign="Center" HeaderText="DELETE" ShowDeleteButton="True" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:CommandField>
            </Columns>
        </asp:GridView>
        <br />
        <br />
        <br />
        <br />
        <br />
    </form>
</center>

</asp:Content>

