/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public  ListNode ReverseKGroup(ListNode head, int k)
        {
            if (k == 1)
            {
                return head;
            }

            return ReverseKGroupRec(head, k, k, true).head;


        }


        //this is my recursive method for solving the problem

        public (ListNode head, bool notEnough) ReverseKGroupRec(ListNode cur, int k, int maxK, bool search)
        {
            if (cur == null)
            {
                return (cur, true);
            }
            if (k == 1)
            {
                if (search)
                    cur.next = ReverseKGroupRec(cur.next, maxK, maxK, search).head;
                return (cur, false);
            }

            var result = ReverseKGroupRec(cur.next, k - 1, maxK, search);
            cur.next = result.head;
            if (result.notEnough)
            {
                return (cur, true);
            }

            var temp1 = cur.next;
            cur.next = temp1.next;
            temp1.next = cur;
            cur = temp1;

            if (k == maxK)
            {
                cur.next = ReverseKGroupRec(cur.next, k - 1, k - 1, false).head;
            }
            return (cur, false);





        }
}