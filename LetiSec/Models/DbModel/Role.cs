namespace LetiSec.Models.DbModel
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> User { get; set; }

    }
}
