using System.ComponentModel.DataAnnotations;

namespace LetiSec.Models.DbModel
{
    public class SuppAnswer
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public int SuppMessageId { get; set; }
        public int UserId { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime Time { get; set; }
    }
}
