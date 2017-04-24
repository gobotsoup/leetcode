using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class MinimumGeneticMutation
    {
        public int MinMutation(string start, string end, string[] bank)
        {
            var availableMutations = new Queue<Tuple<string, int>>();
            availableMutations.Enqueue(new Tuple<string, int>(start, 0));
            int numTries = 0;
            while (availableMutations.Any() && numTries < 140)
            {
                var current = availableMutations.Dequeue();
                //Console.WriteLine("current: {0}", current);
                if (current.Item1 == end) return current.Item2;
                numTries++;
                foreach (string bankItem in bank)
                {
                    if (canMutate(current.Item1, bankItem) && !availableMutations.Any(x => x.Item1 == bankItem))
                    {
                        //Console.WriteLine("able to mute: {0} to {1}", current, bankItem);
                        availableMutations.Enqueue(new Tuple<string, int>(bankItem, current.Item2 + 1));
                    }
                }
            }
            return -1;
        }

        private bool canMutate(string from, string to)
        {
            int numDiffs = 0;
            for (int i = 0; i < from.Length; i++)
            {
                if (to[i] != from[i]) numDiffs++;
                if (numDiffs > 1) return false;
            }
            return true;
        }
    }
}
