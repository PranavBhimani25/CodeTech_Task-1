using System.ComponentModel.DataAnnotations;

namespace CodeTech_Task_1.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
        //public string Picture { get; set; }
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }


}
