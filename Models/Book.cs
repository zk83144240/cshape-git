using CommunityToolkit.Mvvm.ComponentModel;

namespace MyBook2.Models;

public partial class Book: ObservableObject
{
    [ObservableProperty]
    private int _id;
    [ObservableProperty]
    private string _title;
    [ObservableProperty]
    private string _author;
}