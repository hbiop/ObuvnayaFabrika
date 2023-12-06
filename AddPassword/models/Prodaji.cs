namespace AddPassword.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Prodaji")]
    public partial class Prodaji
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KodProdaji { get; set; }

        public int Zakaz { get; set; }

        [Column(TypeName = "date")]
        public DateTime Data { get; set; }

        public TimeSpan Vremia { get; set; }

        public int Summa { get; set; }

        public virtual Zakaz Zakaz1 { get; set; }
    }
}
