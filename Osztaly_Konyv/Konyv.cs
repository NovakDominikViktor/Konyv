using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Osztaly_Konyv
{
    internal class Konyv
    {
        public string isbnSzam;
        public string szerzo_k;
        public string muCime;
        public int kiadasEve;
        public string nyelv;
        public bool enciklopedia;
        public char ebook;

        public override string ToString()
        {
            return $"ISBN szám: {isbnSzam}|Szerző címe: {szerzo_k}|Mű címe: {muCime}|Kiadás éve: {kiadasEve}|Nyelv: {nyelv}|Enciklopédia: {enciklopedia}|Ebook: {ebook}";
        }

        public string IsbnSzam
        {
            get { return isbnSzam; }
            set
            {
                if (value.Length != 10 && value.Length != 13)
                {
                    throw new Osztaly_Konyv.Expection.ISBNszamExpection(value);
                }
                isbnSzam = value;
            }
            }

        public string Szerzo_k
        {
            get { return szerzo_k;}
            set { szerzo_k = value;}
        }

        public string MuCime
        {
            get { return muCime; }
            set { muCime = value; }
        }

        public int KiadasEve
        {
            get { return kiadasEve; }
            set { kiadasEve = value;}
        }

       public string Nyelv
        {
            get { return nyelv; }
            set { nyelv = value; }
        }

        public bool Enciklopedia
        {
            get { return enciklopedia;}
            set { enciklopedia = value;}
        }

       public char Ebook
        {
            get { return ebook; }
            set { ebook = value; }
        }


        public Konyv() { }

        public Konyv(string iSBNSzam, string szerzo_k, string muCime, int kiadasEve, string nyelv, bool enciklopedia, char ebook)
        {
            IsbnSzam = iSBNSzam;
            Szerzo_k = szerzo_k;
            MuCime = muCime;
            KiadasEve = kiadasEve;
            Nyelv = nyelv;
            Enciklopedia = enciklopedia;
            Ebook = ebook;
        }

        ~Konyv() 
        {
            Console.WriteLine("Destruktor az így garazdálkodott");
        }    
    }
}
