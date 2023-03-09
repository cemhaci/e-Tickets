using e_Tickets.Data;
using e_Tickets.Models;
using e_Tickets.Models.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NETCore.Encrypt.Extensions;
using System.Security.Claims;

namespace e_Tickets.Controllers
{
    public class LoginController : Controller
    {
        AppDbContext db;
        IConfiguration _configuration;
        public LoginController(AppDbContext context,IConfiguration configuration)
        {
            db= context;
            _configuration= configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Login model)
        {
            if(ModelState.IsValid)
            {
                string sifre=_configuration.GetValue<string>("appsettings:sifre");
                sifre=model.Password+sifre;
                string sifremd5=sifre.MD5();
                User user=db.Users.SingleOrDefault(x=>x.UserName.ToLower()==model.UserName.ToLower() && x.Password==sifremd5);
                if (user != null)
                {
                List<Claim> claims=new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier,user.id.ToString()));
                claims.Add(new Claim(ClaimTypes.Name,user.Name));
                claims.Add(new Claim(ClaimTypes.Surname,user.SurName));
                claims.Add(new Claim("Username",user.UserName));
                 
                ClaimsIdentity claimsIdentity=new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity)); 
                return RedirectToAction("Index","Home");
                }
               
                else
                {
                    ModelState.AddModelError("","kullanıcı adı veya şifre hatalı");
                }
            }
            return View(model);
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}
