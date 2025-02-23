using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyBooksManager.DataAccess;
using MyBooksManager.Models;

namespace MyBooksManager.ViewModels;

public partial class MainViewModel:ObservableObject
{
    private readonly IBookRepository _repository;
    [ObservableProperty] private string _newTitle;
    [ObservableProperty] private string _newAuthor;
    [ObservableProperty] 
    private ObservableCollection<Book> _books = new();

    //[ObservableProperty] private Book _selectedBook;
    public MainViewModel(IBookRepository repository)
    {
        _repository = repository;
         _=LoadBooksAsync();
    }

    private async Task LoadBooksAsync()
    {
       
        var books = await _repository.GetAllAsync();
        Books = new ObservableCollection<Book>(books);
    }

    [RelayCommand]
    private async Task AddBookAsync()
    {
        if(string.IsNullOrWhiteSpace(NewTitle)||string.IsNullOrWhiteSpace(NewAuthor)) return;
        try
        {
            var newBook = new Book
            {
                Title = NewTitle.Trim(),
                Author = NewAuthor.Trim()
            };
            if(string.IsNullOrWhiteSpace(NewTitle)||string.IsNullOrWhiteSpace(NewAuthor)) return;
            await _repository.AddAsync(newBook);
            await LoadBooksAsync();
            NewTitle = string.Empty;
            NewAuthor = string.Empty;
        }
        catch (Exception e)
        {
            MessageBox.Show($"添加失败:{e.Message}");
        }
    }
    

    [RelayCommand]
    private async Task DeleteBookAsync(Book? book)
    {
        if (book==null) return;
        try
        {
            if (MessageBox.Show($"确认删除<{book.Title}>?","删除确认",MessageBoxButton.YesNo)==MessageBoxResult.Yes)
            {
                await _repository.DeleteAsync(book.Id);
                await LoadBooksAsync();
            }
        }
        catch (Exception e)
        {
            MessageBox.Show($"删除失败:{e.Message}");
        }
    }
    [RelayCommand]
    private async Task UpdateBookAsync(Book? book)
    {
        if (book==null||string.IsNullOrWhiteSpace(NewTitle)||string.IsNullOrWhiteSpace(NewAuthor)) return;
        try
        {
            if (MessageBox.Show($"确认更新<{book.Title}>?","更新确认",MessageBoxButton.YesNo)==MessageBoxResult.Yes)
            {
                var updateBook = new Book
                {
                    Id = book.Id,//保持Id不变
                    Title = NewTitle.Trim(),//使用输入框的新标题
                    Author = NewAuthor.Trim()
                };
                
                await _repository.UpdateAsync(updateBook);
                //更新本地集合,触发UI刷新
                var index = Books.IndexOf(book);//查找旧书籍的索引
                if (index>0)
                {
                    Books.RemoveAt(index);//移除旧书籍
                    Books.Insert(index,updateBook);//插入新书籍
                }
            
                NewTitle = string.Empty;
                NewAuthor = string.Empty; 
            }
        }
        catch (Exception e)
        {
            MessageBox.Show($"修改失败:{e.Message}");
        }
    }
}