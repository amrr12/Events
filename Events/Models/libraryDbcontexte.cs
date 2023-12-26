
using Events.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Models
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Show> Shows { get; set; } = null;
        public DbSet<Owner> Owners { get; set; } = null;
        public DbSet<User> Users { get; set; } = null;
        public DbSet<Performer> Performsers { get; set; } = null;
        public DbSet<Application> Applications { get; set; } = null;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure primary keys
            modelBuilder.Entity<Show>(entity =>
            {
                entity.HasKey(x => x.Id).HasName("pk_showId");
                entity.ToTable("Show");
                entity.HasOne(x => x.Owner).WithMany(s => s.Shows)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ownerid");

            }
            );

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.ToTable("Owner");

            }
            );

            modelBuilder.Entity<Performer>(entity =>
            {
                entity.ToTable("Performer");
                
            }
            );

            modelBuilder.Entity<Application>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.ToTable("Application");
                entity.HasOne(x => x.Performer).WithMany(a => a.Applications)
                .HasForeignKey(x=>x.PerformerId)
                .HasConstraintName("fk_performerid");

                entity.HasOne(x => x.Show).WithMany(a => a.Applications)
                .HasForeignKey(x => x.ShowId)
                .HasConstraintName("fk_showid");

            }
            );





        }


    }
}
