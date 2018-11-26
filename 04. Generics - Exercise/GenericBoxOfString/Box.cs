namespace GenericBoxOfString
{
    public class Box<T>
    {
        public T Value { get; set; }

        public override string ToString()
        {
            return $"System.{this.Value.GetType().Name}: {this.Value}";            
        }
    }
}
