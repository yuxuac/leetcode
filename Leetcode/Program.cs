using System;

namespace Leetcode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
             ["LFUCache","put","put","get","put","get","get","put","get","get","get"]
              [[2],
               [1,1],
               [2,2],
               [1],
               [3,3],
               [2],
               [3],
               [4,4],
               [1],
               [3],
               [4]]
             */
            LFUCache lFUCache = new LFUCache(2);
            lFUCache.Put(1, 1);
            lFUCache.Put(2, 2);
            int v1 = lFUCache.Get(1);
            lFUCache.Put(3, 3);
            int v2 = lFUCache.Get(2);
            int v3 = lFUCache.Get(3);
            lFUCache.Put(4, 4);
            int v4 = lFUCache.Get(1);
            int v5 = lFUCache.Get(3);
            int v6 = lFUCache.Get(4);
        }
    }
}
