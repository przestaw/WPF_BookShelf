using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPF_BookShelf
{
    public interface IWindowService
    {
        void Show(IViewModel viewModel);
        void ShowDialog(IViewModel viewModel);
    }
}
