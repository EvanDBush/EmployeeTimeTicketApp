using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeTimeTicketApp.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        /*(SRP) Single Responsibility Principle. One of the goals of solid priciples is to separate concerns in the program. The Employee class only has one job, 
        to create emplyee objects. This is its single responsiblility.
        [RegularExpression("^([a-zA-Z]{2,}\\s[a-zA-Z]{1,}'?-?[a-zA-Z]{2,}\\s?([a-zA-Z]{1,})?)",
            ErrorMessage = "Valid Characters include (A-Z) (a-z) (' space -)")]*/
        public string? FirstName { get; set; }

        /*[RegularExpression("^([a-zA-Z]{2,}\\s[a-zA-Z]{1,}'?-?[a-zA-Z]{2,}\\s?([a-zA-Z]{1,})?)",
            ErrorMessage = "Valid Characters include (A-Z) (a-z) (' space -)")]*/
        public string? LastName { get; set; }

        /*[EmailAddress]*/
        public string? EMail { get; set; }

        /*[Range(0,1, ErrorMessage = "Value for {0} must be between {1} and {2}")]*/
        public double TaxWithholding { get; set; }

        /*[Range(10,100, ErrorMessage = "Value for {0} must be between {1} and {2}")]*/
        public double HourlyRate { get; set; }

        public List<TimeTicket> TimeTickets { get; set; } = new List<TimeTicket>();

        public List<Project> Projects { get; set; } = new List<Project>();
    }
}