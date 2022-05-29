using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    /// <summary>
    /// LRUCache: the least recent used item will be removed from cache when it exceeds size limit
    /// </summary>
    public class LRUCache
    {
        private readonly int size;
        private readonly Dictionary<int, LinkedListNode<int[]>> data;
        private readonly LinkedList<int[]> linkedList;

        public LRUCache(int capacity)
        {
            this.size = capacity;
            this.data = new Dictionary<int, LinkedListNode<int[]>>();
            this.linkedList = new LinkedList<int[]>();
        }

        // Time: O(1)
        public int Get(int key)
        {
            if (!data.ContainsKey(key))
                return -1;
            // node is a reference
            LinkedListNode<int[]> node = data[key];
            this.linkedList.Remove(node);
            this.linkedList.AddFirst(node);
            return node.Value[1];
        }

        // Time: O(1)
        public void Put(int key, int value)
        {
            // new item
            if (!data.ContainsKey(key))
            {
                if (data.Keys.Count == size)
                {
                    // delete the least recent used item
                    LinkedListNode<int[]> lastNode = this.linkedList.Last;
                    this.data.Remove(lastNode.Value[0]); // remove by key
                    this.linkedList.RemoveLast();
                }
                // add the new one
                this.linkedList.AddFirst(new int[] { key, value });
                this.data.Add(key, this.linkedList.First);
            }
            // existing item
            else
            {
                // node is a reference
                LinkedListNode<int[]> node = data[key];
                this.linkedList.Remove(node);
                node.Value[1] = value;
                this.linkedList.AddFirst(node);
            }
        }
    }
}
