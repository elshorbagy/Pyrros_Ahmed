using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
    public class AccountDatum
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public string Direction { get; set; } = null!;
        [Required]
        public int Account { get; set; }
    }
}
