<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="profile.aspx.cs" Inherits="Kid_s_Garment_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../StyleSheet.css" rel="stylesheet" />
    <form id="form1" runat="server">
    <div>
        <div style="flex-align:center">
				<h2 class="sub-title">PROFILE</h2>
			</div>
              
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
                <center>
                <table style="font-family:Georgia; font-size:20px;margin:10%;">
                    <h2><a class="contact-form" href="edit_profile.aspx">Edit Profile</a></h2>
            </HeaderTemplate>
             
            <ItemTemplate>
               <tr>
                <td class="prf-td"><asp:Label ID="Label4" runat="server" Text="Name: "></asp:Label></td>
                <td class="prf-td"><asp:Label ID="Label1" runat="server" Text='<% #Eval("name") %>'></asp:Label></td>
               </tr>

                <tr>
                <td class="prf-td"><asp:Label ID="Label7" runat="server" Text="Email: "></asp:Label></td>
                <td class="prf-td"><asp:Label ID="Label8" runat="server" Text='<% #Eval("email") %>'></asp:Label></td>
               </tr>
                
                <tr>
                    <td class="prf-td"><asp:Label ID="Label5" runat="server" Text="Mobile: "></asp:Label></td>
                <td class="prf-td"><asp:Label ID="Label2" runat="server" Text='<% #Eval("mobile") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td class="prf-td"><asp:Label ID="Label6" runat="server" Text="Address:  "></asp:Label></td>
                    <td class="prf-td"><asp:Label ID="Label3" runat="server" Text='<% #Eval("address") %>'></asp:Label></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
                </center>
            </FooterTemplate>
        </asp:Repeater>

    
              
    </div>
    </form>

   

</asp:Content>

