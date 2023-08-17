using System.ComponentModel.DataAnnotations;

namespace LinkedinProfile.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Kullanıcı Adı Zorunlu")]
        [StringLength(50)]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı Zorunlu")]
        [StringLength(50)]
        public string Password { get; set; }
    }
}