namespace 栈;

public class _224_基本计算器
{
    // Topic: https://leetcode-cn.com/problems/basic-calculator/

    // 甚至于说可以将表达式转化成逆波兰表达式然后进行计算来实现

    /*
     * 审题：
     * 1、传入参数只会包含 ' ', '0'-'9', '+', '-', '(', ')' 字符；
     * 2、"-(2 + 3)"是一个有效的计算表达式；
     * 3、展开括号时，需要根据括号前的符号对括号内部的操作符有所影响，例如：
     *      1-(2+3) = 1-2-3, 或 1-(2-3) = 1-2+3, 或 +(2+3) = 1+2+3
     *      总结：括号前面为 - 时，则括号内的操作符都要取反；为 + 时，则不改变括号内符号
     */


    /// <summary>
    /// 思路：
    /// · 遍历传入的s，对每个char进行不同的处理；
    /// · 用sign作为当前计算操作符；
    /// · 使用栈ops进行操作符（−1为减,+1为加）的存储，默认压栈操作符为1，且当遇到'('时才需要入栈sign；
    /// 
    /// · 针对当前的操作字符的操作：
    ///     - ' '，不需要进行操作，指针下移；
    ///     - '+'，获取操作符栈栈顶元素(不执行出栈)，赋值给sign，指针下移；
    ///     - '-'，获取操作符栈栈顶元素(不执行出栈)，进行取反，赋值给sign，指针下移；
    ///     - '('，将sign进行入栈，指针下移；
    ///     - ')'，将ops进行出栈，指针下移；
    ///     - '0~9'，此时遇到的是操作数，需要进行完整的数值获取(因为我们是逐个字符处理)，然后得到的num与sign结合，并操作与res结合，最终赋值给res
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static int Calculate(string s)
    {
        var ops = new Stack<int>();
        var sign = 1;
        ops.Push(sign);
        int res = 0;

        int i = 0;
        while (i < s.Length)
        {
            if (s[i] == ' ')
            {
                i++;
                continue;
            }
            else if (s[i] == '+')
            {
                sign = ops.Peek();
                i++;
            }
            else if (s[i] == '-')
            {
                sign = -ops.Peek();
                i++;
            }
            else if (s[i] == '(')
            {
                ops.Push(sign);
                i++;
            }
            else if (s[i] == ')')
            {
                ops.Pop();
                i++;
            }
            else
            {
                // 此处是操作数处理，则进行操作数数值提取，然后与res进行计算；
                int num = 0;

                // 使用while循环将连续的数字char拼接成操作数num，例如：s="45+1"，假设，s[i]=4，则此处需要需要经过两次循环处理，最终取得操作数num=45；
                while (i < s.Length && s[i] >= '0' && s[i] <= '9')
                {
                    // 进行取值，s[i] - '0'利用char 的 ASCII码值进行取值，同样，也可以使用强转
                    num = num * 10 + s[i] - '0';
                    i++;
                }

                res += sign * num;
            }
        }

        return res;

    }
}
