using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            var dd = 365645654546;
            string aa = dd.ToString();
            // string rr = "";
            var tt = 0;
            for (int i = 0; i < aa.Length; i++)
            {
                 tt +=  Convert.ToInt32(aa.Substring(i, 1));
                //tt = tt +  Convert.ToInt32(aa.Substring(i, 1));
                Console.WriteLine(tt);
                 // Console.Write(aa.Substring(i, 1));
            }
            Console.ReadKey();

        }
    }
}
