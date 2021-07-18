namespace MyDictionary_App
{
    class KeyValuePair<Tkey, Tvalue>
    {
        public Tkey Key { get; set; }
        public Tvalue Value { get; set; }

        public KeyValuePair(Tkey key, Tvalue value)
        {
            Key = key;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Key} - {Value}";
        }
    }
}
