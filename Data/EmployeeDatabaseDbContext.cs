using EmployeeDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDatabase.Data
{
    public class EmployeeDatabaseDbContext : DbContext
    {
        //creating constructor with options
        public EmployeeDatabaseDbContext(DbContextOptions options) : base(options)
        {

        }

        //creating properties for CRUD operations
        public DbSet<Employee> Employees { get; set; }

    }
}
