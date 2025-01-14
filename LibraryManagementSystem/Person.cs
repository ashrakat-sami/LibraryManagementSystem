using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public  class Person
    {
        protected Person()
        {
            
        }
        protected Person(string name ,string pass="")
        {
            Name= name;
            Password= pass;
        }
        public string Name { get; set; }
        public string Password { get; set; }

        public static List<Person>  Users = new List<Person>();


        public static void Login()
        {
            Console.Write("Username: ");
            string name = Console.ReadLine();
            Console.Write("Password: ");
            string pass = Console.ReadLine();
            Person person = new Person(name,pass);
            if(Users.Contains(person) )
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You're now logged in");
                Console.ForegroundColor = ConsoleColor.White;
               CheckAdmin(person);


            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong Username or Password");
                Console.ForegroundColor = ConsoleColor.White;
                Login();


            }

        }
       
        public static void CheckAdmin(Person person)
        {
            if (person.Name == "admin" && person.Password == "admin")
            {

                Librarian.AdminAction();

            }
            else
            {
                User.UserAction();
            }
        }

        public static void Display()
        {
            Library.LoadBooks();
            foreach(Book book in Library.Books)
            {
                Console.WriteLine(book);
            }

          
        }
       
    }
}
