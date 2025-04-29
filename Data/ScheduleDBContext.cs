using Microsoft.EntityFrameworkCore;
using schedule_mvc.Models;

namespace schedule_mvc.Data
{
    public class ScheduleDBContext : DbContext
    {
        public ScheduleDBContext(DbContextOptions<ScheduleDBContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Client client1 = new()
            {
                Id = Guid.Parse("76cbf275-2d7c-42fd-96bd-dbd945babb57"),
                Name = "Bill",
                Phone = "555-555-1000",
                Email = "bill@gmail.com"
            };

            Client client2 = new()
            {
                Id = Guid.Parse("46562403-b809-4641-a6bf-85b334936f8c"),
                Name = "Jeff",
                Phone = "555-555-2000",
                Email = "jeff@outlook.com"
            };

            modelBuilder.Entity<Client>().HasData(client1, client2);

            Doctor doctor1 = new()
            {
                Id = Guid.Parse("3527be68-a09f-4edb-8e69-579cf00b61fc"),
                Name = "Doctor1"
            };

            Doctor doctor2 = new()
            {
                Id = Guid.Parse("63e31cd0-d1b2-40f8-bfa3-0b784c898edd"),
                Name = "Doctor2"
            };

            modelBuilder.Entity<Doctor>().HasData(doctor1, doctor2);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Doctor> Doctor { get; set; } = default!;
        public DbSet<Client> Client { get; set; } = default!;
        public DbSet<Appointment> Appointment { get; set; } = default!;
    }
}
