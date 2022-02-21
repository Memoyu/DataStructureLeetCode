using Xunit;
using Xunit.Abstractions;
using 队列.实现队列;

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
}
