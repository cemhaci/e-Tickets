using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace e_Tickets.Models
{
    public class Comment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Text { get; set; }
        public DateTime RegesterDate { get; set; }
        public virtual User User { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
