using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecurityProject2
{
    public partial class ResetPassword : System.Web.UI.Page
    {

        string c = ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString;
        private string key;
        protected void Page_Load(object sender, EventArgs e)
        {
            key = Session["securitykey"].ToString();
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox3.Text == key)
            {
                string s = "update rgtb1 set Password='" + TextBox1.Text + "' where SecurityKey ='" + TextBox3.Text + "'";

                SqlConnection cn = new SqlConnection(c);
                cn.Open();
                SqlCommand cmd = new SqlCommand(s, cn);
                int k = cmd.ExecuteNonQuery();
                if (k > 0)
                {
                    Response.Write("updatetedddd");
                }
              
            }
            else
            {
                Response.Write(" not updatetedddd");
            }
        }
    }
}