using Xunit;
using Xunit.Abstractions;
using 队列.实现队列;
using static 队列._225_用队列实现栈;

namespace DataStructrue.Test;


public class _3_队列Test
{
    protected readonly ITestOutputHelper Output;

    public _3_队列Test(ITestOutputHelper output)
    {
        Output = output;
    }

    [Fact]
    public void 实现对列Test()
    {
        // 队列
        //Queue<int> queue = new Queue<int>();
        //queue.EnQueue(1);
        //queue.EnQueue(2);
        //queue.EnQueue(3);
        //queue.EnQueue(4);
        //queue.EnQueue(5);

        //while (!queue.IsEmpty())
        //{
        //    Output.WriteLine(queue.DeQueue().ToString());
        //}

        // 双端队列
        DeQueue<int> deQueue = new DeQueue<int>();
        deQueue.EnQueueFront(1);
        deQueue.EnQueueFront(2);
        deQueue.EnQueueRear(3);
        deQueue.EnQueueRear(4);

        /* 尾 4 3 1 2 头 */
        while (!deQueue.IsEmpty())
        {
            Output.WriteLine(deQueue.DeQueueRear().ToString());
        }
    }

    [Fact]
    public void 实现循环对列Test()
    {
        // 循环队列
        //CircleQueue<int> circleQueue = new CircleQueue<int>();
        //for (int i = 0; i < 10; i++)
        //{
        //   circleQueue.EnQueue(i);
        //}

        //for (int i = 0; i < 5; i++)
        //{
        //    circleQueue.DeQueue();
        //}

        //for (int i = 15; i < 23; i++)
        //{
        //    circleQueue.EnQueue(i);
        //}

        //while (!circleQueue.IsEmpty())
        //{
        //    Output.WriteLine(circleQueue.DeQueue().ToString());
        //}

        // 循环双端队列
        CircleDeQueue<int> circleQueue = new CircleDeQueue<int>();
        for (int i = 0; i < 10; i++)
        {
            circleQueue.EnQueueFront(i + 1);
            circleQueue.EnQueueRear(i + 100);
        }

        for (int i = 0; i < 3; i++)
        {
            circleQueue.DeQueueFront();
            circleQueue.DeQueueRear();
        }

        circleQueue.EnQueueFront(11);
        circleQueue.EnQueueFront(12);

        Output.WriteLine(circleQueue.ToString());

        while (!circleQueue.IsEmpty())
        {
            Output.WriteLine(circleQueue.DeQueueFront().ToString());
        }
    }

    [Fact]
    public void _225_用队列实现栈Test()
    {
        MyStack myStack = new MyStack();
        myStack.Push(1);
        myStack.Push(2);

        Assert.Equal(2, myStack.Top());
        Assert.Equal(2, myStack.Pop());
        Assert.False(myStack.Empty());
    }
}
