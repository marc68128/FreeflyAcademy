using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace FreeflyAcademy.Views.UserControls
{
    /// <summary>
    /// Interaction logic for FolderPicker.xaml
    /// </summary>
    public partial class FolderPicker : UserControl
    {
        private Brush _textBoxInitialForeground;
        private bool _shouldSelectAll;

        public FolderPicker()
        {
            InitializeComponent();
            this.Loaded += (sender, args) =>
            {
                _textBoxInitialForeground = TextBox.Foreground;

                if (string.IsNullOrWhiteSpace(Folder))
                {
                    TextBox.Text = Placeholder;
                    TextBox.Foreground = new SolidColorBrush(Colors.Gray);
                }
                else
                {
                    TextBox.Text = Folder;
                }
            };
        }

        public static readonly DependencyProperty FolderProperty = DependencyProperty.Register("Folder", typeof(string), typeof(FolderPicker));
        public static readonly DependencyProperty PlaceholderProperty = DependencyProperty.Register("Placeholder", typeof(string), typeof(FolderPicker));

        public string Folder
        {
            get => (string)GetValue(FolderProperty);
            set => SetValue(FolderProperty, value);
        }
        public string Placeholder
        {
            get => (string)GetValue(PlaceholderProperty);
            set => SetValue(PlaceholderProperty, value);
        }


        private void OpenFolderPicker(object sender, RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog
            {
                EnsurePathExists = true,
                EnsureFileExists = false,
                IsFolderPicker = true,
                AllowNonFileSystemItems = false,
                DefaultFileName = "Sélectionner un dossier",
                Title = "Sélectionner un dossier"
            };

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                //Folder = dialog.FileName;
                TextBox.Text = dialog.FileName;
                TextBox.Foreground = _textBoxInitialForeground;
            }
        }


        private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox.Foreground = _textBoxInitialForeground;
            Folder = TextBox.Text;
        }

        private void TextBox_OnGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            _shouldSelectAll = true;
        }

        private void TextBox_OnGotMouseCapture(object sender, MouseEventArgs e)
        {
            if (_shouldSelectAll)
            {
                TextBox.SelectAll();
                _shouldSelectAll = false;
            }
        }
    }
}
