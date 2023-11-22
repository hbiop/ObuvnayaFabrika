namespace ObuvnayaFabrika.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MaterialNaSklade")]
    public partial class MaterialNaSklade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KodSkladMaterial { get; set; }

        public int Sklad { get; set; }

        public int Material { get; set; }

        public int? Kolichestvo { get; set; }

        public virtual Materiali Materiali { get; set; }

        public virtual Sklad Sklad1 { get; set; }
    }
}
