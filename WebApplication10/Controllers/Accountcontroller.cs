using Microsoft.AspNetCore.Mvc;
using WebApplication10.Data;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class Accountcontroller : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly Appdbcontext _dbContext;

        public Accountcontroller(Appdbcontext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: /Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        // POST: /Acount/Register
        [HttpPost]

        public IActionResult Register(RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                // Add user to the database
                _dbContext.Accounts.Add(user);
                _dbContext.SaveChanges();

                // Redirect to login page or perform other actions
                return RedirectToAction("Login", "Account");
            }

            // If model state is not valid, return to registration page with error messages
            return View(user);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(user model)
        {

            if (ModelState.IsValid)
            {
                // Authenticate user against your data store
                var user = AuthenticateUser(model.Email, model.Password);

                if (user != null)
                {
                   
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    ModelState.AddModelError("", "Invalid email or password");
                }
            }
            return View(model);
        }
        private RegisterViewModel AuthenticateUser(string email, string password)
        {
            var user = _dbContext.Accounts.FirstOrDefault(u => u.Email == email);

            if (user != null && user.Password == password)
            {
                return user;
            }
            return null;
        }

    }
}

