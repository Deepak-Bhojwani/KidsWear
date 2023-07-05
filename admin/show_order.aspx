<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin_master.master" AutoEventWireup="true" CodeFile="show_order.aspx.cs" Inherits="Kid_s_Garment_admin_show_order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
    <form id="form1" runat="server">
        
        

        <asp:GridView ID="GridView1" runat="server" CellPadding="4" Width="70%" Height="70%" AutoGenerateColumns="False" HorizontalAlign="Center" BackColor="White" BorderColor="Black" BorderStyle="Solid"
              ShowFooter="True" >
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
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="ORDER NO.">
                    <ItemTemplate>
                        <asp:Label ID="no" runat="server" Text='<%# Eval("fono") %>'></asp:Label>
                    </ItemTemplate>
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

               <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="ORDER DATE">
                    <ItemTemplate>
                        <asp:Label ID="date" Width="80px" Text='<% #Eval("fodate")%>' runat="server"></asp:Label>
                    </ItemTemplate>
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

                   <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="PRODUCT NAME">
                    <ItemTemplate>
                        <asp:Label ID="name" runat="server" Text='<%# Eval("pname") %>'></asp:Label>
                    </ItemTemplate>
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="PRICE">
                    <ItemTemplate>
                        RS.<asp:Label ID="price" Text='<% #Eval("price")%>' runat="server"></asp:Label>
                    </ItemTemplate>
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

                    <asp:TemplateField HeaderText="IMAGE">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" Width="150px" Height="150px" ImageUrl='<%# Eval("img") %>'/>
                        </ItemTemplate>
<ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="DISCRIPTION">
                        <ItemTemplate>
                            <asp:Label ID="desc" Text='<% #Eval("description")%>' runat="server"></asp:Label>
                        </ItemTemplate>
<ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>

                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="QUANTITY">
                    <ItemTemplate>
                        <asp:Label ID="qty" Text='<% #Eval("quantity")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="USER NO.">
                    <ItemTemplate>
                        <asp:Label ID="uno" Text='<% #Eval("uno")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="USER NAME">
                    <ItemTemplate>
                        <asp:Label ID="uname" Text='<% #Eval("uname")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="CONTACT NO.">
                    <ItemTemplate>
                        <asp:Label ID="contact" Text='<% #Eval("contact")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="DELIVERY ADDRESS">
                    <ItemTemplate>
                        <asp:Label ID="address" Text='<% #Eval("address")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="TOTAL AMOUNT">
                    <ItemTemplate>
                        RS.<asp:Label ID="tot" Text='<% #Eval("total")%>' runat="server"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                    
                </asp:TemplateField>
                
                <%--<asp:CommandField ButtonType="Button" ItemStyle-HorizontalAlign="Center" HeaderText="CANCLE ORDER" ShowDeleteButton="True" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:CommandField>--%>
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

