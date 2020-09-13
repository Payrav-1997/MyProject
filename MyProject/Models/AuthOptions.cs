using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer";  //Издатель токена
        public const string AUDIENCE = "MyAuthClient"; // потребитель ткена
        const string KEY = "Admin1234"; //клуюч шифрации
        public const int LIFETIME= 1; //Время жизни токена 

        internal static SecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
