using System;
using System.Collections;
using System.Collections.Generic;

namespace MyDictionary_App
{
    class MyDictionary <Tkey, Tvalue> : IEnumerable<KeyValuePair<Tkey, Tvalue>>
    {
        KeyValuePair<Tkey, Tvalue>[] _dictionary = null;
        private int _count;
        private int _capacity;
        private int _position = -1;

        public int Count => _count;
        public int Capacity
        {
            get => _dictionary.Length;
            set
            {
                if (_capacity != value)
                {
                    KeyValuePair<Tkey, Tvalue>[] array = new KeyValuePair<Tkey, Tvalue>[value];
                    for (int i = 0; i < _count; i++)
                        array[i] = _dictionary[i];

                    _dictionary = array;
                    _capacity = value;
                }
            }
        }

        public MyDictionary() : this(4)
        {
        }
        public MyDictionary(int capasity)
        {
            _capacity = capasity;
            _dictionary = new KeyValuePair<Tkey, Tvalue>[_capacity];
            _count = 0;
        }

        public Tvalue this[Tkey key]
        {
            get
            {
                if (ContainsKey(key))
                    return GetValue(key);
                else
                    Console.WriteLine("There is no such key in the dictionary.");
                return default;
            }
            set
            {
                if (ContainsKey(key))
                    SetValue(key, value);
                else
                    Add(key, value);
            }
        }

        public void Add(Tkey key, Tvalue value)
        {
            if (ContainsKey(key))
                SetValue(key, value);
            else
            {
                if (_count == _capacity)
                    Capacity *= 2;
                _dictionary[_count] = new KeyValuePair<Tkey, Tvalue>(key, value);               
                _count++;
            }
        }

        private void SetValue(Tkey key, Tvalue value)
        {
            for (int i = 0; i < _count; i++)
                if (_dictionary[i].Key.Equals(key))
                {
                    _dictionary[i].Value = value;
                    return;
                }
        }

        private Tvalue GetValue(Tkey key)
        {
            for (int i = 0; i < _count; i++)
                if (_dictionary[i].Key.Equals(key))
                    return _dictionary[i].Value;

            return default;
        }

        public bool ContainsKey(Tkey key)
        {
            for (int i = 0; i < _count; i++)
                if (_dictionary[i].Key.Equals(key))
                    return true;

            return false;
        }

        public bool ContainsValue(Tvalue value)
        {
            for (int i = 0; i < _count; i++)
                if (_dictionary[i].Value.Equals(value))
                    return true;

            return false;
        }

        public void Remove(Tkey key)
        {
            if (ContainsKey(key))
            {
                var array = new KeyValuePair<Tkey, Tvalue>[_capacity];
                for (int i = 0, j = 0; i < _count; i++, j++)
                {
                    if (_dictionary[i].Key.Equals(key))
                        i++;
                    array[j] = _dictionary[i];
                }
                _dictionary = array;
                _count--;
            }
            else
                Console.WriteLine("There is no such key in the dictionary.");
        }

        public void Clear()
        {
            _capacity = 4;
            _dictionary = new KeyValuePair<Tkey, Tvalue>[_capacity];
            _count = 0;
        }

        public override string ToString()
        {
            string stringDicionary;
            if (_count == 0)
            {
                stringDicionary = "The dictionary is empty.";
            }
            else
            {
                stringDicionary = "The dictionary has:\n";
                foreach (var pair in _dictionary)
                {
                    if (pair == null)
                        break;
                    stringDicionary += $" {pair.ToString()}\n";
                } 
            }
            return stringDicionary;
        }

        public IEnumerator<KeyValuePair<Tkey, Tvalue>> GetEnumerator()
        {
            while (true)
            {
                if (_position < _count - 1)
                {
                    _position++;
                    yield return _dictionary[_position];
                }
                else
                {
                    Reset();
                    yield break;
                }
            }
        }

        private void Reset() => _position = -1;
        

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this as IEnumerator;
        }
    }
}
