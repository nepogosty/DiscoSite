namespace Disco2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Жанры
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Жанры()
        {
            Композиции = new List<Композиции>();
        }

        [Key]
        [Column("ID жанра")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_жанра { get; set; }

        [Required]
        [StringLength(30)]
        public string Название { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<Композиции> Композиции { get; set; }
    }
}
