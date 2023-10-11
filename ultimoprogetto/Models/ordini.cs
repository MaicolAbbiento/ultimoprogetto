namespace ultimoprogetto.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ordini")]
    public partial class ordini
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ordini()
        {
            pizeeoridnate = new HashSet<pizeeoridnate>();
        }

        [Key]
        public int idordine { get; set; }

        [StringLength(20)]
        public string indirizzo { get; set; }

        [Required]
        public int idcliente { get; set; }

        [Column(TypeName = "date")]
        public DateTime dataordine { get; set; }

        [Column(TypeName = "money")]
        public decimal costotot { get; set; }

        public bool completato { get; set; }
        public virtual cliente cliente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pizeeoridnate> pizeeoridnate { get; set; }
    }
}