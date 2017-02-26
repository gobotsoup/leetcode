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

        public Node(int value)
        {
            Value = value;
        }
    }

    public class Queue
    {
        private Node _head;
        private Node _tail;

        public int Dequeue()
        {
            if (_tail == null) return -1;

            if (_tail.Prev != _head)
            {
                var temp = _tail;
                _tail = temp.Prev;
                int returnValue = temp.Value;
                temp = null;
                return returnValue;
            }
            else
            {
                int returnValue = _tail.Value;
                var temp = _tail;
                _tail = temp.Prev;
                temp = null;
                return returnValue;
            }
        }

        public void MoveToFront(int value)
        {
            var curr = _head;
            bool found = value == curr.Value;
            if (found) return;

            while (curr != null && !found)
            {
                curr = curr.Next;
                if (curr.Value == value)
                {
                    found = true;

                    if (curr == _tail)
                    {
                        _tail = curr.Prev;
                    }
                    break;
                }
            }

            if (found)
            {
                var temp = _head;
                temp.Next = curr.Next;
                _head = curr;
                _head.Next = temp;
                temp.Prev = _head;
            }
        }

        public void Enqueue(int value)
        {
            if (_head == null)
            {
                _head = new Node(value);
            }
            else if (_tail == null)
            {
                _tail = new Node(value);
                _tail.Prev = _head;
                _head.Next = _tail;
            }
            else
            {
                var n = new Node(value);
                var temp = _tail;
                temp.Next = n;
                _tail = n;
                _tail.Prev = temp;
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
                _queue.MoveToFront(key);
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
            // check if dict is at capacity, if so remove the least recently used
            if (_internalDict.Count == _capacity)
            {
                int remove = _queue.Dequeue();
                Console.WriteLine("Att capacity removing: {0}", remove);
                _internalDict.Remove(remove);
            }

            // add to the tail of the list
            _queue.Enqueue(key);

            if (!_internalDict.ContainsKey(key) && _internalDict.Count < _capacity)
            {
                _internalDict.Add(key, value);
            }
            Console.WriteLine("Put: {0}", value);
        }
    }

}
