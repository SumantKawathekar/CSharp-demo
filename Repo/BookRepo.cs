using my_webapi_demo.Models;

namespace my_webapi_demo.Repo
{
    public class BookRepo : IBook
    {
        private List<Book> _Books;

        public BookRepo() {
            _Books = new () { new Book {Id = Guid.NewGuid(), Title = "Book 0", Price = 10}};
        }
        void IBook.CreateBook(Book book)
        {
            _Books.Add(book);
            throw new NotImplementedException();
        }

        void IBook.DeleteBook(Guid id)
        {
            throw new NotImplementedException();
        }

        Book IBook.GetBook(Guid id)
        {   var book = _Books.Where(x=> x.Id == id).SingleOrDefault();
            return book;
            throw new NotImplementedException();
        }

        IEnumerable<Book> IBook.GetBooks()
        {   
            return _Books;
            // throw new NotImplementedException();
        }

        void IBook.UpdateBook(Guid id, Book book)
        {
            throw new NotImplementedException();
        }
    }
}