using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BooksSearcher.Model {
    public class Book {
		private string title;
		public string Title {
			get { return title; }
			set { title = value; }
		}

		private string author;
		public string Author {
			get { return author; }
			set { author = value; }
		}

		private string url;
		public string URL {
			get { return url; }
			set { url = "https://flibusta.su" + value; }
		}

		public Image Cover;
		public Book(string title = "Неизвестно",string author = "Неизвестно",string url = "Неизвестно") {
			Title = title;
			Author = author;
			URL = url;
		}

		public override string ToString() {
			return $"Название: {title}\nАвтор: {author}\n";
        }
	}
}
