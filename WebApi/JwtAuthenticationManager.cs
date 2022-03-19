using CoreBusiness;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly byte[] key;
        private IConfiguration configuration { get; set; }

        public JwtAuthenticationManager(byte[] key, IConfiguration configuration)
        {
            this.key = key;
            this.configuration = configuration;
        }

        public string Login(string userName, string password)
        {
            var user = new UserLoginDto() { Login = configuration.GetSection("AppSettings:Login").Value, Senha = configuration.GetSection("AppSettings:Senha").Value };

            if (!(user.Login == userName && user.Senha == password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = key;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, userName)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
