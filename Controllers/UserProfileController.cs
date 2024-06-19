using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Universities2.Models;

namespace Universities2.Controllers
{
    public class UserProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UserProfileMainView()
        { 
           
            
                ClassUser2 st1 = ClassUser2.GetByID(User.Identity.Name);
                return View(st1);
            
        }

    }
   
    
        
        
    
}
