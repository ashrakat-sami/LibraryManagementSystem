using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Librarian: Person
    {



        public static Book BookDetails()
        {
            Console.Write("Book's ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Book's Title:");
            string title = Console.ReadLine();
            Console.Write("Book's Author:");
            string author = Console.ReadLine();
            Console.Write("Book's publication year:");
            int year = Convert.ToInt32(Console.ReadLine());
            return new Book(id, title, author, year);

        }

        public static void AdminAction()
        {
            Console.WriteLine("Choose action\n1-Add a new book\n2-Remove a book\n3-Display the books");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Book bookA = BookDetails();                    
                    AddBook(bookA);
                    break;
                case 2:
                    Book bookR = BookDetails();
                    RemoveBook(bookR);
                    break;
                case 3:
                    Display();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                   AdminAction();
                    break;


            }
        }
        public static void AddBook(Book newBook)
        {
            Library.Books.Add(newBook);
            Library.SaveBooks();
        }

        public static void RemoveBook(Book removedBook)
        {
            Library.Books.Remove(removedBook);
           Library. RemoveBooks(removedBook);

        }
    }
}
