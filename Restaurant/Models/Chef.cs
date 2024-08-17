using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Chef
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Image { get; set; }
        public DateTime HireDate { get; set; }
        public string Description { get; set; }

    }
}
