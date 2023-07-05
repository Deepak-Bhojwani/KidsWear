<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="product.aspx.cs" Inherits="Kid_s_Garment_shirts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
   
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <center>
     <div style="border:1px";>
    
    
    <asp:DataList ID="DataList1" runat="server" AlternatingItemStyle-HorizontalAlign="Center" RepeatColumns="5" DataSourceID="SqlDataSource1">
        
    <AlternatingItemStyle HorizontalAlign="Center"></AlternatingItemStyle>
        <ItemTemplate>

            <table border="1" style="padding:10px;margin-left:20px; text-align:center;">
                <tr>
                    <td style="border:none"><asp:Image ID="product_imgLabel" runat="server" Height="200px" Width="200px" ImageUrl='<%# Eval("product_img") %>' /></td></tr>
                <tr>
                    <td style="border:none"><asp:Label ID="product_nameLabel" runat="server" Text='<%# Eval("product_name") %>' /></td>
                </tr>
                <tr>
                    <td style="border:none">Price: <asp:Label ID="product_priceLabel" Text='<%# Eval("product_price") %>' runat="server" /></td>
                </tr>
                <tr>
                    <td style="border:none;">Quantity: <asp:Label ID="product_quantityLabel" runat="server" Text='<%# Eval("product_quantity") %>' /></td>
                </tr>
                <tr>
                    <td style="border:none;"><button id="btn" onclick="btn_click"><a href='view_detail.aspx?pid=<%# Eval("product_id") %>'>View Detail</a></button></td>
                </tr>
            </table>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        </ItemTemplate>
        
        </asp:DataList>
    
    </div>   
    </center>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DB_KGConnectionString %>" SelectCommand="SELECT [product_id],[product_img], [product_name], [product_price], [product_quantity] FROM [product] WHERE (([product_category] = @product_category) AND ([product_subcat] = @product_subcat))">
        <SelectParameters>
            <asp:QueryStringParameter Name="product_category" QueryStringField="cat" Type="String" />
            <asp:QueryStringParameter Name="product_subcat" QueryStringField="sub" Type="String"  />
        </SelectParameters>
</asp:SqlDataSource>
</asp:Content>

