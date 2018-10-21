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
            Sequence n = new Sequence(10000);
            n.BBS("bite");
            Criteria criteria = new Criteria("BBS bite");
            criteria.Equabilyty(n);
            criteria.Independence(n);
            criteria.Uniformity(n, 10);

            n.to_null();
            n.BBS("byte");
            criteria = new Criteria("BBS byte");
            criteria.Equabilyty(n);
            criteria.Independence(n);
            criteria.Uniformity(n, 10);


            Console.ReadKey();
        }
    }
}
