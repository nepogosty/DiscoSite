namespace Disco2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Музыканты
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Музыканты()
        {
            /*  Музыканты_в_группах = new HashSet<Музыканты_в_группах>();
              Композиции = new HashSet<Композиции>();
              Композиции1 = new HashSet<Композиции>();*/
            Музыканты_в_группах = new List<Музыканты_в_группах>();
            Авторы = new List<Композиции>();
            Композиторы= new List<Композиции>();
        }

        [Key]
        [Column("IDмузыканта")]
        public Guid ID_музыканта { get; set; }

        [Required]
        [StringLength(30)]
        public string Фамилия { get; set; }

        [Required]
        [StringLength(30)]
        public string Имя { get; set; }

        [StringLength(30)]
        public string Отчество { get; set; }

        [Required]
        [StringLength(30)]
        public string Гражданство { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<Музыканты_в_группах> Музыканты_в_группах { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<Композиции> Авторы { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<Композиции> Композиторы{ get; set; }
       
    }
}
