using ASPNETPaginationSortingHW.Models;
using ASPNETPaginationSortingHW.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static ASPNETPaginationSortingHW.ViewModels.AllBooksViewModel;

namespace ASPNETPaginationSortingHW.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> Books(int currentPage = 1, int onPage = 12, OrderByEnum orderBy = OrderByEnum.Id)
        {
            return View(await _bookService.GetAll(currentPage, onPage, orderBy));
        }

        [HttpGet]
        public async Task<IActionResult> Book(int id)
        {
            return View(await _bookService.GetById(id));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookService.Delete(id);
            return RedirectToAction("Books");
        }

        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(Book model)
        {
            int bookId = await _bookService.Add(model);
            return RedirectToAction("Book", new { id = bookId });
        }

        [HttpGet]
        public async Task<IActionResult> EditBook(int id)
        {
            var book = await _bookService.GetById(id);
            if (book == null)
            {
                return RedirectToAction("Books");
            }
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> EditBook(Book model)
        {
            int bookId = await _bookService.Edit(model);
            return RedirectToAction("Book", new { id = bookId });
        }
    }
}
