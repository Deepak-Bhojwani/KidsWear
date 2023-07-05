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

public partial class Kid_s_Garment_order : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] != null)
        {
            string cnstr = WebConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            SqlConnection con = new SqlConnection(cnstr);
            con.Open();

            string chk = "select * from [order] where uno=" + Session["uno"];
            SqlCommand chkcmd = new SqlCommand(chk, con);
            int exist = chkcmd.ExecuteNonQuery();

            if (exist == 0)
            {
                
            }
            con.Close();
        }
        else
        {
            Response.Redirect("login.aspx");
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
        con.Open();


        string qry = "select case isplaced when 1 then 'OnGoing' else '' end as status,* from [order] where uno=" + Session["uno"];
        SqlCommand cmd = new SqlCommand(qry, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);

                 
        GridView1.DataSource = dt;
        GridView1.DataBind();
        if (dt.Rows.Count > 0)
        {
            GridView1.FooterRow.Cells[8].Text = "TOTAL AMOUT";
            GridView1.FooterRow.Cells[9].Text = dt.Compute("Sum(total)", "").ToString();
        }
        con.Close();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label id = GridView1.Rows[e.RowIndex].FindControl("no") as Label;
        string cnstr = WebConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        SqlConnection con = new SqlConnection(cnstr);
        con.Open();
        string qry = "delete from [order] where fono=" + id.Text;

        SqlCommand cmd = new SqlCommand(qry, con);

        cmd.ExecuteNonQuery();
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", "alert('Record Deleted Successfully...');", true);
        con.Close();

        GridView1.EditIndex = -1;
        BindGrid();
    }
    
}