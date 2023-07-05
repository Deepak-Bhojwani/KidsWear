using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class Kid_s_Garment_admin_add_cat : System.Web.UI.Page
{
    

    public void cat_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cat.Text == "Boys")
        {
            Session["cat_id"] = 1;
        }
        else if (cat.Text == "Girls")
        {
            Session["cat_id"] = 2;
        }
    }
    public void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindgrid();
        }
        if (Session["admin"] != null)
        {

        }
        else
        {
            Response.Redirect("admin_login.aspx");
        }
    }
    public void submit_Click(object sender, EventArgs e)
    {
        string cnstr = WebConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        SqlConnection con = new SqlConnection(cnstr);
        con.Open();
        
        string ins = @"INSERT INTO sub_cat (cat_id,sub_name) Values (" + Session["cat_id"] + ",'" + sub_category.Text + "')";
        SqlCommand cmd = new SqlCommand(ins, con);
        cmd.ExecuteNonQuery();
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", "alert('Category Inserted Successfully...');", true);
        bindgrid();
        con.Close();
    }
    public void clear_Click(object sender, EventArgs e)
    {
        sub_category.Text = "";
    }


    void bindgrid()
    {
        string cnstr = WebConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        SqlConnection con = new SqlConnection(cnstr);
        string qry = "SELECT category.cat_name,sub_cat.sub_id,sub_cat.sub_name FROM category INNER JOIN sub_cat ON category.cat_id = sub_cat.cat_id";
        
        SqlCommand cmd = new SqlCommand(qry, con);

        SqlDataAdapter ad = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        ad.Fill(ds);

        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        bindgrid();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        bindgrid();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string cnstr = WebConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        
        TextBox t1 = GridView1.Rows[e.RowIndex].FindControl("txtsubname") as TextBox;
        Label l1 = GridView1.Rows[e.RowIndex].FindControl("lblid") as Label;
        string qry = "UPDATE sub_cat SET sub_name=@sub_name where sub_id=@sub_id";

        SqlConnection con = new SqlConnection(cnstr);
        SqlCommand cmd = new SqlCommand(qry, con);
        cmd.Parameters.AddWithValue("@sub_name",t1.Text);
        cmd.Parameters.AddWithValue("@sub_id",l1.Text);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        GridView1.EditIndex = -1;
        bindgrid();
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", "alert('Category Updated Successfully...');", true);
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string cnstr = WebConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        
        Label l1 = GridView1.Rows[e.RowIndex].FindControl("lblid") as Label;
        SqlConnection con = new SqlConnection(cnstr);
        con.Open();
        string qry = "delete from sub_cat where sub_id=@sub_id";
       
        SqlCommand cmd = new SqlCommand(qry, con);
        cmd.Parameters.AddWithValue("@sub_id",l1.Text);
        cmd.ExecuteNonQuery();
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", "alert('Category Deleted Successfully...');", true);
        con.Close();

        GridView1.EditIndex = -1;
        bindgrid();
    }
}
