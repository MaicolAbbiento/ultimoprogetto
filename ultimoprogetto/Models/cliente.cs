namespace ultimoprogetto.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cliente")]
    public partial class cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cliente()
        {
            ordini = new HashSet<ordini>();
        }

        [Key]
        public int idcliente { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "inserisci username")]
        public string username { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "inserisci password")]
        public string password { get; set; }

        [NotMapped]
        [Required]
        [StringLength(50)]
        [Display(Name = "conferma password")]
        public string confermaPassword { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "inserisci nome")]
        public string nome { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "inserisci cognome")]
        public string cognome { get; set; }

        [Required]
        [StringLength(17)]
        [Display(Name = "inserisci contatto telefonico")]
        public string contattotelefonico { get; set; }

        [Required]
        [StringLength(120)]
        [Display(Name = "inserisci email")]
        public string email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ordini> ordini { get; set; }
    }
}