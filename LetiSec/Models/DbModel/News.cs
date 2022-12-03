using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LetiSec.Models.DbModel
{
    public class News
    {
        public int Id { get; set; }

        [Required]
        public string ShortDesc { get; set; }
        [Required]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
        public string? Img { get; set; }


    }
}
