namespace Upi_Without_Internet.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string SenderName { get; set; } = "";
        public string RecieverName { get; set; } = "";
        public decimal Amount { get; set; }

    }
}
