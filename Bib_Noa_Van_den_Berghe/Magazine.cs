    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bib_Noa_Van_den_Berghe
{
    internal class Magazine : ReadingRoomItem
    {
        public Magazine(string title, string publisher, int month, int year) : base(title, publisher)
        {
            if (12 >= month)
            {
                Month = month;
            }
            else
            {
                throw new ArgumentException("De maand is maximaal 12");
            }
            if (year <= 2500)
            {
                Year = year;
            }
            else
            {
                throw new ArgumentException("Het jaartal is maximaal 2500");
            }
            Title = title;
            Publisher = publisher;
        }
        private int year;

        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        private int month;

        public int Month
        {
            get { return month; }
            set { month = value; }
        }





        public override string Identification
        {
            get
            {
                string firstLetters = FirstLetters(Title);
                string maand = this.month.ToString("D2");
                string jaar = year.ToString() ;
                return (firstLetters + maand + jaar);
            }
        }
        private string FirstLetters(string title)
        {
            string[] words = title.Split(' ');
            string initials = "";

            foreach (string word in words)
            {
                initials += word[0];
            }

            return initials.ToUpper();
        }
        public override string Category => "Maandblad";
    }
}
