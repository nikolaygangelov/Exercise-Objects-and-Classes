

namespace _2._Articles
{
    using System;
    using System.Numerics;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                List<string> articles = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

                string title = articles[0];
                string content = articles[1];
                string author = articles[2];

                Article article = new Article(title, content, author);

                Console.WriteLine(article.ToString());
            }

            

        }
    }

    public class Article
    {

        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}

