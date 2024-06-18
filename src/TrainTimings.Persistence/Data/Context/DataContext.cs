using Microsoft.EntityFrameworkCore;
using TrainTimings.Core.Models;

namespace TrainTimings.Persistence.Data.Context;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CitiesTrain> CitiesTrains { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Timing> Timings { get; set; }

    public virtual DbSet<TypeTrain> TypesTrains { get; set; }

    public virtual DbSet<Train> Trains { get; set; }

    public virtual DbSet<TypesFollowing> TypesFollowings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Server=postgres-container;port=5432;user id=postgres;password=toor;database=TrainTiming;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CitiesTrain>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("CitiesTrain_pk");

            entity.ToTable("CitiesTrain");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();

            entity.HasOne(d => d.City).WithMany(p => p.CitiesTrains)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CitiesTrain_Cities_Id_fk");

            entity.HasOne(d => d.Train).WithMany(p => p.CitiesTrains)
                .HasForeignKey(d => d.TrainId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CitiesTrain_Trains_Id_fk");

            entity.HasOne(d => d.Type).WithMany(p => p.CitiesTrains)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CitiesTrain_TypesFollowing_Id_fk");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("cities_pk");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Name).HasMaxLength(40);
        });

        modelBuilder.Entity<Timing>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Timings_pk");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Arrival).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Departure).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Platform).HasColumnType("character varying");

            entity.HasOne(d => d.Train).WithMany(p => p.Timings)
                .HasForeignKey(d => d.TrainId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Timings_Trains_Id_fk");
        });

        modelBuilder.Entity<TypeTrain>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Tipes_pk");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<Train>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("Trains_pk");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Number).HasMaxLength(9);

            entity.HasOne(d => d.TypeTrain).WithMany(p => p.Trains)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Trains_Tipes_Id_fk");
        });

        modelBuilder.Entity<TypesFollowing>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("TypesFollowing_pk");

            entity.ToTable("TypesFollowing");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Name).HasMaxLength(40);
            entity.Property(e => e.Time).HasColumnType("timestamp without time zone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
