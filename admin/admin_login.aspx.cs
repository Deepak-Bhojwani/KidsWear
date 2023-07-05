using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class Kid_s_Garment_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void submit_Click(object sender, EventArgs e)
    {
      

            string cnstr;
            cnstr = WebConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            SqlConnection con = new SqlConnection(cnstr);


            Response.Write("<br>");
            string sel = ("select * from admin where admin_email='" + email.Text + "' and admin_password='" + pass.Text + "'");
            con.Open();
            SqlCommand cmd = new SqlCommand(sel, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            
            

            if (sdr.Read())
            {
                Session["admin"] = email.Text;
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", "alert('Login Successfull...');window.location ='users.aspx';", true);
                
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", "alert('User Name and Password are Wrong...');window.location ='admin_login.aspx';", true);
            }
            sdr.Close();
            con.Close();
        }

    protected void clear_Click(object sender, EventArgs e)
    {
        email.Text = "";
        pass.Text = "";
    }
}





