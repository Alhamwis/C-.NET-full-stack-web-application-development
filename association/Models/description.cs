namespace association.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("description")]
    public partial class description
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public description()
        {
            associations = new HashSet<association>();
        }

        [Key]
        public int ID_description { get; set; }

        [StringLength(255)]
        public string Activite { get; set; }

        [StringLength(255)]
        public string but { get; set; }

        [StringLength(255)]
        public string Categorie { get; set; }

        [StringLength(255)]
        public string beneficiaires { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<association> associations { get; set; }
    }
}
