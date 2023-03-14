namespace DAL.Models
{
    public class Wallet
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int CoinId { get; set; }

        public float Count { get; set; }

        public User user { get; set; }

        public Coin coin { get; set; }
    }
}