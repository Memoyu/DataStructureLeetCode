using Xunit;
using 栈;

namespace 链表.Test;

public class 栈Test
{
    [Fact]
    public void _20_有效的括号Test()
    {
        //"()[]{}" true
        //"([)]" false
        //"["

        var res = _20_有效括号.IsValid("([)]");
        Assert.False(res);
    }

    [Fact]
    public void _150_逆波兰表达式求值Test()
    {
        // var tokens = new string[] { "1", "2", "+", "3", "*" };
        // var tokens = new string[] { "4", "13", "5", "/", "+" };
        var tokens = new string[] { "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+" };

        var res = _150_逆波兰表达式求值.EvalRPN(tokens);
        // Assert.Equal(9, res);
        // Assert.Equal(6, res);
        Assert.Equal(22, res);
    }
}