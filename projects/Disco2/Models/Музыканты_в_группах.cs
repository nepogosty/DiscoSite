namespace Disco2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Музыканты в группах")]
    public partial class Музыканты_в_группах
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Музыканты_в_группах()
        {
            Исполнение_композиций = new List<Исполнение_композиций>();
        }

        [Column("Год вступления")]
        public int Год_вступления { get; set; }

        [Column("Год ухода")]
        public int? Год_ухода { get; set; }

        [Key]
        [Column("ID музыканта", Order = 0)]
        public Guid ID_музыканта { get; set; }

        [Key]
        [Column("ID коллектива", Order = 1)]
        public Guid ID_коллектива { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<Исполнение_композиций> Исполнение_композиций { get; set; }

        public virtual Коллективы Коллективы { get; set; }

        public virtual Музыканты Музыканты { get; set; }
    }
}
