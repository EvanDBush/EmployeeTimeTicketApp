/*using Microsoft.;
using EmployeeTimeTicketApp.Data;
using EmployeeTimeTicketApp.Domain;
using System.Diagnostics;

namespace EmployeeTimeTicketApp.Test
{
    *//*[TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void CanInsertEmployeeIntoDatabase()
        {
            using (var context= new EmployeeTimeTicketContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                var employee = new Employee();
                context.Employees.Add(employee);
                Debug.WriteLine($"Before save: {employee.Id}");
                context.SaveChanges();
                Debug.WriteLine($"After save: {employee.Id}");

                Assert.AreNotEqual(0, employee.Id);
            }
        }
    }
}*/