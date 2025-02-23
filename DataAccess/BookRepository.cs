using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyBooksManager.Models;

namespace MyBooksManager.DataAccess;

public class BookRepository:IBookRepository
{
    private readonly AppDbContext _context;

    public BookRepository(AppDbContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();//自动创建数据库
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task AddAsync(Book book)
    {
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
        
    }

    public async Task UpdateAsync(Book book)
    {
        var editBook = await _context.Books.FindAsync(book.Id);//根据Id查询数据库现有书籍
        if (editBook!=null)   //如果找到对应记录
        {
            editBook.Title = book.Title;//更新标题
            editBook.Author = book.Author;//更新作者
            await _context.SaveChangesAsync();//提交数据库，异步保存
        }

    }

    public async Task DeleteAsync(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book!=null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            
        }
    }
}