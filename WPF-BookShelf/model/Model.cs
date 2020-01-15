using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace WPF_BookShelf
{
    class Model : BooksMgmt
    {
        private ObservableCollection<Book> books = new ObservableCollection<Book>();
        private long minIndex = -1;

        public void AddBook(string title, string author, long isbn, DateTime published, Category category)
        {
            Book newBook = new Book(title, author, isbn, published, category);
            if (books.IndexOf(newBook) < 0)
                books.Add(newBook);
        }
        public void AddBook(Book book)
        {
            if (books.IndexOf(book) < 0)
                books.Add(book);
        }
        public void AddBook()
        {
            AddBook("title", "author", minIndex--, DateTime.Today, Category.NotRecognized);
        }

        public void DeleteBook(Book book)
        {
            books.Remove(book);
        }

        public ObservableCollection<Book> GetBooks()
        {
            return books;
        }

        public void NextCategory(Book book)
        {
            int index = books.IndexOf(book);
            if (index >= 0)
                books[index].NextCategory();
        }
    }
}
