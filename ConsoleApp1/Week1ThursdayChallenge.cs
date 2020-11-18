using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Week1ThursdayChallenge
    {
        static void Main(string[] args)
        {
            // CHALLENGE 1
            string super = "Supercalifragilisticexpialidocious";
            foreach (char letter in super)
            {
                Console.WriteLine(letter);
            }
            Console.ReadLine();


            foreach (char letter in super)
            {
                if (letter == 'i')
                {
                    Console.WriteLine(letter);
                }
                else
                {
                    Console.WriteLine("Not an I");
                }
            }
            Console.ReadLine();

            int i = 1;
            foreach (char letter in super)
            {
                i++;
            }
            Console.WriteLine(i);
            Console.ReadLine();

            foreach (char letter in super)
            {
                switch (letter)
                {
                    case 'i':
                        Console.WriteLine(letter);
                        break;
                    case 'l':
                        Console.WriteLine(letter);
                        break;
                    default:
                        Console.WriteLine("Not an I or L");
                        break;
                }
            }
            Console.ReadLine();

            // CHALLENGE 2
            string firstName = "Casey";
            string lastName = "McDonough";
            int age = 26;

            // CHALLENGE 3
            string[] topFive = { "Only Revolutions", "The Gospel According To Jesus Christ", "The Prophet", "Book Of Hours", ", said the shotgun to the head" };

            // CHALLENGE 4
            List<DateTime> dateList = new List<DateTime>();
            DateTime date1 = new DateTime(1994, 02, 06);
            DateTime date2 = new DateTime(1989, 09, 17);
            DateTime date3 = new DateTime(2008, 01, 24);
            DateTime date4 = new DateTime(2020, 11, 09);
            dateList.Add(date1);
            dateList.Add(date2);
            dateList.Add(date3);
            dateList.Add(date4);
            dateList.Add(DateTime.Now);

            // CHALLENGE 5
            int sum = age + 7;
            int diff = age - 7;
            int prod = age * 7;
            double quot = age / 7d;
            int remainder = age & 7;
            Console.WriteLine(sum);
            Console.WriteLine(diff);
            Console.WriteLine(prod);
            Console.WriteLine(quot);
            Console.WriteLine(remainder);
            Console.ReadLine();

            // CHALLENGE 6
            Console.WriteLine("How many hours did you sleep?");
            string sleepTime = Console.ReadLine();
            int sleep = Int16.Parse(sleepTime);

            if (sleep >= 10)
            {
                Console.WriteLine("Wow, that's a lot of sleep!");
            }
            else if (sleep >= 8 && sleep < 10)
            {
                Console.WriteLine("You should be pretty rested.");
            }
            else if (sleep > 4 && sleep < 8)
            {
                Console.WriteLine("Bummer");
            }
            else
            {
                Console.WriteLine("Oh man, get some sleep!");
            }
            Console.ReadLine();

            // CHALLENGE 7
            Console.WriteLine("How was your day on a scale of 1-5?");
            string dayRate = Console.ReadLine();
            int rating = Int16.Parse(dayRate);

            switch (rating)
            {
                case 5:
                    Console.WriteLine("Great");
                    break;
                case 4:
                    Console.WriteLine("Good");
                    break;
                case 3:
                    Console.WriteLine("Okay");
                    break;
                case 2:
                    Console.WriteLine("Bad");
                    break;
                case 1:
                    Console.WriteLine(":(");
                    break;
                default:
                    Console.WriteLine("I said 1-5!");
                    break;
            }
            Console.ReadLine();
        }
    }
}