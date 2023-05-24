using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SecurityProject2
{
    public partial class Register : System.Web.UI.Page
    {
        string c = ConfigurationManager.ConnectionStrings["sqlconnection"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text != "" && TextBox2.Text != "" && TextBox3.Text != "" && TextBox4.Text != "" && TextBox5.Text != "" 
                && Convert.ToDateTime(TextBox3.Text)<DateTime.Now)
            {
                string s = "select * from rgtb1 where email ='" + TextBox2.Text + "'";
                SqlConnection cn = new SqlConnection(c);

                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(s, cn);
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('This email already exist');", true);

                }
                else
                {
                    string q1 = "insert into rgtb1 (Name,Email,DOB,Mobileno,Password) values('" + TextBox1.Text + "', '" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "')";
                    SqlConnection cn1 = new SqlConnection(c);
                    cn1.Open();
                    SqlCommand cmd1 = new SqlCommand(q1, cn1);
                    int k = cmd1.ExecuteNonQuery();
                    if (k > 0)
                    {
                        Response.Write("<script language='javascript'>alert('Your details has been inserted');</script>");
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        Response.Write("not insertedddddd");
                    }
                    cn1.Close();
                }
            }else
                Response.Write("<script language='javascript'>alert('Please check your dob shold be less than today and all fields are filled or not');</script>");
        }
    }
}