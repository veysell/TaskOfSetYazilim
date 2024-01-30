using Business.JWT;
using DataAccess.Entities;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using TaskOfSetYazilim.Models;

namespace TaskOfSetYazilim.Controllers.Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly TokenOptions _tokenOptions;
        public LoginController(IUnitOfWork unitOfWork,IConfiguration configuration)
        {
            _unitOfWork=unitOfWork;
            _configuration=configuration;
            _tokenOptions=configuration.GetSection("TokenOptions").Get<TokenOptions>();

        }
        


        [HttpPost("CreateToken")]
        public TokenModel CreateToken(LoginModel model)
        {
            if (model!=null)
            {
                var user = _unitOfWork.User.Get(x => x.UserName == model.UserName && x.Password==model.Password);
                if (user!=null)
                {
                    var token = GetToken(user);
                    return new TokenModel { IsSuccess = true, Token = token ,Code=HttpStatusCode.OK};
                }
                else
                {
                    return new TokenModel { Message="Kullanıcı bulunamadı.",Code=HttpStatusCode.NotFound};
                }
            }
            return new TokenModel { Message="Giriş Bilgileriniz Eksik.",Code=HttpStatusCode.Unauthorized};
        }

        protected string GetToken(User user)
        {
            var claims = new[]
            {
               new Claim(JwtRegisteredClaimNames.Sub,_tokenOptions.Subject),
               new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
               new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
               new Claim("DisplayName",user.Name)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.Key));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _tokenOptions.Issuer,
               _tokenOptions.Audience,
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
