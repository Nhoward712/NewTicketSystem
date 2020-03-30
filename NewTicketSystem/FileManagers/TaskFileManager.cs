using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NewTicketSystem
{
    class TaskFileManager
    {
        List<Task> tasks = new List<Task>();
        private string file = "tasks.csv";

        public void readTask()
        {
            StreamReader ticketFile = new StreamReader(file);
            int ticketNumber = 0;
            while (!ticketFile.EndOfStream)
            {
                string line = ticketFile.ReadLine();
                string[] arg = line.Split('|');
                int type = arg.Length;
                if(arg[0] != null)
                {
                    ticketNumber = Int32.Parse(arg[0]);
                    tasks.Add(new Task(Int32.Parse(arg[0]),
                    arg[1], arg[2], arg[3], arg[4],
                    arg[5], arg[6], arg[7], arg[8]));
                }

            }
            ticketFile.Close();

        }
        //project name, due date

        public void saveTask(int ticketNumber, string summary, string status,
            string priority, string submitter, string assignedTo, string watching,
            string projectName, string dueDate)
        {

            tasks.Add(new Task(ticketNumber, summary, status, priority, submitter,
            assignedTo, watching, projectName, dueDate));
            readTask();
            StreamWriter ticketFile = new StreamWriter(file);
            {
                for (int i = 0; i < tasks.Count; i++)
                {
                    
                    ticketFile.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}", tasks[i].ticketNumber, tasks[i].summary,
                            tasks[i].status, tasks[i].priority, tasks[i].submittedBy,
                            tasks[i].assignedTo, tasks[i].watching, tasks[i].projectName, tasks[i].dueDate);
                }
                Console.WriteLine("A Ticket has been created for you.");
                ticketFile.Close();
            }
        }
        public int GetHighestTicketNumber()
        {
            readTask();
            int a = 0;

            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].ticketNumber > a)
                {
                    a = tasks[i].ticketNumber;
                };
            }
            return a;
        }
        public void ListTickets()
        {
            readTask();
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine("Ticket Number: " + tasks[i].ticketNumber);
                Console.WriteLine("Summary of Issue: " + tasks[i].summary);
                Console.WriteLine("Ticket Status: " + tasks[i].status);
                Console.WriteLine("Priority: " + tasks[i].priority);
                Console.WriteLine("Submitted By: " + tasks[i].submittedBy);
                Console.WriteLine("Ticket is assigned to: " + tasks[i].assignedTo);
                Console.WriteLine("People watching the ticket: " + tasks[i].watching);
                Console.WriteLine("Project Name: " + tasks[i].projectName);
                Console.WriteLine("Due Date: " + tasks[i].dueDate);
                Console.WriteLine("");
            }
        }
    }
}
