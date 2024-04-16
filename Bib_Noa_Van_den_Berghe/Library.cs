﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Noa_Van_den_Berghe
{
	internal class Library(string name)
    {
        Dictionary<DateTime, ReadingRoomItem> AllReadingRoom = new Dictionary<DateTime, ReadingRoomItem>();


        private string Name = name;
        private List<Book> BookList = new List<Book>();


		public string name
		{
			get { return Name; }
			set { Name = value; }
		}

        public void AddBook(Book book)
		{
			BookList.Add(book);
		}
        public bool RemoveBook(string title, string author)
        {
            Book bookToRemove = null;
            foreach (Book book in BookList)
            {
                if (book.title.ToLower() == title.ToLower() && book.writer.ToLower() == author.ToLower())
                {
                    bookToRemove = book;
                    break;
                }
            }

            if (bookToRemove != null)
            {
                BookList.Remove(bookToRemove);
                Console.WriteLine("Boek succesvol verwijderd.");
                return true;
            }
            else
            {
                Console.WriteLine("Boek niet gevonden in de bibliotheek.");
                return false;
            }
        }

        public void SearchBookByTitelAutor(string titel, string auteur)
        {
            foreach (Book book in BookList)
            {
				if (book.title == titel && book.writer == auteur)
				{
                    book.ShowInfo();

                }
            }
        }
        public void SearchBookByType(string type)
        {
            foreach (Book book in BookList)
            {
                if (book.type == type)
                {
                    book.ShowInfo();
                }
            }
        }
        public void SearchBookByAutor(string auteur)
        {
            foreach (Book book in BookList)
            {
                if (book.writer == auteur)
                {
                    book.ShowInfo();

                }
            }
        }
        public void SearchBookByISBN(string ISBN)
        {
            foreach (Book book in BookList)
            {
                if (book.isbn == ISBN)
                {
                    book.ShowInfo();

                }
            }
        }
		public void ShowAllBooks()
		{
            foreach (Book book in BookList)
            {
                book.ShowWriterTitle();
            }
        }

        public void addInfoToBook(string iSBNtitle, string iSBNauthor, string iSBN)
        {
            foreach (Book book in BookList)
            {
                if (book.title == iSBNtitle && book.writer == iSBNauthor)
                {
                    book.isbn = iSBN;
                }
            }
        }
    }
}
