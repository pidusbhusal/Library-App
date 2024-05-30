using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace library_app
{
    public class Book
    {
        private string title, author, isbn;

        public string Title { get { return title; } set { title = value; } }
        public string Author { get { return author; } set { author = value; } }
        public string ISBN { get { return isbn; } set { isbn = value; } }


        public Book(string Title, string Author, string ISBN) {
            this.Title = Title;
            this.Author = Author;
            this.ISBN = ISBN;
        }   
        public Book() {

            MessageBox.Show("Invalid Input");
        
        }   
      

        public string getTittle() {  return Title; }
        public string getAuthor() { return Author; }
        public string getISBN() {  return ISBN; }
    }
}
