namespace AddPassword.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sklad")]
    public partial class Sklad
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sklad()
        {
            MaterialNaSklade = new HashSet<MaterialNaSklade>();
            TovarNaSklade = new HashSet<TovarNaSklade>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KodSklada { get; set; }

        [Required]
        [StringLength(30)]
        public string Naimenovanie { get; set; }

        public int Dom { get; set; }

        public int Ulica { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialNaSklade> MaterialNaSklade { get; set; }

        public virtual Ulici Ulici { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TovarNaSklade> TovarNaSklade { get; set; }
    }
}
