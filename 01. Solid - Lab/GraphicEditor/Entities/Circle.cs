namespace GraphicEditor.Entites
{
    using GraphicEditor.Entites.Contracts;

    public class Circle : IShape
    {
        public string Draw()
        {
            return "I am Circle";
        }
    }
}
