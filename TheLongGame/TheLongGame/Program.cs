using System.ComponentModel.DataAnnotations;

namespace TheLongGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your name?");
            string playerName = Console.ReadLine();
            string path = "" + playerName + ".txt";
            int score = 0;
            //will get the previous score, if the file doesn't exist, goes in the catch block
            try
            {
                StreamReader reader = new StreamReader(path);
                while (!reader.EndOfStream)
                {
                    score = int.Parse(reader.ReadLine());
                }
                reader.Close();
                Console.WriteLine("welcome back " + playerName);

            }
            catch (FileNotFoundException e)
            {
                score = 0;
            }
            Console.WriteLine("starting score: " + score);
            Console.WriteLine("start hitting keys!");
            var nextKey = Console.ReadKey().Key;
            while(nextKey != ConsoleKey.Enter)
            {
                score += 1;
                Console.WriteLine("\ncurrent score: " + score);
                nextKey = Console.ReadKey().Key;
            }

            //will make the file if it doesn't already exist
            File.AppendAllText(path, "" + score);
        }
    }
}
