using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.ViewModels
{
    [NotMapped]
    public class UserToRoleVM
    {
        [DisplayName("User")]
        public string UserID { get; set; }
        [DisplayName("Role")]
        public string RoleName { get; set; }
        public SelectList Users { get; set; }
        public SelectList Roles { get; set; }
    }
}
