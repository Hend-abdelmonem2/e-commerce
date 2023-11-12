using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApplication10.Data;

namespace WebApplication10.Controllers
{
    public class usercontroller : Controller

    {
        private readonly Appdbcontext _context;

        public usercontroller(Appdbcontext context)
        {
            _context = context;
        }
        public async Task<IActionResult> IndexAsync()

        {
            return _context.user != null ?
                          View(await _context.user.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Users'  is null.");
            //return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost, ActionName("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string name, string password)
        {
            SqlConnection con = new SqlConnection("Data Source=HENDFCI2;Initial Catalog=E_commerce;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            string sql;
            sql = "SELECT * FROM Users where Name ='" + name + "' and  Password ='" + password + "' ";
            SqlCommand comm = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader reader = comm.ExecuteReader();

            if (reader.Read())
            {
                string role = (string)reader["role"];
                string id = Convert.ToString((int)reader["UserId"]);
                HttpContext.Session.SetString("Name", name);
                HttpContext.Session.SetString("Role", role);
                HttpContext.Session.SetString("userid", id);
                reader.Close();
                con.Close();
                if (role == "customer")
                    return RedirectToAction("Menu", "FoodItems");

                else
                    return RedirectToAction("Index", "FoodItems");

            }
            else
            {
                ViewData["Message"] = "wrong user name password";
                return View();
            }
        }
    }
}
