namespace ObuvnayaFabrika.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MaterialNakladnaya")]
    public partial class MaterialNakladnaya
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KodMaterialNakladnaya { get; set; }

        public int KodNakladnoy { get; set; }

        public int Kolichestvo { get; set; }

        public int Cena { get; set; }

        public int KodMateriala { get; set; }

        public virtual Materiali Materiali { get; set; }

        public virtual Nakladnaya Nakladnaya { get; set; }
    }
}
