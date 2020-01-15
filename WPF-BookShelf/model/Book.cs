using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace WPF_BookShelf
{
    public class Book : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Title"));
            }
        }
        private string author;
        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Author"));
            }
        }
        private long isbn;
        public long ISBN
        {
            get
            {
                return isbn;
            }
            set
            {
                isbn = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ISBN"));
            }
        }
        private DateTime published;
        public DateTime Published
        {
            get
            {
                return published.Date;
            }
            set
            {
                published = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Published"));
            }
        }
        private Category category;
        public Category Category
        {
            get
            {
                return category;
            }
            set
            {
                category = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Category"));
            }
        }
        
        public Book(string title, string author, long isbn, DateTime published, Category category)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            Published = published;
            Category = category;
        }

        public void NextCategory()
        {
            Category temp = category + 1;
            if (temp == Category.Count)
                Category = 0;
            else
                Category = temp;
        }
    }
}
