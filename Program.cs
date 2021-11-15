using System;

namespace LEETCODE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //int[] array = new int[] { 3, 6, 4, 12, 9, 10, 5 };
            MaxHeap maxHeap = new MaxHeap(100);
            maxHeap.Insert(3);
            maxHeap.Insert(6);
            maxHeap.Insert(4);
            maxHeap.Insert(12);
            maxHeap.Insert(9);
            maxHeap.Insert(10);
            maxHeap.Insert(5);
        }
    }
}
