using System.ComponentModel.DataAnnotations;

namespace e_Tickets.Models.ViewModel
{
    public class Register:Login
    {
        [Required]
        public string Email {get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
       
        [MinLength(6),MaxLength(16)]
        [Compare(nameof(Password)),Required(ErrorMessage = "password alanı doldurulmak zorundadır")] 
        public string Password2 { get; set; }
    }
}
