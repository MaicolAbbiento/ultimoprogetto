namespace ultimoprogetto.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pizza")]
    public partial class pizza
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public pizza()
        {
            pizeeoridnate = new HashSet<pizeeoridnate>();
        }

        [Key]
        public int idpizza { get; set; }

        [Column(TypeName = "money")]
        public decimal costo { get; set; }

        [NotMapped]
        public int idpizzaimpt { get; set; }

        public string img { get; set; }

        [Required]
        public string ingredienti { get; set; }

        [Required]
        [StringLength(50)]
        public string nome { get; set; }

        [Required]
        public int tempoConsegnamin { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pizeeoridnate> pizeeoridnate { get; set; }
    }
}