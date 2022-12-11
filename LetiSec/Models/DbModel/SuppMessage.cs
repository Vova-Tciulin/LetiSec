using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LetiSec.Models.DbModel
{
    public class SuppMessage
    {
        public int Id{ get; set; }
        public string ShortDescription { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public string? Img { get; set; }
        public bool IsAnswer { get; set; }
        public bool IsFirst { get; set; }
        public List<SuppQuestions> SuppQuestions { get; set; }
        public List<SuppAnswer> SuppAnswers { get; set; }

        
        

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime Time { get; set; }

    }
}
