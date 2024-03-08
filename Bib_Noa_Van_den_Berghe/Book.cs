    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Bib_Noa_Van_den_Berghe
    {
        internal class Book
        {
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
                fictie
            }
            private string Title;
            private int PageCount;
            private string Language;
            private string Writer;
            private string ISBN;
            private Genre BookGenre;
            private string Type;
            private Library Library;

            public Library library
            {
                get { return Library; }
                set { Library = value; }
            }


            public string type
            {
                get { return Type; }
                set 
                {
                    value = value.ToLower();
                    if (value == "paperback" || value =="hardcover" || value == "e-book")
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

            public Book(string title, string writer, Library library)
            {
                this.writer = writer;
                this.title = title;
                this.library = library;
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
            // Speler voornaam, familienaam, geboortejaar
            string[] lijnen = File.ReadAllLines(path);
            for (int i = 0; i < lijnen.Length; i++)
            {
                string[] kolomwaarden = lijnen[i].Split(',');
                Book book = new Book(kolomwaarden[0], kolomwaarden[1], null);
                books.Add(book);
            }

            return books;
        }
    }
    }
