using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    /// <summary>
    /// LFUCache: the least frequently used item will be removed from cache when it exceeds size limit
    /// </summary>
    public class LFUCache
    {
        // key, value
        private Dictionary<int, int> kv;
        // key, frequency
        private Dictionary<int, int> kf;
        // frequency, keys list
        private Dictionary<int, LinkedList<int>> fn;

        private int capacity;
        private int minFreq;
        public LFUCache(int capacity)
        {
            this.capacity = capacity;
            this.minFreq = 0;
            this.kv = new Dictionary<int, int>();
            this.kf = new Dictionary<int, int>();
            this.fn = new Dictionary<int, LinkedList<int>>();
        }

        public int Get(int key)
        {
            if (!kv.ContainsKey(key))
                return -1;
            // kv
            int val = kv[key];

            // update kf
            int currKeyFreq = kf[key];
            int currKeyNewFreq = currKeyFreq + 1;
            kf[key] = currKeyNewFreq;

            // update fn
            fn[currKeyFreq].Remove(key);
            if (fn.ContainsKey(currKeyNewFreq))
                fn[currKeyNewFreq].AddLast(key);
            else
                fn.Add(currKeyNewFreq, new LinkedList<int>(new int[] { key }));

            // update minFreq
            if (fn[currKeyFreq].Count == 0)
            {
                fn.Remove(currKeyFreq);
                if (minFreq == currKeyFreq)
                    minFreq = currKeyNewFreq;
            }
            return val;
        }

        public void Put(int key, int value)
        {
            if (this.capacity == 0)
                return;
            // new node
            if (!kv.ContainsKey(key))
            {
                // reach size limit
                if (kv.Keys.Count == capacity)
                {
                    // delete least frequent item - delete fn[minFreq].first
                    int keyToDelete = fn[minFreq].First.Value;
                    fn[minFreq].RemoveFirst();
                    if (fn[minFreq].Count == 0)
                        fn.Remove(minFreq);
                    kv.Remove(keyToDelete);
                    kf.Remove(keyToDelete);
                }
                // update kv: add new node
                kv.Add(key, value);
                // update kf
                kf.Add(key, 1);
                // update fn
                if (!fn.ContainsKey(1))
                    fn.Add(1, new LinkedList<int>(new int[] { key }));
                else
                    fn[1].AddLast(key);

                this.minFreq = 1;
            }
            // existing node
            else
            {
                // update kv
                kv[key] = value;
                // update kf
                int currKeyFreq = kf[key];
                kf[key] = currKeyFreq + 1;
                // update fn
                fn[currKeyFreq].Remove(key);
                int currKeyNewFreq = currKeyFreq + 1;
                if (fn.ContainsKey(currKeyNewFreq))
                    fn[currKeyNewFreq].AddLast(key);
                else
                    fn.Add(currKeyNewFreq, new LinkedList<int>(new int[] { key }));

                // update minFreq
                if (fn[currKeyFreq].Count == 0)
                {
                    fn.Remove(currKeyFreq);
                    if (minFreq == currKeyFreq)
                        minFreq = currKeyNewFreq;
                }
            }
        }
    }
}
