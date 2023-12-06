namespace ObuvnayaFabrika.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TovarMaterial")]
    public partial class TovarMaterial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KodTovarMaterial { get; set; }

        public int Material { get; set; }

        public int Tovar { get; set; }

        public virtual Materiali Materiali { get; set; }

        public virtual Tovar Tovar1 { get; set; }
    }
}
