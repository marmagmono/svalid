using System;
using System.Collections.Generic;
using System.Text;

namespace SValid.Core
{
    public class Isbn
    {
        private string isbn;

        private Isbn(string isbn)
        {
            this.isbn = isbn;
        }

        public static bool TryCreate(string isbnString, out Isbn isbn, out ErrorData error)
        {
            if (string.IsNullOrWhiteSpace(isbnString))
            {
                isbn = null;
                error = new SimpleData("WTF");
                return false;
            }
            else
            {
                isbn = new Isbn(isbnString);
                error = null;
                return true;
            }
        }

        public override string ToString() => this.isbn;
    }

    public class Author
    {
        private readonly string author;

        private Author(string author)
        {
            this.author = author;
        }

        public static bool TryCreate(string author, out Author authorOut, out ErrorData errorData)
        {
            if (string.IsNullOrEmpty(author))
            {
                authorOut = null;
                errorData = new SimpleData("WTFA");
                return false;
            }
            else
            {
                authorOut = new Author(author);
                errorData = null;
                return true;
            }
        }
    }

    public class Book
    {
        public string Title { get; }

        public Author Author { get; }

        public Isbn Isbn { get; }

        private Book(string title, Author author, Isbn isbn)
        {
            Title = title;
            Author = author;
            Isbn = isbn;
        }

        private static bool NotEmpty(string s, out (string, string) result)
        {
            if (string.IsNullOrEmpty(s))
            {
                result = (null, "fdsfdsfs");
                return false;
            }
            else
            {
                result = (s, null);
                return true;
            }
        }

        private static bool MaxLength(string s, out (string, string) result)
        {
            if (string.IsNullOrEmpty(s))
            {
                result = (null, "fdsfdsfs");
                return false;
            }
            else
            {
                result = (s, null);
                return true;
            }
        }

        public bool TryCreate(
            string title,
            string author,
            string isbn,
            out Book book,
            out ErrorData errorData)
        {
            //bool valid = NotEmpty(title, out var result)
            //    MaxLength(title, out var mlResult);

            bool ValidateTitle(string t, out string s, out ErrorData e)
            {
                if (string.IsNullOrEmpty(t))
                {
                    s = null;
                    e = new SimpleData("fdsfdsfs");
                    return false;
                }
                else
                {
                    s = t;
                    e = null;
                    return true;
                }
            }

            bool titleCreated = ValidateTitle(title, out var createdTitle, out var titleError);
            bool authorCreated = Author.TryCreate(author, out var createdAuthor, out var authorError);
            bool isbnCreated = Isbn.TryCreate(isbn, out var createdIsbn, out var isbnError);
            if (titleCreated && authorCreated && isbnCreated)
            {
                book = new Book(createdTitle, createdAuthor, createdIsbn);
                errorData = null;
                return true;
            }
            else
            {
                book = null;
                errorData = null;
                //errorData = new ComplexData();
                return false;
            }
        }
    }

    class BookTest
    {
    }
}
