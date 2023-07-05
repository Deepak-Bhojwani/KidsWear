using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

public partial class Invoice : System.Web.UI.Page
{
     string cnstr = WebConfigurationManager.ConnectionStrings["cnstr"].ConnectionString;

    
       

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["oId"] != null)
            lblOId.Text = Request.QueryString["oId"];


        BindGrid();
        BindSubtot();
        BindGrandTot();
        SqlConnection con = new SqlConnection(cnstr);
        con.Open();
        String sel = "select * from [order] where fono =" + lblOId.Text;
        SqlCommand cmd = new SqlCommand(sel, con);
        SqlDataReader dr = cmd.ExecuteReader();


        while (dr.Read())
        {
            lblCname.Text = dr["uname"].ToString();
            lblODate.Text = dr["fodate"].ToString();
            lblAdd.Text = dr["address"].ToString();
            lblPayType.Text = "Cash on delivery";
            lblPayStatus.Text = "Panding";
        }
        dr.Close();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }

    protected void BindGrid()
    {
         SqlConnection con = new SqlConnection(cnstr);
         con.Open();
        int Multiorder = 0;
         if (Request.QueryString["Multiorder"] != null)
           Multiorder = Convert.ToInt32(Request.QueryString["Multiorder"]);

        if(Multiorder == 1)
        {
            String sel = "select O.pname as Prod_Name,P.product_price As MRP, O.quantity As Qty  from [order] As O inner join product P on P.product_name = O.pname where O.fono = " + lblOId.Text;
        SqlCommand cmd = new SqlCommand(sel, con);
        SqlDataReader dr = cmd.ExecuteReader();

        if (dr.HasRows == true)
        {
            GridView1.DataSource = dr;
            GridView1.DataBind();
            //  Method_Status();
        }
        
        }
       
        else
        {
            String sel1 = "select O.pname as Prod_Name,P.product_price As MRP, O.quantity As Qty  from [orderdetails] As O inner join product P on P.product_name = O.pname where O.fono = " + lblOId.Text;
            SqlCommand cmd1 = new SqlCommand(sel1, con);
            SqlDataReader dr1 = cmd1.ExecuteReader();
             if (dr1.HasRows == true)
            {
                GridView1.DataSource = dr1;
                GridView1.DataBind();
                //  Method_Status();
            }
             dr1.Close();
        }
       
        con.Close();
    }

    protected void BindSubtot()
    {
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            Label SubTotal = (Label)GridView1.Rows[i].Cells[1].FindControl("LblSubTot");
            Label mrp = (Label)GridView1.Rows[i].Cells[1].FindControl("LblMRP");
            Label Qty = (Label)GridView1.Rows[i].Cells[1].FindControl("LblQty");
            int SubTot = Convert.ToInt32(mrp.Text) * Convert.ToInt32(Qty.Text);
            SubTotal.Text = SubTot.ToString();
        }
    }

    protected void BindGrandTot()
    {
        int GrandTot = 0;
        for (int j = 0; j < GridView1.Rows.Count; j++)
        {
            Label SubTotal = (Label)GridView1.Rows[j].Cells[3].FindControl("LblSubTot");

            GrandTot = GrandTot + Convert.ToInt32(SubTotal.Text);
        }
        lblGrandTot.Text = " Grand Total : " + "Rs. "+ GrandTot.ToString() + "" ;
    }

    protected void btnDownload_Click(object sender, EventArgs e)
    {
        exportpdf();
    }

    protected void exportpdf()
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=OrderInvoice.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        Panel1.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
    }
}