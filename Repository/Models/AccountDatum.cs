namespace Repository.Models
{
    public class AccountDatum
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Direction { get; set; } = null!;
        public int Account { get; set; }
    }
}
