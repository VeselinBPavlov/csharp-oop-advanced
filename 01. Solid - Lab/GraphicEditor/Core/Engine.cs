namespace GraphicEditor.Core
{
    using global::GraphicEditor.Entites;
    using global::GraphicEditor.Entites.Contracts;

    public class Engine
    {
        public void Run()
        {
            IShape rectangle = new Rectangle();
            IShape circle = new Circle();
            IShape sqare = new Square();

            GraphicEditor graphicEditor = new GraphicEditor();
            graphicEditor.DrawShape(rectangle);
            graphicEditor.DrawShape(circle);
            graphicEditor.DrawShape(sqare);
        }
    }
}
