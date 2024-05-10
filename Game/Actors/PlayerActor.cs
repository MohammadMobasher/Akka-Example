using Akka.Actor;
using Game.Messages;

namespace Game.Actors
{
    public class PlayerActor : ReceiveActor
    {
        private string PlayerName { get; set; }
        private int Health { get; set; }

        public PlayerActor(string playerName, int health)
        {

            PlayerName = playerName;
            Health = health;

            Console.WriteLine($"{PlayerName} created.");

            // Receives
            Receive<DisplayPlayerMessage>(_ => Display());
            Receive<HitPlayerMessage>(message => Hit(message));
            Receive<ErrorMessage>(message => Error());
        }

        private void Display()
        {
            Console.WriteLine($"{PlayerName} received display message.");

            Console.WriteLine($"{PlayerName} has {Health} health");
        }

        private void Hit(HitPlayerMessage input)
        {
            Console.WriteLine($"{PlayerName} received hit message.");

            Health -= input.Damage;
        }

        private void Error()
        {
            Console.WriteLine($"{PlayerName} received CauseErrorMessage");

            throw new ApplicationException($"Simulated exception in player: {PlayerName}");
        }
    }
}
