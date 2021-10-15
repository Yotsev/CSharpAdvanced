using System;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public int CompareTo(Book other)
        {
            int result = Year.CompareTo(other.Year);

            if (result == 0)
            {
                result = Title.CompareTo(other.Title);
            }

            return result;
        }
        public string Title { get; private set; }
        public int Year { get; private set; }
        public IReadOnlyList<string> Authors { get; private set; }

        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = new List<string>(authors);
        }
        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }

    }
}