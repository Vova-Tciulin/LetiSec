using LetiSec.Models.DbModel;
using Microsoft.AspNetCore.Identity;

namespace LetiSec.PassHashes
{
    public class PasswordHash<T>:IPasswordHash<T>  where T:class
    {
        private PasswordHasher<T> password=new PasswordHasher<T>();

        public string HashPas(T user,string pass)
        { 
            return password.HashPassword(user, pass);
        }
        public bool CheckPass(T user, string hashPass,string pass)
        {
            var res=password.VerifyHashedPassword( user, hashPass, pass);
            if (res == PasswordVerificationResult.Success)
                return true;
            else
                return false;
        }
    }
}
