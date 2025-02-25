using Microsoft.EntityFrameworkCore;
using MyBook2.Models;

namespace MyBook2.Data;

public class BookRepository: IBookRepository
{
    private readonly AppDbContext _dbContext;
    public BookRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbContext.Database.EnsureCreated();
    }
    public async Task<List<Book>> GetAllBooksAsync()
    {
        return await _dbContext.Books.ToListAsync();
    }

    public async Task AddBookAsync(Book book)
    {
        _dbContext.Books.Add(book);
        await _dbContext.SaveChangesAsync();
        
    }

    public async Task DeleteBookAsync(int id)
    {
        var book = await _dbContext.Books.FindAsync(id);
        _dbContext.Books.Remove(book);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateBookAsync(Book book)
    {
      var bookToUpdate = await _dbContext.Books.FindAsync(book.Id);
      if (bookToUpdate != null)
      {
          bookToUpdate.Title = book.Title;
          bookToUpdate.Author = book.Author;
          await _dbContext.SaveChangesAsync();
      }

       
    }
}