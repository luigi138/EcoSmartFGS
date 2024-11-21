using EcoSmart.Data;
using EcoSmart.DTO;
using EcoSmart.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EcoSmart.Services
{
    public class AlertService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AlertService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        public IEnumerable<AlertDTO> GetAllAlerts()
        {
            return _context.Alerts.Select(alert => new AlertDTO
            {
                Id = alert.Id,
                Message = alert.Message,
                AlertType = alert.Type.ToString(),
                IsRead = alert.IsRead,
                CreatedAt = alert.CreatedAt,
                UserId = alert.UserId
            }).ToList();
        }

        public AlertDTO? GetAlertById(int id)
        {
            var alert = _context.Alerts.Find(id);
            if (alert == null) return null;

            return new AlertDTO
            {
                Id = alert.Id,
                Message = alert.Message,
                AlertType = alert.Type.ToString(),
                IsRead = alert.IsRead,
                CreatedAt = alert.CreatedAt,
                UserId = alert.UserId
            };
        }

        public void CreateAlert(AlertDTO alertDTO)
        {
            var alert = new Alert
            {
                Message = alertDTO.Message,
                Type = Enum.Parse<AlertType>(alertDTO.AlertType),
                IsRead = alertDTO.IsRead,
                CreatedAt = alertDTO.CreatedAt,
                UserId = alertDTO.UserId
            };

            _context.Alerts.Add(alert);
            _context.SaveChanges();
        }

        public void MarkAsRead(int id)
        {
            var alert = _context.Alerts.Find(id);
            if (alert != null)
            {
                alert.IsRead = 1;
                _context.SaveChanges();
            }
        }

        public void DeleteAlert(int id)
        {
            var alert = _context.Alerts.Find(id);
            if (alert != null)
            {
                _context.Alerts.Remove(alert);
                _context.SaveChanges();
            }
        }
        public string GenerateToken(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null) throw new ArgumentException("usuario nao existi");

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(_configuration["Jwt:ExpireMinutes"])),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
