namespace 队列;

public class _225_用队列实现栈
{
    // Topic: https://leetcode-cn.com/problems/implement-stack-using-queues/

    /*
     * 审题：
     * 1、；
     */

    public class MyStack
    {

        Queue<int> queue1 = new Queue<int>();
        Queue<int> queue2 = new Queue<int>();

        public MyStack()
        {

        }

        public void Push(int x)
        {
            queue2.Enqueue(x);
            foreach (var item in queue1)
            {
                queue2.Enqueue(item);
            }

            var temp = queue1;
            queue1 = queue2;
            queue2 = temp;
        }

        public int Pop()
        {
            return queue1.Dequeue();
        }

        public int Top()
        {
            return queue1.Peek();
        }

        public bool Empty()
        {
            return queue1.Count <= 0;
        }
    }
}
