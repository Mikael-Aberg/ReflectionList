using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionList
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new Menu();
            while (true)
            {
                if(Console.KeyAvailable)
                menu.HandleKeyEvent(Console.ReadKey(true));
            }
        }
    }
}
