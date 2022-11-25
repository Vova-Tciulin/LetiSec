using Microsoft.AspNetCore.SignalR;

namespace LetiSec.Models.DbModel
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId{get;set;}
        public List<Product> Products { get; set; } = new();

    }
}
