using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;


public partial class registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void submit_Click(object sender, EventArgs e)
    {

    
        string cnstr;
        cnstr = WebConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;

        SqlConnection con = new SqlConnection(cnstr);


        string ins = @"INSERT INTO [dbo].[registration]
           ([name]
           ,[email]
           ,[password]
           ,[mobile]
           ,[address])
            VALUES
           ('" +name.Text+"','"+email.Text+"','"+pass.Text+"','"+contact.Text+"','"+address.InnerText+"')";

        con.Open();
        SqlCommand cmd = new SqlCommand(ins, con);

       

        int a = cmd.ExecuteNonQuery();
        
         if (a > 0) 
         {
              ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", "alert('Register Successful....');window.location ='login.aspx';", true);
              name.Text = "";
              email.Text = "";
              pass.Text = "";
              contact.Text = "";
              address.InnerText = "";
 
          }
          else
          {
              ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", "alert('Register Not Successful....');window.location ='registration.aspx';", true);
          } 
       
         con.Close();
      

    }
    

    protected void clear_Click(object sender, EventArgs e)
    {
       name.Text = "";
       email.Text = "";
       pass.Text = "";
       contact.Text = "";
       address.InnerText = "";
    }
    
}
