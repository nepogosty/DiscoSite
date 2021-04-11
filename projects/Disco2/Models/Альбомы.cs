namespace Disco2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Альбомы
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Альбомы()
        {
            Исполнение_композиций = new List<Исполнение_композиций>();
        }

        [Key]
        [Column("ID альбома")]
        public Guid ID_альбома { get; set; }

        [Required]
        [StringLength(30)]
        public string Название { get; set; }

        [Column("Дата выпуска")]
        public int Дата_выпуска { get; set; }

        [Column("ID типа")]
        public int ID_типа { get; set; }

        public virtual Тип Тип { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<Исполнение_композиций> Исполнение_композиций { get; set; }
    }
}
