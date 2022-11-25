using System.ComponentModel.DataAnnotations;

namespace LetiSec.Models.DbModel
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите название продукта")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Введите описание продукта")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Введите стоимость продукта")]
        public double Price { get; set; }

        public string? Img { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
