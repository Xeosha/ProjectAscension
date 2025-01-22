

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;

namespace AsscensionApp.Infrastructure.JWT
{
    public class JwtOptions
    {
        public string SecretKey { get; set; } = string.Empty;
        public int ExpitesHours {  get; set; }
    }


    public class JwtProvider(IOptions<JwtOptions> options)
    {
        private readonly JwtOptions _options = options.Value;

        public string GenerateToken(Guid userId)
        {
            Claim[] claims = [new("userId", userId.ToString())];

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddHours(_options.ExpitesHours)
                );

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue.ToString();
        }
    }
}
