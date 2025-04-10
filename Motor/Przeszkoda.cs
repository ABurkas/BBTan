using System.Security.Cryptography;

namespace Motor
{
    public abstract class Przeszkoda
    {
        public abstract Zdarzenie Kolizja(Kulka kulka);
    }

    public class Ściana : Przeszkoda
    {
        protected Punkt p1, p2;

        public Ściana(int x1, int y1, int x2, int y2)
        {
            p1 = new Punkt() { x = x1, y = y1 };
            p2 = new Punkt() { x = x2, y = y2 };
        }

        public override Zdarzenie Kolizja(Kulka kulka)
        {
            Odcinek o = new Odcinek(p1, p2);
            Kulka k = o.Odbicie(kulka);
            if (k == null) return null;
            return new Zmiana_parametrów_kulki(k);
        }
    }

    public class Wylot : Ściana
    {
        public Wylot(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2)
        { }

        public override Zdarzenie Kolizja(Kulka kulka)
        {
            Odcinek o = new Odcinek(p1, p2);
            Kulka k = o.Odbicie(kulka);
            if (k == null) return null;
            return new Ucieczka_kulki(k);
        }
    }

    public abstract class Znikająca : Przeszkoda
    {
        protected int licznik;
    }

    public class Bloczek : Znikająca
    {
        public override Zdarzenie Kolizja(Kulka kulka)
        {
            //!!!TODO
            return null;
        }
    }
    public class Nagroda : Znikająca
    {
        public override Zdarzenie Kolizja(Kulka kulka)
        {
            //!!!TODO
            return null;
        }
    }
}