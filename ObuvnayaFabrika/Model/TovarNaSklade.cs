namespace ObuvnayaFabrika.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TovarNaSklade")]
    public partial class TovarNaSklade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KodSkladTovar { get; set; }

        public int Sklad { get; set; }

        public int Partia { get; set; }

        public virtual Partia Partia1 { get; set; }

        public virtual Sklad Sklad1 { get; set; }
    }
}
