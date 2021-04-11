namespace Disco2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Тип коллектива")]
    public partial class Тип_коллектива
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Тип_коллектива()
        {
            Коллективы = new List<Коллективы>();
        }

        [Key]
        [Column("ID типа коллектива")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_типа_коллектива { get; set; }

        [Required]
        [StringLength(30)]
        public string Наименование { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<Коллективы> Коллективы { get; set; }
    }
}
