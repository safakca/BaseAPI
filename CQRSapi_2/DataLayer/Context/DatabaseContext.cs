using CQRSapi_2.EntityLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRSapi_2.DataLayer.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
