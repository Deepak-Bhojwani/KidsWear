<%@ Page Language="C#" MasterPageFile="~/admin/admin_master.master" AutoEventWireup="true" CodeFile="add_product.aspx.cs" Inherits="Kid_s_Garment_add_product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <!-- contact -->
	<div>
		<div>
			<div>
			
			<div style="flex-align:center">
				
                <h2 class="sub-title">ADD PRODUCT</h2>
			</div>
			
			<div>
            <center>
			
				<form id="form1" class="contact-form" runat="server">
                	
                    <asp:TextBox CssClass="contact" ID="name" TabIndex="1" runat="server" placeholder="Name" BorderStyle="Solid"></asp:TextBox>
                    <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ControlToValidate="name" ErrorMessage="Enter Product Name" Font-Bold="True" 
                            ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                   
                   
                   <asp:FileUpload ID="img" CssClass="contact" TabIndex="2" placeholder="Select Image" runat="server" />
                    <br />
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="img" ErrorMessage="Upload Image" Font-Bold="True" 
                            ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    
                    <asp:TextBox CssClass="contact" ID="price" TabIndex="3" runat="server" placeholder="Enter Price"></asp:TextBox>
                   <br />
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="price" ErrorMessage="Enter Price" Font-Bold="True" 
                            ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <textarea class="contact" id="disc" runat="server" tabindex="4" placeholder="Enter Discription" rows="2" cols="50" style="line-height: 50px"></textarea>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="disc" ErrorMessage="Enter Discription" Font-Bold="True" 
                            ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <asp:TextBox ID="qty" CssClass="contact" TabIndex="5" placeholder="Enter Quantity" runat="server"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ControlToValidate="qty" ErrorMessage="Enter Quantity" Font-Bold="True" 
                            ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    
                   
                    
                   <asp:ScriptManager ID="ScriptManager1" runat="server">
                   </asp:ScriptManager>
                    <asp:UpdatePanel ID="catpanel" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="cat" runat="server" AppendDataBoundItems="true" AutoPostBack="true" CssClass="contact" TabIndex="6" Font-Size="Medium" Font-Strikeout="False" Font-Underline="False" OnSelectedIndexChanged="cat_SelectedIndexChanged" >
                            <asp:ListItem Selected="True">-- SELECT CATEGORY --</asp:ListItem>
                        </asp:DropDownList>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="cat" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <br />
                    <br />

                    <asp:UpdatePanel ID="subpanel" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="sub" runat="server" AppendDataBoundItems="true" AutoPostBack="True" TabIndex="7" CssClass="contact" Font-Size="Large" Font-Strikeout="False" Font-Underline="False">
                                
                                <asp:ListItem Selected="True">-- SELECT SUB CATEGORY --</asp:ListItem>
                                
                            </asp:DropDownList>         
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="sub" />
                        </Triggers>
                    </asp:UpdatePanel>
                    <br />
                    <br />
                     
                    <asp:Button ID="submit" class="btn-submit" TabIndex="8" runat="server" Text="Submit" OnClick="submit_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;          
                    <asp:Button ID="clear" class="btn-cancle" TabIndex="9" runat="server" Text="clear" OnClick="clear_Click" />
                </form>
                </center>
				 
			</div>
		</div>
	</div>
	<!-- //contact -->
    
    </div>
</asp:Content>

