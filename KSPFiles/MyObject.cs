namespace KSPFiles
{
    public class MyObject
    {
        public string Key { get; set; }
        public object Value { get; set; }

        public MyObject(String key, object value)
        {
            Key = key;
            Value = value;
        }
    }
}