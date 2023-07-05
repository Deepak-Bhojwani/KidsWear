<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="view_detail.aspx.cs" Inherits="Kid_s_Garment_view_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        #name {
        color:white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form id="form1" runat="server">



        <div class="viewdetail">
            <div class="pimg">
                <asp:Image ID="product_imgLabel" runat="server" Height="200px" Width="200px" /></div>

            <div class="detail">
                <div class="pname">
                    <asp:Label ID="name" runat="server" /></div>
                <div class="pprice">Price:
                    <asp:Label ID="price" runat="server" /></div>
                <div class="pqty">Available Stock:
                    <asp:Label ID="qty" runat="server" /></div>
                <div class="pqty">Enter Quantity:
                    <asp:TextBox ID="qty1" runat="server" />
                    <asp:RequiredFieldValidator ID="user" runat="server" ControlToValidate="qty1"   
ErrorMessage="Please enter quantity" ForeColor="Red"></asp:RequiredFieldValidator>  
                </div>
                <div class="viewbtn">
                    <div></div>
                    <asp:Button CssClass="btn-add" ID="addtocart" runat="server" Text="AddToCart" OnClick="addtocart_Click" /><div></div>
                    <asp:Button ID="placeorder" CssClass="btn-place" runat="server" Text="Place Order" OnClick="placeorder_Click" /></div>
            </div>
        </div>
        <div class="description">
            <h3 style="background-color: lightgreen; margin-bottom: 20px; width: 50%;">Product Discription</h3>
            <div class="pdisc">
                <p runat="server">
                    <asp:Label ID="disc" runat="server" Font-Size="20px"></asp:Label></p>
            </div>

        </div>




    </form>
</asp:Content>

