namespace 栈;

public class _856_括号的分数
{
    // Topic: https://leetcode-cn.com/problems/score-of-parentheses/

    /*
     * 审题：
     * 1、；
     */

    public static int ScoreOfParentheses(string s)
    {
        var stack = new Stack<int>();
        foreach (var item in s)
        {
            if (item == '(')
            {
                stack.Push(-1);
            }
            else
            {
                var top = stack.Peek();
                if (top == -1)
                {
                    stack.Pop();
                    stack.Push(1);
                }
                else
                {
                    var re = 0;
                    top = stack.Pop();
                    while (top != -1)
                    {
                        re += top;
                        top = stack.Pop();
                    }

                    stack.Push(2 * re);
                }
            }
        }
        return stack.Sum();
    }

    public static int ScoreOfParentheses_1(string s)
    {
        var stack = new Stack<int>();
        stack.Push(0);
        foreach (var item in s)
        {
            if (item == '(')
            {
                stack.Push(0);
            }
            else
            {
                int top = stack.Pop();
                int sec = stack.Pop();
                stack.Push(sec + Math.Max(2 * top, 1));
            }
        }
        return stack.Pop();
    }
}
