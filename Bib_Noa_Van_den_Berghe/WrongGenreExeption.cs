using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bib_Noa_Van_den_Berghe
{
    internal class WrongGenreExeption: ApplicationException
    {
        public override string ToString()
        {
            return "Dit is geen geldig genre";
        }
    }
}
