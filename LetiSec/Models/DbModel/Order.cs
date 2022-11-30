using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations.Schema;

namespace LetiSec.Models.DbModel
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId{get;set;}
        public int Count { get; set; }
        public int ProductId { get; set; }
        [Column(TypeName ="Date")]
        public DateTime Date { get; set; }
        public Product Product { get; set; }

    }
}
