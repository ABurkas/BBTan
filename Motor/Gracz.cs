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
            throw new NotImplementedException();
            // Nadanie kierunku kulki
        }

    }
}
