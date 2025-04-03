namespace Motor
{
    public abstract class Wizualizator
    {
        protected Motor motor;
        public abstract void PokazZdarzenie(Zdarzenie zdarzenie);

    }

    public class Wizualizator_CLI : Wizualizator
    {
        public override void PokazZdarzenie(Zdarzenie zdarzenie)
        {
            Console.WriteLine($"{zdarzenie.Czas}; {zdarzenie}");
        }
    }

    public class Wizualizator_GUI : Wizualizator
    {
        public override void PokazZdarzenie(Zdarzenie zdarzenie)
        {
            { }
        }
    }
}