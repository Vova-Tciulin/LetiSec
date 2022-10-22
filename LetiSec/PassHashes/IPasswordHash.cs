namespace LetiSec.PassHashes
{
    public interface IPasswordHash<T>
    {
        public string HashPas(T user, string pass);
        public bool CheckPass(T user, string hashPass, string pass);
    }
}
