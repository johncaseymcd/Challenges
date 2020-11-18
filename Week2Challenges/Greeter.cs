using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2Challenges
{
    class Greeter
    {
        string helloName;
        public string SayHello(string name)
        {
            helloName = "Hello, " + name + "!";
            return helloName;
        }

        string goodbyeName;
        public string SayGoodbye(string name)
        {
            goodbyeName = "See ya later, " + name + "!";
            return goodbyeName;
        }

        string timeName;
        TimeSpan timeCheck = DateTime.Now.TimeOfDay;
        TimeSpan morning = new TimeSpan(12,0,0);
        TimeSpan afternoon = new TimeSpan(12, 0, 1);
        TimeSpan evening = new TimeSpan(18,0,0);
        TimeSpan midnight = new TimeSpan(23, 59, 59);
        public string GoodTime(string name)
        {
            if (timeCheck <= morning)
            {
                timeName = "Good morning, " + name + ". Enjoy your day!";
                return timeName;
            }
            else if (timeCheck >= afternoon && timeCheck <= evening)
            {
                timeName = "Good afternoon, " + name + ". Hope your day is good so far!";
                return timeName;
            }
            else if (timeCheck > evening && timeCheck <= midnight)
            {
                timeName = "Good evening, " + name + ". I hope you had a good day!";
                return timeName;
            }
            else
            {
                timeName = "Sorry, " + name + ", I don't know what kind of day you're having.";
                return timeName;
            }
        }
    }
}
