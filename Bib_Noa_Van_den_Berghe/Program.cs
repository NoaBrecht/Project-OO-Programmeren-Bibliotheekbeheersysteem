using static Bib_Noa_Van_den_Berghe.Book;
using static System.Reflection.Metadata.BlobBuilder;

namespace Bib_Noa_Van_den_Berghe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool stop = false;
            Library bib1 = new Library("Bib_Antwerpen");
            //ReadbookFile(@"C:\boeken.csv");
            do
            {
                string keuze = "";

                Console.Clear();
             Console.WriteLine("Wat wenst U te doen?");
                Console.WriteLine("1. Een boek toevoegen aan de bibliotheek op basis van titel en auteur");
                Console.WriteLine("2. Extra informatie toevoegen aan een boek");
                Console.WriteLine("3. Alle info weergeven op basis van titel en auteur");
                Console.WriteLine("4. Een boek zoeken");
                Console.WriteLine("5. Boek verwijderen uit bibliotheek");
                Console.WriteLine("6. Alle boeken tonen");
                Console.WriteLine("exit: Afsluiten");
                keuze = Console.ReadLine();
                switch (keuze.ToLower())
                {
                    case "1":
                        Console.WriteLine("Wat is de titel van het boek?");
                        string title = Console.ReadLine();
                        Console.WriteLine("Wie is de auteur van het boek?");
                        string author = Console.ReadLine();
                        Book newBook = new Book(title, author, bib1);
                        Console.WriteLine($"Het boek met titel: {title} en auteur {author} is toegevoegd aan de bibliotheek");
                        Console.WriteLine("Druk op enter om verder te gaan");
                        Console.ReadLine();

                        break;
                    case "2":
                        Console.WriteLine("Wat is de titel van het boek?");
                        string ISBNtitle = Console.ReadLine();
                        Console.WriteLine("Wie is de auteur van het boek?");
                        string ISBNauthor = Console.ReadLine();
                        Console.WriteLine("Voer het ISBN nummer voor het boek in: (0123456789)");
                        string ISBN = Console.ReadLine();
                        bib1.addInfoToBook(ISBNtitle, ISBNauthor, ISBN);
                        break;
                    case "3":
                        Console.WriteLine("Wat is de titel van het boek?");
                        string naam = Console.ReadLine();
                        Console.WriteLine("Wie is de auteur van het boek?");
                        string auter = Console.ReadLine();
                        bib1.SearchBookByTitelAutor(naam, auter);
                        Console.WriteLine("Druk op enter om verder te gaan");
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.WriteLine("Wat is de titel van het boek dat je wilt zoeken?");
                        string searchString = Console.ReadLine();
                        Console.WriteLine("Wie is de auteur van het boek?");
                        string SearchAuthor = Console.ReadLine();
                        bib1.SearchBookByTitelAutor(searchString, SearchAuthor);
                        Console.WriteLine("Druk op enter om verder te gaan");
                        Console.ReadLine();
                        break;
                    case "5":
                        Console.WriteLine("Wat is de titel van het boek dat je wilt verwijderen?");
                        string removeTitle = Console.ReadLine();
                        Console.WriteLine("Wie is de auteur van het boek?");
                        string removeAuthor = Console.ReadLine();
                        bib1.RemoveBook(removeTitle, removeAuthor);
                        Console.WriteLine("Druk op enter om verder te gaan");
                        Console.ReadLine();
                        break;
                    case "6":
                        bib1.ShowAllBooks();
                        Console.WriteLine("Druk op enter om verder te gaan");
                        Console.ReadLine();
                        break;
                    case "exit":
                        stop = true;
                        break;

                    default:
                        Console.WriteLine("Ongeldige keuze. Kies een nummer uit de lijst.");
                        break;
                } 
            } while (!stop);
        }
    }
}
