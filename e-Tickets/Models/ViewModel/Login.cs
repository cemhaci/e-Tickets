using System.ComponentModel.DataAnnotations;

namespace e_Tickets.Models.ViewModel
{
    public class Login
    {

        public Guid id { get; set; }
        [Required(ErrorMessage ="username alanı doldurulmak zorundadır")]
        [StringLength(35,ErrorMessage ="username max 35 karakter olmalıdır")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="password alanı doldurulmak zorundadır")]
        [MaxLength(35,ErrorMessage ="password alanı max 35 olmalıdır")]
        [MinLength(6,ErrorMessage ="password alanı min 6 karakter olmalıdır")]
        public string Password { get; set; }
    }
}
