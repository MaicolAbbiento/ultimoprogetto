namespace ultimoprogetto.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("amministatori")]
    public partial class amministatori
    {
        [Key]
        public int idamministratori { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "inserisci username")]
        public string username { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "inserisci password")]
        public string password { get; set; }
    }
}