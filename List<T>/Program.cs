namespace CustomList
{
    class CustomList<T>
    {
        private T[] _items;
        private int _count = 0;
        public CustomList()
        {
            _items = new T[4];
        }

        public int Count
        {
            get
            {
                return _count;
            }
        }

        public void Add(T item)
        {
            if (_count == _items.Length)
            {
                var _newItems = new T[_items.Length * 2];
                for (int i = 0; i < _items.Length; i++)
                {
                    _newItems[i] = _items[i];
                }
                _items = _newItems;
            }

            _items[_count] = item;
            _count++;
        }

        public bool Contains(T item)
        {
            int i = 0;
            if(_items == null)
                return false;

            while (i < _items.Length && !_items[i].Equals(item))
            { 
                i++;
            }
            if(i != _items.Length)
                return true;
            
            return false;
        }
        public bool Remove(T item)
        {
            if (_items == null || _count == 0)
                return false;

            int i = 0;

            //karayi sra poxaren im impelemntac contains-y use anei
            while (i < _items.Length && !_items[i].Equals(item))
            {
                i++;
            }
            if(i == _items.Length)
                return false;
            var newLenght = _count - 1;
            var _newItems = new T[_items.Length];

            for (int j = 0; j < i; j++)
            {
                _newItems[j] = _items[j];
            }
            for (int j = i; j < newLenght; j++)
            {
                _newItems[j] = _items[j+1];
            }
            _items = _newItems;
            _count--;
            return true;
           
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                Console.WriteLine("Invalid index");
            }
            var newLenght = _count - 1;
            var _newItems = new T[_items.Length];

            for (int j = 0; j < index; j++)
            {
                _newItems[j] = _items[j];
            }
            for (int j = index; j < newLenght; j++)
            {
                _newItems[j] = _items[j + 1];
            }
            _items = _newItems;
            _count--;
        }

        public void Clear()
        {
            var clearList = new T[_items.Length];
            _items = clearList;

            _count = 0;
        }

        public void InsertAt(int index, T item)
        {
            if (index < 0 || index >= _count)
            {
                Console.WriteLine("Invalid index");
            }
            if (_count == _items.Length)
            {
                var _newItems = new T[_items.Length * 2];
                for (int i = 0; i < _items.Length; i++)
                {
                    _newItems[i] = _items[i];
                }
                _items = _newItems;
            }
            var _newitems = new T[_items.Length]; 
            int k;
            for ( k = 0; k < index; k++)
            {
                _newitems[k] = _items[k];
            }
            
            _newitems[k++] = item;
            
            for (int j = k; j < _items.Length; j++)
            {
                _newitems[j] = _items[j - 1];
            }
            _items = _newitems;
        }
       
        public void Print()
        {
            for (int i = 0; i < _items.Length; i++)
            {
                Console.WriteLine(_items[i]);
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
           CustomList<int> customList = new CustomList<int>();
            customList.Add(1);
            customList.Add(2);
            customList.Add(3);
            customList.Add(4);
            customList.Add(5);
            customList.Add(6);
            
            //removing
            customList.Remove(2);
            //checking if exists
            bool f = customList.Contains(3);
            Console.WriteLine(f);
           
            //removing at
            customList.RemoveAt(1);
            
            //inserting at
            customList.InsertAt(1, 100);

            //clearing
            customList.Clear();
            customList.Print();
        }
    }
}
