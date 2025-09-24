namespace LeetCodeTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            Hashmap hashmap = new Hashmap();
            Matrix matrix = new Matrix();
            Intervals interval = new Intervals();
            Stack stack = new Stack();
            LinkedList linked= new LinkedList();

            //matrix.IsValidSudoku(
            //    [
            //     ['5', '3', '.', '.', '7', '.', '.', '.', '.'],
            //     ['6', '.', '.', '1', '9', '5', '.', '.', '.'],
            //     ['.', '9', '8', '.', '.', '.', '.', '6', '.'],
            //     ['8', '.', '.', '.', '6', '.', '.', '.', '3'],
            //     ['4', '.', '.', '8', '.', '3', '.', '.', '1'],
            //     ['7', '.', '.', '.', '2', '.', '.', '.', '6'],
            //     ['.', '6', '.', '.', '.', '.', '2', '8', '.'],
            //     ['.', '.', '.', '4', '1', '9', '.', '.', '5'],
            //     ['.', '.', '.', '.', '8', '.', '.', '7', '9']
            //    ]);

            //interval.Insert([[1, 2], [3, 5], [6, 7], [8, 10], [12, 16]], [4,8]);

            //stack.Calculate("1-(     -2)");  

            ListNode head = new ListNode(1);
            head.next = new ListNode(2);
            head.next.next = new ListNode(3);
            head.next.next.next = new ListNode(3);
            head.next.next.next.next = new ListNode(5);
            head.next.next.next.next.next = new ListNode(5);

            ListNode head1 = new ListNode(1);
            head1.next = new ListNode(3);
            head1.next.next = new ListNode(4);

            //head.next.next.next.next = head.next;

            //linked.HasCycle(head);
            linked.DeleteDuplicates(head);

            Console.WriteLine("Hello, World!");

        }
        

    }
}
