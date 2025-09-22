namespace LeetCodeTest
{
    public class Stack
    {
        public string SimplifyPath(string path)
        {
            string[] parts = path.Split('/');
            Stack<string> stack = new Stack<string>();
            foreach (string part in parts)
            {
                if (part == "" || part == ".")
                    continue;
                else if (part == "..")
                {
                    if (stack.Count > 0)
                        stack.Pop();
                }
                else
                {
                    stack.Push(part);
                }
            }
            string result = "/" + string.Join("/", stack.Reverse());
            return result;
        }

        public int EvalRPN(string[] tokens)
        {
            Stack<int> stackNum = new Stack<int>();
            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i]=="+"|| tokens[i] == "-"|| tokens[i] == "*"|| tokens[i] == "/")
                {
                    int result = 0;
                    int m=stackNum.Pop();
                    int n=stackNum.Pop();

                    switch (tokens[i])
                    {
                        case "+": result = n + m; break;
                        case "*": result = n * m; break;
                        case "-": result = n - m; break;
                        case "/": result = n / m; break;
                    }

                    stackNum.Push(result);
                    continue;
                }
                stackNum.Push(int.Parse(tokens[i]));
            }

            return stackNum.Pop();
        }

        public int Calculate(string s)
        {
            Stack<int> stack = new Stack<int>();
            Stack<int> stackSum = new Stack<int>();
            int a = 1;
            int result = 0;
            string text = "";
            s = s + " ";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '-')
                    a = -1;
                if (s[i] == '(')
                {
                    stack.Push(a);
                    stackSum.Push(result);
                    result = 0;
                    a = 1;
                }

                if(s[i] >= 48 && s[i]<=57)
                {
                    text += s[i].ToString();
                    if (!(s[i+1] >= 48 && s[i+1] <= 57))
                    {
                        result += Convert.ToInt32(text) * a;
                        a = 1;
                        text = "";
                    }
                }
                if (s[i] == ')')
                {
                    result=stackSum.Pop()+result*stack.Pop();
                }
                    
            }

            return result;
        }
        

    }
    public class MinStack
    {

        private Stack<int> stack;
        private Stack<int> minStack;

        public MinStack()
        {
            stack = new Stack<int>();
            minStack = new Stack<int>();
        }

        public void Push(int val)
        {
            stack.Push(val);
            if (minStack.Count == 0 || val <= minStack.Peek())
                minStack.Push(val);
        }

        public void Pop()
        {
            if (stack.Count == 0) return;

            int removed = stack.Pop();
            if (removed == minStack.Peek())
                minStack.Pop();
        }

        public int Top()
        {
            return stack.Peek();
        }

        public int GetMin()
        {
            return minStack.Peek();
        }
    }

}
