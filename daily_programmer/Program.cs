using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace daily_programmer
{
    class Program
    {
        static void Main(string[] args)
        {
            //RackManagement.Algorithm();
            string[] file = System.IO.File.ReadAllLines(@"C:\Users\DannePanne\Documents\Arbeten\daily_programmer\daily_programmer\res\histogram.txt");
            Histogram.Draw(file);
            Console.ReadLine();
        }
    }
}
