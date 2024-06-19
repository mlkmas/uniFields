using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Universities2.Models;

namespace Universities2.Controllers
{
    public class User2Controller : Controller
    {
        public IActionResult AddNewUserView()
        {
            return View();
        }
        public IActionResult Results(ClassUser2 us)
        {

            
            ClassUser2 st1 = ClassUser2.GetByID(User.Identity.Name);
            return View(us);

        }
        public IActionResult Index()
        {
            return View ();
        }
        //UserAddF1--> F1
        public IActionResult UserAddF1(ClassUser2 st)
        {
            //**********************************************************************

            bool done = ClassUser2.AddToDB(st);

            // return View("ShowTheNewStudentView",st);  ///model

            if (done == true)
            {
              return View("UserMainView");
               // ViewData["Univs"] = ClassUniv2.Search(null);
               // return View("UnivTable");
            }
          
            else
            {
                // ViewData["msg"] = "Errror 2918#";
                return View("AddNewUserView");
            }
            //******************************************************************************************
            return View();
        }

        public IActionResult DeleteUser(string UserID)
        {
            bool done = ClassUser2.DeleteByID(UserID);
            //????????????????????????????????????????????????? if+else
            if (done)
            {
               // ViewData["msg"] = "UserID " + UserID + " was deleted successfully";
            }
            else
            {
               // ViewData["msg"] = "UserID " + UserID + " was NOT deleted ";
            }

            //ViewData["Users"] = ClassUser.SearchUser(null);
           // return View("ViewStudentsInTable");
            return View("AddNewUserView");
        }

        public IActionResult UpdateUserView()
        { ///توقيع العملية غلط لام اقواس فارغة  
           
            string UserID = User.Identity.Name;  //*****
            ClassUser2 st = ClassUser2.GetByID(UserID);

            return View(st);
        }

        //***DoUpdate-->UserUpdateF1

        public IActionResult UserUpdateF1(ClassUser2 st)
        {
           
            bool done = ClassUser2.Update(st);

            if (done)
            {
              // ViewData["msg"] = "student_ID " + st.UserID + " was updated successfully";
            }
            else
            {
               // ViewData["msg"] = "UserID " + st.UserID + " was NOT updated ";
            }

            // ViewData["students"] = Student.Search(null);

            //*******
              return View("UserMainView");
        }
    }
}
