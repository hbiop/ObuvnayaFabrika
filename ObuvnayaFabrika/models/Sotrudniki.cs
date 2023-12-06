namespace ObuvnayaFabrika.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sotrudniki")]
    public partial class Sotrudniki
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sotrudniki()
        {
            Nakladnaya = new HashSet<Nakladnaya>();
        }

        [Key]
        public int KodSotrudnika { get; set; }

        [Required]
        [StringLength(50)]
        public string Imia { get; set; }

        [Required]
        [StringLength(50)]
        public string Familia { get; set; }

        [Required]
        [StringLength(50)]
        public string Otchestvo { get; set; }

        [Required]
        [StringLength(20)]
        public string NomerTelefona { get; set; }

        [Required]
        [StringLength(50)]
        public string Pochta { get; set; }

        public int Brigada { get; set; }

        public int KodParolia { get; set; }

        public int KodRoli { get; set; }

        public virtual Authorizacia Authorizacia { get; set; }

        public virtual Brigadi Brigadi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nakladnaya> Nakladnaya { get; set; }

        public virtual Roli Roli { get; set; }
    }
}
