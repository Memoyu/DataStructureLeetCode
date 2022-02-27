namespace 栈;

public class _224_基本计算器
{
    // Topic: https://leetcode-cn.com/problems/basic-calculator/

    // 甚至于说可以将表达式转化成逆波兰表达式然后进行计算来实现
    /*
     * 审题：
     * 1、传入参数只会包含 ' ', '0'-'9', '+', '-', '(', ')' 字符；
     * 2、"-(2 + 3)"是一个有效的计算表达式
     */


    /// <summary>
    /// 
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
