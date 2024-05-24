using EmployeeManagement.Models; // Import your Person model
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class PersonController : Controller
{
    private readonly ApplicationDbContext _context;

    public PersonController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Update(int id, string name, string description)
    {
        var person = await _context.Persons.FindAsync(id);
        if (person == null)
        {
            return NotFound(); // Return 404 if person with the given ID is not found
        }

        // Update person data
        person.Name = name;
        person.Description = description;

        await _context.SaveChangesAsync(); // Save changes to database asynchronously

        return RedirectToAction("Index"); // Redirect to index or another page after update
    }
    [HttpPost]
public async Task<IActionResult> Delete(int id)
{
    var person = await _context.Persons.FindAsync(id);
    if (person == null)
    {
        return NotFound(); // Return 404 if person with the given ID is not found
    }

    _context.Persons.Remove(person); // Mark person for deletion
    await _context.SaveChangesAsync(); // Save changes to database asynchronously

    return RedirectToAction("Index"); // Redirect to index or another page after deletion
}
}
