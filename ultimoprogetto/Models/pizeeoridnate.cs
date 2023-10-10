namespace ultimoprogetto.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("pizeeoridnate")]
    public partial class pizeeoridnate
    {
        [Key]
        public int idpizeeoridnate { get; set; }

        [Required]
        public int idordine { get; set; }

        public int quantita { get; set; }

        [Required]
        public int idpizza { get; set; }

        public virtual ordini ordini { get; set; }

        public virtual pizza pizza { get; set; }
    }
}