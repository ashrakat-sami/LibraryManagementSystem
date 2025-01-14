using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Book
    {
        public Book(int id, string title , string author="Unknown",int year= 2000)
        {
            Id=id; Title=title; Author=author;  PublicationYear=year;

        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }


        public override string ToString()
        {
            return $"Id:{Id} - Title:{Title} - Author:{Author} - Publication Year:{PublicationYear}";
        }

    }
}
