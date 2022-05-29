using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    /// <summary>
    /// LRUCache2: the least recent used item will be removed from cache when it exceeds size limit
    /// Implemented using custom doubly linked list
    /// </summary>
    public class LRUCache2
    {
        private Node head;
        private Node tail;
        private int capacity;
        private Dictionary<int, Node> cache;

        public LRUCache2(int capacity)
        {
            this.capacity = capacity;
            // initialize head and tail
            this.head = new Node(-1, -1);
            this.tail = new Node(-1, -1);
            this.head.next = this.tail;
            this.tail.pre = this.head;
            // initialize cache
            this.cache = new Dictionary<int, Node>();
        }

        public int Get(int key)
        {
            if (!cache.ContainsKey(key))
                return -1;

            Node node = cache[key];
            Remove(node);
            Add(node);
            return node.val;
        }

        public void Put(int key, int value)
        {
            if (cache.ContainsKey(key))
            {
                Node node = cache[key];
                node.val = value;
                Remove(node);
                Add(node);
            }
            else
            {
                Node node = new Node(value, key);
                // fix capacity exceeding
                if (cache.Count >= capacity)
                {
                    Node delNode = this.tail.pre;
                    Remove(delNode);
                    cache.Remove(delNode.key);
                }
                Add(node);
                cache.Add(key, node);
            }
        }

        private void Remove(Node node)
        {
            node.pre.next = node.next;
            node.next.pre = node.pre;
            node.pre = null;
            node.next = null;
        }

        private void Add(Node node)
        {
            Node headNext = head.next;
            head.next = node;
            node.pre = head;
            headNext.pre = node;
            node.next = headNext;
        }
    }

    public class Node
    {
        public int val;
        public int key;
        public Node pre;
        public Node next;
        public Node(int val, int key, Node pre = null, Node next = null)
        {
            this.pre = pre;
            this.next = next;
            this.val = val;
            this.key = key;
        }
    }
}
