using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    internal class Library
    {
       
        public static List<Book> Books { get; set; }=new List<Book>();
        public static List<Book> BorrowedBooks { get; set; }=new List<Book>();



        public static void SaveBooks()
        {
            using (StreamWriter writer = new StreamWriter(@"C:\Users\Ashrakat\source\repos\LibraryManagementSystem\Books"))
            {
                foreach (var book in Books)
                {
                    writer.WriteLine($"{book.Id},{book.Title},{book.Author},{book.PublicationYear}");
                }
            }
            //Console.WriteLine("Books saved successfully.");
        }

        public static void LoadBooks()
        {
            if (File.Exists(@"C:\Users\Ashrakat\source\repos\LibraryManagementSystem\Books"))
            {
                using (StreamReader reader = new StreamReader(@"C:\Users\Ashrakat\source\repos\LibraryManagementSystem\Books"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var data = line.Split(',');
                        Books.Add(new Book (Convert.ToInt32( data[0]), data[1] ,  data[2] ,  Convert.ToInt32(data[3]) ));
                    }
                }
                Console.WriteLine("Books loaded successfully.");
            }
        }
        public static List<string> LoadBookNames()
        {
            List<string> names = new List<string>();    
            if (File.Exists(@"C:\Users\Ashrakat\source\repos\LibraryManagementSystem\Books"))
            {
                using (StreamReader reader = new StreamReader(@"C:\Users\Ashrakat\source\repos\LibraryManagementSystem\Books"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var data = line.Split(',');
                        
                        names.Add(data[1].Trim().ToLower());

                    }
                }
               
            }
            return names;
        }

        public static void RemoveBooks(Book book)
        {
            var filePath = @"C:\Users\Ashrakat\source\repos\LibraryManagementSystem\Books";
            if (File.Exists(filePath))
            {
                List<string> lines = File.ReadAllLines(filePath).ToList();

               
                lines = lines.Where(line =>
                {
                    var data = line.Split(',');
                    return !(data.Length >= 3 &&
                             Convert.ToInt32(data[0]) == book.Id &&
                             data[1] == book.Title &&
                             data[2] == book.Author &&
                           Convert.ToInt32(data[3]) == book.PublicationYear);
                }).ToList();
               
                File.WriteAllLines(filePath, lines);

            }
        }



    }
}
