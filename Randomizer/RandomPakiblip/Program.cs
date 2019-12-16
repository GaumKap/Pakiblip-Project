using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RandomPakiblip
{

    public struct Hystory
    {
        public int x;
        public int y;
        public string old_pos;
        public int nb;
    }

    class Program
    {

        

        static void Main(/*string[] args*/) // Note : In final product Randomizer can be .dll file and this line can be used, the return value will be the tab "table"
        {
            Randomizer map = new Randomizer();
            //Console.Write("<Enter>");
            //Console.Read();
            Console.Clear();
            map.Progmain();
        }

        
    }
}
