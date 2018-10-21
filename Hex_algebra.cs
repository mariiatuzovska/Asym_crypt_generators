using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assym_Crypt_sharp_1
{
    partial class Hex
    {
        public void sum(Hex a, Hex b, Hex c)
        {
            c.to_null();
            int n = 0; int carry = 0;
            for (int i = 0; i < 2048; i++)
            {
                n = (byte)(a.number[i] + b.number[i] + carry);
                carry = n >> 1;
                c.number[i] = (byte)(n & 1);
            }
        }

        public void sub(Hex a, Hex b, Hex c)
        {
            c.to_null();
            if (cmp(a, b) != -1)
            {
                int n = 0; int borrow = 0;
                for (int i = 0; i < 2048; i++)
                {
                    n = a.number[i] - b.number[i] - borrow;
                    if (n >= 0) { c.number[i] = (byte)(n); borrow = 0; }
                    else {  c.number[i] = (byte)(n & 0x1); borrow = 1; }
                }
            }
            else { Console.WriteLine("noob"); }
        }

        public void mul(Hex a, Hex b, Hex c)
        {
            Hex d = new Hex();  Hex e = new Hex();
            c.to_null();
            for (int i = 0; i < b.length(); i++)
            {
                if (b.number[i] == 1)
                {
                    shift_left(a, i, d);
                    sum(c, d, e);
                    copi(e, c);
                }
            }
        }

        public void div(Hex a, Hex b, Hex q, Hex r)
        {
            Hex c = new Hex(); Hex e = new Hex();
            q.to_null(); r.to_null();
            int k = b.length();
            copi(a, r);
            while ((cmp(r, b)) != -1)
            {
                int t = r.length();
                shift_left(b, t - k, c);
                if (cmp(r, c) == -1) { t--; shift_left(b, t - k, c); }
                sub(r, c, e);
                copi(e, r);
                q.number[t - k] = 0x1;
            }
        }

        public void mod(Hex a, Hex b, Hex c)
        {
            if (cmp(a, b) == 1) { Hex m = new Hex(); div(a, b, m, c); }
            else
            {
                if (cmp(a, b) == -1) { copi(c, a); }
                else { c.to_null(); }
            }
        }
    }
}
