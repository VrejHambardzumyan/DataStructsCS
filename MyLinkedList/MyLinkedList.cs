using System.Collections;
public class MyLinkedList<T> : IEnumerable<T>, IEnumerator<T>
{
    private object? _current;
    private T _current1;
    public MyLinkedListNode<T>? Head { get; private set; }
    public MyLinkedListNode<T>? Tail { get; private set; }
    public int Count { get; private set; }

    public MyLinkedListNode<T> AddFirst(T value)
    {
        var newNode = new MyLinkedListNode<T>(value);
        AddFirst(newNode);
        return newNode;
    }

    public void AddFirst(MyLinkedListNode<T> newNode)
    {
        if (Head == null)
        {
            InsertIntoEmptyList(newNode);
        }
        else
        {
            InsertBefore(Head, newNode);
        }
    }

    public MyLinkedListNode<T> AddLast(T value)
    {
        var newNode = new MyLinkedListNode<T>(value);
        AddLast(newNode);
        return newNode;
    }

    public void AddLast(MyLinkedListNode<T> newNode)
    {
        if (Tail == null)
        {
            InsertIntoEmptyList(newNode);
        }
        else
        {
            InsertAfter(Tail, newNode);
        }
    }

    public void AddAfter(MyLinkedListNode<T> node, MyLinkedListNode<T> newNode)
    {
        InsertAfter(node, newNode);
    }

    public MyLinkedListNode<T> AddAfter(MyLinkedListNode<T> node, T value)
    {
        var newNode = new MyLinkedListNode<T>(value);
        InsertAfter(node, newNode);
        return newNode;
    }

    public void AddBefore(MyLinkedListNode<T> node, MyLinkedListNode<T> newNode)
    {
        InsertBefore(node, newNode);
    }

    public MyLinkedListNode<T> AddBefore(MyLinkedListNode<T> node, T value)
    {
        var newNode = new MyLinkedListNode<T>(value);
        InsertBefore(node, newNode);
        return newNode;
    }

    public void Remove(MyLinkedListNode<T> node)
    {
        if (Head == node)
        {
            Head = Head.Next;
            if (Head != null)
            {
                Head.Previous = null;
            }

            if (Count == 1)
            {
                Tail = null;
            }
            Count--;
            return;
        }

        if (Tail == node)
        {
            Tail = Tail.Previous;
            if (Tail != null)
            {
                Tail.Next = null;
            }
            Count--;
            return;
        }

        node.Previous!.Next = node.Next;
        node.Next!.Previous = node.Previous;
        Count--;
    }

    private void InsertIntoEmptyList(MyLinkedListNode<T> node)
    {
        Head = node;
        Tail = node;
        Count++;
    }

    private void InsertBefore(MyLinkedListNode<T> node, MyLinkedListNode<T> newNode)
    {
        var previous = node.Previous;

        newNode.Next = node;
        node.Previous = newNode;

        if (previous != null)
        {
            previous.Next = newNode;
            newNode.Previous = previous;
        }

        if (node == Head)
        {
            Head = newNode;
        }

        Count++;
    }

    public void InsertAfter(MyLinkedListNode<T> node, MyLinkedListNode<T> newNode)
    {
        var next = node.Next;

        node.Next = newNode;
        newNode.Previous = node;

        if (next != null)
        {
            next.Previous = newNode;
            newNode.Next = next;
        }

        if (node == Tail)
        {
            Tail = newNode;
        }

        Count++;
    }

    public bool Contains(MyLinkedListNode<T> nodeToFind)
    {
        if (this.Count == 0) return false;
        foreach (var element in this)
        {
            if (element!.Equals(nodeToFind.Value))
            {
                return true;
            }
        }
        return false;
    }

    public void Print()
    {
        var temp = Head;
        while (temp != null)
        {
            Console.WriteLine(temp.Value);
            temp = temp.Next;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Dispose()
    {
        // TODO release managed resources here
    }

    private bool ForeachStart = false;
    private MyLinkedListNode<T> temp;
    public bool MoveNext()
    {
        if (ForeachStart == false)
        {
            ForeachStart = true;
            temp = Head;
        }

        if (temp != null)
        {
            _current1 = temp.Value;
            temp = temp.Next;
            return true;
        }

        Reset();
        return false;
    }

    public void Reset()
    {
        ForeachStart = false;
    }

    T IEnumerator<T>.Current => _current1;

    object? IEnumerator.Current => _current;
}


public class MyLinkedListNode<T>
{
    public T Value { get; set; }

    public MyLinkedListNode<T>? Next { get; set; }

    public MyLinkedListNode<T>? Previous { get; set; }

    public MyLinkedListNode(T value)
    {
        Value = value;
    }
}