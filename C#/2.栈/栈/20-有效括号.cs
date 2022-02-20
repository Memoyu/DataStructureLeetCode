namespace 栈;

public class _20_有效括号
{
    // Topic: https://leetcode-cn.com/problems/valid-parentheses/

    /*
     * 审题：
     * 1、传入的 s 仅由括号 '()[]{}' 组成；
     */

    /// <summary>
    /// 思路：
    /// 使用栈去入栈左符号，遇到右符号时，则出栈左符号进行比对；
    /// 依照如上方式，会有如下几种情况：
    /// 1：遇见左字符，进行入栈；
    /// 
    /// 2：遇见右字符串
    ///   2-1：栈为空，则返回False
    ///   2-2：栈不为空，出栈左字符
    ///     2-2-1：左右字符匹配，则继续
    ///     2-2-2：左右字符不匹配，则返回False
    ///     
    /// 3：完成字符遍历
    ///   3-1：栈为空，则返回True
    ///   3-2：栈不为空，则返回False
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static bool IsValid(string s)
    {
        // 比较啰嗦的写法，后期如果添加符号，则需要修改校验逻辑；
        //var stack = new Stack<char>();
        //foreach (var item in s)
        //{
        //    if (item.Equals('(') || item.Equals('[') || item.Equals('{'))
        //    {
        //        stack.Push(item);
        //    }
        //    else
        //    {
        //        if (!stack.TryPop( out var popItem)) return false;
        //        var e = item.Equals(popItem.Equals('(') ? ')' : popItem.Equals('[') ? ']' : popItem.Equals('{') ? '}' : ' ');
        //        if (!e) return false;
        //    }
        //}
        //return stack.Count <= 0;

        // 使用字典进行字符对应的存储，便于后期维护添加，同时也是损耗了内存
        var dic = new Dictionary<char, char> { {'(', ')' }, { '[', ']' }, { '{', '}' } };
        var stack = new Stack<char>();
        foreach (var item in s)
        {
            if (item.Equals('(') || item.Equals('[') || item.Equals('{'))
            {
                stack.Push(item);
            }
            else
            {
                if (!stack.TryPop(out var popItem)) return false;
                var e = item.Equals(dic[popItem]);
                if (!e) return false;
            }
        }
        return stack.Count <= 0;
    }
}
