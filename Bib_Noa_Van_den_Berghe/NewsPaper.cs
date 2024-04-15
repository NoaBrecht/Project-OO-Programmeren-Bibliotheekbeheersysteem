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

        public NewsPaper(string title, string publisher, DateTime date) : base(title, publisher)
        {
            Title = title;
            Publisher = publisher;
            Date = date;
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
		}
        public override string Identification => throw new NotImplementedException();

        public override string Category => throw new NotImplementedException();
        
    }
}
