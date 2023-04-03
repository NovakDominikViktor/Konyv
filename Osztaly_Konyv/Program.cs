using Osztaly_Konyv.Expection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Osztaly_Konyv
{
    internal class Program
    {
        static List<Konyv> adatok = new List<Konyv>();
        static void Main(string[] args)
        {
            /*Konyv
             * isbnszam
             * szerzok
             * mucime
             * kiadasieve
             * nyelv
             * enciklopedia - bool
             * ebook - char
            */
            string isbn = "";
            
            int kEve = 0;
            bool enciklopeia = false;
            string szNev = "";
            char ebook = ' ';
            string mCim = " ";
            string nyelv = " ";


          

            try
            {
                Console.Write("Add meg az ISBN számot: ");
                isbn = Console.ReadLine();

                if (isbn.Length == 9)
                {
                    // Számjegyek összeszorzása és összegzése az ISBN-10 számjegyének meghatározásához
                    int sum = 0;
                    for (int i = 0; i < 9; i++)
                    {
                        int digit = 0;
                        if (int.TryParse(isbn[i].ToString(), out digit))
                        {
                            sum += (10 - i) * digit;
                        }
                    }
                    int checkDigit = (11 - (sum % 11)) % 11;
                    int lastDigit = checkDigit % 10;
                    isbn += lastDigit.ToString();
                }
                else if (isbn.Length == 12)
                {
                    // Számjegyek összeszorzása és összegzése az ISBN-13 számjegyének meghatározásához
                    int sum = 0;
                    for (int i = 0; i < 12; i++)
                    {
                        int digit = 0;
                        if (int.TryParse(isbn[i].ToString(), out digit))
                        {
                            if (i % 2 == 0)
                            {
                                sum += digit;
                            }
                            else
                            {
                                sum += 3 * digit;
                            }
                        }
                    }
                    int checkDigit = (10 - (sum % 10)) % 10;
                    isbn += checkDigit.ToString();
                }


            }
            catch (Expection.ISBNszamExpection e)
            {
                Console.WriteLine(e.Message);

            }

            Konyv bevitt = new Konyv(isbn, szNev, mCim, kEve, nyelv, enciklopeia, ebook);
            Console.Write("Add meg a szerző(k) nevét: ");
             szNev = Console.ReadLine();

            Console.Write("Add meg a műnek a címet: ");
            mCim = Console.ReadLine();

            do
            {
                Console.Write("Add meg a kiadas évét: ");
            } while (!int.TryParse(Console.ReadLine(), out kEve));
           
           Console.Write("Add meg a nyelvet amint íródott: ");
            nyelv = Console.ReadLine();
            bool helyesErtek = false;
            do
            {


                Console.Write("Ez egy enciklopedia-e: ");
               string igen = Console.ReadLine();
                if (igen == "igen")
                {
                    enciklopeia = true;
                    helyesErtek = true;
                }
                else if (igen == "nem")
                {
                    enciklopeia = false;
                    helyesErtek = true;
                }
            } while (!helyesErtek);
            

            do
            {
                Console.Write("Van-e Ebook formában is: ");
            } while (!char.TryParse(Console.ReadLine(), out ebook) || (ebook != 'i' && ebook != 'n'));

          


            adatok.Add(bevitt);
            Console.WriteLine(bevitt);

            Console.ReadKey();

            
            
        }
    }
}
