using System;
using System.Collections.Generic;
using System.Text;

namespace BookTask.Books
{
    public class Book
    {
        public Book()
        {
        }

        public Book(int isbn, string author, string title, string publishingHouse,
            int theYearOfPublishing, int numbersOfPage, int price)
        {
            ISBN = isbn;
            Author = author;
            Title = title;
            PublishingHouse = publishingHouse;
            TheYearOfPublishing = theYearOfPublishing;
            NumbersOfPage = numbersOfPage;
            Price = price;
        }

        public int ISBN { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string PublishingHouse { get; set; }
        public int TheYearOfPublishing { get; set; }
        public int NumbersOfPage { get; set; }
        public int Price { get; set; }

        public override bool Equals(object bookObj)
        {
            var book = (Book)bookObj;
            if (book == null)
                return false;

            return ISBN == book.ISBN && Author == book.Author && Title == book.Title
                   && PublishingHouse == book.PublishingHouse && TheYearOfPublishing == book.TheYearOfPublishing
                   && NumbersOfPage == book.NumbersOfPage && Price == book.Price;
        }

        public bool Equals(Book book)
        {
            if (book == null)
                return false;

            return book.ISBN == ISBN;
        }

        public override string ToString() => $"ISBN 13: {ISBN}, AuthorName: {Author}, " +
            $"Title: {Title}, Publisher: {PublishingHouse}, Year: {TheYearOfPublishing}, " +
            $"Number of pages: {NumbersOfPage}, Price: {Price}";

        public override int GetHashCode() => ISBN.GetHashCode();

        public int CompareTo(object bookObj)
        {
            if (bookObj == null)
                return 1;

            var book = (Book)bookObj;
            return CompareTo(book);
        }

        public int CompareTo(Book book)
        {
            if (book == null)
                return 1;
            return string.Compare(Title, book.Title);
        }
    }
}
