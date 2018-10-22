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
            //Sequence n = new Sequence(1000000);
            //n.Librarian();
            //Criteria criteria = new Criteria("Librarian");
            //criteria.Equabilyty(n);
            //criteria.Independence(n);
            //criteria.Uniformity(n, 10);

            Sequence n = new Sequence(5000000);
            n.L20();
            Criteria criteria = new Criteria("L20");
            criteria.Equabilyty(n);
            criteria.Independence(n);
            criteria.Uniformity(n, 100);

            n.to_null();
            n.L89();
            criteria = new Criteria("L89");
            criteria.Equabilyty(n);
            criteria.Independence(n);
            criteria.Uniformity(n, 100);


            Console.ReadKey();
        }
    }
}
