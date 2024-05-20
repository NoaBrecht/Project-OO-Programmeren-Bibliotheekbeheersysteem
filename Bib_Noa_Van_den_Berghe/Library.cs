using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public void AddNewsaper()
        {
            Console.WriteLine("Wat is de naam van de krant?");
            string newspaperName = Console.ReadLine();
            Console.WriteLine("Wat is de datum van de krant?");
            DateTime newspaperDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Wat is de uitgeverij van de krant?");
            string newspaperPublisher = Console.ReadLine();
            NewsPaper krant = new NewsPaper(newspaperName, newspaperPublisher, newspaperDate);
            AllReadingRoom.Add(newspaperDate,krant);
        }
        public void ShowAllNewspapers()
        {
            Console.WriteLine("De kranten in de leeszaal");
            foreach (NewsPaper newsPaper in AllReadingRoom.Values.OfType<NewsPaper>())
            {
                Console.WriteLine($"- {newsPaper.Title} van {newsPaper.Date.ToLongDateString()}");
            }
        }
        public void AddMagazine()
        {
            try
            {
                Console.WriteLine("Wat is de naam van het magazine?");
                string magazineName = Console.ReadLine();
                Console.WriteLine("Wat is de maand van het magazine?");
                int magazineMonth = int.Parse(Console.ReadLine());
                Console.WriteLine("Wat is de jaar van het magazine?");
                int magazineYear = int.Parse(Console.ReadLine());
                Console.WriteLine("Wat is de uitgeverij van het magazine?");
                string magazinePublisher = Console.ReadLine();
                Magazine magazine = new Magazine(magazineName, magazinePublisher, magazineMonth, magazineYear);
                AllReadingRoom.Add(DateTime.Now, magazine);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void ShowAllMagazines()
        {
            Console.WriteLine("Alle maandbladen in de leeszaal");
            foreach (Magazine magazine in AllReadingRoom.Values.OfType<Magazine>())
            {
                Console.WriteLine($"- {magazine.Title} van {magazine.Month}/{magazine.Year} van uitgeverij {magazine.Publisher}");
            }
        }
        public void AcquisitionsReadingRoomToday()
        {
            DateTime today = DateTime.Today;
            Console.WriteLine($"Aanwinsten in de leeszaal van {today.DayOfWeek} {today.ToLongDateString()}");
            foreach (var item in AllReadingRoom)
            {
                if (item.Key.Date == today)
                {
                    Console.WriteLine($"{item.Value.Title} met id {item.Value.Identification}");
                }
            }
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
                Console.WriteLine();
            }
        }
        public Book GetBook(string titel, string auteur)
        {
            foreach (Book book in BookList)
            {
                if (book.title == titel && book.writer == auteur)
                {
                    return book;
                }
            }
            return null;
        }
        public void addInfoToBook(string title, string author, int pagecount)
        {
            foreach (Book book in BookList)
            {
                if (book.title == title && book.writer == author)
                {
                    book.pagecount = pagecount;
                }
            }
        }
    }
}
