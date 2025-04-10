using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor
{
    public abstract class Zdarzenie
    {
        public DateTime Czas { get; protected set; }
        public abstract void Realizuj(Plansza plansza, PriorityQueue<Zdarzenie, DateTime> zdarzenia);
    }

    public abstract class Zdarzenie_kulki : Zdarzenie
    {
        public int Numer_kulki { get; protected set; }
        
    }

    public class Start_kulki : Zdarzenie_kulki
    {
        public Punkt Kierunek { get; }

        public Start_kulki(int numer, DateTime dateTime, Punkt kierunek)
        {
            Numer_kulki = numer;
            Czas = dateTime;
            Kierunek = kierunek;
        }

        public override void Realizuj(Plansza plansza, PriorityQueue<Zdarzenie, DateTime> zdarzenia)
        {
            plansza.kulki[Numer_kulki].Zmiana(plansza.PozycjaStartowa, Kierunek, Czas);
            Zdarzenie kolejne = plansza.KolejneZdarzenieKulki(Numer_kulki);
            zdarzenia.Enqueue(kolejne, Czas);
        }
    }

    public class Zmiana_parametrów_kulki : Zdarzenie_kulki
    {
        private Kulka k;

        public Zmiana_parametrów_kulki(Kulka k)
        {
            this.k = k;
        }

        public override void Realizuj(Plansza plansza, PriorityQueue<Zdarzenie, DateTime> zdarzenia)
        {
            throw new NotImplementedException();
        }
    }

    public class Rozbicie_bloczka : Zdarzenie_kulki
    {
        public override void Realizuj(Plansza plansza, PriorityQueue<Zdarzenie, DateTime> zdarzenia)
        {
            throw new NotImplementedException();
        }
    }

    public class Ucieczka_kulki : Zdarzenie_kulki
    {
        private Kulka k;

        public Ucieczka_kulki(Kulka k)
        {
            this.k = k;
        }

        public override void Realizuj(Plansza plansza, PriorityQueue<Zdarzenie, DateTime> zdarzenia)
        {
            throw new NotImplementedException();
        }
    }

    public class Przyznanie_nagrody : Zdarzenie
    {
        public override void Realizuj(Plansza plansza, PriorityQueue<Zdarzenie, DateTime> zdarzenia)
        {
            throw new NotImplementedException();
        }
    }
}
