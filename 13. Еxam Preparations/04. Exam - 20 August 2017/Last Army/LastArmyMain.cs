﻿public class LastArmyMain
{
    public static void Main()
    {
        IReader reader = new ConsoleReader();
        IWriter writer = new ConsoleWriter();
        GameController gameController = new GameController(writer);
        Engine engine = new Engine(reader, writer, gameController);

        engine.Run();
    }
}