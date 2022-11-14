using System;
using System.Linq;
using EmployeeTimeTicketApp.Data;
using EmployeeTimeTicketApp.Domain;
using Microsoft.EntityFrameworkCore;

 

namespace EmployeeTimeTicketApp.UI
{
    class Program
    {
        private static EmployeeTimeTicketContext _context = new EmployeeTimeTicketContext();

        private static void Main(string[] args)
        {
            _context.Database.EnsureCreated();
            GetEmployees("Before Add:");
            AddEmployeesByName("Terry", "Gary", "Barry");
            GetEmployees("After Add:");
            Console.Write("Press any key...");
            Console.ReadKey();
        }

        private static void AddEmployee()
        {
            var employee = new Employee { FirstName = "Mary" };
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        private static void AddEmployeesByName(params string[] names)
        {
            foreach (string name in names)
            {
                _context.Employees.Add(new Employee { FirstName = name });
            }
            _context.SaveChanges();
        }
        private static void GetEmployees(string text)
        {
            var employees = _context.Employees.ToList();
            Console.WriteLine($"{text}: Employee count is {employees.Count}");
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.FirstName);
            }
        }

        /*private static void QueryFilters()
        {
            var employees = _context.Employees
                .Where(e => EF.Functions.Like(e.FirstName, "J%"))
                .ToList();
        }*/

        /*private static void RetrieveAndUpdateEmployee()
        {
            var employee = _context.Employees.FirstOrDefault();
            employee.FirstName += "Fred";
            _context.SaveChanges();
        }*/

        private static void RetrieveAndUpdateMultipleEmployees()
        {
            var employees = _context.Employees.Skip(1).Take(4).ToList();
            employees.ForEach(e => e.FirstName += "addedstring");
            _context.SaveChanges();
        }

        /*private static void RetrieveAndDeleteEmployee()
        {
            var employee = _context.Employees.Find(4);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }*/

        private void QueryAndUpdateTimeTickets_Disconnected()
        {
            List<TimeTicket> disconnectedTimeTickets;
            using (var context1 = new EmployeeTimeTicketContext())
            {
                disconnectedTimeTickets = _context.TimeTickets.ToList();
            }
            disconnectedTimeTickets.ForEach(t =>
            {
                    t.Hours = 6.5;
            });
            using (var context2=new EmployeeTimeTicketContext())
            {
               context2.UpdateRange(disconnectedTimeTickets);
               context2.SaveChanges();
            }
        }
    }
}

