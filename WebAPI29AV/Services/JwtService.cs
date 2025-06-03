using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebAPI29AV.Services
{
    public class JwtService
    {
        // Inyección de la configuración de la aplicación (appsettings.json)
        private readonly IConfiguration _config;

        // Constructor que recibe la configuración
        public JwtService(IConfiguration config)
        {
            _config = config;
        }

        // Método para generar un token JWT
        public string GenerateToken(string username, string role)
        {
            // 1. Definir los claims (información) que se incluirán en el token
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username), // Nombre de usuario
                new Claim(ClaimTypes.Role, role)      // Rol del usuario
            };

            // 2. Obtener la clave secreta desde la configuración y crear la clave simétrica
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            // 3. Crear las credenciales de firma usando la clave y el algoritmo HMAC SHA256
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // 4. Crear el token JWT con los datos necesarios
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],         // Emisor del token
                audience: _config["Jwt:Audience"],     // Audiencia del token
                claims: claims,                        // Claims definidos arriba
                expires: DateTime.Now.AddHours(1),     // Tiempo de expiración (1 hora)
                signingCredentials: creds               // Credenciales de firma
            );

            // 5. Serializar el token y devolverlo como string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

