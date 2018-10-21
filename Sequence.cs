using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assym_Crypt_sharp_1
{
    partial class Sequence
    {
        int size = 0;
        byte[] number = new byte[10000000];

        public Sequence(int n)
        {
            number = new byte[n];
            for (int i = 0; i < n; i++) { number[i] = 0; }
            size = n;
        }

        public int length()
        {
            return size;
        }


        public byte this[int index]
        {
            get
            {
                return number[index];
            }
            set
            {
                number[index] = value;
            }
        }

        ~Sequence() { }

        public void to_null() { for (int i = 0; i < size; i++) { number[i] = 0; } }

        public void Show()
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write(number[i]); 
            }
        }

    }

   









       

        //void matrix(int[,] matr)
        //{
        //    matr = new int[256, 8];
        //    for (int i = 0; i < 256; i++)
        //    {
        //        for (int j = 0; j < 8; j++) { matr[i, j] = 0; }
        //    }
        //    int k = 2;
        //    for (int i = 0; i < 8; i++)
        //    {
        //        int p = 0;
        //        for (int q = 0; q < k / 2; q++)
        //        {
        //            for (int j = p; j < p + (256 / k); j++) { matr[j, i] = 1; }
        //            p = p + (2 * (256 / k));
        //        }
        //        k = k * 2;
        //    }
        //}

        //public void byte_frequency(Sequence n, int[] niu)
        //{
        //    for (int i = 0; i < 256; i++) { niu[i] = 0; }
        //    int[,] matr = new int[256, 8];
        //    n.matrix(matr);
        //    for (int i = 0; i < 256; i++)
        //    {
        //        for (int j = 0; j < 125000; j++)
        //        {
        //            int temp = 0;
        //            for (int k = 0; k < 8; k++)
        //            {
        //                if (matr[i, k] == n.number[j, k]) { temp++; }
        //                if (temp == 8) { niu[i]++; }
        //            }
        //        }
        //    }
        //}



        //void two_byte_frequency(Sequence n, int[,] niu, int[] niu_i, int[] niu_j)
        //{
        //    for (int i = 0; i < 256; i++)
        //    {
        //        niu_i[i] = 0;
        //        niu_j[i] = 0;
        //        for (int j = 0; j < 256; j++) { niu[i, j] = 0; }
        //    }
        //    int[,] matr = new int[256, 8]; matrix(matr);
        //    for (int i = 0; i < 125000; i = i + 2)
        //    {
        //        for (int p = 0; p < 256; p++)
        //        {
        //            int temp_1 = 0;
        //            for (int k = 0; k < 8; k++) { if (matr[p, k] == n.number[i, k]) { temp_1++; } }
        //            if (temp_1 == 8)
        //            {
        //                for (int q = 0; q < 256; q++)
        //                {
        //                    int temp_2 = 0;
        //                    for (int k = 0; k < 8; k++)
        //                    {
        //                        if (matr[q, k] == n.number[i + 1, k]) { temp_2++; }
        //                        if (temp_2 == 8) { niu[p, q]++; }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    for (int i = 0; i < 256; i++)
        //    {
        //        for (int j = 0; j < 256; j++)
        //        {
        //            niu_i[i] = niu_i[i] + niu[i, j];
        //            niu_j[i] = niu_j[i] + niu[j, i];
        //        }
        //    }
        //}
    }
