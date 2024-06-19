using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Universities2.Models;

namespace Universities2.Controllers
{
    public class SubjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SubTable()
        {

            //****************************************************
            //List<ClassUniv2> unv = ClassUniv2.GetAll();
            //ViewData["unv"] = unv;
            string UserID = User.Identity.Name;  //*****
            ClassUser2 st = ClassUser2.GetByID(UserID);
           
            ViewData["Subs"] = ClassSubject.Search(st.UserSh);
            return View("SubTable");
        }
    }
}
