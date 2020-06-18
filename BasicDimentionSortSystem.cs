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
        static readonly int dimSize = 1000;   //配列の大きさ 

        static void Main(string[] args)
        {
            int[] n = new int[dimSize];
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            // 配列をランダムで埋める
            RandomizeArray(n);
            //DisplayArray(n);
            sw.Start();
            Array.Sort(n, new ReverserClass());
            sw.Stop();
            Console.WriteLine("かかった時間：{0}",sw.Elapsed);
            //DisplayArray(n);

            RandomizeArray(n);
            //DisplayArray(n);
            sw.Reset();
            sw.Start();
            SelectSort(n);
            sw.Stop();
            Console.WriteLine("かかった時間：{0}", sw.Elapsed);
        }
        
        static void SelectSort(int[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            { //最大値をn[i]にする
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] < a[j])
                    {   //　最大値と入れ替え
                        int t = a[i];
                        a[i] = a[j];
                        a[j] = t;
                    }
                }
            }
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
