using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testNextsol.Models;

namespace testNextsol.Controllers
{
    public class UsersController : Controller
    {
        nxtSolEntities edm = new nxtSolEntities();
        public ActionResult Index()
        {
            return View(edm.Users.ToList());
        }
        public ActionResult CreateUsers()
        {
            ViewBag.departments = new SelectList(edm.Departments, "departmentId", "name");
            return View();
        }
        [HttpPost]
        public ActionResult CreateUsers(User dep)
        {
            ViewBag.departments = new SelectList(edm.Departments, "departmentId", "name");
            if (ModelState.IsValid)
            {
                edm.Users.Add(dep);
                dep.dateTimeEntered = DateTime.Now;
                edm.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult UpdateUsers(int id = 0)
        {
            ViewBag.departments = new SelectList(edm.Departments, "departmentId", "name");
            User std = edm.Users.Single(a => a.UserId == id);

            return View(std);
        }

        [HttpPost]
        public ActionResult UpdateUsers(User dep)
        {
            ViewBag.departments = new SelectList(edm.Departments, "departmentId", "name");
            if (ModelState.IsValid)
            {
                User us = new Models.User();
                us.Address = dep.Address;
                us.Country = dep.Country;
                us.depId = dep.depId;
                us.Desciption = dep.Desciption;
                us.firstName = dep.firstName;
                us.LastName = dep.LastName;
                us.active = dep.active;
                edm.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult DeleteUsers(int id = 0)
        {
             User std = edm.Users.Single(a => a.UserId == id);
            edm.Users.Remove(std);
            edm.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}