using Motor;
namespace TestWKonsoli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Wizualizator_CLI wizualizator = new Wizualizator_CLI();
            Gracz_CLI gracz = new Gracz_CLI("Gracz");
            Plansza plansza = new Plansza();
            plansza.BBTan(10,20,5);

            Motor.Motor motor = new Motor.Motor(plansza,gracz,wizualizator);
            motor.Start(100);
        }
    }
}
