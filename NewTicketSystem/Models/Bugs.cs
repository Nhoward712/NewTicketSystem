using System;

namespace NewTicketSystem
{
    public class Bugs : Tickets
    {
        public string Severity { get; set; }

        public Bugs(int ticketNumber, string summary, string status, string priority, string submittedBy,
            string assignedTo, string watching, string severity)

            : base(ticketNumber, summary, status, priority, submittedBy, assignedTo, watching)
        {
            Severity = severity;
        }


    }


}
