namespace GraphicEditor.Core
{
    using global::GraphicEditor.Entites.Contracts;
    using System;

    public class GraphicEditor
    {
        public void DrawShape(IShape shape)
        {
            Console.WriteLine(shape.Draw());
        }
    }
}
