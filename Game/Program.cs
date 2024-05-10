using Akka.Actor;
using Game.Actors;
using Game.Messages;

namespace Game
{
    class Program
    {
        private static ActorSystem? GameSystem { get; set; }
        private static IActorRef? PlayerCoordinator { get; set; }


        static void Main(string[] args)
        {
            GameSystem = ActorSystem.Create("Game");

            PlayerCoordinator = GameSystem.ActorOf<PlayerCoordinatorActor>("PlayerCoordinator");

            Thread.Sleep(2000);
            Console.WriteLine("Available commands:");
            Console.WriteLine("<playername> create");
            Console.WriteLine("<playername> hit");
            Console.WriteLine("<playername> display");
            Console.WriteLine("<playername> error");

            while (true)
            {
                string? action = Console.ReadLine();

                if (string.IsNullOrEmpty(action))
                {
                    Console.WriteLine("Please write the action.");
                    continue;
                }

                string playerName = action.Split(' ')[0];

                if (action.Contains("create"))
                {
                    CreatePlayer(playerName);
                }
                else if (action.Contains("hit"))
                {
                    var damage = int.Parse(action.Split(' ')[2]);

                    HitPlayer(playerName, damage);
                }
                else if (action.Contains("display"))
                {
                    DisplayPlayer(playerName);
                }
                else if (action.Contains("error"))
                {
                    ErrorPlayer(playerName);
                }
                else
                {
                    Console.WriteLine("Unknown command");
                }

            }

        }

        private static void ErrorPlayer(string playerName)
        {
            GameSystem?.ActorSelection($"/user/PlayerCoordinator/{playerName}")
                    .Tell(new ErrorMessage());
        }


        private static void DisplayPlayer(string playerName)
        {
            GameSystem?.ActorSelection($"/user/PlayerCoordinator/{playerName}")
                .Tell(new DisplayPlayerMessage(playerName));
        }


        private static void HitPlayer(string playerName, int damage)
        {
            GameSystem?.ActorSelection($"/user/PlayerCoordinator/{playerName}")
                .Tell(new HitPlayerMessage(damage));
        }


        private static void CreatePlayer(string playerName)
        {
            PlayerCoordinator?.Tell(new CreatePlayerGameMessage(playerName));
        }
    }
}