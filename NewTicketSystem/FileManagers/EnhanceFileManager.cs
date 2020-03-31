using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace NewTicketSystem
{
    public class EnhanceFileManager
    {
        List<Enhancement> enhance = new List<Enhancement>();
        string file = "enhancements.csv";

        public void readEnhancements()
        {
            StreamReader ticketFile = new StreamReader(file);
            int ticketNumber = 0;
            while (!ticketFile.EndOfStream)
            {
                string line = ticketFile.ReadLine();
                string[] arg = line.Split('|');
                int type = arg.Length;
                ticketNumber = Int32.Parse(arg[0]);
                enhance.Add(new Enhancement(Int32.Parse(arg[0]),
                arg[1], arg[2], arg[3], arg[4],
                    arg[5], arg[6], arg[7],arg[8],arg[9],arg[10]));
            }
            ticketFile.Close();

        }
        public void saveEnhancements(int ticketNumber, string summary, string status,
            string priority, string submitter, string assignedTo, string watching,string software, string cost,
            string reason, string estimate)
        {
            readEnhancements();
            enhance.Add(new Enhancement(ticketNumber, summary, status, priority, submitter,
                        assignedTo, watching, software, cost, reason, estimate));

            //software, cost, reason, estimate
            StreamWriter ticketFile = new StreamWriter(file);
            {
                for (int i = 0; i < enhance.Count; i++)
                {
                    ticketFile.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}", enhance[i].ticketNumber, enhance[i].summary,
                            enhance[i].status, enhance[i].priority, enhance[i].submittedBy, enhance[i].assignedTo
                            , enhance[i].watching, enhance[i].Software, enhance[i].Cost,
                            enhance[i].Reason, enhance[i].Estimate);
                }
                Console.WriteLine("A Ticket has been created for you.");
                ticketFile.Close();
            }
        }
        public int GetHighestTicketNumber()
        {
            readEnhancements();
            int a = 0;

            for (int i = 0; i < enhance.Count; i++)
            {
                if (enhance[i].ticketNumber > a)
                {
                    a = enhance[i].ticketNumber;
                };
            }
            return a;
        }

        public void List(string type, string keyword)
        {
            readEnhancements();
            var name = enhance.Where(b => b.status.Contains(keyword));

            switch (type)
            {
                case "status":
                    name = enhance.Where(b => b.status.Contains(keyword));
                    break;
                case "priority":
                    name = enhance.Where(b => b.priority.Contains(keyword));
                    break;
                case "submitter":
                    name = enhance.Where(b => b.submittedBy.Contains(keyword));
                    break;
                default:
                    name = enhance.Where(b => b.ticketNumber > 0);
                    break;
            }
            Console.WriteLine("\n\nENHANCEMENT TICKETS");
            Console.WriteLine("Number Of Enhancement Results: " + name.Count());
            Console.WriteLine(String.Format("{0,-4} {1,-40} {2,-8} {3,-10} {4,-20} {5,-20} {6,-12} {7,-10} {8,-20} {9,-10} ", "ID", "Summary", "Status",
            "Priority", "Submitted By", "Assigned To", "Software", "Cost", "Reason", "Estimate"));

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------");

            foreach (Enhancement enhance in name)
            {
                Console.WriteLine(String.Format("{0,-4} {1,-40} {2,-8} {3,-10} {4,-20} {5,-20} {6,-12} {7,-10} {8,-20} {9,-10}", 
                    enhance.ticketNumber, enhance.summary, enhance.status,
                    enhance.priority, enhance.submittedBy, enhance.assignedTo, 
                    enhance.Software, enhance.Cost, enhance.Reason,
                    enhance.Estimate));

            }

            Console.WriteLine("");
        }
    }
}
