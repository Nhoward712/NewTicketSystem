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
            Console.WriteLine("\n\nTASK TICKETS");
            Console.WriteLine(String.Format("{0,-4} {1,-40} {2,-8} {3,-10} {4,-20} {5,-20} {6,-20} {7,-10}", "ID", "Summary", "Status",
            "Priority", "Submitted By", "Assigned To", "Project Name", "Due Date"));
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------");

            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine(String.Format("{0,-4} {1,-40} {2,-8} {3,-10} {4,-20} {5,-20} {6,-20} {7,-12}", tasks[i].ticketNumber, tasks[i].summary, tasks[i].status,
                tasks[i].priority, tasks[i].submittedBy, tasks[i].assignedTo, tasks[i].projectName, tasks[i].dueDate));
            }
            Console.WriteLine("");
        }
    }
}
