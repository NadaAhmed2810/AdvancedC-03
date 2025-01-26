using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public delegate string BookFunc(Book B);
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string[] Authors { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }

        public Book(string _ISBN, string _Title, string[] _Authors, DateTime _PublicationDate,decimal _Price)
        {
            ISBN = _ISBN;
            Title = _Title;
            Authors = _Authors;
            PublicationDate = _PublicationDate;
            Price = _Price;
        }
        public override string ToString()
        {
            return  $"ISBN:{ISBN},TiTle:{Title},Authors:{Authors},PublicationDate:{PublicationDate}, Price:{Price}";
        }

    }
    public static class BookFunctions
    {
        public static string GetTitle(Book B)
        {
            return B?.Title??" " ;
        }
        public static string GetAuthors(Book B)
        {
            string s = " ";
            if (B is not null && B.Authors != null)
            {
                for (int i = 0; i < B.Authors.Length; i++)
                {
                    s += B.Authors[i] + " ";
                }
            }
            return s ;
        }
        public static string GetPrice(Book B)
        {
            return (B?.Price ?? 0).ToString();

        }
    }
    public class LibraryEngine
    {
        // public static void ProcessBooks(List<Book> bList, BookFunc fPtr)
        public static void ProcessBooks(List<Book> bList, Func<Book,string> fPtr)

        {
            if (bList is not  null) 
                foreach (Book B in bList)
                {
                    Console.WriteLine(fPtr(B));
                }
        }
    }
}
