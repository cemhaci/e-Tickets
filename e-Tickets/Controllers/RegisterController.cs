using AspNetCore;
using e_Tickets.Data;
using e_Tickets.Data.Services;
using e_Tickets.Models;
using e_Tickets.Models.Mail;
using e_Tickets.Models.ViewModel;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using NETCore.Encrypt.Extensions;
using Org.BouncyCastle.Asn1.Pkcs;

namespace e_Tickets.Controllers
{
    public class RegisterController : Controller
    {   AppDbContext db;
        IConfiguration _configuration;
        IEmailSender _email;
        IRepository<Register> _reg;
		public RegisterController(AppDbContext context,IConfiguration configuration,IEmailSender email,IRepository<Register> reg) 
            { 
            db= context;
            _configuration= configuration;
            _email= email;
           _reg= reg;
            }
        
        public IActionResult Index()
        {
          return View();
        }
        [HttpPost]
        public IActionResult Index(Register model)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.Any(x => x.UserName.ToLower() == model.UserName.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.UserName), "böyle bir kullanıcıadı kullanılmaktadır");
                    return View(model);
                }
                if (db.Users.Any(x => x.EMail == model.Email))
                {
                    ModelState.AddModelError(nameof(model.Email), "bu email kullanılmaktadır");
                }
                string sifre = _configuration.GetValue<string>("appsettings:sifre");
                sifre = model.Password + sifre;
                string md5sifre = sifre.MD5();

                User user = new User()
                {
                    UserName = model.UserName,
                    Password = md5sifre,
                    EMail = model.Email,
                    Name = model.Name,
                    SurName = model.Surname,
                    Aktif = true,
                    ProfileImageFile="fg"
                };
                db.Users.Add(user);

                int sonuc = db.SaveChanges();


                List<string> kisi = new List<string>();
                kisi.Add(model.Email);
                if (sonuc == 0)
                {
                    ModelState.AddModelError("", "kayıt yenilenemedi");
                }
                else
                {
                    var correct = _reg.Find(x => x.Email == model.Email);
                    if(correct == null)
                    {
                    string siteUrl = _configuration.GetValue<string>("appsettings:SiteRootUri");
					string activateUrl = $"{siteUrl}/Home/Index/{model.id}";
					
                    Message message = new Message(kisi, "INTERNATIONAL CYBER CRIMES", $"SAYIN KULLANICI;\n Hesabınız aJKLY*42/3N*hj-bF kullanıcısı tarafından ele geçirilmiştir!\n\n Hesabınızı kurtarmak için CEM HACIOSMANOĞLU kullanıcısıyla iletişime geçin. İstenilen verileri gerçekleştirip yönlendirmelere uymanız gerekmektedir !!\n\n ERROR : 404 <a href='{activateUrl}'>tıklayınız</a>");

					_email.SendEmail(message);
                    return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        ModelState.AddModelError(nameof(model.Email), "E-mail zaten kullanılmaktadır. Lütfen başka bir E-mail giriniz.");
                        return View(model);
                    }
                   
                }
            }
            return View(model);
        }

    }
}
