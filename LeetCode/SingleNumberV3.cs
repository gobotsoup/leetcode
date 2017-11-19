using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class SingleNumberV3
    {
        private HashSet<int> _set;
        private HashSet<int> _used;

        //Given an array of numbers nums, in which exactly two elements appear only once and all the other elements appear exactly twice.
        //Find the two elements that appear only once.
        public int[] SingleNumber(int[] nums)
        {
            _set = new HashSet<int>();
            _used = new HashSet<int>();
            foreach(int num in nums)
            {
                if (_set.Contains(num))
                {
                    _set.Remove(num);
                    _used.Add(num);
                }
                else if (_used.Contains(num) == false)
                {
                    _set.Add(num);
                }
            }

            return _set.ToArray();
        }
    }
}
