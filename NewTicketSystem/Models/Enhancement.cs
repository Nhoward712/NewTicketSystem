using System;

namespace NewTicketSystem
{
	public class Enhancement : Tickets
	{
		//software, cost, reason, estimate
		public string Software { get; set; }
		public string Cost { get; set; }
		public string Reason { get; set; }
		public string Estimate { get; set; }
		public Enhancement(int ticketNumber, string summary, string status, string priority, string submittedBy,
			string assignedTo, string watching, string software, string cost, string reason, string estimate)
			: base(ticketNumber, summary, status, priority, submittedBy, assignedTo, watching)
		{
			Software = software;
			Cost = cost;
			Reason = reason;
			Estimate = estimate;

		}
	}
}