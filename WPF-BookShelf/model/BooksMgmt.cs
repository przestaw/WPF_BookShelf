using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace WPF_BookShelf
{
    public interface BooksMgmt
    {
        void AddBook(string title, string author, long isbn, DateTime published, Category category);
        void AddBook(Book book);
        void AddBook();
        void DeleteBook(Book book);
        ObservableCollection<Book> GetBooks();
        void NextCategory(Book book);
    }
}
