using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList_App
{
    class MyList<T> : IEnumerable<T>
    {
        private T[] _list;
        private int _count;
        private int _capacity;
        private int _position = -1;

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
                if (index >= 0 && index < _count)
                    return _list[index];
                else
                    Console.WriteLine("Index out of range.");
                return default;
            }
            set
            {
                if (index >= 0 && index < _count)
                    _list[index] = value;
                else
                    Console.WriteLine("Index out of range.");
            }
        }

        public MyList()
        {
            _capacity = 4;
            _list = new T[_capacity];
            _count = 0;
        }
        public MyList(int capacity)
        {
            _capacity = capacity;
            _list = new T[_capacity];
            _count = 0;
        }

        public void CopyTo(T[] array)
        {
            if (_count > array.Length)
                for (int i = 0; i < array.Length; i++)
                    array[i] = _list[i];
            else
                for (int i = 0; i < _count; i++)
                    array[i] = _list[i];
        }

        public void Add(T item)
        {
            if (_count == _capacity)
                Capacity *= 2;
            _list[_count] = item;
            _count++;
        }

        public void Clear()
        {
            _list = new T[_capacity];
            _count = 0;
        }

        //TODO (object)_list[i] == (object)item don't work
        public int IndexOf(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if ((object)_list[i] == (object)item)
                    return i;
            }
            Console.WriteLine("There is no item in this collection.");
            return -1;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index == -1)
                return false;
            else
            {
                T[] array = new T[_count - 1];
                for (int i = 0; i < index; i++)
                    array[i] = _list[i];

                for (int i = index + 1; i < array.Length; i++)
                    array[i] = _list[i];

                _list = array;
                _count--;
                return true;
            }
        }

        private void Reset() => _position = -1;

        public IEnumerator<T> GetEnumerator()
        {
            while (true)
            {
                if (_position < _count - 1)
                {
                    _position++;
                    yield return _list[_position];
                }
                else
                {
                    Reset();
                    yield break;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this as IEnumerator;
        }
    }
}
