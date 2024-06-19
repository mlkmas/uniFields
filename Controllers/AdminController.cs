using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Universities2.Models;

namespace Universities2.Controllers
{
    public class AdminController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Indev24()
        {///students=Univs
            //////////////////////////؟؟
            ViewData["Univs"] = ClassUniv2.Search(null);
            return View("EditUnivTable");
        }
        /* public IActionResult EditUnivTable()
         {
             return View();
         } */
        /*     public IActionResult AdminView1()
             {
                 return View();
             }
        */
        [Authorize(Roles = "Admin")]
        public IActionResult AdminView1()
        {
            return View();
        }
        public IActionResult F11(ClassUniv2 u2)

        {
            //************************************************
            //List<ClassUniv2> unv = ClassUniv2.Search(null);
            // unv.AddToDB(u2);
           bool done= ClassUniv2.AddToDB(u2);


            return View("AdminView1");
        }
        public IActionResult AddNewUniv()
        {
            return View();
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

           /// ViewData["students"] = ClassUniv2.Search(null);
            return View("EditUnivTable");
        }

    }
  /*  public IActionResult UnivAddF1(ClassUniv2 st)
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
    } */
}
