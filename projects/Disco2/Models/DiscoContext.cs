namespace Disco2.Models
{

    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Web;

    public partial class DiscoContext : DbContext
    {
        public DiscoContext()
            : base("name=Disco")
        {
        }

      //  public  DbSet<sysdiagrams> sysdiagrams { get; set; }
        public  DbSet<Альбомы> Альбомы { get; set; }
        public DbSet<Жанры> Жанры { get; set; }
        public DbSet<Исполнение_композиций> Исполнение_композиций { get; set; }
        public  DbSet<Коллективы> Коллективы { get; set; }
        public  DbSet<Композиции> Композиции { get; set; }
       
        public  DbSet<Музыканты> Музыканты { get; set; }
        public DbSet<Музыканты_в_группах> Музыканты_в_группах { get; set; }
        public  DbSet<Тип> Тип { get; set; }
        public DbSet<Тип_коллектива> Тип_коллектива { get; set; }
      
        
        public DbSet<User> Users { get; set; }
      

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Альбомы>()
                .Property(e => e.Название)
                .IsUnicode(false);

            modelBuilder.Entity<Альбомы>()
                .HasMany(e => e.Исполнение_композиций)
                .WithMany(e => e.Альбомы)
                .Map(m => m.ToTable("ИК_альбомы").MapLeftKey("ID альбома").MapRightKey("ID исполнение композиции"));

            modelBuilder.Entity<Жанры>()
                .Property(e => e.Название)
                .IsUnicode(false);

            modelBuilder.Entity<Жанры>()
                .HasMany(e => e.Композиции)
                .WithRequired(e => e.Жанры)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Коллективы>()
                .Property(e => e.Страна)
                .IsUnicode(false);

            modelBuilder.Entity<Коллективы>()
                .Property(e => e.Название)
                .IsUnicode(false);

            modelBuilder.Entity<Коллективы>()
                .HasMany(e => e.Музыканты_в_группах)
                .WithRequired(e => e.Коллективы)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Композиции>()
                .Property(e => e.Название)
                .IsUnicode(false);

            modelBuilder.Entity<Композиции>()
                .HasMany(e => e.Композиторы)
                .WithMany(e => e.Композиторы)
                .Map(m => m.ToTable("Композиторы").MapLeftKey("IDкомпозиции").MapRightKey("IDмузыканта"));

            modelBuilder.Entity<Композиции>()
                .HasMany(e => e.Авторы)
                .WithMany(e => e.Авторы)
                .Map(m => m.ToTable("Авторы").MapLeftKey("IDкомпозиции").MapRightKey("IDмузыканта"));

            modelBuilder.Entity<Музыканты>()
                .Property(e => e.Имя)
                .IsUnicode(false);

            modelBuilder.Entity<Музыканты>()
                .Property(e => e.Отчество)
                .IsUnicode(false);

            modelBuilder.Entity<Музыканты>()
                .Property(e => e.Гражданство)
                .IsUnicode(false);

            modelBuilder.Entity<Музыканты>()
                .HasMany(e => e.Музыканты_в_группах)
                .WithRequired(e => e.Музыканты)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Музыканты_в_группах>()
                .HasMany(e => e.Исполнение_композиций)
                .WithOptional(e => e.Музыканты_в_группах)
                .HasForeignKey(e => new { e.ID_музыканта, e.ID_коллектива });

            modelBuilder.Entity<Тип>()
                .Property(e => e.Название)
                .IsUnicode(false);

            modelBuilder.Entity<Тип>()
                .HasMany(e => e.Альбомы)
                .WithRequired(e => e.Тип)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Тип_коллектива>()
                .Property(e => e.Наименование)
                .IsUnicode(false);

            modelBuilder.Entity<Тип_коллектива>()
                .HasMany(e => e.Коллективы)
                .WithRequired(e => e.Тип_коллектива)
                .WillCascadeOnDelete(false);

          
        }
    }
}

