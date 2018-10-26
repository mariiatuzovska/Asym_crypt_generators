using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assym_Crypt_sharp_1
{
    class Criteria
    {
        //double[] a = new double[3] { 0.01, 0.05, 0.1 };
        double[] a_1 = new double[3] { 0.161, 0.171, 0.184 };

        public Criteria(string generator)
        {
            Console.WriteLine("");
            Console.WriteLine(generator + " Generator:");
        }

        public void Equabilyty(Sequence n)
        {
            Console.WriteLine("Equabilyty: ");

            Byte_Sequence seq = new Byte_Sequence(n);
            double chi = 0;

            int[] niu = new int[256];
            for (int i = 0; i < 256; i++) { niu[i] = 0; }
            for (int i = 0; i < seq.length(); i++) { niu[seq[i]]++; }

            for (int i = 0; i < 256; i++)
            {
                double x = niu[i] - (seq.length() / 256);
                chi += x * x / (seq.length() / 256);
            }
            
            for (int i = 0; i < 3; i++)
            {
                double lim = Math.Sqrt(2 * 255) * a_1[i] + 255;
                Console.WriteLine("Statistic/Quantile:   " + chi + "/" + lim);
            }
        }

        public void Independence(Sequence n)
        {
            Console.WriteLine("Independence: ");

            Byte_Sequence seq = new Byte_Sequence(n);
            double chi = 0;

            int[] niu_1 = new int[256];
            int[] niu_2 = new int[256];
            int[,] niu = new int[256,256];
            for (int i = 0; i < 256; i++)
            {
                niu_1[i] = 0;
                niu_2[i] = 0;
                for (int j = 0; j < 256; j++) { niu[i, j] = 0; } 
            }
            for (int i = 0; i < seq.length(); i += 2)
            {
                niu_1[seq[i]]++;
                niu_2[seq[i + 1]]++;
                niu[seq[i], seq[i + 1]]++;
            }

            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    double x = niu[i, j] * niu[i, j];
                    double y = niu_1[i] * niu_2[j];
                    if (y != 0)
                        chi += x / y;
                }
            }
            int m = (int)(seq.length() / 2);
            chi = (chi - 1) * m;

            for (int i = 0; i < 3; i++)
            {
                double lim = Math.Sqrt(2 * 255) * a_1[i] + (255 * 255);
                Console.WriteLine("Statistic/Quantile:   " + chi + "/" + lim);
            }
        }

        public void Uniformity(Sequence n, int r)
        {
            Console.WriteLine("Uniformity: ");
            Console.WriteLine("intervals: " + r);

            Byte_Sequence seq = new Byte_Sequence(n);
            double chi = 0;
            int m = (int)(seq.length() / r);

            int[,] niu = new int[256, r];
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < r; j++)
                {
                    niu[i, j] = 0;
                }
            }
            for (int j = 0; j < r; j++)
            {
                for (int k = 0; k < m; k++)
                {
                    niu[seq[j * r + k], j]++;
                }
            }
            
            for (int i = 0; i < 256; i++)
            {
                double p = 0;
                for (int j = 0; j < r; j++)
                {
                    p += niu[i, j];
                }
                for (int j = 0; j < r; j++)
                {
                    double x = niu[i, j] * niu[i, j];
                    double y = p * m;
                    if (y != 0)
                        chi += x / y;
                }
            }
            chi = (chi - 1) * seq.length();
            for (int i = 0; i < 3; i++)
            {
                double lim = Math.Sqrt(2 * 255) * a_1[i] + 255 * (r - 1);
                Console.WriteLine("Statistic/Quantile:   " + chi + "/" + lim);
            }
        }


    }
}
