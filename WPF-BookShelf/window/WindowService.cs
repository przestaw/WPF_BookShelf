﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace WPF_BookShelf
{
    public class WindowService : IWindowService
    {
        public void Show(IViewModel viewModel)
        {
            Window window = new Window();
            window.SizeToContent = SizeToContent.WidthAndHeight;
            window.Content = viewModel;
            viewModel.Close = window.Close;
            window.Show();
        }

        public void ShowDialog(IViewModel viewModel)
        {
            Window window = new Window();
            window.SizeToContent = SizeToContent.WidthAndHeight;
            window.Content = viewModel;
            viewModel.Close = window.Close;
            window.ShowDialog();
        }
    }
}
