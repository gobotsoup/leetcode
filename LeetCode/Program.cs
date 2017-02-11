using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
 
 //Definition for a binary tree node.
  public class TreeNode
  {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
  }
 
    class Program
    {
        IList<IList<int>> _levels;
        static void Main(string[] args)
        {
            Program p = new Program();
            p._levels = new List<IList<int>>();
            p.Traverse(SetUpTestTree(), 0);
        }

        private static TreeNode SetUpTestTree()
        {
            TreeNode tn1 = new TreeNode(3);
            TreeNode tn2 = new TreeNode(9);
            tn1.right = tn2;
            return tn1;
        }

        public bool CanConstruct(string ransomNote, string magazine)
        {
            var charCounts = new Dictionary<char, int>();
            foreach (char c in magazine)
            {
                if (charCounts.ContainsKey(c))
                {
                    charCounts[c] += 1;
                }
                else
                {
                    charCounts[c] = 1;
                }
            }
            foreach (char c in ransomNote)
            {
                if (charCounts.ContainsKey(c) == false || charCounts[c] < 1)
                {
                    return false;
                }
                else
                {
                    charCounts[c] -= 1;
                }
            } 
            return true;
        }

        public static string ReverseWords(string wordsToReverse)
        {

            //int i = 0;
            //int j = wordToReverse.Length - 1;
            //for(; i < wordToReverse.Length / 2 && j > wordToReverse.Length / 2 ; i++, j--)
            //{

            //}
            int leftIndex = 0; 
            for (int index = wordsToReverse.Length - 1; index >= 0; index --)
            { 
                char currRightChar = wordsToReverse[index];
            }


            return "";
        }


        public static string SwapEndToFrontAndShiftRight(char[] wordToShift)
        {
            //"Flern "
            var temp = wordToShift[0];
            wordToShift[0] = wordToShift[wordToShift.Length - 1];
            //" lern "
            for (int index = wordToShift.Length - 1; index > 1; index--)
            {
                wordToShift[index] = wordToShift[index -1];
            }
            wordToShift[1] = temp;

            return new string(wordToShift);
            //" Flern"
        }

        //public static string SwapIndexRages(char[] chars, int range1start, int range1end, int range2start, int range2end)
        //{
        //    for (int i = range1start, j=range2start; i< )
        //}


        private void Traverse(TreeNode root, int level)
        {
            IList<int> levelValues = null;
            if (_levels.ElementAtOrDefault(level) != null)
            {
                levelValues = _levels[level];
            }
            else
            {
                levelValues = new List<int>();
                _levels.Add(levelValues);
            }
            levelValues.Add(root.val);
            //_levels[level] = levelValues;
            if (root.left != null)
            {
                Traverse(root.left, level + 1);
            }
            if (root.right != null)
            {
                Traverse(root.right, level + 1);
            }
        }
    }
}
