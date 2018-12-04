using System;

class StartUp
{
    static void Main()
    {
        Spy spy = new Spy();
        var result = spy.CollectGettersAndSetters("Hacker");

        Console.WriteLine(result);
    }
}

