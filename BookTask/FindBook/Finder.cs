using BookTask.Books;
using System.Collections.Generic;
using System.Linq;

namespace BookTask.FindBook
{
    public class FindBookByISBN : IFinder
    {
        public FindBookByISBN(int isbn, List<Book> books)
        {
            ISBN = isbn;
            Books = books;
        }

        public int ISBN { get; }
        public List<Book> Books { get; }

        public Book FindBook()
        {
            return Books.FirstOrDefault(book => book.ISBN == ISBN);
        }
    }

    public class FindBookByAuthor : IFinder
    {
        public FindBookByAuthor(string author, List<Book> books)
        {
            Author = author;
            Books = books;
        }

        public string Author { get; }
        public List<Book> Books { get; }

        public Book FindBook()
        {
            return Books.FirstOrDefault(book => book.Author == Author);
        }
    }

    public class FindBookByTitle : IFinder
    {
        public FindBookByTitle(string title, List<Book> books)
        {
            Title = title;
            Books = books;
        }

        public string Title { get; }
        public List<Book> Books { get; }

        public Book FindBook()
        {
            return Books.FirstOrDefault(book => book.Title == Title);
        }
    }

    public class FindBookByPublishingHouse : IFinder
    {
        public FindBookByPublishingHouse(string publishingHouse, List<Book> books)
        {
            PublishingHouse = publishingHouse;
            Books = books;
        }

        public string PublishingHouse { get; }
        public List<Book> Books { get; }

        public Book FindBook()
        {
            return Books.FirstOrDefault(book => book.PublishingHouse == PublishingHouse);
        }
    }

    public class FindBookByTheYearOfPublishing : IFinder
    {
        public FindBookByTheYearOfPublishing(int theYearOfPublishing, List<Book> books)
        {
            TheYearOfPublishing = theYearOfPublishing;
            Books = books;
        }

        public int TheYearOfPublishing { get; }
        public List<Book> Books { get; }

        public Book FindBook()
        {
            return Books.FirstOrDefault(book => book.TheYearOfPublishing == TheYearOfPublishing);
        }
    }

    public class FindBookByNumbersOfPage : IFinder
    {
        public FindBookByNumbersOfPage(int numbersOfPage, List<Book> books)
        {
            NumbersOfPage = numbersOfPage;
            Books = books;
        }

        public int NumbersOfPage { get; }
        public List<Book> Books { get; }

        public Book FindBook()
        {
            return Books.FirstOrDefault(book => book.NumbersOfPage == NumbersOfPage);
        }
    }

    public class FindBookByPrice : IFinder
    {
        public FindBookByPrice(int price, List<Book> books)
        {
            Price = price;
            Books = books;
        }

        public int Price { get; }
        public List<Book> Books { get; }

        public Book FindBook()
        {
            return Books.FirstOrDefault(book => book.Price == Price);
        }
    }
}
