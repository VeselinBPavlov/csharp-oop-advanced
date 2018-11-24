namespace GenericScale
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            Scale<int> scale = new Scale<int>(5, 15);
            Console.WriteLine(scale.GetHeavier());
        }
    }
}
