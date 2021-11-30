using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeTestning
{
    public interface IUserInterface
    {
        void Clear();
        void Output(string s, bool wl=true);
        string Input();
        void Quit();
    }
}
