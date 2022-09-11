using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MVC_Ajmera.Models
{
    public partial class MVC_AjmeraContext : DbContext
    {
        public MVC_AjmeraContext()
        {
        }

        public MVC_AjmeraContext(DbContextOptions<MVC_AjmeraContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=MVC_Ajmera;Trusted_Connection=True;");
            }
            */
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("MVC_Ajmera");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Author");

                entity.Property(e => e.Authorid)
                    .ValueGeneratedNever()
                    .HasColumnName("authorid");

                entity.Property(e => e.AuthorName)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("authorName");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.Bookid).ValueGeneratedNever();

                entity.Property(e => e.Author)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("author");

                entity.Property(e => e.AuthorId).HasColumnName("authorId");

                entity.Property(e => e.Booktitle)
                    .HasMaxLength(35)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
