namespace association.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("association")]
    public partial class association
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public association()
        {
            Adherents = new HashSet<Adherent>();
        }

        [Key]
        public int ID_association { get; set; }

        [StringLength(25)]
        public string nom_association { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_Creation { get; set; }

        public int? ID_description { get; set; }

        public int? Idorganisateurs { get; set; }

        public int? code_adherent { get; set; }

        public virtual Adherent Adherent { get; set; }

        public virtual description description { get; set; }

        public virtual organisateur organisateur { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Adherent> Adherents { get; set; }
    }
}
