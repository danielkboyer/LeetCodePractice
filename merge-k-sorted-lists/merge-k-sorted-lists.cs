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
    public ListNode MergeKLists(ListNode[] lists) {
        
        while(lists.Length > 1){
            ListNode[] newList = new ListNode[lists.Length/2 + lists.Length%2];
            
            for(int i = 0;i<lists.Length;i+=2){
                if(i+1 >= lists.Length)
                {
                    newList[i/2] = lists[i];
                    break;
                }
                
                ListNode baseNode = new ListNode();
                if(lists[i] == null){
                    newList[i/2] = lists[i+1];
                    continue;
                }
                else if(lists[i+1] == null){
                    newList[i/2] = lists[i];
                    continue;
                }
                
                if(lists[i].val <= lists[i+1].val){
                    baseNode.val = lists[i].val;
                    lists[i] = lists[i].next;
                }
                else{
                    baseNode.val = lists[i+1].val;
                    lists[i+1] = lists[i+1].next;
                }
                
                Merge(lists[i],lists[i+1],baseNode);
                newList[i/2] = baseNode;
                
                
            }
            lists = newList;
        }
        if(lists.Length == 0)
            return null;
        
            
        return lists[0];
    }
    
    
    public void Merge(ListNode first, ListNode second,ListNode baseNode){
        
        if(first == null){
            baseNode.next = second;
            return;
        }
        
        if(second == null){
            baseNode.next = first;
            return;
        }
        
        
        if(first.val <= second.val){
            
            baseNode.next = first;
            Merge(first.next,second,baseNode.next);
            return;
        }
        else{
            baseNode.next = second;
            Merge(first,second.next,baseNode.next);
        }
        
        
        
    }
}