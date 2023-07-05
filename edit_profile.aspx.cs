using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class Kid_s_Garment_edit_profile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            prfdata();
        }
    }
    public void prfdata()
    {
        string cnstr = WebConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        SqlConnection con = new SqlConnection(cnstr);
        string qry = "select name,email,mobile,address from registration where email=" + " '" + Session["user"] + "' ";
        SqlCommand cmd = new SqlCommand(qry, con);
        con.Open();

        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.HasRows)
        {

            dr.Read();
            name.Text = dr["name"].ToString();
            email.Text = dr["email"].ToString();
            mobile.Text = dr["mobile"].ToString();
            add.InnerText = dr["address"].ToString();

        }
    }

    protected void submit_Click1(object sender, EventArgs e)
    {
        

        try
        {
            Console.Write("start");

            string cnstr = WebConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            SqlConnection con = new SqlConnection(cnstr);
            con.Open();

            SqlCommand cmd1 = new SqlCommand("UPDATE [dbo].[registration] SET [name] = '" + name.Text + "',[email] = '" + email.Text + "',[mobile] = '" + mobile.Text + "',[address] = '" + add.InnerText + "' WHERE email=" + " '" + Session["user"] + "' ", con);

            //SqlCommand cmd = new SqlCommand
            //("update registration set name='" + name.Text + "',email='" + email.Text + "',mobile='" + mobile.Text + "',address='" + add.InnerText + "' where email=" + " '" + Session["user"] + "' ", con);
            ////cmd.Parameters.AddWithValue("@name", name.Text);
            //cmd.Parameters.AddWithValue("@email", email.Text);
            //cmd.Parameters.AddWithValue("@mobile", mobile.Text);
            //cmd.Parameters.AddWithValue("@add", add.InnerText);
            Console.Write("Ok");
            int a = cmd1.ExecuteNonQuery();
            name.Text = "";
            email.Text = "";
            mobile.Text = "";
            add.InnerText = "";

            if (a > 0)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", "alert('Profile Updated...');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", "alert('Something Went Wrong');", true);
            }
            con.Close();
        }
        catch (Exception a2)
        {
            Response.Write(a2.ToString());
        }
    }
}

