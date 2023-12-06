namespace ObuvnayaFabrika.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Postavshiki")]
    public partial class Postavshiki
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Postavshiki()
        {
            Nakladnaya = new HashSet<Nakladnaya>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KodPostavshika { get; set; }

        [Required]
        [StringLength(50)]
        public string Naimenovanie { get; set; }

        public int Dom { get; set; }

        public int Ulica { get; set; }

        [Required]
        [StringLength(20)]
        public string NomerTelefona { get; set; }

        [Required]
        [StringLength(50)]
        public string Pochta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nakladnaya> Nakladnaya { get; set; }

        public virtual Ulici Ulici { get; set; }
    }
}
