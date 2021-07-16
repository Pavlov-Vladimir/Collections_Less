using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList_App
{
    class MyList<T> : IEnumerable<T>, IEnumerator<T>
    {
        private T[] _list;
        private int _count = 0;
        private int _capacity;

        public int Count => _count;
        public int Capacity
        { 
            get => _list.Length;
            set
            {
                if (_capacity != value)
                {
                    T[] array = new T[value];
                    this.CopyTo(array);
                    _list = array;
                    _capacity = value;
                }
            }
        }
        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < _list.Length)
                    return _list[index];
                Console.WriteLine("Index out of range.");
                return default;
            }
            set
            {
                if (index >= 0 && index < _list.Length)
                    _list[index] = value;
                Console.WriteLine("Index out of range.");
            }
        }

        public void CopyTo(T[] array)
        {
            if(_capacity > array.Length)
                for (int i = 0; i < array.Length; i++)
                    array[i] = _list[i];

            else
                for (int i = 0; i < _capacity; i++)
                    array[i] = _list[i];
        }
    }
}
