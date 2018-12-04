using System;

public class StartUp
{
    static void Main()
    {
        Spy spy = new Spy();
        var result = spy.AnalyzeAcessModifiers("Hacker");

        Console.WriteLine(result);
    }
}

