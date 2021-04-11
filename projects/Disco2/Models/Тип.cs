namespace Disco2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Тип
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Тип()
        {
           Альбомы = new List<Альбомы>();
        }

        [Key]
        [Column("ID типа")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_типа { get; set; }

        [Required]
        [StringLength(30)]
        public string Название { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<Альбомы> Альбомы { get; set; }
    }
}
