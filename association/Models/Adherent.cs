namespace association.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;


    [Table("Adherent")]
    public partial class Adherent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Adherent()
        {
            associations = new HashSet<association>();
           // associations1 = new HashSet<association>();
        }

        [Key]
        public int code_adherent { get; set; }

        [StringLength(55)]
        public string nom_complet { get; set; }

        [Required]
        [StringLength(10)]
        public string sexe { get; set; }

        [Required]
        [StringLength(25)]
        public string num_tel { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(16)]
        public string password { get; set; }

        [Column(TypeName = "date")]
        public DateTime date_naissance { get; set; }

        [Column(TypeName = "date")]
        public DateTime date_inscr { get; set; }

        public int Villes { get; set; }

        [Column(TypeName = "money")]
        public decimal paid { get; set; }

        public int role { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(10)]
        public string Paye { get; set; }

        public virtual role role1 { get; set; }

        public virtual ville ville { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<association> associations { get; set; }

       // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
       // public virtual ICollection<association> associations1 { get; set; }

        public List<Adherent> listar()
        {
            var adherent = new List<Adherent>();
            string cadena = "SELECT * FROM Adherent";
            try
            {
                using (var contenedor = new Model1())
                {
                    adherent = contenedor.Database.SqlQuery<Adherent>(cadena).ToList();
                }
            }
            catch (Exception)
            {

                //throw;
            }
            return adherent;
        }

        //public Boolean Insertar(
        //    string nom_complet, string sexe, string num_tel, string Email, string password, DateTime date_naissance,
        //   DateTime date_inscr, int Villes, float paid, int role
        //    )
        //{
        //    bool estado = false;
        //    string cadena = "'" + nom_complet + "',";
        //    cadena = cadena + "'" + sexe + "',";
        //    cadena = cadena + "'" + num_tel + "'";
        //    cadena = cadena + "'" + Email + "'";
        //    cadena = cadena + "'" + password + "'";
        //    cadena = cadena + "'" + date_naissance + "'";
        //    cadena = cadena + "'" + date_inscr + "'";
        //    cadena = cadena + "'" + Villes + "'";
        //    cadena = cadena + "'" + paid + "'";
        //    cadena = cadena + "'" + role + "'";
        //    try
        //    {
        //        using (var cnx = new Model1())
        //        {
        //            int r = cnx.Database.ExecuteSqlCommand("INSERT INTO Adherent VALUES (" + cadena + ")");
        //            if (r == 1)
        //            {
        //                estado = true;
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        estado = false;
        //        //throw;
        //    }
        //    return estado;
        //}
        public Adherent un_registro(int id)
        {
            var registro = new Adherent();
            try
            {
                using (var cnx = new Model1())
                {
                    registro = cnx.Adherents.Where(a => a.code_adherent == id).Single();
                }
            }
            catch (Exception)
            {

                //throw;
            }
            return registro;
        }

        public Boolean Edit
            (
            int code_adherent, string nom_complet, string sexe, string num_tel, string Email, string password, string date_naissance,
            DateTime date_inscr, int Villes, float paid ,int role
            )
        {
            bool estado = false;
            string cadena = "nom_complet='" + nom_complet + "', sexe='" + sexe + "', num_tel='" + num_tel + "',Email='" + Email + "',password='" + password + "',date_naissance='" + date_naissance + "',date_inscr='" + date_inscr + "',Villes='" + Villes + "',paid='" + paid + "',role='" + role + "'";
            try
            {
                using (var cnx = new Model1())
                {
                    int r = cnx.Database.ExecuteSqlCommand("UPDATE Adherent SET " + cadena + " WHERE code_adherent=" + code_adherent);
                    if (r == 1)
                    {
                        estado = true;
                    }
                }
            }
            catch (Exception)
            {
                estado = false;
                //throw;
            }
            return estado;
        }

        public Boolean Delete(int code_adherent)
        {
            bool estado = false;
            try
            {
                using (var cnx = new Model1())
                {
                    int r = cnx.Database.ExecuteSqlCommand("DELETE FROM Adherent WHERE code_adherent=" + code_adherent);
                    if (r == 1)
                    {
                        estado = true;
                    }
                }
            }
            catch (Exception)
            {
                estado = false;
                //throw;
            }
            return estado;
        }


    }
}
