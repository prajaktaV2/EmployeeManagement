using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Model.Models
{
    public class SupportTicket
    {
        public string TicketType { get; set; }
        public DateTime TicketDate { get; set; }

        public SupportTicket(string ticketType, DateTime ticketDate)
        {
            TicketType = ticketType;
            TicketDate = ticketDate;
        }
    }
}
