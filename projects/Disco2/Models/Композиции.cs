namespace Disco2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Композиции")]
    public partial class Композиции
    {
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Композиции()
        {
            
            Композиторы = new List<Музыканты>();
            Авторы = new List<Музыканты>();
            Исполнение_композиций = new List<Исполнение_композиций>();
        }

        
        [Key]
        [Column("IDкомпозиции")]

        public Guid ID_композиции { get; set; }

        [Column("Название")]
        [Required]
        [StringLength(30)]
        
        public string Название { get; set; }

        [Column("Год выпуска")]
        public int Год_выпуска { get; set; }

        
        [Column("ID жанра")]

        public int ID_жанра { get; set; }
        [NotMapped]
        public Guid ID_музыканта{ get; set; }
        [NotMapped]
        public Guid ID_композитора { get; set; }

        public virtual Жанры Жанры { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<Исполнение_композиций> Исполнение_композиций { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<Музыканты> Композиторы { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<Музыканты> Авторы { get; set; }
    }
}
