using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeTestning
{
    class ConsoleUI : IUserInterface
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void Output(string s, bool wl = true)
        {
            if (wl)
            {
                Console.WriteLine(s);
            }
            else
            {
                Console.Write(s);
            }
        }

        public string Input()
        {
            return Console.ReadLine();
        }

        public void Quit()
        {
            System.Environment.Exit(0);
        }
    }
}
