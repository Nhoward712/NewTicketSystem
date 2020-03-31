using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace NewTicketSystem
{
    public class BugFileManager
    {
        List<Bugs> bug = new List<Bugs>();
        string file = "bugs.csv";

        public void readBugs()
        {
            StreamReader ticketFile = new StreamReader(file);
            int ticketNumber = 0;
            while (!ticketFile.EndOfStream)
            {
                string line = ticketFile.ReadLine();
                string[] arg = line.Split('|');
                int type = arg.Length;
                ticketNumber = Int32.Parse(arg[0]);
                bug.Add(new Bugs(Int32.Parse(arg[0]),
                arg[1], arg[2], arg[3], arg[4],
                    arg[5], arg[6], arg[7]));
            }
            ticketFile.Close();

        }
        public void saveBug(int ticketNumber, string summary, string status, string priority,
            string submitter, string assignedTo, string watching, string severity)
        {
            readBugs();
            bug.Add(new Bugs(ticketNumber, summary, status, priority, submitter,
            assignedTo, watching, severity));

            StreamWriter ticketFile = new StreamWriter(file);
            {
                for (int i = 0; i < bug.Count; i++)
                {
                    ticketFile.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}", bug[i].ticketNumber, bug[i].summary,
                            bug[i].status, bug[i].priority, bug[i].submittedBy,
                            bug[i].assignedTo, bug[i].watching, bug[i].Severity);
                }
                Console.WriteLine("A Ticket has been created for you.");
                ticketFile.Close();
            }
        }
        public int GetHighestTicketNumber()
        {
            readBugs();
            int a = 0;

            for(int i = 0; i < bug.Count; i++)
            {
                if (bug[i].ticketNumber > a){
                    a = bug[i].ticketNumber;
                };
            }
            return a;
        }

        public void List(string type, string keyword)
        {
            readBugs();
            var name = bug.Where(b => b.status.Contains(keyword));

            switch (type)
            {
                case "status":
                    name = bug.Where(b => b.status.Contains(keyword));
                    break;
                case "priority":
                    name = bug.Where(b => b.priority.Contains(keyword));
                    break;
                case "submitter":
                    name = bug.Where(b => b.submittedBy.Contains(keyword));
                    break;
                default:
                    name = bug.Where(b => b.ticketNumber > 0);
                    break;
            }
            Console.WriteLine("\n\nBUG TICKETS");
            Console.WriteLine("Number Of Bug Results: " + name.Count());
            Console.WriteLine(String.Format("{0,-4} {1,-40} {2,-8} {3,-10} {4,-20} {5,-20} {6,-12}", "ID", "Summary", "Status",
            "Priority", "Submitted By", "Assigned To", "Severity"));
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------");

            foreach(Bugs bug in name)
            {
                Console.WriteLine(String.Format("{0,-4} {1,-40} {2,-8} {3,-10} {4,-20} {5,-20} {6,-12}",
                   bug.ticketNumber, bug.summary, bug.status,
                   bug.priority, bug.submittedBy, bug.assignedTo,
                   bug.Severity));
            }

            Console.WriteLine("");
        }

    }
}
