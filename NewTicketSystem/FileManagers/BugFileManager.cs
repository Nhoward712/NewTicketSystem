using System;
using System.IO;
using System.Collections.Generic;

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
        public void ListTickets()
        {
            readBugs();
            for (int i = 0; i < bug.Count; i++)
            {
                Console.WriteLine("Ticket Number: " + bug[i].ticketNumber);
                Console.WriteLine("Summary of Issue: " + bug[i].summary);
                Console.WriteLine("Ticket Status: " + bug[i].status);
                Console.WriteLine("Priority: " + bug[i].priority);
                Console.WriteLine("Submitted By: " + bug[i].submittedBy);
                Console.WriteLine("Ticket is assigned to: " + bug[i].assignedTo);
                Console.WriteLine(" Who is watching the ticket? " + bug[i].watching);
                Console.WriteLine("What is the Severity? " + bug[i].Severity);
                Console.WriteLine("");
            }
        }

    }
}
