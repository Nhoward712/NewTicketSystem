using System;
namespace NewTicketSystem
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our Ticket system");
            string choice;
            //main loop
            do
            {
                do
                {
                    Console.WriteLine("Menu:");
                    Console.WriteLine("(1) Create a New Ticket");
                    Console.WriteLine("(2) List Current Tickets");
                    Console.WriteLine("(3) Exit Program");
                    choice = Console.ReadLine();
                } while (choice != "1" && choice != "2" && choice != "3");
                //modify input for defining what type of ticket it is. - done
                if (choice == "1")
                {
                    Console.WriteLine("What type of ticket is it");
                    Console.WriteLine("(b)ug, (e)nhancment, or (t)ask");
                    choice = Console.ReadLine();
                    CreateTicket.NewTicket(choice);
                }
                if (choice == "2")
                {
                    BugFileManager bug = new BugFileManager();
                    EnhanceFileManager enhance = new EnhanceFileManager();
                    TaskFileManager task = new TaskFileManager();
                    bug.ListTickets();
                    enhance.ListTickets();
                    task.ListTickets();
                }
            } while (choice != "3");
        }
    }
}
