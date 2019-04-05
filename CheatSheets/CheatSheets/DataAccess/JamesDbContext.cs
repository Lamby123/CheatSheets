namespace CheatSheets.DataAccess
{
    using Microsoft.EntityFrameworkCore;
    using Models;
    using System;

    public class JamesDbContext : DbContext
    {
        public JamesDbContext(DbContextOptions<JamesDbContext> options) : base(options){}

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Job> Job { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasKey(t => new { t.EmployeeId });
            modelBuilder.Entity<Employee>().HasIndex(t => t.EmployeeId);

            modelBuilder.Entity<Job>().HasKey(t => new { t.JobId });
            modelBuilder.Entity<Job>().HasIndex(t => t.JobId);

            // configures relationship between employee and job. 
            modelBuilder.Entity<Employee>()
                .HasOne<Job>(o => o.Job)
                .WithMany(m => m.Employees)
                .HasForeignKey(c => c.JobId);


            // add additional properties not explicitly on the model
            modelBuilder.Entity<Employee>().Property<DateTime>("CreatedAt");

            modelBuilder.Entity<Job>().Property<DateTime>("CreatedAt");
            modelBuilder.Entity<Job>().Property<DateTime>("LastUpdatedAt");

        }

        // override save changes to update any datetime properties. 
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }


        // update any columns required before saving. 
        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();

            foreach (var entry in entries)
            {
                if (entry.Entity is Employee curve || entry.Entity is Job curveContract)
                {
                    var now = DateTime.UtcNow;

                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            entry.CurrentValues["LastUpdatedAt"] = now;
                            break;

                        case EntityState.Added:
                            entry.CurrentValues["CreatedAt"] = now;
                            entry.CurrentValues["LastUpdatedAt"] = now;
                            break;
                    }
                }
            }
        }
    }
}
