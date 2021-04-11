namespace Disco2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Исполнение композиций")]
    public partial class Исполнение_композиций
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Исполнение_композиций()
        {
            Альбомы = new List<Альбомы>();
            
        }

        [Column("Дата исполнения", TypeName = "date")]
        public DateTime Дата_исполнения { get; set; }

        [Column("ID музыканта")]
        public Guid? ID_музыканта { get; set; }

        [Column("ID коллектива")]
        public Guid? ID_коллектива { get; set; }

        [Column("ID композиции")]
        public Guid? ID_композиции { get; set; }

        [Key]
        [Column("ID исполнение композиции")]
        public Guid ID_исполнение_композиции { get; set; }

        public virtual Композиции Композиции { get; set; }

        public virtual Музыканты_в_группах Музыканты_в_группах { get; set; }

        public virtual List<Альбомы> Альбомы { get; set; }
    }
}
