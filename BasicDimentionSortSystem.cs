using System;
using System.Collections;

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
            // 配列を定義
            int[] n = new int[dimSize];
            // 入力
            for (int i = 0; i < dimSize; i++)
            {
                Console.Write("数値を入力,{0}個目:",i+1);
                n[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(n, new ReverserClass());
            for (int i = 0; i < dimSize; i++)
            {
                Console.WriteLine("{0}番目は{1}\n", i, n[i]);
            }

        }
    }
}
