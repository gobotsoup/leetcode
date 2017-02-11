using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class ListNodeProblems
    {
        public static ListNode GetLinkedListAfterAddition(ListNode list1, ListNode list2)
        {
            ListNode head = null;
            ListNode current = null;
            int remainder = 0;

            while (list1 != null && list2 != null)
            {
                int val = list1.val + list2.val + remainder;
                if (val > 9)
                {
                    val = val - 10;
                    remainder = 1;
                }
                else remainder = 0;
                var node = new ListNode(val);
                if (head == null)
                {
                    head = node;
                    current = head;

                    Console.WriteLine("Add Head with: {0}", val);
                }
                else
                {
                    while (current.next != null)
                    {
                        current = current.next;
                    }
                    current.next = node;
                }

                list1 = list1.next;
                list2 = list2.next;
            }

            ListNode printNode = head;
            while (printNode != null)
            {
                Console.WriteLine("We got: {0}", printNode.val);
                printNode = printNode.next;
            }

            return head;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

}
