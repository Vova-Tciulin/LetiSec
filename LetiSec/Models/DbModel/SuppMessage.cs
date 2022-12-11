using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LetiSec.Models.DbModel
{
    public class SuppMessage
    {
        public int Id{ get; set; }
        public string ShortDescription { get; set; }
        public List<string> Descriptions { get; set; }
        public List<string> Answers{ get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public string? Img { get; set; }
        public bool IsAnswer { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
    }
}
