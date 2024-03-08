using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Noa_Van_den_Berghe
{
	internal class Library
	{
		List<Book> Booklist = new List<Book>();

		private string Name;
		private List<Book> BookList;

		public List<Book> books
		{
			get { return BookList; }
			set { BookList = value; }
		}


		public string name
		{
			get { return Name; }
			set { Name = value; }
		}
		public Library(string name)
		{
			this.Name = name;
		}

		public void AddBook(Book book)
		{
			Booklist.Add(book);
		}
        public bool RemoveBook(string title, string author)
        {
            Book bookToRemove = null;
            foreach (Book book in Booklist)
            {
                if (book.title.ToLower() == title.ToLower() && book.writer.ToLower() == author.ToLower())
                {
                    bookToRemove = book;
                    break; // Stop searching once the book is found
                }
            }

            if (bookToRemove != null)
            {
                Booklist.Remove(bookToRemove);
                Console.WriteLine("Boek succesvol verwijderd.");
                return true;
            }
            else
            {
                Console.WriteLine("Boek niet gevonden in de bibliotheek.");
                return false;
            }
        }

        public void SearchBook(string titel, string auteur)
        {
            foreach (Book book in Booklist)
            {
				if (book.title == titel && book.writer == auteur)
				{
                    book.ShowInfo();

                }
            }
        }
		public void SearchBookBySpec()
		{

		}
		public void ShowAllBooks()
		{
            if (BookList.Count > 0)
            {
                foreach (Book book in Booklist)
                {
                    book.ShowInfo();
                }
            }
            else
            {
                Console.WriteLine("Er zijn geen boeken in de bibliotheek");
            }
        }

    }
}
