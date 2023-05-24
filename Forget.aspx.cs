using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.WebRequestMethods;

namespace SecurityProject2
{
    public partial class Forget : System.Web.UI.Page
    {

        string c = ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }
        public string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        private string sk;
        protected void Button1_Click(object sender, EventArgs e)
        {
           sk = CreatePassword(20);
            string s = "update rgtb1 set SecurityKey='" + sk + "' where email ='" + TextBox1.Text +"'";

            SqlConnection cn = new SqlConnection(c);
            cn.Open();
            SqlCommand cmd = new SqlCommand(s, cn);
            int k = cmd.ExecuteNonQuery();
            if (k > 0)
            {
                Response.Write("updatetedddd");
           
                SmtpClient obj = new SmtpClient();
                obj.Credentials = new NetworkCredential("rjha3352@gmail.com", "xguxrgjpvflyurpk");
                obj.Port = 587;
                obj.Host = "smtp.gmail.com";
                obj.EnableSsl = true;
                Session["link"] = "https://localhost:44387/ResetPassword.aspx";
                Session["securitykey"] = sk;
                MailMessage msg = new MailMessage("rjha3352@gmail.com", TextBox1.Text);
                msg.Subject = "Thank you for registration..";
                string mg = "Hello\n Please use this link to reset your password '" + Session["link"].ToString() +"'\n securitykey='"+sk+"'\n This link is valid for two minutes only";
                msg.Body = mg;
                obj.Send(msg);
               
                Session.Timeout= 2000;

                Response.Write("<script language='javascript'>alert('Please check your email for security key.');</script>");
                Response.Redirect("ResetPassword.aspx");
            }
            else
            {
                Response.Write("not updatedddddd");
            }
        }
    }
}