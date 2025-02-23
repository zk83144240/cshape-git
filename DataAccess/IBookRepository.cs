using MyBooksManager.Models;

namespace MyBooksManager.DataAccess;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllAsync();
    Task AddAsync(Book book);
    Task UpdateAsync(Book book);
    Task DeleteAsync(int id);
}