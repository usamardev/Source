using static LeetCodeTest.Heap;

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
            BinaryTreeGeneral binaryTreeGeneral = new BinaryTreeGeneral();
            BinarySearchTree binaryTreeBFS = new BinarySearchTree();
            GraphGeneral graphGeneral = new GraphGeneral();
            #region TestPart
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

            //ListNode head = new ListNode(4);
            //head.next = new ListNode(2);
            //head.next.next = new ListNode(1);
            //head.next.next.next = new ListNode(3);
            //head.next.next.next.next = new ListNode(2);
            //head.next.next.next.next.next = new ListNode(5);

            //ListNode head1 = new ListNode(1);
            //head1.next = new ListNode(3);
            //head1.next.next = new ListNode(4);

            //head.next.next.next.next = head.next;

            //linked.HasCycle(head);
            //linked.Partition(head,3);


            //TreeNode root = new TreeNode(3,
            //    new TreeNode(9),
            //    new TreeNode(20,
            //        new TreeNode(15),
            //        new TreeNode(7)
            //    )
            //);

            //binaryTreeGeneral.InvertTree(root);
            //binaryTreeGeneral.BuildTree([3, 9, 20, 15, 7], [9, 3, 15, 20, 7]);
            //var a=binaryTreeGeneral.BuildTree2([9, 15, 7, 20, 3], [9, 3, 15, 20, 7]);

            //TreeNode root = new TreeNode(1);
            //root.left = new TreeNode(2);
            //root.right = new TreeNode(5);

            //root.left.left = new TreeNode(3);
            //root.left.right = new TreeNode(4);

            //root.right.right = new TreeNode(6);

            //binaryTreeGeneral.Flatten(root);

            //TreeNode root = new TreeNode(5);

            //root.left = new TreeNode(4);
            //root.right = new TreeNode(8);

            //root.left.left = new TreeNode(11);

            //root.left.left.left = new TreeNode(7);
            //root.left.left.right = new TreeNode(2);

            //root.right.left = new TreeNode(13);
            //root.right.right = new TreeNode(4);

            //root.right.right.right = new TreeNode(1);

            //binaryTreeGeneral.HasPathSum(root, 22);

            //TreeNode root =new TreeNode(4);
            //root.left= new TreeNode(9);
            //root.right= new TreeNode(0);
            //root.left.left= new TreeNode(5);
            //root.left.right= new TreeNode(1);
            //int a=binaryTreeGeneral.SumNumbers(root);

            //TreeNode root = new TreeNode(-10);
            //root.left = new TreeNode(9);
            //root.right = new TreeNode(20);
            //root.right.left = new TreeNode(15);
            //root.right.right = new TreeNode(7);
            //int a = binaryTreeGeneral.MaxPathSum(root);

            //TreeNode treeNode = new TreeNode(4);
            //treeNode.right=new TreeNode(6);
            //treeNode.left=new TreeNode(2);
            //treeNode.left.right=new TreeNode(3);
            //treeNode.left.left=new TreeNode(1);
            //var a=binaryTreeBFS.GetMinimumDifference(treeNode);

            //graphGeneral.NumIslands([['1','1','0','0','0'],
            //                         ['1','1','0','0','0'],
            //                         ['0','0','1','0','0'],
            //                         ['0','0','0','1','1']
            //                       ]);

            //graphGeneral.Solve([['X', 'X', 'X', 'X'], ['X', 'O', 'O', 'X'], ['X', 'X', 'O', 'X'], ['X', 'O', 'X', 'X']]);

            MathALG mathALG = new MathALG();
            //mathALG.MyPow(2,10);

            //_1DDP _1DDP = new _1DDP();
            //_1DDP.LengthOfLIS_BNSearch([10, 9, 2, 5, 3, 7, 101, 18]);
            //graphGeneral.CanFinish(2, [[1, 0]]);
            //testWordDic trie = new testWordDic();
            //trie.AddWord("apple");
            //trie.AddWord("hpsle");
            //trie.Search(".ps.e");
            //trie.Search("apple");
            //SolutionTrie trie = new SolutionTrie();

            //trie.FindWords([
            //    ['o', 'a', 'a', 'n'],
            //    ['e', 't', 'a', 'e'],
            //    ['i', 'h', 'k', 'r'],
            //    ['i', 'f', 'l', 'v']], ["oath", "pea", "eat", "rain"]);
            //MultidimensionalDP binarySearch = new MultidimensionalDP();

            //binarySearch.UniquePathsWithObstaclesOPTWay([[0, 0, 0], [0, 1, 0], [0, 0, 0]]);
            //Backtracking backtracking = new Backtracking();

            //backtracking.Exist([
            //    ['A', 'B', 'C', 'E'], 
            //    ['S', 'F', 'C', 'S'], 
            //    ['A', 'D', 'E', 'E']], "ABCCED");

            //backtracking.TotalNQueensFaster(4);
            //ListNode l1 = new ListNode(1);
            //l1.next = new ListNode(4);
            //l1.next.next = new ListNode(5);

            //// 1 → 3 → 4
            //ListNode l2 = new ListNode(1);
            //l2.next = new ListNode(3);
            //l2.next.next = new ListNode(4);

            //// 2 → 6
            //ListNode l3 = new ListNode(2);
            //l3.next = new ListNode(6);

            //// ListNode[] massiv shaklida saqlaymiz
            //ListNode[] lists = new ListNode[] { l1, l2, l3 };

            //DivideConquer conquer = new DivideConquer();

            ////conquer.SortedArrayToBST([-10, -3, 0, 5, 9]);
            ////conquer.SortList(head);

            //conquer.MergeKLists(lists);
            Heap heap = new Heap();

            //heap.FindKthLargest([3, 2, 1, 5, 6, 4], 2);

            //heap.FindMaximizedCapitalMine(3, 0, [1, 2, 3], [0, 1, 2]);

            //var finder = new MedianFinder();
            //finder.AddNum(1);
            //finder.AddNum(2);
            //Console.WriteLine(finder.FindMedian()); // 1.5
            //finder.AddNum(3);
            //Console.WriteLine(finder.FindMedian()); // 2
            //BitManipulation bitManipulation = new BitManipulation();

            //bitManipulation.RangeBitwiseAnd(5,7);
            #endregion

            BitManipulation bitManipulation = new BitManipulation();

            //bitManipulation.IsInterleave("aabcc", "dbbca", "aadbbcbcac");

            MultidimensionalDP multidimensionalDP = new MultidimensionalDP();

            multidimensionalDP.MaxProfit([3, 3, 5, 0, 0, 3, 1, 4]);

            Console.WriteLine("Hello, World!");
        }

    }
}
