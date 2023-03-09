using Castle.Components.DictionaryAdapter;
using System.ComponentModel.DataAnnotations;

namespace e_Tickets.Models
{
    public class User
    {
        [System.ComponentModel.DataAnnotations.Key]
        public Guid id { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(20)]
        public string SurName { get; set; }
        [StringLength(20)]
        [Required]
        public string UserName { get; set; }
        [StringLength(50)]
        [Required]
        public string EMail { get; set; }
        [StringLength(100)]
        [Required]
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }=DateTime.Now;
        public bool Activate { get; set; }=false;
        [StringLength(250)]
        [Required]
        public string ProfileImageFile { get; set; }
        public string Role { get; set; }="User";
        public bool Aktif { get; set; }=false;

    }
}
