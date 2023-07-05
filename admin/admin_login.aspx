<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/admin/admin_master.master" CodeFile="admin_login.aspx.cs" Inherits="Kid_s_Garment_login" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"></asp:Content>
  <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">           
    
     <!-- contact -->
      <div>
		<div>
			<div>
			
			<div style="flex-align:center">
				<h2 class="sub-title">LOGIN FORM</h2>
			</div>
			
			<div>
            <center>
			
				<form id="form1" class="contact-form" runat="server">
                    
                	
                    
                    <asp:TextBox CssClass="contact" ID="email" TabIndex="2" runat="server" placeholder="Email" TextMode="email" ></asp:TextBox>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                            ControlToValidate="email" ErrorMessage="Enter Valid Email" 
                            Font-Bold="True" ForeColor="Red" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                        
                    <br />
                        
                    <br />
                   
                    <asp:TextBox class="contact" ID="pass" runat="server" TabIndex="3" placeholder="Password" TextMode="password"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="pass" ErrorMessage="Enter Password" 
                            Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    
                    <asp:Button ID="submit" class="btn-submit" TabIndex="6" runat="server" Text="Submit" OnClick="submit_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;          
                    <asp:Button ID="clear" class="btn-cancle" runat="server" 
                            Text="clear" OnClick="clear_Click" />
                </form>
                </center>
				 
			</div>
		</div>
	</div>
	<!-- //contact -->
    
    </div>

</asp:Content>

