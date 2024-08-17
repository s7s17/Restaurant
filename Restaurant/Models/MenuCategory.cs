using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class MenuCategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
    }
}
