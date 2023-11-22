namespace ObuvnayaFabrika.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CehPartia")]
    public partial class CehPartia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KodCehPartia { get; set; }

        public int Ceh { get; set; }

        public int Partia { get; set; }

        public int Etap { get; set; }

        public int Status { get; set; }

        public virtual Ceh Ceh1 { get; set; }

        public virtual Etapi Etapi { get; set; }

        public virtual Status Status1 { get; set; }

        public virtual Tovar Tovar { get; set; }
    }
}
