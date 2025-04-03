using System.Drawing;

namespace Motor
{
    public class Plansza
    {
        public List<Kulka> kulki { get; protected set; }
        public List<Przeszkoda> przeszkody { get; protected set; }
        public Punkt PozycjaStartowa { get; protected set; }


        public void BBTan(int szerokość, int wysokość, int punktStartu)
        {
            kulki = [new Kulka()];
            przeszkody = new List<Przeszkoda>();
            przeszkody.Add( new Ściana(0,0,0, wysokość));
            przeszkody.Add( new Ściana(0, wysokość, szerokość, wysokość));
            przeszkody.Add( new Ściana(szerokość, wysokość, szerokość, 0));
            przeszkody.Add( new Wylot(0,0, szerokość, 0));
        }

        internal Zdarzenie KolejneZdarzenieKulki(int numer_kulki)
        {
            Zdarzenie minimalne = null;
            foreach(var przeszkoda in przeszkody)
            {
                var z = przeszkoda.Kolizja(kulki[numer_kulki]);
                if (minimalne == null || minimalne.Czas > z.Czas)
                    minimalne = z;
            }
            return minimalne;
        }
    }
}