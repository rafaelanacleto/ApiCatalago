using System.ComponentModel.DataAnnotations;

namespace ApiCatalago.Models
{
    public class AddRoleToUserModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string RoleName { get; set; }
        public string UserName { get; set; }
    }
}
