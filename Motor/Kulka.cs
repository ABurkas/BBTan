namespace Motor
{
    public class Kulka
    {
        public Punkt pozycja;
        public Punkt kierunek;
        public DateTime start;
        public float promień;
        public void Zmiana(Punkt PozycjaStartowa, Punkt kierunek, DateTime czas) {
            pozycja = PozycjaStartowa;
            this.kierunek = kierunek;
            start = czas;
        }


    }
}