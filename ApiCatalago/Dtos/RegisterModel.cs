using System.ComponentModel.DataAnnotations;

namespace ApiCatalago.Dtos
{
    public class RegisterModel
    {
        [Required]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}
