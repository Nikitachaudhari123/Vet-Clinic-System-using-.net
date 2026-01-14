using Microsoft.EntityFrameworkCore;
using VetClinic.Models;

namespace VetClinic.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<VetDoctor> VetDoctors { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetProfile> PetProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Doctors
            modelBuilder.Entity<VetDoctor>().HasData(
                new VetDoctor { Id = 1, Name = "Dr. Alice", Specialty = "Dogs" },
                new VetDoctor { Id = 2, Name = "Dr. Bob", Specialty = "Cats" },
                new VetDoctor { Id = 3, Name = "Dr. Maria", Specialty = "Birds & Exotics" }
            );

            // Seed Pets
            modelBuilder.Entity<Pet>().HasData(
                new Pet { Id = 1, MicrochipId = "MC001", Name = "Buddy", Species = "Dog", VetDoctorId = 1 },
                new Pet { Id = 2, MicrochipId = "MC002", Name = "Mittens", Species = "Cat", VetDoctorId = 2 },
                new Pet { Id = 3, MicrochipId = "MC003", Name = "Luna", Species = "Cat", VetDoctorId = 2 },
                new Pet { Id = 4, MicrochipId = "MC004", Name = "Kiwi", Species = "Parrot", VetDoctorId = 3 }
            );

            modelBuilder.Entity<PetProfile>().HasData(
                new PetProfile { Id = 1, PetId = 1, VetNotes = "Healthy. Annual checkup done." },
                new PetProfile { Id = 2, PetId = 2, VetNotes = "Allergy to food. Monitor diet." },
                new PetProfile { Id = 3, PetId = 3, VetNotes = "Vaccinated. Monitor side effects." },
                new PetProfile { Id = 4, PetId = 4, VetNotes = "Feathers trimmed. Follow-up in 3 months." }
            );
        }
    }
}
