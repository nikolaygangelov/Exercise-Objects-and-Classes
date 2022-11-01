

namespace _2._Articles
{
    using System;
    using System.Numerics;
    using System.Collections.Generic;
    using System.Linq;
    class Articles
    {
        static void Main(string[] args)
        {
            string[] articles = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();


            int n = int.Parse(Console.ReadLine());

            string title = articles[0];
            string content = articles[1];
            string author = articles[2];

            Article article1 = new Article(title, content, author);

            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();

                string[] inputParameters = command.Split(": ");
                string firstParameter = inputParameters[0];
                string secondParameter = inputParameters[1];

                if (firstParameter == "Edit")
                {
                    article1.OperationEdit(secondParameter);

                }
                else if(firstParameter == "ChangeAuthor")
                {
                    article1.OperationChangeAuthor(secondParameter);
                }
                else if(firstParameter == "Rename")
                {
                    article1.OperationRename(secondParameter);
                }
            }

            Console.WriteLine(article1.ToString());

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

        public void OperationEdit(string secondParameter)
        {
                Content = secondParameter;
        }

        public void OperationChangeAuthor(string secondParameter)
        {
                Author = secondParameter;
        }

        public void OperationRename(string secondParameter)
        {
                Title = secondParameter;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}

