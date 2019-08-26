using BookTask.FindBook;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookTask.Books
{
    class BookListService
    {
        List<Book> books = new List<Book>();
        BookListStorage bookListStorage = new BookListStorage();

        /// <summary>
        /// Adds a book.
        /// </summary>
        /// <param name="book"></param>
        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException();
            if (IsContains(book))
                throw new InvalidOperationException();

            books.Add(book);
        }

        /// <summary>
        /// Checks if the list contains this book.
        /// </summary>
        /// <param name="book"></param>
        /// <returns>true/false</returns>
        private bool IsContains(Book book)
        {
            foreach (var item in books)
            {
                if (book.Equals(item))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Removes a book.
        /// </summary>
        /// <param name="book"></param>
        public void RemoveBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException();
            if (!IsContains(book))
                throw new InvalidOperationException();

            books.Remove(book);
        }

        /// <summary>
        /// Finds a book by tag.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>Book</returns>
        public Book FindBookByTag(IFinder parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException();

            return parameter.FindBook();
        }

        public List<Book> GetBooks(string path)
        {
            return bookListStorage.GetBookList(path);
        }

        /// <summary>
        /// Saves books to the file system.
        /// </summary>
        /// <param name="path"></param>
        public void Save(string path)
        {
            bookListStorage.SaveBooks(path, books);
        }

        /// <summary>
        /// Sorts books.
        /// </summary>
        /// <param name="comparer"></param>
        public void Sort(IComparer<Book> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException();
            books.Sort(comparer);
        }
    }
}
