<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="edit_profile.aspx.cs" Inherits="Kid_s_Garment_edit_profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   
	
		
			
			<div style="flex-align:center">
				<h2 class="sub-title">Edit Profile</h2>
			</div>
			
			
			<div>
            <center>
			
				<form id="form1" class="contact-form" runat="server">
    

                    <asp:TextBox CssClass="contact" ID="name" TabIndex="1" runat="server" placeholder="Enter Name" BorderStyle="Solid"></asp:TextBox>
                    <br />
                    <br />
                    
                    <asp:TextBox CssClass="contact" ID="email" TabIndex="2" runat="server" placeholder="Enter Email"></asp:TextBox>
                    <br />
                    <br />
                    
                    <asp:TextBox ID="mobile" CssClass="contact" TabIndex="3" placeholder="Enter Mobile" runat="server"></asp:TextBox>
                    <br />
                    <br />

                    
                    <textarea class="contact" id="add" runat="server" tabindex="4" placeholder="Enter Address" rows="2" cols="50" style="line-height: 50px"></textarea>
                    <br />
                    <br />

                     <asp:Button ID="submit" class="btn-submit" TabIndex="5" runat="server" Text="Submit" OnClick="submit_Click1" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;          
                    <asp:Button ID="clear" class="btn-cancle" TabIndex="6" runat="server" Text="Clear" /> 
</form>
</center>
</div>

</asp:Content>

    