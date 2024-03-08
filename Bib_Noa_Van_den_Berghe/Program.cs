using static Bib_Noa_Van_den_Berghe.Book;
using static System.Reflection.Metadata.BlobBuilder;

namespace Bib_Noa_Van_den_Berghe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool stop = false;
            Library bib1 = new Library("TestBib");
            do
            {
                int keuze = 0;

                Console.Clear();
             Console.WriteLine("Wat wenst U te doen?");
                Console.WriteLine("1. Een boek toevoegen aan de bibliotheek op basis van titel en auteur");
                Console.WriteLine("2. Extra informatie toevoegen aan een boek"); //TODO
                Console.WriteLine("3. Alle info weergeven op basis van titel en auteur"); //TODO
                Console.WriteLine("4. Een boek zoeken"); //TODO
                Console.WriteLine("5. Boek verwijderen uit bibliotheek");
                Console.WriteLine("6. Alle boeken tonen");
                Console.WriteLine("9. Afsluiten");
                keuze = int.Parse(Console.ReadLine());
                switch (keuze)
                {
                    case 1:
                        Console.WriteLine("Wat is de titel van het boek?");
                        string title = Console.ReadLine();
                        Console.WriteLine("Wie is de auteur van het boek?");
                        string author = Console.ReadLine();
                        // Create the book object
                        Book newBook = new Book(title, author);
                        bib1.AddBook(newBook);
                        Console.WriteLine($"Het boek met titel: {title} en auteur {author} is toegevoegd aan de bibliotheek");
                        Console.WriteLine("Druk op enter om verder te gaan");
                        Console.ReadLine();

                        break;
                    case 2:
                        // Add additional information to a book
                        break;
                    case 3:
                        Console.WriteLine("Wat is de titel van het boek?");
                        string naam = Console.ReadLine();
                        Console.WriteLine("Wie is de auteur van het boek?");
                        string auter = Console.ReadLine();
                        bib1.SearchBook(naam, auter);
                        Console.WriteLine("Druk op enter om verder te gaan");
                        Console.ReadLine();
                        break;
                    case 4:
                        bib1.SearchBookBySpec();
                        break;
                    case 5:
                        Console.WriteLine("Wat is de titel van het boek dat je wilt verwijderen?");
                        string removeTitle = Console.ReadLine();
                        Console.WriteLine("Wie is de auteur van het boek?");
                        string removeAuthor = Console.ReadLine();
                        bib1.RemoveBook(removeTitle, removeAuthor);
                        Console.WriteLine("Druk op enter om verder te gaan");
                        Console.ReadLine();
                        break;
                    case 6:
                        bib1.ShowAllBooks();
                        Console.WriteLine("Druk op enter om verder te gaan");
                        Console.ReadLine();
                        break;
                    case 9:
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
