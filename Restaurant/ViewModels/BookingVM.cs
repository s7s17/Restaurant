using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.ViewModels
{
    [NotMapped]
    public class BookingVM
    {
        public string Email { get; set; }

        public SelectList Tables { get; set; }
        [DisplayName("Table Number")]
        public string TableNum { get; set; }

        public string? Message { get; set; }
        [BindProperty, DataType(DataType.Date)]
        public DateOnly BookDate { get; set; }
        [BindProperty, DataType(DataType.Time)]
        public TimeOnly BookTime { get; set; }
        public byte NumOfPersons { get; set; }

    }
}
