<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="add_to_cart.aspx.cs" Inherits="Kid_s_Garment_add_to_cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form runat="server">
        <div style="flex-align:center">
				<h2 class="sub-title">My Cart</h2>
			</div><br /><br /><br /<br />
        
        <center>
        <div style="flex-align:center">
				 <asp:Label ID="empty" CssClass="sub-title" runat="server" Text=""></asp:Label>
			</div>
            </center>
    <%--<asp:Button CssClass="btn-submit" ID="PlaceAllOrder" TabIndex="5" runat="server" Text="Submit" OnClick="PlaceAllOrder_Click" />--%>
    <asp:GridView ID="GridView1" runat="server" CellPadding="4" Width="70%" Height="70%" AutoGenerateColumns="False" HorizontalAlign="Center" BackColor="White" BorderColor="Black" BorderStyle="Solid"
        OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" DataKeyNames="pid" OnRowDeleting="GridView1_RowDeleting" >
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
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="CNO">
                <ItemTemplate>
                    <asp:Label ID="cid" runat="server" Text='<%# Eval("cno") %>'></asp:Label>
                </ItemTemplate>
                <%--<EditItemTemplate>
                    <asp:Label ID="txtcid" runat="server" Text='<%# Eval("cid") %>'></asp:Label>
                </EditItemTemplate>--%>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="NAME">
                <ItemTemplate>
                    <asp:Label ID="name" Text='<% #Eval("pname")%>' runat="server"></asp:Label>
                </ItemTemplate>

                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>

            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="PRICE">
                <ItemTemplate>
                    <asp:Label ID="price" Text='<% #Eval("price")%>' runat="server"></asp:Label>
                </ItemTemplate>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="IMAGE">
                <ItemTemplate>
                    <asp:Image ID="Image1" runat="server" Width="150px" Height="150px" ImageUrl='<%# Eval("img") %>' />
                </ItemTemplate>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            
            
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="QUANTITY">
                <ItemTemplate>
                    <asp:Label ID="qty" Text='<% #Eval("quantity")%>' runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                        <asp:TextBox ID="txtqty" Text='<% #Eval("quantity")%>' TextMode="Number" runat="server"></asp:TextBox>
                    </EditItemTemplate>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="TOTAL">
                <ItemTemplate>
                    <asp:Label ID="tot" Text='<% #Eval("total")%>' runat="server"></asp:Label>
                </ItemTemplate>

                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="ACTION">
                <ItemTemplate>
                    <asp:Button id="plcordr" runat="server" Text="Place Order" OnClick="plcordr_Click1"/>
                </ItemTemplate>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:TemplateField>
            <asp:CommandField ButtonType="Button" ItemStyle-HorizontalAlign="Center" HeaderText="EDIT" ShowEditButton="True" >
            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:CommandField>
            <asp:CommandField ButtonType="Button" ItemStyle-HorizontalAlign="Center" HeaderText="REMOVE" ShowDeleteButton="True">
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:CommandField>
        </Columns>


    </asp:GridView>
        </form>
</asp:Content>

