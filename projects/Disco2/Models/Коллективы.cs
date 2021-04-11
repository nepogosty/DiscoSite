namespace Disco2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Коллективы
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Коллективы()
        {
           
            Музыканты_в_группах = new List<Музыканты_в_группах>();
        }

        [Key]
        [Column("ID коллектива")]
        public Guid ID_коллектива { get; set; }

        [Required]
        [StringLength(30)]
        public string Страна { get; set; }

        [Required]
        [StringLength(50)]
        public string Название { get; set; }

        [Column("ID типа коллектива")]
        public int ID_типа_коллектива { get; set; }

        [Column("Год создания", TypeName = "date")]
        public DateTime Год_создания { get; set; }

        public virtual Тип_коллектива Тип_коллектива { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<Музыканты_в_группах> Музыканты_в_группах { get; set; }
    }
}
