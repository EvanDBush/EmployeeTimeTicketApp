using System.Collections.Generic;

namespace EmployeeTimeTicketApp.Domain
{
    public class Employee
    {
        public int Id { get; set; }
        
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? EMail { get; set; }

        public double TaxWithholding { get; set; }

        public double HourlyRate { get; set; }

        public List<TimeTicket> TimeTickets { get; set; } = new List<TimeTicket>();
    }
}