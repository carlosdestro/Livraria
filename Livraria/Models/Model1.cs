namespace Livraria
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Livraria")
        {
        }

        public virtual DbSet<Editora> Editoras { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<Idioma> Idiomas { get; set; }
        public virtual DbSet<Livro> Livros { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Editora>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<Editora>()
                .HasMany(e => e.Livros)
                .WithOptional(e => e.Editora)
                .HasForeignKey(e => e.EDITORA_ID);

            modelBuilder.Entity<Genero>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<Genero>()
                .HasMany(e => e.Livros)
                .WithOptional(e => e.Genero)
                .HasForeignKey(e => e.GENERO_ID);

            modelBuilder.Entity<Idioma>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<Idioma>()
                .HasMany(e => e.Livros)
                .WithRequired(e => e.Idioma)
                .HasForeignKey(e => e.IDIOMA_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Livro>()
                .Property(e => e.NOME)
                .IsUnicode(false);

            modelBuilder.Entity<Livro>()
                .Property(e => e.AUTOR)
                .IsUnicode(false);
        }
    }
}
