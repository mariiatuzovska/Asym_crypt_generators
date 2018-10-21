using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assym_Crypt_sharp_1
{
    partial class Hex
    {
        public byte[] number = new byte[2048];

        public Hex() { for (int i = 0; i < 2048; i++) { number[i] = 0; } }

        public Hex(string n)
        {
            number = new byte[2048];
            for (int i = 0; i < 2048; i++) { number[i] = 0; }
            char[] c = new char[16] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
            byte[,] b  = new byte[16, 4] { 
                { 0,0,0,0 }, { 1,0,0,0 }, { 0,1,0,0 }, { 1,1,0,0 }, { 0,0,1,0 }, { 1,0,1,0 }, { 0,1,1,0 }, { 1,1,1,0 }, 
                { 0,0,0,1 }, { 1,0,0,1 }, { 0,1,0,1 }, { 1,1,0,1 }, { 0,0,1,1 }, { 1,0,1,1 }, { 0,1,1,1 }, { 1,1,1,1 }
	        };
            int j = 0;
            for (int i = n.Length - 1; i > -1; i--)
            {
                int k = 0;
                while (c[k] != /*tolower*/(n[i])) { k++; } //to do : do up registry
                for (int m = 0; m < 4; m++) { number[4 * j + m] = b[k,m]; }
                j++;
            }
        }

        ~Hex() { }

        public int length()
        {
            for (int i = 2047; i > 0; i--) { if (number[i] == 1) { return i + 1; } }
            return 1;
        }

        public string Show()
        {
            char[] c = new char[16] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
            int[,] b = new int[16, 4] {
                { 0,0,0,0 }, { 1,0,0,0 }, { 0,1,0,0 }, { 1,1,0,0 }, { 0,0,1,0 }, { 1,0,1,0 }, { 0,1,1,0 }, { 1,1,1,0 },
                { 0,0,0,1 }, { 1,0,0,1 }, { 0,1,0,1 }, { 1,1,0,1 }, { 0,0,1,1 }, { 1,0,1,1 }, { 0,1,1,1 }, { 1,1,1,1 }
            };
            int l = (length() + 3) / 4;
            string result = null;
	        for (int i = 0; i < l; i++)
            {
		        int j;
		        for (j = 0; j < 16; j++)
                {
			        bool flag = true;
			        for (int k = 0; k < 4; k++) { flag = flag && (number[4 * i + k] == b[j, k]); }
                    if (flag) { break; }
		        }
                result = c[j] + result;
	        }   
	        return "0x" + result;
        }

        public void to_null() { for (int i = 0; i < 2048; i++) { number[i] = 0; } }

        public void copi(Hex a, Hex b) { for (int i = 0; i < 2048; i++) { b.number[i] = a.number[i]; } }

        public void shift_right(Hex a, int x, Hex b)
        {
            b.to_null();
            for (int i = 0; i < 2048 - x; i++) { b.number[i] = a.number[i + x]; }
        }

        public void shift_left(Hex a, int x, Hex b)
        {
            b.to_null();
            for(int i = 0; i < 2048 - x; i++) { b.number[i + x] = a.number[i]; }
        }

        int cmp(Hex a, Hex b)
        {
            int i = 2047;
            while (a.number[i] == b.number[i]) { i--; }
            if (i == -1) { return 0; }
            else
                if (a.number[i] > b.number[i]) { return 1; }
            else
                return -1;
        }

        public void rand(int k)
        {
            to_null();
            Random random = new Random();
            for (int i = 0; i < k; i++) { number[i] = (byte)random.Next(0, 2); }
        }

    }
}
