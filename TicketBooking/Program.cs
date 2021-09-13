using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TicketBooking
{
    class Program
    {
        static void Main(string[] args)
        {
            string movies = File.ReadAllText($"../../../Files/Movies.json");

            var list = JsonConvert.DeserializeObject<List<Movie>>(movies);

            int length = 100;

            var films = new List<Film>();

            for (int i = 0; i < length; i++)
            {
                films.Add(new Film() { Name = $"Film {i.ToString("D3")}" });
            }

            //Console.WriteLine("1. Find by name");
            //Console.WriteLine("2. Order by name");
            //Console.WriteLine("3. Book a ticket");
            //Console.WriteLine("4. Add new film");


            WriteMenu(list);
            //var asd =  Console.ReadLine();

            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.Backspace:

                        break;

                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:

                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        list = list.OrderBy(i => i.Title).ToList();

                        File.WriteAllText($"../../../Files/Movies.json", JsonConvert.SerializeObject(list));

                        WriteMenu(list);

                        break;

                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        Environment.Exit(0);
                        break;
                }
            }
            while (keyInfo.Key != ConsoleKey.X);

        }

        private static void WriteMenu(List<Movie> list)
        {
            Console.Clear();

            int va = list.Max(movie => movie.Title.Length);
            Console.WriteLine(va);

            Console.WriteLine();

            Console.WriteLine($"| #  | Name{new string(' ', va - 4)} |");
            Console.WriteLine($"-----------{new string('-', va - 4)}--");

            foreach (var iterator in list.Select((item, index) => (item, index)))
            {
                var index = iterator.index;
                var item = iterator.item;

                Console.WriteLine($" {(index + 1).ToString("D3")} | {item.Title}{new string(' ', va - item.Title.Length)} |");
            }

            Console.WriteLine();
            Console.WriteLine("1. Find by name | 2. Order by name | 3. Book a ticket | 4. Booking list | 5. Add new film");
        }
    }

    internal class Movie
    {
        public string Title { get; set; }
    }

    internal class Film
    {
        public string Name { get; internal set; }
    }
}
