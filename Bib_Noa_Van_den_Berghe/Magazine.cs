using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Noa_Van_den_Berghe
{
    internal class Magazine : ReadingRoomItem
    {
        public Magazine(string title, string publisher) : base(title, publisher)
        {
        }

        public override string Identification => throw new NotImplementedException();

        public override string Category => throw new NotImplementedException();
    }
}
