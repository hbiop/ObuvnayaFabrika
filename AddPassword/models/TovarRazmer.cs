namespace AddPassword.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TovarRazmer")]
    public partial class TovarRazmer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KodTovarRazmer { get; set; }

        public int Tovar { get; set; }

        public int Razmer { get; set; }

        public virtual Tovar Tovar1 { get; set; }
    }
}
