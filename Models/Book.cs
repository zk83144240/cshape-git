using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MyBooksManager.Models;


public partial class Book:ObservableObject
{
    
    [ObservableProperty] private int _id;
    
    [ObservableProperty] private string _title;
   
    [ObservableProperty] private string _author;

}  