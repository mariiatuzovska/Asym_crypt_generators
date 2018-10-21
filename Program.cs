using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assym_Crypt_sharp_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Sequence n = new Sequence(1000000);
            n.rand();
            Criteria criteria = new Criteria("Rand");
            criteria.Uniformity(n, 10);
            
            
            Console.ReadKey();
        }
    }
}
