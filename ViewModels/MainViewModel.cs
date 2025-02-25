using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyBook2.Data;
using MyBook2.Models;

namespace MyBook2.ViewModels;

public partial class MainViewModel: ObservableObject
{
    private readonly IBookRepository _bookRepository;
    [ObservableProperty]
    private ObservableCollection<Book> _books;
    [ObservableProperty]
    private Book _selectedBook;
    [ObservableProperty]
    private string _newTitle;
    [ObservableProperty]
    private string _newAuthor;

    public MainViewModel(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository; 
         _=LoadBookAsync();
    }
    
    private async Task LoadBookAsync()
    {
        var books = await _bookRepository.GetAllBooksAsync();
        Books = new ObservableCollection<Book>(books);
    }
    [RelayCommand]
    private async Task AddBookAsync()
    {
       if(string.IsNullOrWhiteSpace(NewTitle)||string.IsNullOrWhiteSpace(NewAuthor)) return;
       try
       {
           var book = new Book
           {
               Title = NewTitle,
               Author = NewAuthor
           };
           await _bookRepository.AddBookAsync(book);
           Books.Add(book);
           await LoadBookAsync();
           NewTitle = string.Empty;
           NewAuthor = string.Empty;
       }
       catch (Exception e)
       {
           MessageBox.Show(e.Message);
       }
    }
    [RelayCommand]
    private async Task DeleteBookAsync()
    {
        if (MessageBox.Show($"确认删除《{SelectedBook.Title}》？", "确认", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        {
            await _bookRepository.DeleteBookAsync(SelectedBook.Id);
            Books.Remove(SelectedBook);
            await LoadBookAsync();
        }
    }
    [RelayCommand]
    private async Task UpdateBookAsync()
    {
        if (SelectedBook == null|| string.IsNullOrWhiteSpace(NewTitle)|| string.IsNullOrWhiteSpace(NewAuthor)) return;
        
            SelectedBook.Title = NewTitle;
            SelectedBook.Author = NewAuthor;
            await _bookRepository.UpdateBookAsync(SelectedBook);
            await LoadBookAsync();
            NewTitle = string.Empty;
            NewAuthor = string.Empty;
        
    }
}