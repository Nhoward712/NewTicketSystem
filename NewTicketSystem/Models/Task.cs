using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewTicketSystem
{
    public class Task : Tickets
    {
        //project name, due date
        public string projectName { get; set; }
        public string dueDate { get; set; }
        public Task(int ticketNumber, string summary, string status, string priority, string submittedBy,
            string assignedTo, string watching, string name, string due)
            : base(ticketNumber, summary, status, priority, submittedBy, assignedTo, watching)
        {
            projectName = name;
            dueDate = due;
        }

    }
    
}