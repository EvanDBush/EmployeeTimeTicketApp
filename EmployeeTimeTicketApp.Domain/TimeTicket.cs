using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTimeTicketApp.Domain
{
    public class TimeTicket
    {
        public int Id { get; set; }

        public double Hours { get; set; }

        public Employee? Employee { get; set; }

        public int EmployeeId { get; set; }

        public Project? Project { get; set; }

        public int ProjectId { get; set; }

        public DateTime? DateTime { get; set; }

        public bool NotPaid { get; set; }
    }
}
