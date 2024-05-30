using System; 
using System.Collections.Generic;

namespace library_app
{
    internal class Library
    {
        private LinkedList<Book> Booklist; 
        public Library()
        {
            
            Booklist = new LinkedList<Book>(); 
        }

        public void addBook(Book book)
        {
            Booklist.AddLast(book);
        }

        public LinkedList<Book> searchByTitle(string titleName)
        {
           LinkedList<Book> searchedBookList = new LinkedList<Book>();

            foreach (Book book in Booklist)
            {
                if(book.Title.Contains(titleName.ToUpper()))
                {
                    searchedBookList.AddLast(book);
                }
            }

            return searchedBookList;
        }




        public LinkedList<Book> searchByAuthor(string authorName)
        {
            LinkedList<Book> searchedBookList = new LinkedList<Book>();

            foreach (Book book in Booklist)
            {
                if (book.Author.Contains(authorName))
                {
                    searchedBookList.AddLast(book);
                }
            }

            return searchedBookList;
        }

        public LinkedList<Book> searchByBooknAuthor(string titleName, string authorName)
        {
            LinkedList<Book> searchedBookList = new LinkedList<Book>();

            foreach (Book book in Booklist)
            {
                if (book.Title.Contains(titleName.ToUpper()) || book.Author.Contains(authorName) )
                {
                    searchedBookList.AddLast(book);
                }
            }

            return searchedBookList;

        }




        public LinkedList<Book> displayAllBooks() 
        {
            return new LinkedList<Book>(Booklist); 
        }
    }
}
