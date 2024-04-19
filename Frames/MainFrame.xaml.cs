using BooksSearcher.Frames.MainViewFrames;
using BooksSearcher.Model;
using HtmlAgilityPack;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Xml;

namespace BooksSearcher.Frames {
    public partial class MainFrame : Page {
        Model.Usermodel.User user;
        ObservableCollection<Model.Book> books = new ObservableCollection<Model.Book>();
        public MainFrame() {
            InitializeComponent();
        }

        public MainFrame(Model.Usermodel.User user) {
            InitializeComponent();
            this.user = user;
            userNameTextBlock.Text = user.Login;
            mainViewFrame.Content = new SearchBooksFrame();
        }

        private void ExitButton_Click(object sender,RoutedEventArgs e) {
            NavigationService.Navigate(new Autorization.LoginFrame());
        }

        private void toFindBook_Click(object sender,RoutedEventArgs e) {
            mainViewFrame.Content = new SearchBooksFrame(books);
        }

        private void toMyBook_CLick(object sender,RoutedEventArgs e) {
            mainViewFrame.Content = new MyBooksFrame();
        }

        private async void searchBooks_Click(object sender,RoutedEventArgs e) {
            if(mainViewFrame.Content is MyBooksFrame) {
                
            } else if(mainViewFrame.Content is SearchBooksFrame) {
                string htmlPage = await GetHtmlPage(searchTextBox.Text);
                HtmlNode allBooksNode = GetAllBooks(htmlPage);
                GetBook(allBooksNode);
            }
        }

        async Task<string> GetHtmlPage(string inputValue) {
            HttpClient client = new HttpClient();
            string baseurl = "https://flibusta.su/booksearch/";

            baseurl += "?ask=" + inputValue;

            HttpResponseMessage response = await client.GetAsync(baseurl);

            if(!response.IsSuccessStatusCode) return " ";

            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;
        }
        HtmlNode GetAllBooks(string htmlPage) {
            HtmlDocument doc = new HtmlDocument();

            doc.LoadHtml(htmlPage);

            var allbook = doc.DocumentNode.SelectSingleNode("//div[@class='book_list']");

            return allbook;
        }
        void GetBook(HtmlNode allBook) {
            if(allBook == null) return;

            HtmlNodeCollection linkNode = allBook.SelectNodes("//div[@class='cover']/a");

            HtmlNodeCollection authorNode = allBook.SelectNodes(".//span[@class='author']/a"); 

            HtmlNodeCollection bookNode = allBook.SelectNodes(".//div[@class='book_name']/a");
            if(books.Count > 0) books.Clear();
            for(int i = 0; i < linkNode.Count; i++) {
                string url = linkNode[i].GetAttributeValue("href","");
                string author = authorNode[i].InnerHtml;
                string title = bookNode[i].InnerHtml;
                books.Add(new Book(title,author,url));
            }
        }
    }
}
