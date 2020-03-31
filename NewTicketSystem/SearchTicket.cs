using System;
using System.Collections.Generic;
using System.Text;

namespace NewTicketSystem
{
    abstract class SearchTicket
    {
        public static void Search()
        {
            string choice, keyword;
            BugFileManager bug = new BugFileManager();
            EnhanceFileManager enhance = new EnhanceFileManager();
            TaskFileManager task = new TaskFileManager();
            do
            {
                Console.WriteLine("What do you want to search for? ");
                Console.WriteLine("(1) Status");
                Console.WriteLine("(2) Priority");
                Console.WriteLine("(3) Submitter");
                choice = Console.ReadLine();

            } while (choice != "1" && choice != "2" && choice != "3");
            switch (choice)
            {
                case "1":
                    keyword = "Closed";
                    Console.WriteLine("Search for:");
                    Console.WriteLine("(1) Open Tickets");
                    Console.WriteLine("(2) Closed Tickets");
                    keyword = Console.ReadLine();
                    if (keyword == "1")
                        keyword = "Open";
                    bug.List("status",keyword);
                    task.List("status",keyword);
                    enhance.List("status",keyword);
                    break;
                case "2":
                    Console.WriteLine("What priority you want to search for? High, Normal, or Low?");
                    keyword = Console.ReadLine();
                    bug.List("priority", keyword);
                    task.List("priority", keyword);
                    enhance.List("priority", keyword);
                    break;
                case "3":
                    Console.WriteLine("Which submitter you want to search for? ");
                    keyword = Console.ReadLine();
                    bug.List("submitter", keyword);
                    task.List("submitter", keyword);
                    enhance.List("submitter", keyword);
                    break;

            }


        }

    }
}
