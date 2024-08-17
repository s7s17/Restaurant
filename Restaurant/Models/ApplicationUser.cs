using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Restaurant.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Address { get; set; }
        public byte Age { get; set; }
        public DateTime RegisterDate { get; set; }
        public ICollection<BookedTable> BookedTables { get; set; }

    }
}
