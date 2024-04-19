using BooksSearcher.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace BooksSearcher.Frames.MainViewFrames {
    /// <summary>
    /// Логика взаимодействия для SearchBooksFrame.xaml
    /// </summary>
    public partial class SearchBooksFrame : Page {
        public SearchBooksFrame() {
            InitializeComponent();
        }
        public SearchBooksFrame(ObservableCollection<Book> books) {
            InitializeComponent();
            booksListBox.ItemsSource = books;
        }

        private void booksListBox_SelectionChanged(object sender,SelectionChangedEventArgs e) {
            if(booksListBox.SelectedItem != null) {
                var book = booksListBox.SelectedItem as Book;
                if(book == null) return;
                Clipboard.SetText(book.URL);
                MessageBox.Show("Ссылка на книгу скопирована в буфер обмена");
            }
        }
    }
}
