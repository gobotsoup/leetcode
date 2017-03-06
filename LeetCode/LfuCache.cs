using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class Node
    {
        public Node Next { get; set; }
        public Node Prev { get; set; }
        public int Value { get; set; }
        public int NumUses { get; set; }

        public Node(int value)
        {
            Value = value;
            NumUses = 0;
        }

        public void SwapNode(Node node)
        {
            Node tempNode = new Node(node.Value);
            tempNode.Next = node.Next;
            tempNode.Prev = node.Prev;

            if (Prev == node)
            {
                node.Prev = this;
                node.Next = this.Next;
                this.Prev = tempNode.Prev;
                this.Next = node;
            }
            else if (this.Next == node)
            {                
                node.Next = this;
                node.Prev = this.Prev;
                this.Next = tempNode.Next;
                this.Prev = node;
            }
            else
            {
                throw new InvalidOperationException("Nodes must be sequential");
            }
        }
    }

    public class Queue
    {
        private Node _head;
        private Node _tail;

        public int Dequeue()
        {
            if (_tail == null) return -1;

            if (_tail.Prev == _head)
            {
                int returnValue = _tail.Value;
                _tail = null;
                _head.Next = null;
                return returnValue;
            }
            else
            {
                var temp = _tail;
                _tail = temp.Prev;
                _tail.Next = null;
                int returnValue = temp.Value;
                temp = null;
                return returnValue;                
            }
        }

        public void IncrementUses(int value)
        {
            var curr = _tail ?? _head;

            while (curr.Value != value)
            {
                curr = curr.Prev;
            }

            curr.NumUses++;

            // move node up as long as previous has <= usage
            while(curr.Prev != null && curr.Prev.NumUses <= curr.NumUses) // after swapping 3 with 4, tail.Prev should point to 4 (not 3)
            {
                // swap the previous with the current
                curr.Prev.SwapNode(curr);
                if (curr.Next == _head) _head = curr;
                if (curr == _tail) _tail = curr.Next;

                //check if update _head.Next, or _tail.Prev
                if (_tail.Prev == curr) _tail.Prev = curr.Next;
                //if (_head.Next == curr.Prev) _head.Next = curr;
            }
        }

        public void Enqueue(int value)
        {
            var n = new Node(value);

            if (_head == null)
            {
                _head = n;
                return;
            }

            if (_tail == null)
            {
                if (_head.NumUses > 0)
                {
                    _tail = n;
                    _tail.Prev = _head;
                    _head.Next = _tail;
                }
                else
                {
                    var t = _head;
                    _head = n;
                    _tail = t;
                    _tail.Prev = _head;
                    _head.Next = _tail;
                }

                return;
            }

            var curr = _tail;
            while (curr.Prev != null && curr.Prev.NumUses == 0)
            {
                curr = curr.Prev;
            }

            if (curr.NumUses == 0)
            {
                n.Next = curr;
                n.Prev = curr.Prev;
                curr.Prev = n;

                if (curr == _head) _head = n;
                if (curr == _tail) _tail = n.Next;
            }
            else
            {
                n.Prev = curr;
                curr.Next = n;
                if (curr == _tail) _tail = n;
            }
        }
    }

    public class LFUCache
    {

        private Dictionary<int, int> _internalDict;
        private Queue _queue;
        private int _capacity;

        public LFUCache(int capacity)
        {

            _internalDict = new Dictionary<int, int>();
            _queue = new Queue();
            _capacity = capacity;
        }

        public int Get(int key)
        {
            // check the Dictionary to find the value, if not found return -1
            if (_internalDict.ContainsKey(key))
            {
                // add this element to the top of the queue as most recent used
                _queue.IncrementUses(key);
                int val = _internalDict[key];
                Console.WriteLine("Get Found: {0} for: {1}", val, key);
                return val;
            }
            else
            {
                Console.WriteLine("Get could not find for: {0}", key);
                return -1;
            }
        }

        public void Put(int key, int value)
        {
            if (_internalDict.ContainsKey(key)) return;
            if (_internalDict.Count == _capacity)
            {
                int remove = _queue.Dequeue();
                _internalDict.Remove(remove);
            }

            _queue.Enqueue(key);
            _internalDict.Add(key, value);
        }
    }

}
