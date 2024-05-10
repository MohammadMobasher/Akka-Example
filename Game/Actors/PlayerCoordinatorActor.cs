using Akka.Actor;
using Game.Messages;

namespace Game.Actors
{
    public class PlayerCoordinatorActor : ReceiveActor
    {
        public PlayerCoordinatorActor()
        {
            Receive<CreatePlayerGameMessage>(message =>
            {
                Console.WriteLine($"PlayerCoordinatorActor received CreatePlayerMessage for {message.PlayerName}");

                Context.ActorOf(
                    Props.Create(() => new PlayerActor(message.PlayerName, 100)),
                    message.PlayerName
                );
            });
        }
    }
}
