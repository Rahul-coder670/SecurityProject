using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecurityProject2
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["em"] != null)
            {
                string con = ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString;
                string s = "select * from rgtb1 where Email ='" + Session["em"].ToString() + "'";
                SqlConnection cn = new SqlConnection(con);
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(s, cn);
                da.Fill(ds);

                DataList1.DataSource = ds;
                DataList1.DataBind();              
                Session.Timeout = 1;
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}