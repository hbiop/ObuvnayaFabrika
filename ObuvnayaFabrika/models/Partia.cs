namespace ObuvnayaFabrika.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Partia")]
    public partial class Partia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Partia()
        {
            TovarNaSklade = new HashSet<TovarNaSklade>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KodPartii { get; set; }

        public int Tovar { get; set; }

        public int Kolichestvo { get; set; }

        public virtual Tovar Tovar1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TovarNaSklade> TovarNaSklade { get; set; }
    }
}
