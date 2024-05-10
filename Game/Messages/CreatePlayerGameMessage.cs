namespace Game.Messages
{
    public class CreatePlayerGameMessage
    {
        public string PlayerName { get; set; }

        public CreatePlayerGameMessage(string playerName)
        {
            PlayerName = playerName;
        }
    }
}
