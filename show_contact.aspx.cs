using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class Kid_s_Garment_show_contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["user"] != null)
        //{

        //}
        //else
        //{
        //    Response.Redirect("login.aspx");
        //}
        
        //string cnstr = WebConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        //SqlConnection con = new SqlConnection(cnstr);
        //con.Open();
        //string qry = "select [name],[email],[phone],[address] FROM [DB_KG].[dbo].[contact_us]";
        //SqlCommand cmd = new SqlCommand(qry, con);
        //SqlDataReader sdr = cmd.ExecuteReader();
        //sdr.Read();
        //name.Text = sdr["name"].ToString();
        //email.Text = sdr["email"].ToString();
        //phone.Text = sdr["phone"].ToString();
        //address.Text = sdr["address"].ToString();
        
        //con.Close();
    }
}