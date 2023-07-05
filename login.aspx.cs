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
            string sel = ("select * from registration where email='" + email.Text + "' and password='" + pass.Text + "'");
            con.Open();
            SqlCommand cmd = new SqlCommand(sel, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            
            

            if (sdr.Read())
            {
                Session["user"] = email.Text;
                Session["uno"] = sdr["id"];
                Session["name"] = sdr["name"];
                Session["mobile"] = sdr["mobile"];
                Session["address"] = sdr["address"];

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", "alert('Login Successfull...');window.location ='index.aspx';", true);
                
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", "alert('User name and password are wrong...');window.location ='login.aspx';", true);
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





