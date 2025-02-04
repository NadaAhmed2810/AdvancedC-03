﻿using System;

namespace Assignment
{

    internal class Program
    {
        static void Main(string[] args)
        {
            #region a. User Defined Delegate Datatype
            //BookFunc func01 = BookFunctions.GetTitle;

            //string[] Authors = ["Nada", "Noura", "Nour", "Radwa"];
            //Book book = new Book("2002206", "Advanced Software", Authors, DateTime.Now, 500);
            //Console.WriteLine(func01.Invoke(book));
            //func01 = BookFunctions.GetPrice;
            //Console.WriteLine(func01.Invoke(book));
            //func01 = BookFunctions.GetAuthors;
            //Console.WriteLine(func01.Invoke(book));
            #endregion
            #region BCL Delegates
            //Func<Book,string> func01 = BookFunctions.GetTitle;

            //string[] Authors = ["Nada", "Noura", "Nour", "Radwa"];
            //Book book = new Book("2002206", "Advanced Software", Authors, DateTime.Now, 500);
            //Console.WriteLine(func01.Invoke(book));
            //func01 = BookFunctions.GetPrice;
            //Console.WriteLine(func01.Invoke(book));
            //func01 = BookFunctions.GetAuthors;
            //Console.WriteLine(func01.Invoke(book));
            #endregion
            #region Anonymous Method (GetISBN)
            //Func<Book, string> func01 =delegate (Book book1){ return book1?.ISBN??" "; };

            //string[] Authors = ["Nada", "Noura", "Nour", "Radwa"];
            //Book book = new Book("2002206", "Advanced Software", Authors, DateTime.Now, 500);
            //Console.WriteLine(func01.Invoke(book));
            #endregion
            #region Lambda Expression (GetPublicationDate)
            //Func<Book, string> func01 = book1 => book1?.PublicationDate.ToString() ?? " ";

            //string[] Authors = ["Nada", "Noura", "Nour", "Radwa"];
            //Book book = new Book("2002206", "Advanced Software", Authors, DateTime.Now, 500);
            //Console.WriteLine(func01.Invoke(book));
            #endregion


        }
    }
}
