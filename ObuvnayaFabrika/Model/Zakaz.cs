namespace ObuvnayaFabrika.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Zakaz")]
    public partial class Zakaz
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Zakaz()
        {
            Prodaji = new HashSet<Prodaji>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int KodZakaza { get; set; }

        public int Zakazchik { get; set; }

        public int Kolichestvo { get; set; }

        public int StatusZakaza { get; set; }

        public virtual Clienti Clienti { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prodaji> Prodaji { get; set; }

        public virtual Status Status { get; set; }
    }
}
