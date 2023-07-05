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

public partial class Kid_s_Garment_add_product : System.Web.UI.Page
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
            bind_ddlcat();
        }

        
    }
    public void bind_ddlcat()
    {
        string cnstr = WebConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;    
        SqlConnection con = new SqlConnection(cnstr);
        con.Open();
        SqlCommand cmd = new SqlCommand("select cat_id,cat_name from category",con);
        SqlDataReader sdr = cmd.ExecuteReader();
        cat.DataSource = sdr;
        cat.Items.Clear();
        cat.Items.Add(" --Select Category-- ");
        cat.DataTextField = "cat_name";
        cat.DataValueField = "cat_id";
        cat.DataBind();
        con.Close();
    }
    public void bind_subcat()
    {
        sub.Items.Add(cat.SelectedValue);
        string cnstr = WebConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
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
  

    protected void submit_Click(object sender, EventArgs e)
    {
        img.SaveAs(Server.MapPath("~/Pictures/")+Path.GetFileName(img.FileName));
        string img1 = "~/Pictures/"+Path.GetFileName(img.FileName);
        string cnstr = WebConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        SqlConnection con = new SqlConnection(cnstr);
        string ins = @"INSERT INTO [dbo].[product]
           ([product_name]
           ,[product_img]
           ,[product_price]
           ,[product_description]
           ,[product_quantity]
           ,[product_category]
           ,[product_subcat])
            Values
           ('"+ name.Text +"','"+ img1 +"',"+ price.Text +",'"+ disc.InnerText +"',"+ qty.Text +",'"+ cat.Text +"','"+ sub.Text +"')";

        con.Open();
        SqlCommand cmd = new SqlCommand(ins, con);
        string disp = "select * from product where product_name ='"+ name.Text +"'";
        SqlCommand cmd1 = new SqlCommand(disp,con);
        SqlDataAdapter sda = new SqlDataAdapter(cmd1);
        DataSet ds = new DataSet();
        sda.Fill(ds);

        if (ds.Tables[0].Rows.Count < 0)
        {

            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", "alert('Sorry SomeThing Went Wrong...');", true);
            name.Text = "";
            price.Text = "";
            disc.InnerText = "";
            qty.Text = "";

        }
        else
        {
            cmd.ExecuteNonQuery();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", "alert('Product Inserted Successfully...');", true);
            name.Text = "";
            price.Text = "";
            disc.InnerText = "";
            qty.Text = "";

            con.Close();
        }  
    }
    protected void clear_Click(object sender, EventArgs e)
    {
        name.Text = "";
        price.Text = "";
        disc.InnerText = "";
        qty.Text = "";
        
    }
    protected void cat_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_subcat();
    }
}