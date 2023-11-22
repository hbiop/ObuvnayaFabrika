namespace ObuvnayaFabrika.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Clienti")]
    public partial class Clienti
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clienti()
        {
            Otzivi = new HashSet<Otzivi>();
            Zakaz = new HashSet<Zakaz>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KodClienta { get; set; }

        [Required]
        [StringLength(50)]
        public string Naimenovanie { get; set; }

        [Required]
        [StringLength(50)]
        public string Pochta { get; set; }

        [Required]
        [StringLength(20)]
        public string Telefon { get; set; }

        public int Dom { get; set; }

        public int Ulica { get; set; }

        public virtual Ulici Ulici { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Otzivi> Otzivi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zakaz> Zakaz { get; set; }
    }
}
