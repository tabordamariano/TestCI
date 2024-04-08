using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public class program
    {
        public static void Main(string[] args)
        {
            var service = new VideoService();
            var title = service.ReadVideoTitle();
            Console.WriteLine(title);
        }
    }
}
