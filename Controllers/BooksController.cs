using Microsoft.AspNetCore.Mvc;
using my_webapi_demo.Models;
using my_webapi_demo.Repo;

namespace my_webapi_demo.Controllers
{
    [ApiController]
    [Route("books")]
    public class BooksController: ControllerBase
    {
        private IBook _BookRepo;
        public BooksController() {
            _BookRepo = new BookRepo();

        }
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks(){
            return _BookRepo.GetBooks().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(Guid id){
            var book = _BookRepo.GetBook(id);
            return book;
        }

        [HttpPost]
        public ActionResult CreateBook(Book book) {
            var myBook = new Book();
            myBook.Id = Guid.NewGuid();
            myBook.Title = book.Title;
            myBook.Price = book.Price;
            _BookRepo.CreateBook(myBook);

            return Ok();

        }
    }
}