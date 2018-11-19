namespace GraphicEditor.Entites
{
    using GraphicEditor.Entites.Contracts;

    public class Rectangle : IShape
    {
        public string Draw()
        {
            return "I am Rectangle";
        }
    }
}
