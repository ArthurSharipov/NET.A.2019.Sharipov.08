using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BookTask.Books
{
    class BookListStorage
    {
        public List<Book> GetBookList(string path)
        {
            List<Book> books = new List<Book>();
            using (var binaryReader = new BinaryReader(File.Open(path, FileMode.OpenOrCreate,
                FileAccess.Read, FileShare.Read)))
            {
                while (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
                {
                    var book = Reader(binaryReader);
                    books.Add(book);
                }
            }
            return books;
        }

        private static Book Reader(BinaryReader binaryReader)
        {
            var isbn = binaryReader.ReadInt32();
            var author = binaryReader.ReadString();
            var title = binaryReader.ReadString();
            var publishingHouse = binaryReader.ReadString();
            var theYearOfPublishing = binaryReader.ReadInt32();
            var numbersOfPage = binaryReader.ReadInt32();
            var price = binaryReader.ReadInt32();

            return new Book(isbn, author, title, publishingHouse, theYearOfPublishing, numbersOfPage, price);
        }

        public void SaveBooks(string path, IEnumerable<Book> books)
        {
            using (var binaryWriter = new BinaryWriter(File.Open(path, FileMode.Create,
                FileAccess.Write, FileShare.None)))
            {
                foreach (var book in books)
                {
                    Writer(binaryWriter, book);
                }
            }
        }

        private static void Writer(BinaryWriter binaryWriter, Book book)
        {
            binaryWriter.Write(book.ISBN);
            binaryWriter.Write(book.Author);
            binaryWriter.Write(book.Title);
            binaryWriter.Write(book.PublishingHouse);
            binaryWriter.Write(book.TheYearOfPublishing);
            binaryWriter.Write(book.NumbersOfPage);
            binaryWriter.Write(book.Price);
        }
    }
}
