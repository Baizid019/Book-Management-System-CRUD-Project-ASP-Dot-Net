using BookList.Data;
using BookList.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookList.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context; // This stores the database connection. 

        public BooksController(ApplicationDbContext context)//ASP.NET Core automatically creates an ApplicationDbContext and gives it to the controller.
        {
            _context = context;
        }

        // READ
        public IActionResult Index()
        {
            var books = _context.Books.ToList(); // Fetch all books from the database and store them in a C# list. 
                              // ToList() is a built-in LINQ method that retrieves all the results of a query and returns them as a List<T>.
            return View(books);
        }

        // CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid) // This checks whether the submitted data is valid.
            {
                _context.Books.Add(book); // Marks the new book to be inserted into the database.
                _context.SaveChanges(); // Saves all pending changes to the database.

                return RedirectToAction(nameof(Index));
            }

            return View(book);
        }

        // EDIT
       // Retrieves a book by its ID from the database and displays it in the Edit view, or returns a 404 error if the book is not found.
        public IActionResult Edit(int id)
        {
            var book = _context.Books.Find(id);

            if (book == null)
                return NotFound();

            return View(book);
        }

        [HttpPost] // Receive data submitted from a form.
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Update(book);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(book);
        }

        // DELETE

/* 

 Add(), Find(), Update(), Remove(), and SaveChanges() are Entity Framework Core methods 
 used to perform CRUD operations on the database.

*/

public IActionResult Delete(int id)
{
    var book = _context.Books.Find(id);

    if (book == null)
        return NotFound();

    return View(book);
}

[HttpPost, ActionName("Delete")]
public IActionResult DeleteConfirmed(int id)
{
    var book = _context.Books.Find(id);

    if (book != null)
    {
        _context.Books.Remove(book);
        _context.SaveChanges();
    }

    return RedirectToAction(nameof(Index));
}
}
}