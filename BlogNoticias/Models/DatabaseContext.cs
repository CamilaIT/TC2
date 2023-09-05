using Microsoft.EntityFrameworkCore;

namespace BlogNoticias.Models {
    public partial class DatabaseContext : DbContext {
        public DatabaseContext() {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options) {
        }
        
        public virtual DbSet<Noticia>? Noticias { get; set; }
        public virtual DbSet<UserInfo>? UserInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<UserInfo>(entity => {
                entity.HasNoKey();
                entity.ToTable("UserInfo");
                entity.Property(e => e.UserId).HasColumnName("UserId");
                
                entity.Property(e => e.UserName).HasMaxLength(30).IsUnicode(false);
               
                entity.Property(e => e.Password).HasMaxLength(20).IsUnicode(false);
                
            });

            modelBuilder.Entity<Noticia>(entity => {
                entity.ToTable("Noticia");
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Titulo).HasMaxLength(256).IsUnicode(false);
                entity.Property(e => e.Conteudo).IsUnicode(false);
                entity.Property(e => e.DataPublicacao).IsUnicode(false);
                entity.Property(e => e.Autor).HasMaxLength(256).IsUnicode(false);
               
               
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}