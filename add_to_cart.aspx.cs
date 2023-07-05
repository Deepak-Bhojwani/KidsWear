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

public partial class Kid_s_Garment_add_to_cart : System.Web.UI.Page
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
            BindGrid();
        }
    }
    public void BindGrid()
    {
        try
        {
            string cnstr = WebConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
            SqlConnection con = new SqlConnection(cnstr);
            string qry = "SELECT [cno],[date],[pid],[pname],[price],[img],[quantity],[total] FROM [DB_KG].[dbo].[cart] where uno=" + Session["uno"];
            con.Open();
            SqlCommand cmd = new SqlCommand(qry, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count == 0)
            {
                empty.Text = "Cart Is Empty";
            }
            Session["count"]= ds.Tables[0].Rows.Count;
            
            GridView1.DataSource = ds;
            GridView1.DataBind();
            con.Close();
        }
        catch (Exception e)
        {
            Response.Write(e.ToString());
        }
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

        Label id = GridView1.Rows[e.RowIndex].FindControl("cid") as Label;
        TextBox qty = GridView1.Rows[e.RowIndex].FindControl("txtqty") as TextBox;
        string cnstr = WebConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        SqlConnection con = new SqlConnection(cnstr);
        string qry = "UPDATE cart SET quantity=" + qty.Text + " where cno=" +id.Text;
        SqlCommand cmd = new SqlCommand(qry, con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
        GridView1.EditIndex = -1;
        BindGrid();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        Label id = GridView1.Rows[e.RowIndex].FindControl("cid") as Label;
        string cnstr = WebConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
        SqlConnection con = new SqlConnection(cnstr);
        con.Open();
        string qry = "delete from cart where cno=" + id.Text;

        SqlCommand cmd = new SqlCommand(qry, con);

        cmd.ExecuteNonQuery();
        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", "alert('Product Removed Successfully From Cart...');", true);
        con.Close();

        GridView1.EditIndex = -1;
        BindGrid();
    }
    
    protected void plcordr_Click1(object sender, EventArgs e)
    {
        
       int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
       int id = Convert.ToInt32(GridView1.DataKeys[rowIndex].Values[0]);
       int qty = Convert.ToInt32(((System.Web.UI.WebControls.Label)(GridView1.Rows[rowIndex].FindControl("qty"))).Text);
       try
       {
           string date = DateTime.Now.ToString("dd-MM-yyyy");
           string cnstr = WebConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
           SqlConnection con = new SqlConnection(cnstr);
           con.Open();

           string cart = "SELECT * from cart where uno = " + Session["uno"].ToString() + " and  pid = " + id;
           SqlCommand cmd2 = new SqlCommand(cart, con);
           SqlDataReader sdr1 = cmd2.ExecuteReader();
           sdr1.Read();

           int quantity = (int)sdr1["quantity"];

           string sel = "SELECT [product_id],[product_name],[product_img],[product_price],[product_description],[product_quantity] FROM [dbo].[product] where product_id =" + sdr1["pid"];
           sdr1.Close();
           SqlCommand cmd = new SqlCommand(sel, con);
           SqlDataReader sdr = cmd.ExecuteReader();
           sdr.Read();

           string pro_name = sdr["product_name"].ToString();
           string pro_img = sdr["product_img"].ToString();
           int pro_price = (int)sdr["product_price"];
           string pro_disc = sdr["product_description"].ToString();
           int txtqty = (int)sdr["product_quantity"];
           int tot = txtqty * pro_price;
           sdr.Close();

           string ins = @"INSERT INTO [dbo].[order] ([fodate],[pname],[img],[quantity],[price],[description],[uno],[uname],[contact],[address],[total],[isplaced])
             VALUES ('" + date + "','" + pro_name + "','" + pro_img + "'," + quantity + "," + pro_price + ",'" + pro_disc + "'," + Session["uno"] + ",'" + Session["name"] + "'," + Session["mobile"] + ",'" + Session["address"] + "'," + tot + ",'1')";


           SqlCommand cmd1 = new SqlCommand(ins, con);
           cmd1.ExecuteNonQuery();

           string upd = @"update product set product_quantity = ((select product_quantity from product where product_id = " + id + ") - " + qty + ") where product_id =" + id;
           SqlCommand cmdupd = new SqlCommand(upd, con);
           cmdupd.ExecuteNonQuery();



           string dlt = @"delete from cart where uno = " + Session["uno"].ToString() + " and pid =" + id;
           SqlCommand cmddlt = new SqlCommand(dlt, con);
           cmddlt.ExecuteNonQuery();


           string query = @"select top 1 fono from [order] where uno = " + Session["uno"].ToString() + " order by fono desc";
           SqlCommand cmdselect = new SqlCommand(query, con);
           SqlDataReader sdrselect = cmdselect.ExecuteReader();
           sdrselect.Read();

           ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", "alert('Order Placed Successfully...');", true);

           Response.Redirect("Invoice.aspx?oId=" + sdrselect["fono"].ToString() + "&Multiorder=" + 1+ "");
           // 
           con.Close();

       }
       catch (Exception ex)
       {
           Response.Write(ex.Message);
       }

    }

//    protected void PlaceAllOrder_Click(object sender, EventArgs e)
//    {
//        string date = DateTime.Now.ToString("dd-MM-yyyy");
//        string cnstr = WebConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;
//        SqlConnection con = new SqlConnection(cnstr);
//        con.Open();

//        string cart = "SELECT * from cart where uno = " + Session["uno"].ToString() ;
//        SqlCommand cmd2 = new SqlCommand(cart, con);
//        SqlDataReader sdr1 = cmd2.ExecuteReader();
//        sdr1.Read();
//        if (sdr1.HasRows)
//        {
       

//            int quantity = (int)sdr1["quantity"];
//            string sel = "SELECT [product_id],[product_name],[product_img],[product_price],[product_description],[product_quantity] FROM [dbo].[product] where product_id =" + sdr1["pid"];
//            SqlCommand cmd = new SqlCommand(sel, con);
//            sdr1.Close();
//            SqlDataReader sdr = cmd.ExecuteReader();
//            sdr.Read();

//            string pro_name = sdr["product_name"].ToString();
//            string pro_img = sdr["product_img"].ToString();
//            int pro_price = (int)sdr["product_price"];
//            string pro_disc = sdr["product_description"].ToString();
//            int txtqty = (int)sdr["product_quantity"];
//            int tot = txtqty * pro_price;
//            sdr.Close();

//         string ins = @"INSERT INTO [dbo].[order] ([fodate],[pname],[img],[quantity],[price],[description],[uno],[uname],[contact],[address],[total],[isplaced])
//             VALUES ('" + date + "','" + pro_name + "','" + pro_img + "'," + quantity + "," + pro_price + ",'" + pro_disc + "'," + Session["uno"] + ",'" + Session["name"] + "'," + Session["mobile"] + ",'" + Session["address"] + "'," + tot + ",'1')";

//            SqlCommand cmd13 = new SqlCommand(ins, con);
//            cmd13.ExecuteNonQuery();


//         string query = @"select top 1 fono from [order] where uno = " + Session["uno"].ToString() + " order by fono desc";
//           SqlCommand cmdselect = new SqlCommand(query, con);
//           SqlDataReader sdrselect = cmdselect.ExecuteReader();
//           sdrselect.Read();

//          string OIds=   sdrselect["fono"].ToString() ;
//          sdrselect.Close();

//          string cart1 = "SELECT * from cart where uno = " + Session["uno"].ToString();
//          SqlCommand cmd21 = new SqlCommand(cart1, con);
//          cmd21.ExecuteNonQuery();
//          DataTable dt = new DataTable();
//          SqlDataAdapter da = new SqlDataAdapter(cmd21);
//          da.Fill(dt);
         
//          string ProID = string.Empty;
//          string Quantity = string.Empty;
         

//          for (int i = 0; i < dt.Rows.Count;i++ )
//          {
//              ProID += dt.Rows[i]["pid"]+ ",";
//              Quantity += dt.Rows[i]["quantity"] + ",";

//          }
       
//        for(int i = 0; i < dt.Rows.Count;i++)
//        {


//            string sel12 = "SELECT [product_id],[product_name],[product_img],[product_price],[product_description],[product_quantity] FROM [dbo].[product] where product_id =" + dt.Rows[i]["pid"];
//            SqlCommand cmd12 = new SqlCommand(sel12, con);
            
//            SqlDataReader sdr12 = cmd.ExecuteReader();
//            sdr12.Read();

//            string pro_name12 = sdr12["product_name"].ToString();
//            string pro_img12 = sdr12["product_img"].ToString();
//            int pro_price12 = (int)sdr12["product_price"];
//            string pro_disc12 = sdr12["product_description"].ToString();
//            int txtqty12 = (int)sdr12["product_quantity"];
//            int tot12 = txtqty * pro_price;
//            int pid = (int)dt.Rows[i][" pid"];
//            int quantity123 = (int)dt.Rows[i]["quantity"];

//            sdr12.Close();
//            string ins12 = @"INSERT INTO [dbo].[orderdetails] ([fono],[fodate],[pname],[img],[quantity],[price],[description],[uno],[uname],[contact],[address],[total],[isplaced])
//                         VALUES (" + OIds + ",'" + date + "','" + pro_name12 + "','" + pro_img12 + "'," + dt.Rows[i]["quantity"] + "," + pro_price12 + ",'" + pro_disc12 + "'," + Session["uno"] + ",'" + Session["name"] + "'," + Session["mobile"] + ",'" + Session["address"] + "'," + tot12 + ",'1')";

//            SqlCommand cmd1 = new SqlCommand(ins12, con);
//            cmd1.ExecuteNonQuery();

//            string upd = @"update product set product_quantity = ((select product_quantity from product where product_id = " + pid + ") - " + quantity123 + ") where product_id =" + pid;
//            SqlCommand cmdupd = new SqlCommand(upd, con);
//            cmdupd.ExecuteNonQuery();

//            string dlt = @"delete from cart where uno = " + Session["uno"].ToString() + " and pid =" + pid;
//            SqlCommand cmddlt = new SqlCommand(dlt, con);
//            cmddlt.ExecuteNonQuery();
            
//        }
   
//        con.Close();

//        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "alert", "alert('Order Placed Successfully...');", true);
//        Response.Redirect("Invoice.aspx?oId=" + OIds + "&Multiorder=" + 2 + "");

//        }
//    }
}