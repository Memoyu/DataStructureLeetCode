using Xunit;
using 栈;

namespace 链表.Test
{
    public class 栈Test
    {
        [Fact]
        public void _20_有效的括号Test()
        {
            //"()[]{}" true
            //"([)]" false
            //"["

            var res = _20_有效括号.IsValid("[");
            Assert.False(res);
        }
    }
}