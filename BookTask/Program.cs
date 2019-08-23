using BookTask.Books;
using BookTask.FindBook;
using System;

namespace BookTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookListService = new BookListService();

            bookListService.AddBook(new Book()
            {
                ISBN = 1337,
                Author = "Author_1",
                Title = "Title_1",
                PublishingHouse = "PublishingHouse_1",
                TheYearOfPublishing = 1337,
                NumbersOfPage = 1337,
                Price = 1337
            });

            bookListService.AddBook(new Book()
            {
                ISBN = 1608,
                Author = "Author_2",
                Title = "Title_2",
                PublishingHouse = "PublishingHouse_2",
                TheYearOfPublishing = 1608,
                NumbersOfPage = 1608,
                Price = 1608
            });

            Console.WriteLine(bookListService.FindBookByTag(new FindBookByTitle("Title_2", bookListService.GetBooks(@"R:\states.txt"))));
            Console.WriteLine(bookListService.GetHashCode());
            Console.WriteLine(bookListService.Equals(bookListService.GetBooks(@"R:\states.txt")));

            bookListService.Save(@"R:\states.txt");
        }
    }
}
