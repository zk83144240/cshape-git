using MyBook2.Models;

namespace MyBook2.Data;

public interface IBookRepository
{
     Task<List<Book>> GetAllBooksAsync();
     Task AddBookAsync(Book book);
     Task DeleteBookAsync(int id);
     Task UpdateBookAsync(Book book);
}