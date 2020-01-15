using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace WPF_BookShelf
{
    public class DeleteCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MainWindowViewModel viewModel = (MainWindowViewModel)parameter;
            viewModel.Model.DeleteBook(viewModel.SelectedBook);
        }
    }
}
