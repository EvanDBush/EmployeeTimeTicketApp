using Microsoft.EntityFrameworkCore;
using EmployeeTimeTicketApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeTimeTicketApp.Data
{
    public class EmployeeTimeTicketContext: DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TimeTicket> TimeTickets { get; set; }

        private StreamWriter _writer =
                new("EfCoreLog.txt", append: true);
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog= EmployeeTimeTIcketAppData")
                .LogTo(_writer.WriteLine, new[] {DbLoggerCategory.Database.Command.Name},
                Microsoft.Extensions.Logging.LogLevel.Information)
                .EnableSensitiveDataLogging();
            
        }

    }
}
