namespace CryptoTravel.Models
{
    public class ConversionRate
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public decimal Rate { get; set; }
        public decimal TransactionFee { get; set; }
        public decimal ConvertedAmount { get; set; }
    }
}
