using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor
{
    public abstract class Gracz
    {
        public string Imię { get; protected set; }
        public abstract Punkt wyznacz_kierunek();

    }

    public class Gracz_CLI : Gracz 
    {

        public Gracz_CLI(string imię)
        {
            Imię = imię;

        }

        public override Punkt wyznacz_kierunek()
        {
            Console.WriteLine("Kierunek wyrzutu: ");
            string str = Console.ReadLine();
            string[] s = str.Split();
            return new Punkt { x = float.Parse(s[0]), y = float.Parse(s[1]) };
        }

    }
}
