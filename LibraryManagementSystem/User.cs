using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class User: Person
    {
        public User(string name,string pass):base(name, pass) 
        {
          
        }

        public User():base()
        {
            
        }
        public LibraryCard MemberCard { get; set; }

       
        public static void CreateUser()
        {
            Console.WriteLine("Join us!");
            User user = new User();
            Console.Write("Enter user name:");
            user.Name = Console.ReadLine();
            Console.Write("Enter password:");
            user.Password=Console.ReadLine();

            Users.Add(user);
            Console.WriteLine("User created successfully.");
        }


        public static void UserAction()
        {
            Console.WriteLine("Choose action\n1-Display the books\n2-Borrow a book\n");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Display();
                    break;
                case 2:
                    Console.Write("Enter book name: ");
                    string bookName= Console.ReadLine();
                    Borrow(bookName);
                    break;
                
                default:
                    Console.WriteLine("Invalid choice");
                    UserAction();
                    break;


            }
        }
        public static void SaveUsers()
        {
            using (StreamWriter writer = new StreamWriter(@"C:\Users\Ashrakat\source\repos\LibraryManagementSystem\Users"))
            {
                foreach (var user in Users)
                {
                    writer.WriteLine($"{user.Name},{user.Password}");
                }
            }
           // Console.WriteLine("Users saved successfully.");
        }
        public static void LoadUsers()
        {
            if (File.Exists(@"C:\Users\Ashrakat\source\repos\LibraryManagementSystem\Users"))
            {
                using (StreamReader reader = new StreamReader(@"C:\Users\Ashrakat\source\repos\LibraryManagementSystem\Users"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var data = line.Split(',');
                        Users.Add(new User { Name = data[0], Password = data[1] });
                    }
                }
               // Console.WriteLine("Users loaded successfully.");
            }
        }

        public static void Borrow(string name)
        {

            List<string> bookNames= Library.LoadBookNames();
            string bookName=name.Trim().ToLower();
            if (bookNames.Contains(bookName)==true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You can borrow this book");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("This book does not exist");
                Console.ForegroundColor = ConsoleColor.White;

                
            }
           
        }

        public override bool Equals(object obj)
        {
            if (obj is Person other)
            {
                return this.Name == other.Name && this.Password == other.Password;
            }
            return false;
        }
    }
}
