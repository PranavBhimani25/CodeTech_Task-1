using System.ComponentModel.DataAnnotations;

namespace CodeTech_Task_1.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }


}
