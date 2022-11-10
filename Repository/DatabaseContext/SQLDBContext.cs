using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Repository.DatabaseContext
{
    public partial class SQLDBContext : DbContext
    {
        public SQLDBContext()
        {
        }

        public SQLDBContext(DbContextOptions<SQLDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountDatum> AccountData { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountDatum>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Direction)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
