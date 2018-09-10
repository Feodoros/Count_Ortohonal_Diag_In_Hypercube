using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count_Ortohonal_Diag_In_Hypercube
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            int[] m = { 0, 1 };
            Console.Write("Размерность пространства: ");
            int n = Int32.Parse(Console.ReadLine());
            var digits = new int[n];
            int k = 1;
            int s = 0;
            Console.WriteLine("Вершины для " + n + "-куба:");
            do
            {
                Console.WriteLine(k.ToString() + " " + string.Join("", digits.Select(d => m[d])));
                Proverka(digits);
                k++;
            } while (Increment(m.Length, digits));


            bool Increment(int baseNumber, int[] digits1)
            {
                int i = digits1.Length - 1;
                while (i >= 0 && digits[i] == baseNumber - 1)
                {
                    digits1[i] = 0;
                    i -= 1;
                }
                   
                if (i < 0)
                {
                    return false;
                }
                digits1[i] += 1;
                return true;
            }

            void Proverka(int[] a)
            {
                Console.WriteLine();
                int[] x = a;
                int[] y = new int[n];
                int[] vector = new int[n];
                int sum = 0;
                for (int i = 0; i < n; i++)
                {
                    y[i] = 1 - x[i];
                    vector[i] = 1 - 2 * x[i];
                }
                for (int i = 0; i < n; i++)
                {

                    sum = sum + vector[i];
                }

                if (sum == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Вершина 1: ");
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write(x[i] + " ");
                    }
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Вершина 2: ");
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write(y[i] + " ");
                    }
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Ортогональный вектор к вектору (1,..,1): ");
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write(vector[i] + " ");
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    s++;
                }
            }

            Console.WriteLine("Число диагоналей, ортогональных к выбранной: " + s / 2);
            
            Console.ReadKey();
        }
    }
}

