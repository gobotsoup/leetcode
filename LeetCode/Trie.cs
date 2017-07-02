using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Node
    {
        private List<Node> _children;
        private char _prefix;

        public char Value { get; private set; }
        public bool IsLeaf { get; private set; }

        public Node(char prefix)
        {
            _prefix = prefix;
            Value = prefix;
            IsLeaf = true;
            _children = new List<Node>();
        }

        public Node FindNode(char c)
        {
            foreach (Node n in _children)
            {
                if (n.Value == c) return n;
            }
            return null;
        }

        public bool HasChildren()
        {
            return _children.Any();
        }

        public void AddToChildren(string prefix)
        {
            if (string.IsNullOrWhiteSpace(prefix))
            {
                IsLeaf = true;
                return;
            }

            Node n = new Node(prefix[0]);
            n.IsLeaf = prefix.Length == 1;
            _children.Add(n);
            n.AddToChildren(prefix.Substring(1));
        }
    }

    public class Trie
    {
        private Node _root;

        /** Initialize your data structure here. */
        public Trie()
        {
            _root = new Node('\0');
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            Node curr = _root;
            string restOfWord = word;
            for (int i = 0; i < word.Length; i++)
            {
                Node prev = curr;
                curr = curr.FindNode(restOfWord[0]);
                if (curr == null)
                {
                    curr = prev;
                    break;
                }
                restOfWord = restOfWord.Substring(1);
            }

            curr.AddToChildren(restOfWord);
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word) // should only be true if the found node is a leaf
        {
            Node curr = _root;
            for (int i = 0; i < word.Length; i++)
            {
                curr = curr.FindNode(word[i]);
                if (curr == null) return false;
            }

            return curr.IsLeaf;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            Node curr = _root;
            foreach(char c in prefix)
            {
                curr = curr.FindNode(c);
                if (curr == null) return false;
            }

            return true;
            //return _root.GetChild(prefix) != null; // return true if any node found
        }
    }

    /**
     * Your Trie object will be instantiated and called as such:
     * Trie obj = new Trie();
     * obj.Insert(word);
     * bool param_2 = obj.Search(word);
     * bool param_3 = obj.StartsWith(prefix);
     */
}
