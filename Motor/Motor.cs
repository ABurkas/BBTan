namespace Motor
{
    public class Motor
    {
        Plansza plansza;
        List<Wizualizator> wizualizatory = new List<Wizualizator>();
        Gracz gracz;
        PriorityQueue<Zdarzenie, DateTime> zdarzenia = new PriorityQueue<Zdarzenie, DateTime>();
        DateTime start;

        public Motor(Plansza plansza, Gracz_CLI gracz, Wizualizator_CLI wizualizator)
        {
            this.plansza = plansza;
            this.gracz = gracz;
            wizualizatory.Add(wizualizator);
        }

        public void Start(int CoIleStartowac) {
            Punkt kierunek = gracz.wyznacz_kierunek();
            start = DateTime.Now;
            for (int i = 0; i < plansza.kulki.Count; i++)
            {
                DateTime czas = start.AddMilliseconds(CoIleStartowac);
                zdarzenia.Enqueue(new Start_kulki(i, czas, kierunek), czas);
            }
            ObsłużZdarzenia();
        }

        private void ObsłużZdarzenia()
        {
            while(zdarzenia.Count > 0)
            {
                var Pierwszy = zdarzenia.Peek();
                if (Pierwszy.Czas > DateTime.Now)
                    Thread.Sleep(Pierwszy.Czas-DateTime.Now);
                zdarzenia.Dequeue();
                Pierwszy.Realizuj(plansza, zdarzenia);
                Wizualizuj(Pierwszy);
            }
        }

        private void Wizualizuj(Zdarzenie pierwszy)
        {
            foreach (var item in wizualizatory)
            {
                item.PokazZdarzenie(pierwszy);
            }
        }
    }
}
