using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Challenges
{
    class Runner
    {
        static void Main(string[] args)
        {
            Greeter greetMe = new Greeter();
            string hello = greetMe.SayHello("Casey");
            string goodbye = greetMe.SayGoodbye("Casey");
            string goodDay = greetMe.GoodTime("Casey");

            Console.WriteLine(hello);
            Console.ReadLine();

            Console.WriteLine(goodDay);
            Console.ReadLine();

            Console.WriteLine(goodbye);
            Console.ReadLine();
        }
    }
}
