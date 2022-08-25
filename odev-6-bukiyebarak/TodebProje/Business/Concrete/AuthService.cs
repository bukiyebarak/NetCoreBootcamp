﻿using Business.Abstract;
using Business.Configuration.Auth;
using Business.Configuration.Response;
using DAL.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public AccessToken Login(string email, string password)
        {
            var verifyPassword = VerifyPassword(email, password);
            if(verifyPassword.Status)
            {
                #region Token

                var verifypassword = VerifyPassword(email, password);

                var user = _userRepository.Get(x => x.Email == email);

                if (verifypassword.Status)
                {
                    var tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOption>();

                    var expireDate = DateTime.Now.AddMinutes(tokenOptions.AccessTokenExpiration);

                    //claimlere gerekli olan verilmelidir. Şişirilmemesi gerekiyor.
                    var claims = new Claim[]
                    {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.GivenName, user.Name),
                    new Claim(ClaimTypes.Role,user.Role.ToString())
                    };

                    SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey));
                    var jwtToken = new JwtSecurityToken(
                        issuer: tokenOptions.Issuer,
                        audience: tokenOptions.Audience,
                        claims: claims,
                        expires: expireDate,
                        signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
                    );

                    var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
                    #endregion

                    return new AccessToken()
                    {
                        Token = token,
                        ExpireDate = expireDate
                    };

                }
               
            }
            return new AccessToken()
            {

            };
        }

        public CommandResponse VerifyPassword(string email, string password)
        {
            var user = _userRepository.Get(x => x.Email == email);
            var user2 = _userRepository.GetUserWithPassword(email);
            if (HashHelper.VerifyPasswordHash(password, user2.Password.PasswordHash, user2.Password.PasswordSalt))
            {
                return new CommandResponse()
                {
                    Status = true,
                    Messsage = "Şifre Doğru"
                };
            }

            return new CommandResponse()
            {
                Status = false,
                Messsage = "Şifre Hatalı"
            };
        }

    }
}
