<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="registration.aspx.cs" Inherits="registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <!-- contact -->
	<div>
		<div>
			<div>
			
			<div style="flex-align:center">
				<h2 class="sub-title">REGISTERATION FORM</h2>
			</div>
			
			
			<div>
            <center>
			
				<form id="form1" class="contact-form" runat="server">
                    
                	
                    <asp:TextBox CssClass="contact" ID="name" TabIndex="1" runat="server" placeholder="Name" BorderStyle="Solid"></asp:TextBox>
                    <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="name" ErrorMessage="Enter Name" Font-Bold="True" 
                            ForeColor="Red"></asp:RequiredFieldValidator>
                        <br />
                    <br />
                    
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
                    
                    <asp:TextBox CssClass="contact" ID="contact" runat="server" TabIndex="4" placeholder="Mobile" ></asp:TextBox>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ControlToValidate="contact" ErrorMessage="Enter Valid Number" 
                            Font-Bold="True" ForeColor="Red" ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator>
                    <br />
                    <br />
                   
                    <textarea class="contact" id="address"  runat="server" tabindex="5" placeholder="Address" rows="2" cols="40" style="line-height: 50px"></textarea>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="address" ErrorMessage="Enter Your Address" Font-Bold="True" 
                            ForeColor="Red"></asp:RequiredFieldValidator>
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

