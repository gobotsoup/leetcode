using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class LongestAbsoluteFilepath
    {
        public class Node
        {
            public string Element { get; set; }
            public Node Parent { get; set; }
        }
        public static int LengthLongestPath(string input)
        {
            int longest = 0;
            var directories = new List<Node>();
            var files = new List<Node>();
            char[] theChars = input.ToCharArray();

            string name = "";
            int pathLevel = 0;
            Node currParent = null;
            for (int index = 0; index < theChars.Length; index++)
            {
                char c = theChars[index];
                if (c == 9 || c == 10)
                {
                    int nextPathLevel = 0;
                    char checkTab = theChars[index];
                    while (checkTab == 10 || checkTab == 9)
                    {
                        // if tab increment path level
                        if (checkTab == 9) nextPathLevel++;
                        index++;
                        checkTab = theChars[index];
                    }

                    currParent = GetCurrParent(directories, files, name, pathLevel, currParent, nextPathLevel);

                    pathLevel = nextPathLevel;
                    name = "" + checkTab;
                }
                else
                {
                    name += c;
                    if (index == theChars.Length - 1)
                    {
                        GetCurrParent(directories, files, name, pathLevel, currParent, -1);
                    }
                }
            }

            foreach(Node n in files)
            {
                string path = n.Element;
                Node current = n;
                while (current.Parent != null)
                {
                    path = string.Format(@"{0}\{1}", current.Parent.Element, path);
                    current = current.Parent;
                }
                if (path.Length > longest) longest = path.Length;
            }

            
            return longest;
        }

        private static Node GetCurrParent(List<Node> directories, List<Node> files, string name, int pathLevel, Node currParent, int nextPathLevel)
        {
            Node n = new Node();
            n.Element = name.TrimEnd();
            n.Parent = currParent;
             
            if (name.Contains(".") == false)
            {
                directories.Add(n);
                if (nextPathLevel > pathLevel)
                {
                    currParent = n;
                }
                if (nextPathLevel < pathLevel && n.Parent != null)
                {
                    currParent = n.Parent.Parent;
                }
            }
            else
            {
                files.Add(n);
            }

            return currParent;
        }
    }
}
