
class Program
{
    static void Main(string[] args)
    {

        MyLinkedList<int> list = new MyLinkedList<int>();
        var n1 = list.AddFirst(1);
        list.AddFirst(2);
        list.AddFirst(3);
        var n4 = list.AddFirst(4);
        list.AddFirst(5);
        var n6 = list.AddFirst(6);
        list.AddLast(7);
        var n8 = list.AddLast(8);

        list.AddAfter(n1, new MyLinkedListNode<int>(9));

        if (list.Contains(n6))
        {
            Console.WriteLine("List contains the specified node");
        }
        else
        {
            Console.WriteLine("List doesnt contain the specified node");
        }
        var enumerator = list.GetEnumerator();

        while (enumerator.MoveNext())
        {
            var i = enumerator.Current + 10;
            Console.WriteLine(enumerator.Current);
        }
    }

}