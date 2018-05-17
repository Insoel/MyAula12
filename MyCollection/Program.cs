using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula12
{
    class Program
    {
        static void Main(string[] args)
        {
            Guarda3<IStuff> g3I = new Guarda3<IStuff>();
            Guarda3<string> g3s = new Guarda3<string>();
            Guarda3<float> g3f = new Guarda3<float>();

            g3I.SetItem(2, new Food(FoodType.Bread, 2, 7));
            g3s.SetItem(2, "hello");
            g3f.SetItem(1, 2.2f);

            foreach (IStuff i in g3I)
            {
                Console.WriteLine(i);
            }

            foreach (string s in g3s)
            {
                Console.WriteLine(s);
            }

            foreach (float f in g3f)
            {
                Console.WriteLine(f);
            }
        }
    }
}
