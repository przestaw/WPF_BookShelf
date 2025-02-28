﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace WPF_BookShelf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IWindowService WindowService { get; } = new WindowService();
        private Model BooksModel { get; } = new Model();
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindowViewModel books1 = new MainWindowViewModel(BooksModel);
            WindowService.Show(books1);
            MainWindowViewModel books2 = new MainWindowViewModel(BooksModel);
            WindowService.Show(books2);
        }
    }
}
