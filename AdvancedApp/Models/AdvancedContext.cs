using Microsoft.EntityFrameworkCore;
using System;
namespace AdvancedApp.Models
{
    public class AdvancedContext : DbContext
    {
        public AdvancedContext(DbContextOptions<AdvancedContext> opts) : base(opts)
        {
            //ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            Database.AutoTransactionsEnabled = false;
        }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // builder.Entity<Employee>().Property(c => c.Id).UseHiLo();
            // builder.Entity<Employee>().HasIndex(c=>c.SSN).HasName("SSNIndex").IsUnique();
            builder.Entity<Employee>().HasQueryFilter(c=>!c.SoftDeleted);
            builder.Entity<Employee>().Ignore(c=>c.Id);
            builder.Entity<Employee>().HasKey(c=> new {c.SSN, c.FirstName, c.FamilyName});

            //builder.Entity<Employee>().HasAlternateKey(c => c.SSN);
            builder.Entity<SecondaryIdentity>().HasOne(c => c.PrimaryIdentity).WithOne(c => c.OtherIdentity).HasPrincipalKey<Employee>(c => new { c.SSN, c.FirstName, c.FamilyName })
                .HasForeignKey<SecondaryIdentity>(s=>new { s.PrimarySSN, s.PrimaryFirstName, s.PrimaryFamilyName}).OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Employee>().Property(c => c.Salary).HasColumnType("decimal(8,2)").HasField("databaseSalary").UsePropertyAccessMode(PropertyAccessMode.Field);
                //.IsConcurrencyToken();
            builder.Entity<SecondaryIdentity>().Property(c => c.Name).HasMaxLength(100);

            builder.Entity<Employee>().Property<DateTime>("LastUpdated").HasDefaultValue(new DateTime(2000, 1, 1));

            // builder.Entity<Employee>().Property(c => c.RowVersion).IsRowVersion();
              builder.HasSequence<int>("ReSe").StartsAt(100).IncrementsBy(3);
            // builder.HasSequence<int>("ReferenceSeq").StartsAt(200).IncrementsBy(3);
            builder.Entity<Employee>().Property(c => c.GeneratedValueT).HasDefaultValueSql("GETDATE()");//(@"'REFERENCE_' + CONVERT(varchar, NEXT VALUE FOR ReSe)");

        }
    }
}
