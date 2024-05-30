using System.Diagnostics.Eventing.Reader;
using System.Security.Cryptography.X509Certificates;
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

namespace library_app
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


       

        Library lib1 = new Library();
         
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            /// get details
           
            string bookName = txtBookName.Text.Trim();
            string authorName = txtAuthorName.Text.Trim();  
            string isbn = txtISBN.Text.Trim();
            double numisbn;

            // checking if the isbn number is number of not



            txtBookName.BorderBrush = Brushes.Gray;
            txtAuthorName.BorderBrush = Brushes.Gray;
            txtISBN.BorderBrush = Brushes.Gray;
            txtError.Text = "";


            if (string.IsNullOrEmpty(bookName) )
            {
                txtError.Text = "Book Name canoot be empty";
                txtBookName.BorderBrush = Brushes.Red;
                return;
            } else if(string.IsNullOrEmpty(authorName) ) {
                txtError.Text = "Author Name canot be empty";
                txtAuthorName.BorderBrush = Brushes.Red;
                return;
            } else if(string.IsNullOrEmpty(isbn) )
            {
                txtError.Text = "ISBN Number canot be empty";
                txtISBN.BorderBrush = Brushes.Red;
                return;
            } else if (isbn.Length < 13){
                txtError.Text = "ISBN should be of 13 number";
                txtISBN.BorderBrush = Brushes.Red;
                return;

            } else if (!double.TryParse(isbn, out numisbn))
            {
                txtError.Text = "ISBN should be numbers only";
                txtISBN.BorderBrush = Brushes.Red;
                return;

            }



            Book book = new Book(txtBookName.Text.ToUpper(),  txtAuthorName.Text, txtISBN.Text );
            lib1.addBook(book);
            showBooks.ItemsSource = new LinkedList<Book>(lib1.displayAllBooks());
            txtBookName.Text = "";
            txtAuthorName.Text = "";
            txtISBN.Text = "";
            
        }

        private void showBooks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAdd_Copy_Click(object sender, RoutedEventArgs e)
        {
           if(string.IsNullOrWhiteSpace(searchByAuthor.Text) && string.IsNullOrEmpty(searchByBook.Text))
            {
                MessageBox.Show("Please enter something to search");
                return;
            }

           if(searchByBook.Text.Trim()=="")
            {
                showBooks.ItemsSource = lib1.searchByAuthor(searchByAuthor.Text);

            } else if(searchByAuthor.Text.Trim() == "")
            {
                showBooks.ItemsSource =lib1.searchByTitle(searchByBook.Text);
            } else
            {
                showBooks.ItemsSource = lib1.searchByBooknAuthor(searchByBook.Text, searchByAuthor.Text);
            }
          

        }

        private void btnDisplayAll_Click(object sender, RoutedEventArgs e)
        {
            showBooks.ItemsSource = new LinkedList<Book>(lib1.displayAllBooks());
        }
    }
}