namespace ObuvnayaFabrika.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nakladnaya")]
    public partial class Nakladnaya
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nakladnaya()
        {
            MaterialNakladnaya = new HashSet<MaterialNakladnaya>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KodNakladnoy { get; set; }

        public int KodPostavshiaka { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataPostavki { get; set; }

        public int KodSotrudnikaPrinivshego { get; set; }

        public int Cena { get; set; }

        public int KodSklada { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialNakladnaya> MaterialNakladnaya { get; set; }

        public virtual Postavshiki Postavshiki { get; set; }

        public virtual Sotrudniki Sotrudniki { get; set; }
    }
}
