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


public partial class Kid_s_Garment_view_detail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] != null)
        {

        }
        else
        {
            Response.Redirect("login.aspx");
        }
        if (!IsPostBack)
        {
            BindData();
        }
        
    }
    public void BindData()
    {
        string cnstr = WebConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        SqlConnection con = new SqlConnection(cnstr);
        con.Open();
        if (Request.QueryString["pid"] != null && Request.QueryString["pid"] != "")
        {

            string id = Request.QueryString["pid"];
            string sel = "SELECT [product_id],[product_name],[product_img],[product_price],[product_description],[product_quantity],[product_category],[product_subcat] FROM [dbo].[product] where product_id =" + id;
            SqlCommand cmd = new SqlCommand(sel, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();

            name.Text = sdr["product_name"].ToString();
            product_imgLabel.ImageUrl = sdr["product_img"].ToString();
            price.Text = sdr["product_price"].ToString();
            qty.Text = sdr["product_quantity"].ToString();
            disc.Text = sdr["product_description"].ToString();
        }
        con.Close();
    }
    
    protected void addtocart_Click(object sender, EventArgs e)
    {
        try
        {
            string id = Request.QueryString["pid"];
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string cnstr = WebConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            SqlConnection con = new SqlConnection(cnstr);
            con.Open();   

            string sel = "SELECT [product_id],[product_name],[product_img],[product_price],[product_description],[product_quantity],[product_category],[product_subcat] FROM [dbo].[product] where product_id =" + id;
            SqlCommand cmd = new SqlCommand(sel, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            string pro_name = sdr["product_name"].ToString();
            string pro_img = sdr["product_img"].ToString();
            int pro_price = Convert.ToInt32(sdr["product_price"].ToString());
            
            string pro_disc = sdr["product_description"].ToString();
            int quantity = Convert.ToInt32(qty1.Text);
            int tot =  quantity * pro_price;
            sdr.Close();

            string ins = @"INSERT INTO [dbo].[cart]([date],[pid],[pname],[price],[img],[description],[uno],[uname],[quantity],[total]) VALUES
           ('" + date + "'," + id + ",'" + pro_name + "'," + pro_price + ",'" + pro_img + "','" + pro_disc + "'," + Session["uno"].ToString() + ",'" + Session["name"].ToString() + "'," + qty1.Text + "," + tot + ")";


            SqlCommand cmd1 = new SqlCommand(ins, con);
            
            cmd1.ExecuteNonQuery();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", "alert('Item Added To Cart..');window.location ='add_to_cart.aspx';", true);
            con.Close();
        }
        catch (Exception a)
        {
            Response.Write(a);
        }
    }
    protected void placeorder_Click(object sender, EventArgs e)
    {
        try
        {
            string id = Request.QueryString["pid"];
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string cnstr = WebConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            SqlConnection con = new SqlConnection(cnstr);
            con.Open();

            

            string sel = "SELECT [product_id],[product_name],[product_img],[product_price],[product_description],[product_quantity] FROM [dbo].[product] where product_id =" + id;
            SqlCommand cmd = new SqlCommand(sel, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            sdr.Read();
            if ((int)sdr["product_quantity"] > 0 && (int)sdr["product_quantity"]  >= Convert.ToInt32(qty1.Text))
            {
                string pro_name = sdr["product_name"].ToString();
                string pro_img = sdr["product_img"].ToString();
                int pro_price = (int)sdr["product_price"];
                int txtqty = (int)sdr["product_quantity"];
                string pro_disc = sdr["product_description"].ToString();
                int quantity = Convert.ToInt32(qty1.Text);
                int tot = quantity * pro_price;
                sdr.Close();



                string ins = @"INSERT INTO [dbo].[order] ([fodate],[pname],[img],[quantity],[price],[description],[uno],[uname],[contact],[address],[total],[isplaced])
                            VALUES ('" + date + "','" + pro_name + "','" + pro_img + "'," + quantity + "," + pro_price + ",'" + pro_disc + "'," + Session["uno"] + ",'" + Session["name"].ToString() + "'," + Session["mobile"] + ",'" + Session["address"].ToString() + "'," + tot + ",'1')";

                SqlCommand cmd1 = new SqlCommand(ins, con);
                cmd1.ExecuteNonQuery();

                string upd = @"update product set product_quantity = ((select product_quantity from product where product_id = " + id + ") - " + Convert.ToInt32(qty1.Text) + ") where product_id =" + id;
                SqlCommand cmd2 = new SqlCommand(upd, con);
                cmd2.ExecuteNonQuery();

                string query = @"select top 1 fono from [order] where uno = " + Session["uno"].ToString() + " order by fono desc";
                SqlCommand cmdselect = new SqlCommand(query, con);
                SqlDataReader sdrselect = cmdselect.ExecuteReader();
                sdrselect.Read();
                int fono = (int)sdrselect["fono"];
               

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", "alert('Order Placed Successfully...');", true);
                Response.Redirect("Invoice.aspx?oId=" + sdrselect["fono"].ToString() + "&Multiorder=" + 1 + "");
                //
                sdrselect.Close();
                con.Close();

            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", "alert('Order Placed Successfully...');window.location ='view_detail.aspx?pid=" + Request.QueryString["pid"] + "';", true);
            }

        }
        catch (Exception a)
        {
            Response.Write(a);
        }
    }
}