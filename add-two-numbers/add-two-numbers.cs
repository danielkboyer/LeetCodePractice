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
       public ListNode AddTwoNumbers(ListNode l1, ListNode l2, int carry)
        {
            if(l1 == null && l2 == null)
            {
                if(carry > 0)
                {
                    return  new ListNode(carry);
                }    
                return null;
            }

            int current = 0;

            if (l1 != null)
            {
                current += l1.val;
                l1 = l1.next;
            }

            if (l2 != null)
            {
                current += l2.val;
                l2 = l2.next;
            }

            current += carry;

            ListNode toReturn = new ListNode();
            toReturn.val = current % 10;
            carry = current / 10;


            toReturn.next = AddTwoNumbers(l1, l2, carry);

            return toReturn;
        }
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {

            return AddTwoNumbers(l1, l2, 0);
        }
}