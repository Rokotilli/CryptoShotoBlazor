namespace DAL.Models
{
    public class Coin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public List<Wallet> Wallets { get; set; }
    }
}