namespace Game.Messages
{
    public class HitPlayerMessage
    {
        public int Damage { get; set; }

        public HitPlayerMessage(int damage)
        {
            Damage = damage;
        }
    }
}
