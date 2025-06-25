﻿using HaircutSite.Domain.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using HaircutSite.Application.Interfaces.Auth;

namespace HaircutSite.Infrastructure.Extensions
{
    public class JwtProvider : IJwtRepository
    {
        private readonly JwtOptions _options;

        public JwtProvider(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }
        public string GenerateToken(User user)
        {
            Claim[] claim = [new("userId", user.Id.ToString())];

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claim,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddHours(_options.ExpirationHours));

            var TokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return TokenValue;
        }
    }
}
