using GrivenceCellForCollage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.Data;

namespace GrivenceCellForCollage.Controllers
{
    public class CollageController : Controller
    {

        public readonly CollageDbContext? _context;
        public CollageController(CollageDbContext dbContext)
        {
            _context = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            var departments = _context.Departments.ToList();
            ViewBag.Dept = new SelectList(departments, "BranchId", "BranchName");
            var branches = _context.Branches.ToList();
            ViewBag.Branch = new SelectList(branches, "DepartmentId", "DepartmentName");
            return View();

        }
        [HttpGet]
        public IActionResult Complaint()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Complaint(CompaintBox Cb)
        {
            _context.Complaints.Add(Cb);
            var i = _context.SaveChanges();
            if (i == 1)
            {
                return RedirectToAction("Student", "Collage");
            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Register register)
        {
           
            _context.Registers.Add(register);
           var i= _context.SaveChanges();
            
            return View();
          
        }
        [HttpGet]

        public IActionResult LogIn()
        {
            var departments = _context.Departments.ToList();
            ViewBag.Dept = new SelectList(departments, "DepartmentId", "DepartmentName");

            return View();
        }
        [HttpPost]
        public IActionResult LogIn(Register register)
        {


            var user = _context.Registers.FirstOrDefault(a => a.Id == register.Id && a.Password == register.Password);
            if (user != null)
            {
                if (user.DepartmentId == 1001)
                {
                    HttpContext.Session.SetInt32("Id", register.Id);
                   return RedirectToAction("Admin", "Collage");
                }
                else if (user.DepartmentId == 1002)
                {
                    HttpContext.Session.SetInt32("Id", register.Id);
                    return RedirectToAction("Student", "Collage");
                }
                else if (user.DepartmentId == 1003)
                {
                    HttpContext.Session.SetInt32("Id", register.Id);
                    return RedirectToAction("HOD", "Collage");
                }


            }
            else
            {
                ViewBag.Result = "LogIn Failure";
            }
            return View(register);
        }
        [HttpGet]
        public IActionResult Admin()
        {
            var data = _context.Complaints.ToList();
            var obj = data.Select(d => new CompaintBox
            {
                ComplaintId = d.ComplaintId,
                Description = d.Description,
                Id = d.Id,
                Time = d.Time,
                status = d.status,

            }).ToList();
            ViewBag.Result = obj;
            return View(obj);
        }
        [HttpPost]
        public IActionResult Admin(int id)
        {
            var update = _context.Complaints.FirstOrDefault(s => s.ComplaintId == id);
            if (update != null)
            {
                update.status = "solved";
                _context.SaveChanges();
            }
            
            return RedirectToAction("Admin","Collage");
        }
       
        [HttpGet]
        public IActionResult Student()
        {
          var data=  _context.Complaints.ToList();
            var obj = data.Select(d => new CompaintBox
            {
                ComplaintId = d.ComplaintId,
                Description = d.Description,
                Id = d.Id,
                Time = d.Time,
                status = d.status,

            }).ToList() ;  
            return View(obj);
        }
        [HttpGet]
        public IActionResult HOD()
        {
            var data = _context.Complaints.ToList();
            var obj = data.Select(d => new CompaintBox
            {
                ComplaintId = d.ComplaintId,
                Description = d.Description,
                Id = d.Id,
                Time = d.Time,
                status = d.status,

            }).ToList();
            ViewBag.Result = obj;
            return View(obj);
        }
        [HttpPost]
        public IActionResult HOD(int id)
        {
            var update = _context.Complaints.FirstOrDefault(s => s.ComplaintId == id);
            if (update != null)
            {
                update.status = "solved";
                _context.SaveChanges();
            }

            return RedirectToAction("HOD", "Collage");
        }
            [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Users user)
        {
            try
            {
                _context.Users.Add(user);
                var i = _context.SaveChanges();
                if (i == 1)
                {
                    ViewBag.Result = "Thanks for Register";
                }

            }
            catch (Exception ex)
            {
                ViewBag.Result = "Id Is Alredy Exist ";
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Users user)
        {
            var users = _context.Users.Find(user.Id);
            if (users != null)
            {
                _context.Users.Remove(users);
                 var i=  _context.SaveChanges();

                if (i == 1)
                {
                    ViewBag.Result = "Record Deleted  ";
                }
                else
                {
                    ViewBag.Result = "Record Not Found  ";
                }
            }

            return View();
        }


    }
}