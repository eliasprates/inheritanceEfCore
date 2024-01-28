using inheritanceEfCore.Models.Tpc;
using inheritanceEfCore.Models.Tph;
using inheritanceEfCore.Models.Tpt;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace inheritanceEfCore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions)
        : base(contextOptions)
        {
        }
        public DbSet<CarTpc> CarsTpc { get; set; }
        public DbSet<MotorcycleTpc> MotorcyclesTpc { get; set; }
        public DbSet<VehicleTph> VehiclesTph { get; set; }
        public DbSet<VehicleTpt> VehiclesTpt { get; set;}
        public DbSet<CarTpt> CarsTpt { get; set; }
        public DbSet<MotorcycleTpt> MotorcyclesTpt { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração para CarTpc (TPC)
            // Configuration for CarTpc (TPC)
            modelBuilder.Entity<CarTpc>().ToTable("CarsTpc");

            // Configuração para MotorcycleTpc  (TPC)
            // Configuration for MotorcycleTpc (TPC)
            modelBuilder.Entity<MotorcycleTpc>().ToTable("MotorcyclesTpc");

            // Mapeamento das tabelas (TPH)
            // Mapping of tables (TPH)
            modelBuilder.Entity<VehicleTph>()
                .ToTable("VehiclesTph")
                .HasDiscriminator<string>("Type")
                .HasValue<CarTph>("CarTph")
                .HasValue<MotorcycleTph>("MotorcycleTph");

            // Mapeamento das tabelas (TPT)
            // Mapping of tables (TPT)
            modelBuilder.Entity<VehicleTpt>().ToTable("VehiclesTpt");
            modelBuilder.Entity<CarTpt>().ToTable("CarsTpt");
            modelBuilder.Entity<MotorcycleTpt>().ToTable("MotorcyclesTpt");

            //Configura exclusão em cascata em que sempre que uma classe pai for excluída, a classe filha seja excluída também
            modelBuilder.Entity<VehicleTpt>()
                .HasOne<CarTpt>()
                .WithOne()
                .HasForeignKey<CarTpt>(c => c.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);

            //Configura exclusão em cascata em que sempre que uma classe pai for excluída, a classe filha seja excluída também
            modelBuilder.Entity<VehicleTpt>()
                .HasOne<MotorcycleTpt>()
                .WithOne()
                .HasForeignKey<MotorcycleTpt>(m => m.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configurando relacionamento entre CarTpt e VehicleTpt (TPT)
            // Configuring relationship between CarTpt and VehicleTpt (TPT)
            modelBuilder.Entity<CarTpt>()
                .HasOne(c => c.VehicleTpt)
                .WithMany()
                .HasForeignKey(c => c.VehicleId)
                .OnDelete(DeleteBehavior.NoAction);

            // Configurando relacionamento entre MotorcycleTpt e VehicleTpt (TPT)
            // Configuring relationship between MotorcycleTpt and VehicleTpt (TPT)
            modelBuilder.Entity<MotorcycleTpt>()
                .HasOne(m => m.VehicleTpt)
                .WithMany()
                .HasForeignKey(m => m.VehicleId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
