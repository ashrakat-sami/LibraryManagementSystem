using System.ComponentModel.Design;

namespace LibraryManagementSystem
{
    internal class Program
    {
        public static void Welcome()
        {
            
            Console.WriteLine("Do you have an account?(Y/N)");
            char choice = Console.ReadLine().ToLower()[0];
            if(choice == 'y')
            {
                User.LoadUsers();
                Person.Login();
            }else if(choice == 'n')
            {
                User.CreateUser();
                User.SaveUsers();

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Choice!");
                Console.ForegroundColor = ConsoleColor.White;
                Welcome();

            }
        }
       
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to my Library Management System");
            Welcome();








        }
    }
}
