using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testNextsol.classes;
using testNextsol.Models;

namespace testNextsol.Controllers
{
    public class HomeController : Controller
    {
        nxtSolEntities edm = new nxtSolEntities();   
        public ActionResult Index()
        {
            //var ss = from c in edm.Users
            //         group c by c.depId into g
            //         select (p => new
            //         {
            //             id = g.Where(a => a.depId == g.Key).Select(a => a.Department.departmentId).FirstOrDefault(),
            //             Name = g.Where(a => a.depId == g.Key).Select(a => a.Department.name).FirstOrDefault(),
            //             desciption = g.Where(a => a.depId == g.Key).Select(a => a.Department.description).FirstOrDefault(),
            //             address = g.Where(a => a.depId == g.Key).Select(a => a.Department.description).FirstOrDefault(),
            //             active = g.Where(a => a.depId == g.Key).Select(a => a.Department.active).FirstOrDefault(),
            //             Sum = g.Sum(oi => oi.depId)
            //         });

            //var result = (from c in edm.Users
            //              group c by new { c.depId } into grp
            //              join d in edm.Departments on grp.Key.depId equals d.departmentId
            //              select new dep {
            //                  id = grp.Key.depId,
            //                  Name = d.name,
            //                  desciption = d.description,
            //                  address = d.Adress,
            //                  count = grp.Count() == 0 ? 0: grp.Count()
            //              })
            //              .ToList();

            var result = (from c in edm.Departments                          
                          join d in edm.Users
                          on c.departmentId equals d.depId into egrp
                          //group c by new { c.departmentId } into grp
                          //from c in grp.DefaultIfEmpty()
                          select new dep
                          {
                              id = c.departmentId,
                              Name = c.name,
                              desciption = c.description,
                              address = c.Adress,
                              count = egrp.Count() == 0 ? 0 : egrp.Count()
                          })
                          .ToList();


            //var result = (from u in edm.Users
            //          group c by new { c.depId } into grp
            //              join d in edm.Departments
            //              on u.depId equals d.departmentId into grp
            //              from d in egrp.DefaultIfEmpty()
            //              select new
            //              {
            //                  id = u.Department.departmentId,
            //                  Name = u.Department.name,
            //                  desciption = u.Department.description,
            //                  address = u.Department.Adress,
            //                  count = grp.Count() == 0 ? 0 : grp.Count()
            //              })
            //              .ToList();



            return View(result);
        }

        public ActionResult CreateDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateDepartment(Department dep)
        {
            if (ModelState.IsValid)
            {
                edm.Departments.Add(dep);
                dep.dateTimeEntered = DateTime.Now;
                edm.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult UpdateDepartment(int id = 0)
        {
            Department std = edm.Departments.Single(a => a.departmentId == id);

            return View(std);
        }

        [HttpPost]
        public ActionResult UpdateDepartment(Department dep)
        {
            if (ModelState.IsValid)
            {
                edm.Departments.Attach(dep);
                edm.Entry(dep).State = EntityState.Modified;
                edm.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult DeleteDepartment(int id = 0)
        {
            Department std = edm.Departments.Single(a => a.departmentId == id);
            edm.Departments.Remove(std);
            return RedirectToAction("Index");
        }
    }
}