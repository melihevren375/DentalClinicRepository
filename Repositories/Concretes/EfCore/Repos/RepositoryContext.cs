using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Repositories.Concretes.EfCore.Repos;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> dbContextOptions) : base(dbContextOptions)
    {

    }

    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<ClinicalAssistant> ClinicalAssistants { get; set; }
    public DbSet<Dentist> Dentists { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeType> EmployeeTypes { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<Treatment> Treatments { get; set; }
    public DbSet<TreatmentDetailsRepository> TreatmentDetails { get; set; }
    public DbSet<TreatmentType> TreatmentTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
