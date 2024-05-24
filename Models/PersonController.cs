using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PersonController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddPerson(string name, string description)
        {
            if (ModelState.IsValid)
            {
                var person = new Person { Name = name, Description = description };
                _context.Persons.Add(person);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View("Error");
        }
    }
}
