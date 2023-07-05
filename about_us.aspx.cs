using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class Kid_s_Garment_about_us : System.Web.UI.Page
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
        //string qry = "select name,detail from about where id = 2";
        //SqlCommand cmd = new SqlCommand(qry, con);
        //SqlDataReader sdr = cmd.ExecuteReader();

        //sdr.Read();
        //name.Text = sdr["name"].ToString();
        //detail.Text = sdr["detail"].ToString();
        //con.Close();
    }
}