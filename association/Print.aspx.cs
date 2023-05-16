using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;

namespace association
{
    public partial class Print : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            cmd = new SqlCommand(@"SELECT Adherent.nom_complet, Adherent.sexe, Adherent.num_tel, Adherent.Email, Adherent.password, DATEDIFF(yyyy, Adherent.date_naissance, GETDATE()) AS Age, Adherent.date_inscr, ville.ville, Adherent.paid, Adherent.Paye, role.role FROM Adherent INNER JOIN role ON Adherent.role = role.idRole INNER JOIN ville ON Adherent.Villes = ville.idville WHERE Adherent.nom_complet ='" + Request.QueryString.Get("nom_complet") + "'", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Session["nom_complet"] = rdr["nom_complet"].ToString();
                Session["role"] = rdr["role"].ToString();
                Session["ville"] = rdr["ville"].ToString();
                //Label6.Text = Session["nom_complet"].ToString();
                //Label3.Text = Session["ville"].ToString();
                //Label2.Text = Session["role"].ToString();

            }
            //Response.Redirect("https://localhost:44323/HtmPrint.html?nom_complet="+Session["nom_complet"]+ "?role="+ Session["role"]+ "?ville="+ Session["ville"]+"?Code="+ Session["Code"]);
            Response.Redirect(String.Format("HtmPrint.html?nom_complet={0}&role={1}&ville={2}", Server.UrlEncode(Session["nom_complet"].ToString()), Server.UrlEncode(Session["role"].ToString()), Server.UrlEncode(Session["ville"].ToString())));
        }


    }

}
