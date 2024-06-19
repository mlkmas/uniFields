using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Universities2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace Universities2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
            
        {
            return RedirectToAction("LogInView", "Tsjeel");
            //return View();
        }
        public IActionResult Univuser()
        {
            return RedirectToAction("AddNewUserView", "User");
           
        }
        public IActionResult Subss()
        {
            return RedirectToAction("SubTable", "Subject");

        }
        public IActionResult AddNew()
        {
            return RedirectToAction("AddNewUniv", "Admin");

        }
        public IActionResult UnivMain()
        {
            return View();
        }
        public IActionResult Results()
        {
            return View();
        }
        /*  public IActionResult QVi5ew()
          {
              return View();
          } */
        public IActionResult F2(string q)
        {///students=Univs
            //////////////////////////؟؟
            ViewData["Univs"] = ClassUniv2.Search(q);
            return View("UnivTable");
        }

        /* public IActionResult F1(ClassUniv2 st)
        {
            
  
            bool done = ClassUniv2.AddToDB(st);   

            // return View("ShowTheNewStudentView",st);  ///model

            if (done == true)
            {
                ViewData["Univs"] = ClassUniv2.Search(null);
                return View("UnivTable");
            }
            else
            {
               // ViewData["msg"] = "Errror 2918#";
                return View("AddUniversity");
            }

        } */
        
        public IActionResult Index3()
        {
           
            //****************************************************
            //List<ClassUniv2> unv = ClassUniv2.GetAll();
            //ViewData["unv"] = unv;
            ViewData["Univs"] = ClassUniv2.Search(null);
            return View("UnivTable");
        }
        public IActionResult Univ2(ClassUniv2 unv)
        {
            return View(unv);
        }
        public IActionResult Q3View()
        {
           string UserID = User.Identity.Name;  //*****
            ClassUser2 st = ClassUser2.GetByID(UserID);

          //  ClassUser2 st = ClassUser2.GetByID(UserID);
            return View(st);
        }
        public IActionResult DoUp(ClassUser2 us)
        {
           us=ClassUser2.AddPoints(us);
           return RedirectToAction("Results", "User2", us);
           // return View("UserProfileMainView");
        }
        public IActionResult U1(ClassUniv2 unv)
        {
            return View();
        }
        public IActionResult Index1()
        {
            return View();
        }
        
        public IActionResult F11(ClassUniv2 u2)
        
        {
            //************************************************
            List<ClassUniv2> unv = ClassUniv2.Search(null);
            unv.Add (u2);
           
          
            return View("UnivTable");
        }
        public IActionResult AddUniversity()
        {
            return View();
        }

        public IActionResult UnivTable()
        {
            //**************************************************
            ViewData["Univs"] = ClassUniv2.Search(null);
            return View();
        }
        public IActionResult UnivRan()
        {
            List<ClassUniv2> univerr = ClassUniv2.Ranlist(ClassUniv2 .Getunivers ());
            ViewData["ClassUniv2"] = univerr;
            return View();
        }
        public IActionResult Indev24()
        {///students=Univs
            //////////////////////////؟؟
            ViewData["Univs"] = ClassUniv2.Search(null);
            return View("EditUnivTable");
        }
        public IActionResult DeleteUniv(string UnivID)
        {
            bool done = ClassUniv2.DeleteByID(UnivID);
            if (done)
            {
                ViewData["msg"] = "UnivID " + UnivID + " was deleted successfully";
            }
            else
            {
                ViewData["msg"] = "UnivID " + UnivID + " was NOT deleted ";
            }

            ViewData["Univs"] = ClassUniv2.Search(null);
            return View("EditUnivTable");
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
