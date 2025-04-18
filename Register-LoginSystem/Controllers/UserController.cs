using Microsoft.AspNetCore.Mvc;
using Register_LoginSystem.Data;
using Register_LoginSystem.Models;

namespace Register_LoginSystem.Controllers
{
    public class UserController : Controller
    {
        private myDbContext _db;
        public UserController(myDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            _db.tbl_users.Add(user);
            _db.SaveChanges();
            return RedirectToAction("Login");

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string uemail,string upass)
        {
       
            var row = _db.tbl_users.FirstOrDefault(u => u.Email==uemail);
            if(row != null && row.Password ==upass)
               
            {
                HttpContext.Session.SetString("name", row.Name);
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.msg = "Invalid Email or Password";
                return View();
            }


              
        }
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("name") != null)
            {
                ViewBag.name = HttpContext.Session.GetString("name");
            }
            return View();
        }
        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("name") != null)
            {
                 HttpContext.Session.Remove("name");
                return RedirectToAction("Login");
            }
            return View();
          
        }
    }
}
