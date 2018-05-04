using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Tennis.DataAcces
{
    public partial class Tennis_DbContext : DbContext
    {
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<Ground> Ground { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<PlayerResult> PlayerResult { get; set; }
        public virtual DbSet<Surface> Surface { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=.\SQLExpress;Database=Tennis_Db;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.DatePlayed).HasColumnType("date");

                entity.Property(e => e.PlayerOneResultId).HasColumnName("PlayerOne_Result_Id");

                entity.Property(e => e.PlayerTwoResultId).HasColumnName("PlayerTwo_Result_Id");

                entity.HasOne(d => d.Ground)
                    .WithMany(p => p.Game)
                    .HasForeignKey(d => d.GroundId)
                    .HasConstraintName("FK__Game__Ground_Id__2E1BDC42");

                entity.HasOne(d => d.PlayerOneResult)
                    .WithMany(p => p.GamePlayerOneResult)
                    .HasForeignKey(d => d.PlayerOneResultId)
                    .HasConstraintName("FK__Game__PlayerOne___2F10007B");

                entity.HasOne(d => d.PlayerTwoResult)
                    .WithMany(p => p.GamePlayerTwoResult)
                    .HasForeignKey(d => d.PlayerTwoResultId)
                    .HasConstraintName("FK__Game__PlayerTwo___300424B4");
            });

            modelBuilder.Entity<Ground>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(150);

                entity.HasOne(d => d.Surface)
                    .WithMany(p => p.Ground)
                    .HasForeignKey(d => d.SurfaceId)
                    .HasConstraintName("FK__Ground__Surface___267ABA7A");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<PlayerResult>(entity =>
            {
                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PlayerResult)
                    .HasForeignKey(d => d.PlayerId)
                    .HasConstraintName("FK__PlayerRes__Playe__2B3F6F97");
            });

            modelBuilder.Entity<Surface>(entity =>
            {
                entity.HasIndex(e => e.Type)
                    .HasName("UQ__Surface__F9B8A48BD00EF486")
                    .IsUnique();

                entity.Property(e => e.Type).HasMaxLength(150);
            });
        }
    }
}
