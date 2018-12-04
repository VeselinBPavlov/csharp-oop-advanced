using System;
using System.Reflection;
using System.Text;

public class Spy
{
    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);
        object classInstance = Activator.CreateInstance(classType);

        var allFields = classType.GetFields((BindingFlags)62);
        var privateMethods = classType.GetMethods((BindingFlags.NonPublic | BindingFlags.Instance));
        var publicMethods = classType.GetMethods((BindingFlags.Public | BindingFlags.Instance));
        var sb = new StringBuilder();

        foreach (var field in allFields)
        {
            if (field.IsPublic)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
        }

        foreach (var method in privateMethods)
        {
            if (method.Name.Contains("get"))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
        }

        foreach (var method in publicMethods)
        {
            if (method.Name.Contains("set"))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }
        }

        return sb.ToString().TrimEnd();
    }
}

