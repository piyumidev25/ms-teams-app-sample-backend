using Libraries.DBClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;
using Newtonsoft.Json;
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TestWebAppToShowTeams.Helpers;

namespace TestWebAppToShowTeams.Controllers
{
    public class AuthController : Controller
    {
        private static IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            try
            {
                var url = new AuthHelper(_configuration).GetAuthUrl();

                return Redirect(url);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IActionResult> CallbackAsync(string code)
        {
            try
            {
                var token = await new AuthHelper(_configuration).GetMSTokenAsync(code);
                if (token != null)
                {
                    //save access token in a seesion - valid for 1 minute
                    HttpContext.Session.SetString("MSAuthToken", token.access_token);
                }
                return RedirectToAction("Index", "Home");
            }
            catch (Exception) {
                throw;
            }
        }
    }
}
