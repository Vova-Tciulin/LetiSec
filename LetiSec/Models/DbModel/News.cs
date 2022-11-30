using System.ComponentModel.DataAnnotations;

namespace LetiSec.Models.DbModel
{
    public class News
    {
        public int Id { get; set; }

       // public DateOnly Date { get; set; }
        [Required]
        public string ShortDesc { get; set; }
        [Required]
        public string Description { get; set; }
        public string? Img { get; set; }


    }
}
