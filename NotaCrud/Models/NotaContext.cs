using Microsoft.EntityFrameworkCore;

namespace NotaCrud.Models
{
    public class NotaContext : DbContext
    {

        public NotaContext(DbContextOptions<NotaContext> options) : base(options) 
        {
            
        }

        public DbSet<Nota> Notas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Nota>().Property(n => n.bEstado).HasDefaultValue(true);
            modelBuilder.Entity<Nota>().Property(n => n.dFechaCreacion).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<Nota>())
            {
                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.dFechaModificacion = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
