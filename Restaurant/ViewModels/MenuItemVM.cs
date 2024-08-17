using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.ViewModels
{
    [NotMapped]
    public class MenuItemVM
    {
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public float Price { get; set; }
        public string Image { get; set; }
        public SelectList Categories { get; set; }
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
    }
}
