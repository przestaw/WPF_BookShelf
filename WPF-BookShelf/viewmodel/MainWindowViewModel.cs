using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Controls;

namespace WPF_BookShelf
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int filter;
        private bool filterBefore;
        private bool filterActive;
        private BooksMgmt model;
        private Book selectedBook;

        public BooksMgmt Model { get { return model; } }

        public AddCommand AddCommand { get; }

        public DeleteCommand DeleteCommand { get; }

        public NextCategoryCommand NextCategoryCommand { get; }
        
        private bool FilterBeforeFunc(object o)
        {
            Book book = o as Book;
            if (book == null)
                return false;
            if (book.Published.Year < Filter)
                return true;
            else
                return false;
        }

        private bool FilterAfterFunc(object o)
        {
            Book book = o as Book;
            if (book == null)
                return false;
            if (book.Published.Year >= Filter)
                return true;
            else
                return false;
        }

        public CollectionViewSource BooksViewSource { get; }

        public ObservableCollection<Book> Books
        {
            get {
                return model.GetBooks();
            }
        }

        public Book SelectedBook
        {
            get { return selectedBook; }
            set
            {
                selectedBook = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedBook"));
            }
        }

        public int Filter {
            get
            {
                return filter;
            }
            set
            {
                filter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BooksViewSource.View"));
            }
        }

        public bool FilterBefore
        {
            get
            {
                return filterBefore;
            }
            set
            {
                filterBefore = value;
                if (FilterActive)
                {
                    if (value)
                        BooksViewSource.View.Filter = FilterBeforeFunc;
                    else
                        BooksViewSource.View.Filter = FilterAfterFunc;
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BooksViewSource.View"));
            }
        }

        public bool FilterActive
        {
            get
            {
                return filterActive;
            }
            set
            {
                filterActive = value;
                if (value)
                {
                    if (FilterBefore)
                        BooksViewSource.View.Filter = FilterBeforeFunc;
                    else
                        BooksViewSource.View.Filter = FilterAfterFunc;
                }
                else
                    BooksViewSource.View.Filter = null;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BooksViewSource.View"));
            }
        }
        
        public MainWindowViewModel()
        {
            model = new Model();
            AddCommand = new AddCommand();
            DeleteCommand = new DeleteCommand();
            NextCategoryCommand = new NextCategoryCommand();
            BooksViewSource = new CollectionViewSource
            {
                Source = model.GetBooks()
            };
        }
    }
}
