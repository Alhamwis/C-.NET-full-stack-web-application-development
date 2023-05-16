using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;

namespace association
{
    public partial class inscription : System.Web.UI.Page
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


            if (!IsPostBack)
            {
                chargerVille();
                chargerRole();
                if (Session["run"] == "1")
                {
                    var r = Request.QueryString.Get("code_adherent");
                    int z = int.Parse(r);
                    if (z == 0)
                    {
                        Response.Write("<script>alert('Ajouter Adherent')</script>");
                    }
                    else
                    {
                        Btn2.Visible = true;
                        Button1.Visible = false;

                        string constr = ConfigurationManager.ConnectionStrings["cnx"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(constr))
                        {
                            using (SqlCommand cmd = new SqlCommand("SELECT nom_complet,sexe ,num_tel,Email,password,date_naissance,villes,role,paid FROM Adherent WHERE code_adherent = '" + Request.QueryString.Get("code_adherent") + "'"))
                            {
                                cmd.CommandType = CommandType.Text;
                                cmd.Connection = con;
                                con.Open();
                                using (SqlDataReader sdr = cmd.ExecuteReader())
                                {
                                    sdr.Read();
                                    if (sdr["sexe"].ToString() == "Homme")
                                    {
                                        IsMale.Checked = true;
                                    }
                                    else
                                    {
                                        IsFemale.Checked = true;
                                    }
                                    TextBEmail.Text = sdr["nom_complet"].ToString();
                                    TextBNom.Text = TextBEmail.Text.Split(new char[] { ' ' }).FirstOrDefault().ToString();
                                    TextBPrenom.Text = TextBEmail.Text.Split(new char[] { ' ' }).LastOrDefault().ToString();
                                    TextPhone.Text = sdr["num_tel"].ToString();
                                    TextBEmail.Text = sdr["Email"].ToString();
                                    TextBPassword.Text = sdr["password"].ToString();
                                    TextDate.Text = sdr["date_naissance"].ToString();
                                    TexPaiement.Text = sdr["paid"].ToString();

                                    SqlCommand cmd1 = new SqlCommand("select idville from ville inner join Adherent on ville.idville = Adherent.villes   WHERE code_adherent = '" + Request.QueryString.Get("code_adherent") + "'");
                                    cmd1.CommandType = CommandType.Text;
                                    cmd1.Connection = con;
                                    int x = (Int32)cmd1.ExecuteScalar();
                                    DropDownList1.SelectedIndex = x - 1;
                                    SqlCommand cmd2 = new SqlCommand("select idRole from role inner join Adherent on role.idRole = Adherent.role   WHERE code_adherent = '" + Request.QueryString.Get("code_adherent") + "'");
                                    cmd2.CommandType = CommandType.Text;
                                    cmd2.Connection = con;
                                    int y = (Int32)cmd2.ExecuteScalar();
                                    DropDownList2.SelectedIndex = y - 1;
                                }
                                con.Close();
                            }
                        }
                    }
                }

            }
        }
        void chargerVille()
        {
            SqlCommand com = new SqlCommand("select * from ville", con);
            // table name   
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);  // fill dataset  
            DropDownList1.DataTextField = ds.Tables[0].Columns["ville"].ToString(); // text field name of table dispalyed in dropdown       
            DropDownList1.DataValueField = ds.Tables[0].Columns["idville"].ToString();
            // to retrive specific  textfield name   
            DropDownList1.DataSource = ds.Tables[0];      //assigning datasource to the dropdownlist  
            DropDownList1.DataBind();  //binding dropdownlist  
        }
        void chargerRole()
        {
            SqlCommand com = new SqlCommand("select * from role", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DropDownList2.DataTextField = ds.Tables[0].Columns["role"].ToString();
            DropDownList2.DataValueField = ds.Tables[0].Columns["idRole"].ToString();
            DropDownList2.DataSource = ds.Tables[0];
            DropDownList2.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {

                string sexe;
                if (IsFemale.Checked)
                {
                    sexe = "Femme";
                }
                else
                {
                    sexe = "Homme";
                }
                string nom_complet = TextBNom.Text + " " + TextBPrenom.Text;
                double paid = Convert.ToDouble(TexPaiement.Text);
                string date = TextDate.Text;
                string query = @"INSERT INTO Adherent VALUES(@nom_complet, @sexe, @phone, @email, @passowrd,  @date_nai, default, @ville, @paid, @role)";
                cmd = new SqlCommand(query, con);
                if (Checktextbox() == true)
                {
                    if (Checkage() == true)
                    {
                        if (Checkpaid() == true)
                        {

                            if (Checkemail() == false)
                            {
                                if (Checkphone() == false)
                                {
                                    cmd.Parameters.AddWithValue("@nom_complet", nom_complet);
                                    cmd.Parameters.AddWithValue("@sexe", sexe);
                                    cmd.Parameters.AddWithValue("@phone", TextPhone.Text);
                                    cmd.Parameters.AddWithValue("@email", TextBEmail.Text);
                                    cmd.Parameters.AddWithValue("@passowrd", TextBPassword.Text);
                                    cmd.Parameters.AddWithValue("@date_nai", date);
                                    cmd.Parameters.AddWithValue("@ville", DropDownList1.SelectedIndex + 1);
                                    cmd.Parameters.AddWithValue("@paid", paid);
                                    cmd.Parameters.AddWithValue("@role", DropDownList2.SelectedIndex + 1);
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                    Response.Write("<script>alert('Nouvel enregistrement ajouté')</script>");
                                    vidertextbox();
                                    if (Session["qui"] == "Adherent")
                                    {
                                        Response.Redirect("authentification.aspx");
                                    }
                                    var r = Request.QueryString.Get("qui");
                                    int z = int.Parse(r);
                                    if (z == 1)
                                    {
                                        Response.Redirect("authentification.aspx");
                                    }
                                }
                                else
                                {
                                    Response.Write("<script>alert('Phone Existe')</script>");
                                }
                            }
                            else
                            {
                                Response.Write("<script>alert('Email Existe')</script>");
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('paiement max est 2000')</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('moins de 18 ans')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('veuillez remplir toutes les informations')</script>");
                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }


        }

        protected void But2_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextDate.Text = Calendar1.SelectedDate.ToShortDateString();
            Calendar1.Visible = false;
        }
        public bool Checkage()
        {
            string iDate = TextDate.Text;
            DateTime oDate = Convert.ToDateTime(iDate);
            //MessageBox.Show(oDate.Day + " " + oDate.Month + "  " + oDate.Year);
            var today = DateTime.Today;
            var age = today.Year - oDate.Year;
            if (oDate > today.AddYears(-age))
                age--;
            Console.WriteLine(age);
            if (age > 18)
            {
                return true;
            }
            return false;
        }
        public bool Checkpaid()
        {
            double paid = Convert.ToDouble(TexPaiement.Text);
            if (paid <= 2000)
            {
                return true;
            }
            return false;
        }
        public bool Checkemail()
        {
            string sql1 = "select count(*) from Adherent where Email=@email";
            SqlCommand cmd = new SqlCommand(sql1, con);
            cmd.Parameters.AddWithValue("@email", TextBEmail.Text);
            con.Open();
            int n = int.Parse(cmd.ExecuteScalar().ToString());
            con.Close();
            if (n == 1)
            {
                return true;
            }
            return false;
        }
        public bool Checkphone()
        {
            string sql1 = "select count(*) from Adherent where num_tel=@phone ";
            SqlCommand cmd = new SqlCommand(sql1, con);
            cmd.Parameters.AddWithValue("@phone", TextPhone.Text);
            con.Open();
            int n = int.Parse(cmd.ExecuteScalar().ToString());
            con.Close();
            if (n == 1)
            {
                return true;
            }
            return false;
        }

        public bool Checktextbox()
        {
            if (
                TextBNom.Text == string.Empty || TextBPrenom.Text == string.Empty || TextDate.Text == string.Empty || TextPhone.Text == string.Empty ||
                TextBEmail.Text == string.Empty || TextBPassword.Text == string.Empty || TexPaiement.Text == string.Empty
              )
            {
                return false;
            }
            return true;
        }
        void vidertextbox()
        {
            TextBNom.Text = string.Empty;
            TextBPrenom.Text = string.Empty;
            TextDate.Text = string.Empty;
            TextPhone.Text = string.Empty;
            TextBEmail.Text = string.Empty;
            TextBPassword.Text = string.Empty;
            TexPaiement.Text = string.Empty;
            IsFemale.Checked = false;
            DropDownList1.SelectedIndex = 0;
            DropDownList2.SelectedIndex = 0;
        }


        protected void Btn2_Click(object sender, EventArgs e)
        {
            try
            {

                string sexe;
                if (IsFemale.Checked)
                {
                    sexe = "Femme";
                }
                else
                {
                    sexe = "Homme";
                }
                string nom_complet = TextBNom.Text + " " + TextBPrenom.Text;
                double paid = Convert.ToDouble(TexPaiement.Text);
                string date = TextDate.Text;
                string query = @"UPDATE Adherent SET nom_complet = @nom_complet  , sexe = @sexe  , num_tel = @num_tel  ,Email = @Email ,password = @password ,date_naissance = @date_naissance ,Villes = @Villes ,paid = @paid  ,role = @role  WHERE code_adherent = @code_adherent";
                cmd = new SqlCommand(query, con);
                if (Checktextbox() == true)
                {
                    if (Checkage() == true)
                    {
                        if (Checkpaid() == true)
                        {


                            cmd.Parameters.AddWithValue("@nom_complet", nom_complet);
                            cmd.Parameters.AddWithValue("@sexe", sexe);
                            cmd.Parameters.AddWithValue("@num_tel", TextPhone.Text);
                            cmd.Parameters.AddWithValue("@Email", TextBEmail.Text);
                            cmd.Parameters.AddWithValue("@password", TextBPassword.Text);
                            cmd.Parameters.AddWithValue("@date_naissance", date);
                            cmd.Parameters.AddWithValue("@Villes", DropDownList1.SelectedIndex + 1);
                            cmd.Parameters.AddWithValue("@paid", paid);
                            cmd.Parameters.AddWithValue("@role", DropDownList2.SelectedIndex + 1);
                            cmd.Parameters.AddWithValue("@code_adherent", Request.QueryString.Get("code_adherent"));

                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            Response.Write("<script>alert('Nouveau Enregistré Mis à jour')</script>");
                            //vidertextbox();

                        }
                        else
                        {
                            Response.Write("<script>alert('paiement max est 2000')</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('moins de 18 ans')</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('veuillez remplir toutes les informations')</script>");
                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('" + ex.Message + "')</script>");
            }

        }

        public int Adherentpaid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Adherentpaid", con);
            int x = (int)cmd.ExecuteScalar();
            con.Close();
            return x;
        }
    }
}