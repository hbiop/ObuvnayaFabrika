namespace ObuvnayaFabrika.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Authorizacia")]
    public partial class Authorizacia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KodAuthorizacii { get; set; }

        public int Sotrudnik { get; set; }

        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        [Required]
        [StringLength(150)]
        public string Parol { get; set; }

        public virtual Sotrudniki Sotrudniki { get; set; }
    }
}
