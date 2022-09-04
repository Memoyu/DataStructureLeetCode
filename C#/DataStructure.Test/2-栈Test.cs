using Xunit;
using 栈;

namespace DataStructure.Test;

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

    [Fact]
    public void _224_基本计算器Test()
    {
        // var s = "1 + 1";
        // var s = " 2-1 + 2 ";
        // var s = "(1+(4+5+2)-3)+(6+8)";
        var s = "-(2+3)";

        var res = _224_基本计算器.Calculate(s);
        // Assert.Equal(2, res);
        // Assert.Equal(3, res);
        // Assert.Equal(23, res);
        Assert.Equal(-5, res);
    }

    [Fact]
    public void _856_括号的分数Test()
    {
        // var s = "()";
        // var s = "(())";
        // var s = "()()";
        // var s = "(()(()))";
        var s = "()(()(()))";

        var res = _856_括号的分数.ScoreOfParentheses_1(s);
        // Assert.Equal(1, res);
        // Assert.Equal(2, res);
        // Assert.Equal(2, res);
        // Assert.Equal(6, res);
         Assert.Equal(7, res);
    }
}