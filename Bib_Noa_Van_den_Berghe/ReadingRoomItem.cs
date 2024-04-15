using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Noa_Van_den_Berghe
{
    abstract class ReadingRoomItem
    {
        public string Title { get; set; }
        public string Publisher { get; set; }

        public abstract string Identification { get; }
        public abstract string Category { get; }

        public ReadingRoomItem(string title, string publisher)
        {
            Title = title;
            Publisher = publisher;
        }
    }
}
