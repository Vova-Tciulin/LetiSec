using System.ComponentModel.DataAnnotations;

namespace LetiSec.Models.DbModel
{
    public class SuppQuestions
    {
        public int Id { get; set; }
        public string Questions { get; set; }
        public int SuppMessageId { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime Time { get; set; }

    }
}
