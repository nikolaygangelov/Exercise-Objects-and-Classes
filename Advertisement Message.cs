using System;

namespace _1._Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] phrases =
            {
                "Excellent product.",
                "Such a great product.",
                "I always use that product.",
                "Best product of its category.",
                "Exceptional product.",
                "I can't live without this product."
            };

            string[] events =
            {
                "Now I feel good.",
                "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!",
                "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.",
                "I feel great!"
            };

            string[] authors =
            {
                "Diana",
                "Petya",
                "Stella",
                "Elena",
                "Katya",
                "Iva",
                "Annie",
                "Eva"
            };

            string[] cities =
            {
                "Burgas",
                "Sofia",
                "Plovdiv",
                "Varna",
                "Ruse"
            };
            int numberOfMessages = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numberOfMessages; i++)
            {

                Random randomPhrases = new Random();
                Random randomEvents = new Random();
                Random randomAuthors = new Random();
                Random randomCities = new Random();

                int IndexPhrases = randomPhrases.Next(0, phrases.Length);
                int IndexEvents = randomEvents.Next(0, events.Length);
                int IndexAuthors = randomAuthors.Next(0, authors.Length);
                int IndexCities = randomCities.Next(0, cities.Length);


                Console.WriteLine($"{phrases[IndexPhrases]} {events[IndexEvents]} " +
                $"{authors[IndexAuthors]} – {cities[IndexCities]}.");
            }

        }
    }
}
