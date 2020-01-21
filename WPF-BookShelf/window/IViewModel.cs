using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPF_BookShelf
{ 
    public interface IViewModel
    {
        Action Close { get; set; }
    }
}
