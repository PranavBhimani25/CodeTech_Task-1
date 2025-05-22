using System.ComponentModel.DataAnnotations;

namespace CodeTech_Task_1.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<Product> Products { get; set; }
    }


}
