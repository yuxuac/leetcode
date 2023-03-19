using System;
using System.Collections.Generic;

namespace Leetcode
{
    public class Trie
    {
        private TrieNode root;
        public Trie()
        {
            root = new TrieNode();
        }

        public void Insert(string word)
        {
            var curr = root;
            for (int i = 0; i < word.Length; i++)
            {
                char ch = word[i];
                if (!curr.children.ContainsKey(ch))
                    curr.children.Add(ch, new TrieNode(ch));
                if (i == word.Length - 1)
                    curr.children[ch].end = true;
                curr = curr.children[ch];
            }
        }

        public bool Search(string word)
        {
            var curr = root;
            for (int i = 0; i < word.Length; i++)
            {
                char ch = word[i];
                if (!curr.children.ContainsKey(ch))
                    return false;
                curr = curr.children[ch];
            }
            return curr.end;
        }

        public bool StartsWith(string prefix)
        {
            var curr = root;
            for (int i = 0; i < prefix.Length; i++)
            {
                char ch = prefix[i];
                if (!curr.children.ContainsKey(ch))
                    return false;
                curr = curr.children[ch];
            }
            return true;
        }

        /*
            private void Print(Node node, List<char> path)
            {
                path.Add(node.ch);
                if(node.children.Keys.Count == 0 || node.end)
                {
                    string endingWith = "";
                    if(node.end)
                        endingWith = "(*)";
                    Console.WriteLine(string.Join("->", path) + endingWith);
                }

                foreach(var kvp in node.children)
                    Print(kvp.Value, path);
                path.RemoveAt(path.Count - 1);
            }
        */
    }

    public class TrieNode
    {
        public TrieNode(char ch = '0', bool end = false)
        {
            this.ch = ch;
            this.children = new Dictionary<char, TrieNode>();
            this.end = end;
        }

        public char ch { get; set; }
        public bool end { get; set; }
        public Dictionary<char, TrieNode> children { get; set; }
    }

    /**
     * Your Trie object will be instantiated and called as such:
     * Trie obj = new Trie();
     * obj.Insert(word);
     * bool param_2 = obj.Search(word);
     * bool param_3 = obj.StartsWith(prefix);
     */
}
