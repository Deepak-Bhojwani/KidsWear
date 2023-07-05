using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.IO;

public partial class Kid_s_Garment_admin_show_order : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["admin"] != null)
        {

        }
        else
        {
            Response.Redirect("admin_login.aspx");
        }
        if (!IsPostBack)
        {
            BindGrid();
        }
    }
    public void BindGrid()
    {
        string cnstr = WebConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        SqlConnection con = new SqlConnection(cnstr);
        string qry = "select * from [order] ";
        SqlCommand cmd = new SqlCommand(qry, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        GridView1.DataSource = dt;
        GridView1.DataBind();
        //GridView1.FooterRow.Cells[10].Text = "TOTAL AMOUT";
        //GridView1.FooterRow.Cells[11].Text = "RS."+dt.Compute("Sum(total)", "").ToString();
        con.Close();
    }
}