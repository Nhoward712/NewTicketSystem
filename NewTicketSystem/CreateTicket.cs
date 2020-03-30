using System;
using System.Collections.Generic;
using System.Text;

namespace NewTicketSystem
{
    abstract class CreateTicket
    {
        public static void NewTicket(string choice)
        {
            string summary, status = "Open", priority, submitter, assignedTo, watching = "";
            Console.WriteLine("Please enter a brief summary of the issue");
            summary = Console.ReadLine();
            Console.WriteLine("What is the priority of this issue (High, Normal, Low)");
            priority = Console.ReadLine();
            Console.WriteLine("What is your Name?");
            submitter = Console.ReadLine();
            Console.WriteLine("Who should this ticket be assigned to?");
            assignedTo = Console.ReadLine();
            Console.WriteLine("Who will be watching this ticket?(type 'none' when done)");
            while (watching != "none")
            {
                watching = Console.ReadLine();
            }
            int ticketNumber = GetTicketNumber();
            ticketNumber++;
            switch (choice)
            {
                case "b":
                    Console.WriteLine("what is the severity of this issue?");
                    string severity = Console.ReadLine();

                    BugFileManager bug = new BugFileManager();
                    bug.saveBug(ticketNumber, summary, status, priority, submitter,
                        assignedTo, watching, severity);
                    break;
                case "e":
                    //software, cost, reason, estimate
                    Console.WriteLine("What software is needed?");
                    string software = Console.ReadLine();
                    Console.WriteLine("What is the cost?");
                    string cost = Console.ReadLine();
                    Console.WriteLine("What is the reason for the enhancement?");
                    string reason = Console.ReadLine();
                    Console.WriteLine("What is the estimate?");
                    string estimate = Console.ReadLine();

                    EnhanceFileManager enhance = new EnhanceFileManager();
                    enhance.saveEnhancements(ticketNumber, summary, status, priority, submitter,
                        assignedTo, watching, software, cost, reason, estimate);

                    break;
                case "t":
                    //project name, due date
                    Console.WriteLine("What should the project be named?");
                    string projectName = Console.ReadLine();
                    Console.WriteLine("When is it due?");
                    string dueDate = Console.ReadLine();

                    TaskFileManager task = new TaskFileManager();
                    task.saveTask(ticketNumber, summary, status, priority, submitter,
                        assignedTo, watching, projectName, dueDate);
                    break;
            }
        }
        public static int GetTicketNumber()
        {
            BugFileManager bug = new BugFileManager();
            EnhanceFileManager enhance = new EnhanceFileManager();
            TaskFileManager task = new TaskFileManager();

            int ticketNumber = 0;
            //goes through each ticket array and finds the highest ticket number
            if (bug.GetHighestTicketNumber() > ticketNumber)
            {
                ticketNumber = bug.GetHighestTicketNumber();
            }
            if (task.GetHighestTicketNumber() > ticketNumber)
            {
                ticketNumber = task.GetHighestTicketNumber();
            }
            if (enhance.GetHighestTicketNumber() > ticketNumber)
            {
                ticketNumber = enhance.GetHighestTicketNumber();
            }
            return ticketNumber;
        }
    }
}
