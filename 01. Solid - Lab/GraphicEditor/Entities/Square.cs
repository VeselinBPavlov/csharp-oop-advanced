namespace GraphicEditor.Entites
{
    using GraphicEditor.Entites.Contracts;

    public class Square : IShape
    {
        public string Draw()
        {
            return "I am square";
        }
    }
}
