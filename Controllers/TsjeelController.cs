using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Universities2.Models;

namespace Universities2.Controllers
{
    public class TsjeelController : Controller
    {
        public IActionResult LogInView()
        {
            return View();
        }
        
        /*  public IActionResult ()
          {
              return View();
          } */
        public async Task<IActionResult> DoLogin(string the_email, string the_password)
        {  
            ///امين المكتبة Admin@elahlya.net (123456)
            //check... signin move next  ///// compare with configs const values
            if (the_email == Configs.admin_email && the_password == Configs.admin_password)
            {
                //عقد اتفاقية تسجيل الدخول.... ختم وتصريح وتحديد نوعية المستخدم
                /////البداية

                var claims = new List<Claim>
                        {
                        new Claim(ClaimTypes.Name, the_email),
                        new Claim(ClaimTypes.Role,"Admin")
                        };
                var userIdentity = new ClaimsIdentity(claims, "SecureLogin");
                var userPrincipal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                userPrincipal,
                new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(5),
                    IsPersistent = false,
                    AllowRefresh = false
                });
                /////
                return RedirectToAction("AdminView1", "Admin");

                ////النهاية
            }
            else
            {
                //اذا مش امين المكتبة.... احتمال انه طالب
                //عشان هيك بدنا نفحص تفاصيله في الداتابيس
                //واحنا كتبنا عملية جاهزة الي بتتلقى ايميل وباسوورد وبترجع الكائن -الطالب اذا موجود واذا لع بترجع نل
                //واسمها TryLogin
                ClassUser2 st1 = ClassUser2.TryLogin(the_email, the_password);
                if (st1 != null) ///الطالب موجود... عبي تفاصيه ووقعه الاوراق واختمله وخذه على منطقته الخاصة- حسابه الخاص
                {
                    ///signin as student
                    //عقد اتفاقية تسجيل الدخول.... ختم وتصريح وتحديد نوعية المستخدم
                    /////البداية

                    var claims = new List<Claim>
                        {
                        new Claim(ClaimTypes.Name, st1.UserID),
                        new Claim(ClaimTypes.Role,"User")
                        };
                    var userIdentity = new ClaimsIdentity(claims, "SecureLogin");
                    var userPrincipal = new ClaimsPrincipal(userIdentity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    userPrincipal,
                    new AuthenticationProperties
                    {
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(30),
                        IsPersistent = false,
                        AllowRefresh = false
                    });
                    /////
                    return RedirectToAction("UserProfileMainView", "UserProfile");
                    ////
                }
                ViewData["msg"] = "User email Or Password are Incorrect";
                return View("LoginView");
            }
            
            return View();
        }
        public async Task<IActionResult> LogOutView()
        {
            await HttpContext.SignOutAsync();
            return View();
        }
       /* public async Task<IActionResult> LogOutViewAsync()
        {
            await HttpContext.SignOutAsync();
            return View();
        } */
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult NoWayView()
        {
            return View();
        }
    }
}
