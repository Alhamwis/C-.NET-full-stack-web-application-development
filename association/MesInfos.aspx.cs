using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace association
{
    public partial class MesInfos : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);
        SqlCommand cmd;

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
        }
    }
}