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

public partial class Kid_s_Garment_admin_show_product : System.Web.UI.Page
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
            bind_cat();
            BindGrid();
        }
    }
    public void bind_cat()
    {
        string cnstr = WebConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        SqlConnection con = new SqlConnection(cnstr);
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [cat_id],[cat_name] FROM [dbo].[category]", con);
        SqlDataReader sdr = cmd.ExecuteReader();
        cat.DataSource = sdr;
        cat.Items.Clear();
        cat.Items.Add("category");
        cat.DataTextField = "cat_name";
        cat.DataValueField = "cat_id";
        cat.DataBind();
        con.Close();
    }
    public void bind_subcat()
    {
        string cnstr = WebConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        sub.Items.Add(cat.SelectedValue);
        SqlConnection con = new SqlConnection(cnstr);
        con.Open();
        SqlCommand cmd = new SqlCommand("select sub_id,sub_name from sub_cat where cat_id='" + cat.SelectedValue + "'", con);
        SqlDataReader sdr = cmd.ExecuteReader();
        sub.DataSource = sdr;
        sub.Items.Clear();
        //sub.Items.Add("-- Select Sub Category --");
        sub.DataTextField = "sub_name";
        sub.DataValueField = "sub_id";
        sub.DataBind();
        con.Close();
    }
    public void BindGrid()
    {
        string cnstr = WebConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        SqlConnection con = new SqlConnection(cnstr);
        string qry = "select * from product";
        SqlCommand cmd = new SqlCommand(qry, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        con.Close();

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindGrid();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindGrid();
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        Label id = GridView1.Rows[e.RowIndex].FindControl("proid") as Label;
        TextBox name = GridView1.Rows[e.RowIndex].FindControl("txtname") as TextBox;
        FileUpload img = GridView1.Rows[e.RowIndex].FindControl("fu") as FileUpload;
        img.SaveAs(Server.MapPath("~/Pictures/") + Path.GetFileName(img.FileName));
        string img1 = "~/Pictures/" + Path.GetFileName(img.FileName);
        TextBox price = GridView1.Rows[e.RowIndex].FindControl("txtprice") as TextBox;
        TextBox disc = GridView1.Rows[e.RowIndex].FindControl("txtdisc") as TextBox;
        TextBox qty = GridView1.Rows[e.RowIndex].FindControl("txtqty") as TextBox;
        DropDownList cat = GridView1.Rows[e.RowIndex].FindControl("cat") as DropDownList;
        DropDownList subcat = GridView1.Rows[e.RowIndex].FindControl("sub-cat") as DropDownList;
        string cnstr = WebConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        SqlConnection con = new SqlConnection(cnstr);
        string qry = "UPDATE product SET product_name='"+name.Text+"',product_img='"+ img1 +"',product_price="+price.Text+",product_description='"+disc.Text+"',product_quantity="+qty.Text+" where product_id="+id.Text;

        SqlCommand cmd = new SqlCommand(qry, con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        GridView1.EditIndex = -1;
        BindGrid();
        
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label id = GridView1.Rows[e.RowIndex].FindControl("proid") as Label;
        string cnstr = WebConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        SqlConnection con = new SqlConnection(cnstr);
        con.Open();
        string qry = "delete from product where product_id="+id.Text;

        SqlCommand cmd = new SqlCommand(qry, con);
        
        cmd.ExecuteNonQuery();
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", "alert('Product Deleted Successfully..');", true);
        con.Close();

        GridView1.EditIndex = -1;
        BindGrid();
    }
    protected void cat_SelectedIndexChanged1(object sender, EventArgs e)
    {
        
        
        bind_subcat();

        string cnstr = WebConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        SqlConnection con = new SqlConnection(cnstr);

        string qry = "SELECT * from product where product_category=" + cat.Text + " ";
        SqlCommand cmd = new SqlCommand(qry, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        con.Close();
        
       
    }
    protected void sub_SelectedIndexChanged(object sender, EventArgs e)
    {
        string cnstr = WebConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        SqlConnection con = new SqlConnection(cnstr);
        string qry = "SELECT * from product where product_subcat=" + sub.Text + " ";
        SqlCommand cmd = new SqlCommand(qry, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        con.Close();
    }
   
}