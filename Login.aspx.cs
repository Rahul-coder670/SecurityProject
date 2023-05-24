using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecurityProject2
{
    public partial class Login : System.Web.UI.Page
    {
        string c = ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        private string usnm;
        private string psw;
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "" && TextBox2.Text != "")
            {

                string s = "select * from rgtb1 where Email= '" + TextBox1.Text + "'";
                SqlConnection cn = new SqlConnection(c);
                cn.Open();
                SqlCommand cmd = new SqlCommand(s, cn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    usnm = dr["Email"].ToString();
                    psw = dr["Password"].ToString();
                }
                if (TextBox1.Text != usnm)
                {
                    Response.Write("<script language='javascript'>alert('This email doesn't exist.');</script>");
                }
                else if (TextBox2.Text != psw)
                {
                    Response.Write("<script language='javascript'>alert('Your Password is incorrect.');</script>");
                }
                else if (TextBox1.Text == usnm && TextBox2.Text == psw)
                {
                    FormsAuthentication.RedirectFromLoginPage(TextBox1.Text, CheckBox1.Checked);
                   Session["em"] = TextBox1.Text;
                    Response.Redirect("~/SecuredPages/Dashboard.aspx");
                }
                else
                {
                    Response.Write("Some error occured");

                }
            }
            else
                Response.Write("<script language='javascript'>alert('All fields are mandatory to login.');</script>");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Forget.aspx");
        }
    }
}