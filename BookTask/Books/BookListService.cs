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

        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException();
            if (IsContains(book))
                throw new InvalidOperationException();

            books.Add(book);
        }

        private bool IsContains(Book book)
        {
            foreach (var item in books)
            {
                if (book.Equals(item))
                    return true;
            }

            return false;
        }

        public void RemoveBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException();
            if (!IsContains(book))
                throw new InvalidOperationException();

            books.Remove(book);
        }

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

        public void Save(string path)
        {
            bookListStorage.SaveBooks(path, books);
        }

        public void Sort(IComparer<Book> comparer)
        {
            if (comparer == null)
                throw new ArgumentNullException();
            books.Sort(comparer);
        }
    }
}
