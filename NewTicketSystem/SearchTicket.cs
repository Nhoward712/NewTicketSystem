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
                Console.WriteLine("What do you want to seach for? (s)tatus, (p)riority or (s)ubmitter");
                Console.WriteLine("Search by: ");
                Console.WriteLine("(1) Status");
                Console.WriteLine("(2) Priority");
                Console.WriteLine("(3) Submitter");
                choice = Console.ReadLine();

            } while (choice != "1" && choice != "2" && choice != "3");
            switch (choice)
            {

                case "1":
                    Console.WriteLine("Search for:");
                    Console.WriteLine("(1) Open Tickets");
                    Console.WriteLine("(2) Closed Tickets");
                    keyword = Console.ReadLine();
                    var key = keyword == "1" ? keyword = "Open" : "Closed";
                    bug.listStatus(keyword);
                    break;
                case "2":
                    Console.WriteLine("What is the Keyword you want to search for? ");
                    keyword = Console.ReadLine();
                    break;
                case "3":
                    break;

            }


        }

    }
}
