namespace AddPassword.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Otzivi")]
    public partial class Otzivi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KodOtziva { get; set; }

        public int Magazine { get; set; }

        [Required]
        public string Otziv { get; set; }

        public virtual Clienti Clienti { get; set; }
    }
}
