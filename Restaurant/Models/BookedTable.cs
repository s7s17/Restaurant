using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Models
{
    [PrimaryKey("TableNum", "BookDate")]
    public class BookedTable
    {
        [ForeignKey("Table")]
        public string TableNum { get; set; }
        [ForeignKey("User")]
        public string UserID { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public DateOnly BookDate { get; set; }
        [BindProperty, DataType(DataType.Time)]
        public TimeOnly BookTime { get; set; }
        
        public string? Message { get; set; }
        public byte NumOfPersons { get; set; }
        public Table Table { get; set; }
        public ApplicationUser User { get; set; }
        
    }
}
