using System;
using System.ComponentModel.DataAnnotations;

namespace PhotoryModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

    }
}