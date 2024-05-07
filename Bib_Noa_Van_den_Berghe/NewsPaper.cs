using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bib_Noa_Van_den_Berghe
{
    internal class NewsPaper : ReadingRoomItem
    {
        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }


        public NewsPaper(string title, string publisher, DateTime date) : base(title, publisher)
        {
            this.date = date;
        }

        public override string Identification
        {
            get
            {
                string firstLetters = FirstLetters(Title);
                string day = Date.Day.ToString("D2") ;
                string month = Date.Month.ToString("D2");
                string year = Date.Year.ToString();
                return (firstLetters + day + month + year);
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
        public override string Category => "Krant";

    }
}
