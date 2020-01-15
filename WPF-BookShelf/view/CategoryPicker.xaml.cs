using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_BookShelf
{
    /// <summary>
    /// Interaction logic for CategoryPicker.xaml
    /// </summary>
    public partial class CategoryPicker : UserControl
    {
        public CategoryPicker()
        {
            InitializeComponent();
        }

        #region TextProperty
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(String), typeof(CategoryPicker),
            new FrameworkPropertyMetadata(string.Empty, OnTextPropertyChanged, OnCoerceTextProperty));

        public string Text
        {
            get { return GetValue(TextProperty).ToString(); }
            set { SetValue(TextProperty, value); }
        }

        private static void OnTextPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            CategoryPicker control = source as CategoryPicker;
            string text = (string)e.NewValue;
            control.IsText = text.Length > 0;
        }

        private static object OnCoerceTextProperty(DependencyObject sender, object data)
        {
            return data;
        }

        #endregion

        #region ImageSourceProperty
        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(CategoryPicker), new FrameworkPropertyMetadata(null));

        public ImageSource ImageSource
        {
            get { return GetValue(ImageSourceProperty) as ImageSource; }
            set { SetValue(ImageSourceProperty, value); }
        }
        #endregion


        #region readonly property
        private static readonly DependencyPropertyKey IsTextPropertyKey = DependencyProperty.RegisterReadOnly("IsText", typeof(bool), typeof(CategoryPicker), new FrameworkPropertyMetadata(false));

        public static readonly DependencyProperty IsTextProperty = IsTextPropertyKey.DependencyProperty;

        public bool IsText
        {
            get { return (bool)GetValue(IsTextProperty); }
            private set { SetValue(IsTextPropertyKey, value); }
        }
        #endregion


        #region clickEvent
        public static readonly RoutedEvent ClickEvent = EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(CategoryPicker));

        public event RoutedEventHandler Click
        {
            add { AddHandler(ClickEvent, value); }
            remove { RemoveHandler(ClickEvent, value); }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(ClickEvent));
        }
        #endregion
    }
}
