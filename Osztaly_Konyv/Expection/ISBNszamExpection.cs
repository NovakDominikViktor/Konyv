using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osztaly_Konyv.Expection
{
    internal class ISBNszamExpection:Exception
    {
        string hibasISBN;

        public string HibasISBN
        {
            get { return hibasISBN; }
            set { hibasISBN = value;}
        }

        public ISBNszamExpection(string hibasISBN)
        {
            HibasISBN = hibasISBN;
        }
    }
}
