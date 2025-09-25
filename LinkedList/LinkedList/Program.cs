namespace LinkedList
{
    public class Node<T>
    {
        public T? value;
        public Node<T>? next;
    }

    public class LinkedList<T> : Node<T>
    {
        Node<T>? head;
        public bool IsCyclic(Node<T> head)
        {
            if (head == null)
            {
                return false;
            }
           
            Node<T>? fastStep = head;
            Node<T>? slowStep = head;

            while (fastStep! != null && fastStep!.next != null)
            {
                fastStep = fastStep.next.next;
                slowStep = slowStep.next;
               if(fastStep == slowStep)
                    return true;
            }
            return false; 
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            Node<int> n1 = new ();
            Node<int> n2 = new ();
            Node<int> n3 = new ();
            Node<int> n4 = new ();
            Node<int> n5 = new ();

            n1.value = 1;
            n2.value = 2;
            n3.value = 3;
            n4.value = 4;
            n5.value = 5;

            n1.next = n2;
            n2.next = n3;
            n3.next = n4;
            n4.next = n5;
            n5.next = n3;

            if (linkedList.IsCyclic(n1))
            {
                Console.WriteLine("List is cyclic");
            }
            else { 
                Console.WriteLine("List isnt cyclic");
            }
        }
    }
}
