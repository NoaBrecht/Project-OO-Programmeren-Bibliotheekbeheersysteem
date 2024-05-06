using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Noa_Van_den_Berghe
{
    internal class WronginputExeption : ApplicationException
    {
        public override string ToString()
        {
            return "De invoer is ongeldig.";
        }
    }
}
