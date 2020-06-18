using System;
using System.Collections;
using System.Diagnostics;

namespace EX17
{
    public class ReverserClass : IComparer
    {
        // Call CaseInsensitiveComparer.Compare with the parameters reversed.
        int IComparer.Compare(Object x, Object y)
        {
            return ((new CaseInsensitiveComparer()).Compare(y, x));
        }
    }
    class Program
    {
        // 環境定義
        static readonly int dimSize = 10;   //配列の大きさ 

        static void Main(string[] args)
        {
            int[] n = new int[10000];
            n[0] = 0;
            RandomizeArray(n);
            DisplayArray(n);
            Array.Sort(n, new ReverserClass());
            DisplayArray(n);
        }

        static void RandomizeArray(int[] a)
        {
            Random random = new Random();
            for(int i =0;i<a.Length;i++)
            {
                 a[i] = random.Next();
            }
            return;
        }
        static void DisplayArray(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine("[{0}]={1}", i, a[i]);
            }
            return;
        }

    }
}
