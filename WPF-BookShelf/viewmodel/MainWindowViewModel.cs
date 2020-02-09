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
    public class MainWindowViewModel : INotifyPropertyChanged, IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int filter;
        private bool filterBefore;
        private bool filterActive;
        private BooksMgmt model;
        private Book selectedBook;

        public BooksMgmt BooksModel { get { return model; } }

        //public AddCommand AddCommand { get; }
        private RelayCommand<object> addCommand;
        public RelayCommand<object> AddCommand => (addCommand = addCommand ?? new RelayCommand<object>(o => BooksModel.AddBook()));

        private RelayCommand<object> deleteCommand;
        public RelayCommand<object> DeleteCommand => (deleteCommand = deleteCommand ?? new RelayCommand<object>(o => BooksModel.DeleteBook(SelectedBook), o => SelectedBook != null));

        private RelayCommand<object> nextCategoryCommand;
        public RelayCommand<object> NextCategoryCommand => (nextCategoryCommand = nextCategoryCommand ?? new RelayCommand<object>(o => BooksModel.NextCategory(SelectedBook), o => SelectedBook != null));
        
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
                NextCategoryCommand.NotifyCanExecuteChanged();
                DeleteCommand.NotifyCanExecuteChanged();
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
                else
                {
                    BooksViewSource.View.Filter = null;
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
                {
                    BooksViewSource.View.Filter = null;
                }
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BooksViewSource.View"));
            }
        }

        public Action Close { get; set; }

        public MainWindowViewModel(BooksMgmt model_arg)
        {
            filterActive = false;
            model = model_arg;
            //AddCommand = new AddCommand();
            //DeleteCommand = new DeleteCommand();
            //NextCategoryCommand = new NextCategoryCommand();
            BooksViewSource = new CollectionViewSource
            {
                Source = model.GetBooks()
            };
        }
    }
}
