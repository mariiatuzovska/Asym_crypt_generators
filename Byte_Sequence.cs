using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assym_Crypt_sharp_1
{
    class Byte_Sequence
    {
        int size = 0;
        byte[] byte_number;

        public int length()
        {
            return size;
        }

        public Byte_Sequence(Sequence sequence)
        {
            byte[,] matrix = new byte[256, 8];
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 8; j++) { matrix[i, j] = 0; }
            }
            int k = 2;
            for (int i = 0; i < 8; i++)
            {
                int p = 0;
                for (int q = 0; q < k / 2; q++)
                {
                    for (int j = p; j < p + (256 / k); j++) { matrix[j, i] = 1; }
                    p = p + (2 * (256 / k));
                }
                k = k * 2;
            }


            for (int i = 0; i < size; i++)
            {
                bool flag = false;
                byte s = 0;
                while (flag == false)
                {
                    byte temp = 0;
                    for (int j = 0; j < 8; j++)
                    {
                        if (sequence[i * 8 + j] == matrix[s, j]) { temp++; }
                        else
                            break;
                    }
                    if (temp == 8) { flag = true; }
                    s++;
                }
                byte_number[i] = s;
            }

        }
    }
}


