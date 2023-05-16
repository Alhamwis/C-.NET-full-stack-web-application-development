namespace association.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Web.Mvc;

    [Table("ville")]
    public partial class ville
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ville()
        {
            Adherents = new HashSet<Adherent>();
        }
        public List<ville> ville_Liste { get; set; }
        public int? villeid { get; set; }
        public int? villee { get; set; }

        [Key]
        public int idville { get; set; }

        [Column("ville")]
        [StringLength(25)]
        public string ville1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Adherent> Adherents { get; set; }
        public class AddVilleViewModel
        {
            public string ville { get; set; }
            public List<SelectListItem> villes_liste { get; set; }
        }

    }
}
