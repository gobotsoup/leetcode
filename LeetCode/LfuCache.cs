using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class LFUCache
    {

        private Dictionary<int, int> _internalDict;
        private Dictionary<int, LinkedList<int>> _usageQueue;
        private Dictionary<int, int> _usageDict;
        private int _capacity;

        public LFUCache(int capacity)
        {

            _internalDict = new Dictionary<int, int>();
            _usageQueue = new Dictionary<int, LinkedList<int>>(); // key is the number of uses, with queue of most recently used values
            _usageDict = new Dictionary<int, int>();
            _capacity = capacity;
        }

        public int Get(int key)
        {
            // check the Dictionary to find the value, if not found return -1
            if (_internalDict.ContainsKey(key))
            {
                int uses = _usageDict[key] + 1;
                _usageQueue[uses - 1].Remove(key);
                if (_usageQueue.ContainsKey(uses))
                {
                    LinkedList<int> usageQ = _usageQueue[uses];
                    usageQ.AddFirst(key);
                }
                else
                {
                    _usageQueue[uses] = new LinkedList<int>();
                    _usageQueue[uses].AddFirst(key);
                }
                _usageDict[key] += 1;
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
            if (_capacity <= 0) return;

            if (_internalDict.ContainsKey(key))
            {
                int uses = _usageDict[key];
                _usageQueue[uses].Remove(key);
                _usageQueue[1].AddFirst(key);
                _internalDict[key] = value;
                _usageDict[key] = 1;
                return;
            }
            if (_internalDict.Count == _capacity)
            {
                var q = _usageQueue[GetLowestUsage()];
                _internalDict.Remove(q.Last.Value);
                _usageDict.Remove(q.Last.Value);
                q.Remove(q.Last);
            }

            if (_usageQueue.ContainsKey(1))
            {
                var firstUseQ = _usageQueue[1];
                firstUseQ.AddFirst(key);
            }
            else
            {
                _usageQueue[1] = new LinkedList<int>();
                _usageQueue[1].AddFirst(key);
            }
            _usageDict[key] = 1;
            _internalDict.Add(key, value);
        }

        private int GetLowestUsage()
        {
            return _usageDict.OrderBy(x => x.Value).First().Value;
        }
    }

}
