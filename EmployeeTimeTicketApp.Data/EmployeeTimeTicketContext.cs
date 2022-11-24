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
        /*Creates a constructor to take in Db context options for contexts created on startup. 
         * This allows the app to instantiate a db context, 
         * pass it the options defined in startup, and
         * then pass the resulting object into the controller.
         * this is an example of Dependency Injection.*/
        public EmployeeTimeTicketContext(DbContextOptions<EmployeeTimeTicketContext> options)
            : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TimeTicket> TimeTickets { get; set; }
        

    }
}
