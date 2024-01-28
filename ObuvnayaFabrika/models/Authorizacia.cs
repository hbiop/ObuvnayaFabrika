namespace ObuvnayaFabrika.models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Authorizacia")]
    public partial class Authorizacia
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Authorizacia()
        {
            Sotrudniki = new HashSet<Sotrudniki>();
        }

        [Key]
        public int KodAuthorizacii { get; set; }

        [Required(ErrorMessage = "Не указан логин")]
        [StringLength(50)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string Parol { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sotrudniki> Sotrudniki { get; set; }
    }
}
