using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class Table
    {
        [Key]
        public string TableNumber { get; set; }
        public byte TableCapacity { get; set; }
        public ICollection<BookedTable> BookedTables { get; set; }
    }
}
