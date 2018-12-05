namespace HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type type = typeof(HarvestingFields);

            var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            string command;
            while ((command = Console.ReadLine()) != "HARVEST")
            {
                Func<FieldInfo, bool> condition = x => x.IsPrivate;

                if (command == "public")
                {
                    condition = x => x.IsPublic;
                }
                else if (command == "protected")
                {
                    condition = x => x.IsFamily;
                }                    
                else if (command == "all")
                {
                    condition = x => !x.IsStatic;
                }

                FieldInfo[] fields = type.GetFields(flags);

                foreach (var field in fields.Where(condition))
                {
                    Console.WriteLine($"{field.Attributes.ToString().ToLower().Replace("family", "protected")} {field.FieldType.Name} {field.Name}");
                }
            }            
        }        
    }
}
