using LetiSec.Models.DbModel;
using System.ComponentModel.DataAnnotations;

namespace LetiSec.Models.ViewModels
{
    public class SupportVM
    {
        public SuppMessage SuppMessage { get; set; }
        [Required(ErrorMessage = "Опишите свою проблему")]
        public string? Questions { get; set; }
        public string? Answer { get; set; }
    }
}
