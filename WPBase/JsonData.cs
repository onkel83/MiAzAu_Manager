namespace WPBase
{
    public class JsonData<T>
    {
        public T? Value { get; set; } = default(T);
        public string Command { get; set; } = string.Empty;
        public string Response { get; set; } = string.Empty;
    }
}
