namespace Game.Messages
{
    public class DisplayPlayerMessage
    {
        public string PlayerName { get; set; }

        public DisplayPlayerMessage(string playerName)
        {
            PlayerName = playerName;
        }
    }
}
