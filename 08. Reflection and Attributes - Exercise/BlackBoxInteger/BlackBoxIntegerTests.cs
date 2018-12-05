namespace BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type type = typeof(BlackBoxInteger);
            BindingFlags flags = BindingFlags.Instance | BindingFlags.NonPublic;
            ConstructorInfo constructor = type.GetConstructor(flags, null, new Type[] { typeof(int) }, null);
            BlackBoxInteger instance = (BlackBoxInteger)constructor.Invoke(new object[] { 0 });
            FieldInfo field = type.GetField("innerValue", flags);

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var data = command.Split('_');
                var methodName = data[0];
                var number = int.Parse(data[1]);

                MethodInfo method = type.GetMethod(methodName, flags);
                method.Invoke(instance, new object[] { number });

                Console.WriteLine(field.GetValue(instance));
            }
        }
    }
}
