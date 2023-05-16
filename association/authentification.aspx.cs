using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Security;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;



namespace association
{
    public partial class authentification : System.Web.UI.Page
    {
        //SqlConnection cnx = new SqlConnection(@"Data Source=DESKTOP-I7RGLV9\SQLEXPRESS;Initial Catalog=Control_ASP;Integrated Security=True");
        SqlCommand cmd;
        // connection string  
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            string squery = "select gPaye from Adherentpaid";
            cmd = new SqlCommand(squery, con);
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    int number = Convert.ToInt32(rdr["gPaye"]);
                    Session["pay"] = number;
                }
            }
            con.Close();
           // Response.Write("<script>alert('" + Session["pay"] + "')</script>");
        }

        public bool CheckID()
        {
            if (id.Text == "ALHAMWI" || id.Text == "FAHMI" || id.Text == "BOULASSEL" || id.Text.Contains("@gmail.com") == true)
            {
                return true;
            }
            return false;
        }

        public int CheckIDexacclyt()
        {
            int x = 5 ;
            if (CheckID() == true)
            {
                if(id.Text== "ALHAMWI")
                {
                    x = 1;
                }
                else if (id.Text == "FAHMI")
                {
                    x = 2;

                }
                else if (id.Text == "BOULASSEL")
                {
                    x = 3;
                }
                else if(id.Text.Contains("@gmail.com") == true)
                {
                    x = 4;
                }
                else
                {
                    x = 6;
                }
            }
            else if (CheckID()==false)
            {
                x = 0;
            }
            return x;
        }

        protected void keyid_Click(object sender, EventArgs e)
        {
            // Session["qui"] = "12345ALHAMWI";
            // Session["Treasurer"] = "12345FAHMI";
            // Session["Redacteur"] = "12345BOULASSEL";

            if (CheckIDexacclyt() == 1)
            {
                string sql1 = "select count(*) from organisateurs where CHEF = @id and key_CHEF = @key";
                SqlCommand cmd = new SqlCommand(sql1, con);
                cmd.Parameters.AddWithValue("@id", id.Text);
                cmd.Parameters.AddWithValue("@key", key.Text);
                con.Open();
                int n = int.Parse(cmd.ExecuteScalar().ToString());
                con.Close();
                if (n == 1)
                {
                    Session["qui"] = "12345ALHAMWI";
                    Response.Redirect("https://localhost:44323/Adherent/Index");
                    //Response.Write("<script>alert('"+ id.Text + "')</script>");
                }
            }
            else if (CheckIDexacclyt() == 2)
            {
                string sql1 = "select count(*) from organisateurs where Treasurer = @id and key_Treasurer =  @key";
                SqlCommand cmd = new SqlCommand(sql1, con);
                cmd.Parameters.AddWithValue("@id", id.Text);
                cmd.Parameters.AddWithValue("@key", key.Text);
                con.Open();
                int n = int.Parse(cmd.ExecuteScalar().ToString());
                con.Close();
                if (n == 1)
                {
                    Session["qui"] = "12345FAHMI";
                    Response.Redirect("https://localhost:44323/Adherent/Index");

                }
            }
            else if (CheckIDexacclyt() == 3)
            {
                string sql1 = "select count(*) from organisateurs where Redacteur = @id and key_Redacteur = @key";
                SqlCommand cmd = new SqlCommand(sql1, con);
                cmd.Parameters.AddWithValue("@id", id.Text);
                cmd.Parameters.AddWithValue("@key", key.Text);
                con.Open();
                int n = int.Parse(cmd.ExecuteScalar().ToString());
                con.Close();
                if (n == 1)
                {
                    Session["qui"] = "12345BOULASSEL";
                    //Response.Write("<script>alert('" + Session["qui"] + "')</script>");

                    Response.Redirect("https://localhost:44323/Adherent/Index");
                }
            }
            else if (CheckIDexacclyt() == 4)
            {
                string sql1 = "select count(*) from Adherent where Email = @id and password = @key";
                SqlCommand cmd = new SqlCommand(sql1, con);
                cmd.Parameters.AddWithValue("@id", id.Text);
                cmd.Parameters.AddWithValue("@key", key.Text);
                con.Open();
                int n = int.Parse(cmd.ExecuteScalar().ToString());
                con.Close();
                if (n == 1)
                {
                    Session["qui"] = "adherent";
                    Session["adhd"] = id.Text.Trim();
                    Response.Redirect("https://localhost:44323/Home/Index?Email="+Session["adhd"]);
                    //Response.Redirect("MesInfos.aspx?Email=" + Session["adhd"]);


                    /// Response.Write("<script>alert('" + id.Text + " " + Session["qui"]+"')</script>");
                }
            }
            else if(CheckIDexacclyt() == 6 || CheckIDexacclyt() == 0)
            {
                Response.Write("<script>alert('N existe pas cette user')</script>");
                LinkButton1.Visible = true;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
        }

        protected void LinkButton1_Click1(object sender, EventArgs e)
        {
            Session["qui"] = "adherent";
            Response.Redirect("inscription.aspx?qui=1");

        }
    }
}