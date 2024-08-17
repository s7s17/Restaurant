using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models
{
    public class MenuItem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        [ForeignKey("Category")]
        public int CategoryID { get; set; }
        public MenuCategory Category { get; set; }
    }
}
