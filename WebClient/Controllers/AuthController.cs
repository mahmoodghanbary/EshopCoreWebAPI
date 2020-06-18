using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebClient.ViewModel;
using System.Net.Http;
using Newtonsoft.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;



namespace WebClient.Controllers
{
    public class AuthController : Controller
    {
        private IHttpClientFactory _clientFactory;
        public AuthController(IHttpClientFactory clientFactory)
        {
           _clientFactory = clientFactory;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            var _client = _clientFactory.CreateClient("webclient");
            var jsonbody = JsonConvert.SerializeObject(login);
            var content = new StringContent(jsonbody, System.Text.Encoding.UTF8, "application/json");
            var response = _client.PostAsync("/Api/Auth", content).Result;
            if (response.IsSuccessStatusCode)
            {
                var token = response.Content.ReadAsAsync<TokenModel>().Result;
                var claims = new List<Claim>() {
                    new Claim(ClaimTypes.NameIdentifier, login.UserName ),
                    new Claim (ClaimTypes.Name,login.UserName),
                    new Claim("AccessToken", token.Token)
                    };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    AllowRefresh = true
                };
                HttpContext.SignInAsync(principal, properties);
                return Redirect("/User");
            }
            else
            {
                ModelState.AddModelError("UserName", "username not valid");
                return View(login);
            }

        }
    }
}