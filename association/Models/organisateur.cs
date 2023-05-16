namespace association.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class organisateur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public organisateur()
        {
            associations = new HashSet<association>();
        }

        [Key]
        public int Idorganisateurs { get; set; }

        [StringLength(25)]
        public string CHEF { get; set; }

        [StringLength(25)]
        public string Treasurer { get; set; }

        [StringLength(25)]
        public string Redacteur { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(25)]
        public string key_CHEF { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(25)]
        public string key_Treasurer { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(25)]
        public string key_Redacteur { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<association> associations { get; set; }
    }
}
