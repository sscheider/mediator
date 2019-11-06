using System;
using SS.Mediation.Example.Colleague;
using SS.Mediation.Example.Interfaces;
using SS.Mediation.Example.Mediator;

namespace mediator01
{
    class Program
    {
        static void Main(string[] args)
        {
            // setup
            IMediator mediator = new Mediator();
            ColleagueBlue blue = new ColleagueBlue(mediator);
            ColleagueRed red = new ColleagueRed(mediator);

            // use
            blue.Send("Red loves blue...");
            red.Send("Blue is a fool.");

            Console.WriteLine("\nHit RETURN to exit.");
            string leaving = Console.ReadLine();
        }
    }
}
