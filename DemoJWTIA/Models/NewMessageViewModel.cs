using System.ComponentModel.DataAnnotations;

namespace DemoJWTIA.Models
{
    public class NewMessageViewModel
    {
        [Required]
        public string Content { get; set; }
    }
}
