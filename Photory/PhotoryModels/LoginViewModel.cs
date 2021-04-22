using System.ComponentModel.DataAnnotations;

namespace PhotoryModels
{
    public class LoginViewModel
    {
        [Required]
        public string ValidationName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}