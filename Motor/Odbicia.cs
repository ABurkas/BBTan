using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Motor
{
    abstract public class Linia
    {
        abstract public Kulka Przecięcie(Kulka kulka);
    }
    public class Łuk : Linia
    {
        private Punkt p1;
        private float promień;

        public Łuk(Punkt p1, float promień)
        {
            this.p1 = p1;
            this.promień = promień;
        }

        public override Kulka Przecięcie(Kulka kulka)
        {
            //!!!TODO
            return null;
        }
    }
    public class Odcinek : Linia
    {
        private Punkt p1;
        private Punkt p2;

        public Odcinek(Punkt p1, Punkt p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }

        public Kulka Odbicie(Kulka kulka)
        {
            Linia[] linie =
            {
                this.Przesuń(kulka.promień),
                this.Przesuń(-kulka.promień),
                new Łuk(p1, kulka.promień),
                new Łuk(p2, kulka.promień)
            };
            Kulka minimalna = null;
            foreach (var linia in linie)
            {
                Kulka z = linia.Przecięcie(kulka);
                if (minimalna == null || z != null && minimalna.start > z.start)
                    minimalna = z;
            }
            return minimalna;
        }

        private Odcinek Przesuń(float promień)
        {
            if(p1.y == p2.y) return new Odcinek(new Punkt() { x = p1.x, y = p1.y + promień},
                new Punkt() { x = p2.x, y = p2.y + promień});
            if (p1.x == p2.x) return new Odcinek(new Punkt() { x = p1.x + promień, y = p1.y },
                new Punkt() { x = p2.x + promień, y = p2.y });
            //!!!TODO: dla ukośnych odcinków
            return null;
        }

        public override Kulka Przecięcie(Kulka kulka)
        {
            float a1 = kulka.kierunek.x == 0 ? float.PositiveInfinity * kulka.kierunek.y : kulka.kierunek.y / kulka.kierunek.x;
            float b1 = kulka.pozycja.y - a1 * kulka.pozycja.x;
            float a2 = p2.x - p1.x == 0 ? float.PositiveInfinity * (p2.y - p1.y) : (p2.y - p1.y) / (p2.x - p1.x);
            float b2 = p2.y - a1 * p2.x;

            //!!!TODO: obsłużyć nieskończoności

            float x_przeciecie = (b1 - b2) / (a2 - a1);
            float y_przeciecie = x_przeciecie * a1 + b1;

            if (!wewnątrz(x_przeciecie, y_przeciecie))
                return null;

            return new Kulka()
            {
                pozycja = new Punkt { x = x_przeciecie, y = y_przeciecie },
                promień = kulka.promień,
                kierunek = kierunek_odbicia(kulka),
                start = kulka.start.AddSeconds(euklides(x_przeciecie - kulka.pozycja.x, y_przeciecie - kulka.pozycja.y) / euklides(kulka.kierunek.x, kulka.kierunek.y))
            };
        }

        private bool wewnątrz(float x, float y)
        {
            if (p1.x == p2.x) // przypadek pionowy
                return (y - p1.y) * (y - p2.y) <= 0;
            // przypadek poziomy lub ukośny
            return (x - p1.x) * (x - p2.x) <= 0;
        }

        private Punkt kierunek_odbicia(Kulka kulka)
        {
            // pionowe
            if (p2.x - p1.x == 0) return new Punkt { x = -kulka.kierunek.x, y = kulka.kierunek.y };
            // poziome
            if (p2.y - p1.y == 0) return new Punkt { y = -kulka.kierunek.y, x = kulka.kierunek.x };

            //!!!TODO: bez ukośnych odcinków
            return new Punkt();
        }

        private float euklides(float x, float y)
        {
            return (float) Math.Sqrt(x * x + y * y);
        }
    }
}
