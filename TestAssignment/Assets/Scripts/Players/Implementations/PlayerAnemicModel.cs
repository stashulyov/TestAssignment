namespace Players
{
    public class PlayerAnemicModel : IPlayerModel
    {
        public int PlayerId { get; }

        public float Hp { get; set; }
        public float Armor { get; set; }
        public float Vampirism { get; set; }
        public float Damage { get; set; }

        public PlayerAnemicModel(int playerId)
        {
            PlayerId = playerId;
        }
    }
}