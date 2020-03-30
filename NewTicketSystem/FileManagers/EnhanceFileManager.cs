using System;
using System.IO;
using System.Collections.Generic;

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
        public void ListTickets()
        {
            readEnhancements();
            Console.WriteLine("\n\nENHANCEMENT TICKETS");
            Console.WriteLine(String.Format("{0,-4} {1,-40} {2,-8} {3,-10} {4,-20} {5,-20} {6,-12} {7,-7} {8,-20} {9,-10} ", "ID", "Summary", "Status",
            "Priority", "Submitted By", "Assigned To", "Software", "Cost","Reason", "Estimate"));
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------");

            for (int i = 0; i < enhance.Count; i++)
            {
                Console.WriteLine(String.Format("{0,-4} {1,-40} {2,-8} {3,-10} {4,-20} {5,-20} {6,-12} {7,-7} {8,-20} {9,-10}", enhance[i].ticketNumber, enhance[i].summary, enhance[i].status,
                enhance[i].priority, enhance[i].submittedBy, enhance[i].assignedTo, enhance[i].Software, enhance[i].Cost,enhance[i].Reason,enhance[i].Estimate));
                //Console.WriteLine("Ticket Number: " + enhance[i].ticketNumber);
                //Console.WriteLine("Summary of Issue: " + enhance[i].summary);
                //Console.WriteLine("Ticket Status: " + enhance[i].status);
                //Console.WriteLine("Priority: " + enhance[i].priority);
                //Console.WriteLine("Submitted By: " + enhance[i].submittedBy);
                //Console.WriteLine("Ticket is assigned to: " + enhance[i].assignedTo);
                //Console.WriteLine("Who is watching the ticket? " + enhance[i].watching);
                //Console.WriteLine("Software to be used: " + enhance[i].Software);
                //Console.WriteLine("Cost of project: " + enhance[i].Cost);
                //Console.WriteLine("Reason for enhancement " + enhance[i].Reason);
                //Console.WriteLine("What is the Estimate? " + enhance[i].Estimate);
                //Console.WriteLine("");
            }
        }
    }
}
