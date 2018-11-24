namespace Logger.Layouts.Factory
{
    using Contracts;
    using Logger.Layouts.Contracts;
    using System;

    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            type = type.ToLower();

            switch (type)
            {
                case "simplelayout": return new SimpleLayout();
                case "xmllayout": return new XmlLayout();
                default: throw new ArgumentException("Invalid layout type!");
            }
        }
    }
}
