using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace API_Inventaire.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthentificationController : Controller
    {
        private readonly ILogger<AuthentificationController> _logger;

        public AuthentificationController(ILogger<AuthentificationController> logger)
        {

        }

        [HttpPost]
        public IActionResult Login([FromForm][Required] string user, [FromForm][Required] string password)
        {

            if(!this.Authenticate(user, password))
            {
                return Unauthorized("Erreur, le mot de passe et/ou l'utilisateur ne correspondent pas");
            }

            string token = this.GenerateToken(user);

            var obj = new { token };
            return Ok(obj);
}

        [ApiExplorerSettings(IgnoreApi = true)]
        private bool Authenticate(string username, string password)
        {
            bool resultTestLoginUser = false;
            if(username =="admin" && password =="admin")
            {
                resultTestLoginUser=true;
            }
            return resultTestLoginUser;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        private string GenerateToken(string user)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("monSuperSecretmonSuperSecretmonSuperSecretmonSuperSecretmonSuperSecret"));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>() { new Claim("username", user)};

            JwtSecurityToken st = new JwtSecurityToken("3iL", "API Test", claims, DateTime.UtcNow.AddHours(1), DateTime.Now, credentials);
        
            return new JwtSecurityTokenHandler().WriteToken(st);
        }
    }
}
