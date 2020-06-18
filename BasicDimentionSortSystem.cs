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
        static readonly int dimSize = 10000;   //配列の大きさ 

        static void Main(string[] args)
        {
            int[] n1 = new int[dimSize];
            int[] n2 = new int[dimSize];
            int[] n3 = new int[dimSize];
            int[] n4 = new int[dimSize];
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            // 配列をランダムで埋める
            RandomizeArray(n1);
            Array.Copy(n1, n2,n1.Length);
            Array.Copy(n1, n3, n1.Length);
            Array.Copy(n1, n4, n1.Length);
            // Array.Sort
            sw.Start();
            Array.Sort(n1, new ReverserClass());
            sw.Stop();
            Console.WriteLine("Array.Sortでかかった時間：{0}",sw.Elapsed);
            sw.Reset();

            // Array.Sort,Reverse
            sw.Start();
            Array.Sort(n2);
            Array.Reverse(n2);
            sw.Stop();
            Console.WriteLine("Array.Sort,Reverseでかかった時間：{0}", sw.Elapsed);
            sw.Reset();

            // Select
            sw.Start();
            SelectSort(n3);
            sw.Stop();
            Console.WriteLine("Selectでかかった時間：{0}", sw.Elapsed);

            // bubble
            sw.Start();
            BubbleSort(n4);
            sw.Stop();
            Console.WriteLine("Bubbleかかった時間：{0}", sw.Elapsed);
            //DisplayArray(n4);

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

        static void BubbleSort(int[] a)
        {
            bool changed;
            for (int i = a.Length-1; i >0; i--)
            {
                changed = false;
                for (int j = 0; j < i; j++)
                {
                    if (a[j] < a[j+1])
                    {   //　入れ替え
                        int t = a[j];
                        a[j] = a[j+1];
                        a[j+1] = t;
                        changed = true;
                    }
                }
                if (!changed)
                {
                    break;
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
