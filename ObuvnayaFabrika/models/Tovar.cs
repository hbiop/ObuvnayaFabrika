namespace ObuvnayaFabrika.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tovar")]
    public partial class Tovar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tovar()
        {
            CehPartia = new HashSet<CehPartia>();
            Partia = new HashSet<Partia>();
            TovarMaterial = new HashSet<TovarMaterial>();
            TovarRazmer = new HashSet<TovarRazmer>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KodTovara { get; set; }

        [Required]
        [StringLength(50)]
        public string Naimenovanie { get; set; }

        public int Kategoria { get; set; }

        [Required]
        [StringLength(10)]
        public string CenaTovara { get; set; }

        public int Cvet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CehPartia> CehPartia { get; set; }

        public virtual Cvet Cvet1 { get; set; }

        public virtual Kategorii Kategorii { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Partia> Partia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TovarMaterial> TovarMaterial { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TovarRazmer> TovarRazmer { get; set; }
    }
}
