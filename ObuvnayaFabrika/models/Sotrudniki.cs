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

        [Required(ErrorMessage = "Не указано имя пользователя")]
        [StringLength(50)]
        public string Imia { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        [StringLength(50)]
        public string Familia { get; set; }

        [Required(ErrorMessage = "Не указано отчество")]
        [StringLength(50)]
        public string Otchestvo { get; set; }

        [Required(ErrorMessage = "Номер телефона не указан" )]
        [StringLength(20)]
        [RegularExpression(@"8\([0-9][0-9][0-9]\)-[0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]",ErrorMessage = "Телефон в неправильном формате")]
        public string NomerTelefona { get; set; }

        [Required(ErrorMessage = "Почта не указана")]
        [StringLength(50, MinimumLength = 10)]
        //[RegularExpression(@"[a-zA-z0-9]+\@[a-zA-z0-9]+", ErrorMessage = "Почта в неправильном формате")]
        public string Pochta { get; set; }
        [Required]
        public int Brigada { get; set; }
        public int KodParolia { get; set; }
        [Required]
        public int KodRoli { get; set; }
        
        public virtual Authorizacia Authorizacia { get; set; }
        
        public virtual Brigadi Brigadi { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nakladnaya> Nakladnaya { get; set; }
        public virtual Roli Roli { get; set; }
    }
}
