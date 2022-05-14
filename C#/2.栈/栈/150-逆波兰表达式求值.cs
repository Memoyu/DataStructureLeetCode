namespace 栈;

public class _150_逆波兰表达式求值
{
    // 顺便了解前缀表达式、中缀表达式、后缀表达式
    // 中缀表达式：通用的算术或逻辑公式表示方法，例如：(1 + 2) * 3
    // 前缀表达式：又称波兰表达式，是运算表达式，没有括号，运算符写在操作数前边；例如："*, 3, +, 2, 1"；
    // 后缀表达式：又称逆波兰表达式，是前缀表达式的"反向"表达，运算符写在操作数后边；例如："1, 2, +, 3, *"；

    // Topic: https://leetcode-cn.com/problems/evaluate-reverse-polish-notation/

    /*
     * 审题：
     * 1、逆波兰表达式：遵循从左到右，运算符在数值后边；例如："2, 1, +, 3, *" = (2 + 1) * 3；
     * 2、操作符只有"+, -, /, *"
     */

    public static int EvalRPN(string[] tokens)
    {
        // 使用Equals进行比对实现
        var stack = new Stack<int>();
        foreach (var item in tokens)
        {
            if (item.Equals("+") || item.Equals("-") || item.Equals("*") || item.Equals("/"))
            {
                var p1 = stack.Pop();
                var p2 = stack.Pop();
                var com = item.Equals("+") ? p2 + p1 : item.Equals("-") ? p2 - p1 : item.Equals("*") ? p2 * p1 : item.Equals("/") ? p2 / p1 : 0;
                stack.Push(com);
            }
            else
            {
                stack.Push(int.Parse(item));
            }
        }

        return stack.Pop();

        // 使用Switch 实现，相对会比较耗时
        //var stack = new Stack<int>();
        //foreach (var item in tokens)
        //{
        //    if (!int.TryParse(item, out int val))
        //    {
        //        var p1 = stack.Pop();
        //        var p2 = stack.Pop();
        //        switch (item)
        //        {
        //            case "+":
        //                stack.Push(p2 + p1);
        //                break;
        //            case "-":
        //                stack.Push(p2 - p1);
        //                break;
        //            case "*":
        //                stack.Push(p2 * p1);
        //                break;
        //            case "/":
        //                stack.Push(p2 / p1);
        //                break;
        //        }
        //    }
        //    else
        //    {
        //        stack.Push(val);
        //    }
        //}

        //return stack.Pop();
    }
}
