using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Noa_Van_den_Berghe
{
    internal class Book : ILendable
    {
        public static Library bib1 = new Library("Bib_Antwerpen");

        public enum Genre
        {
            Thriller,
            Msdaad,
            Fantasy,
            Sciencefiction,
            Romantiek,
            Historisch,
            Jeugd,
            Kinder,
            Nonfictie,
            Biografie,
            Poëzie,
            fictie,
            schoolboek
        }
        private string Title;
        private int PageCount;
        private string Language;
        private string Writer;
        private string ISBN;
        private Genre BookGenre;
        private string Type;
        private bool isAvailable;
        private int borrowDays;
        private DateTime borrowingDate;

        public string type
        {
            get { return Type; }
            set
            {
                value = value.ToLower();
                if (value == "paperback" || value == "hardcover" || value == "e-book")
                {
                    Type = value;
                }
                else
                {
                    Console.WriteLine("Ongeldig type");
                }
            }
        }

        public Genre bookgenre
        {
            get { return BookGenre; }
            set
            {
                if (Enum.IsDefined(typeof(Genre), value))
                {
                    BookGenre = value;

                }
                else
                {
                    Console.WriteLine("Ongeldig genre");
                    throw new WronginputExeption();
                }
            }
        }

        public string isbn
        {
            get { return ISBN; }
            set
            {
                if (value == null || value.Length != 10)
                {
                    Console.WriteLine("Ongeldig ISBN nummer");
                }
                else
                {
                    ISBN = value;
                }
            }
        }

        public string writer
        {
            get { return Writer; }
            set
            {
                if (value == null || value == "")
                {
                    Console.WriteLine("Gelieve een schrijver in te geven");
                    throw new ArgumentNullException();
                }
                else
                {
                    Writer = value;
                }
            }
        }

        public string language
        {
            get { return Language; }
            set { Language = value; }
        }

        public int pagecount
        {
            get { return PageCount; }
            set { PageCount = value; }
        }

        public string title
        {
            get { return Title; }
            set { Title = value; }
        }

        public bool IsAvailable
        {
            get { return isAvailable; }
            set { this.isAvailable = value; }
        }
        public DateTime BorrowingDate
        {
            get { return borrowingDate; }
            set { borrowingDate = value; }
        }

        public int BorrowDays 
        {
            get { return borrowDays; }
            set
            {
                borrowDays = 20;
                if (BookGenre == Genre.schoolboek)
                {
                    borrowDays = 10;
                }
            }
        }

        public Book(string title, string writer, Library library)
        {
            writer = writer;
            title = title;
            isAvailable = true;
            library.AddBook(this);
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Titel: {title}");
            Console.WriteLine($"Schrijver: {writer}");
            Console.WriteLine($"ISBN: {isbn}");
            Console.WriteLine($"Genre: {bookgenre}");
            Console.WriteLine($"Taal: {language}");
            Console.WriteLine($"Aantal pagina's: {pagecount}");
        }
        internal void ShowWriterTitle()
        {
            Console.WriteLine($"Titel: {title}");
            Console.WriteLine($"Schrijver: {writer}");
        }
        public static List<Book> ReadbookFile(string path)
        {
            List<Book> books = new List<Book>();
            string[] lijnen = File.ReadAllLines(path);
            for (int i = 0; i < lijnen.Length; i++)
            {
                string[] kolomwaarden = lijnen[i]
                                            .Split(';');
                Book book = new Book(kolomwaarden[0], kolomwaarden[1], bib1);
            }

            return books;
        }

        public void Borrow()
        {
            try
            {
                if (IsAvailable)
                {
                    Console.WriteLine("Geef de uitleendatum in");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    borrowingDate = date;
                    isAvailable = false; 
                }
            }
            catch (Exception)
                {
                    throw;
                }


        }

        public void Return()
        {
            try
            {
                isAvailable = true;
                DateTime today = DateTime.Today;
                TimeSpan diff = today - (borrowingDate.AddDays(borrowDays));
                if (diff.TotalDays > 0)
                {
                    Console.WriteLine("Het boek is te laat binnengebracht");
                }
                else
                {
                    Console.WriteLine("Het boek is op tijd binnengebracht");
                }
            }
            catch (Exception)
            {

                Console.WriteLine("Er is iets foutgegaan bij het terugbrengen van het boek");
            }

        }
    }
}