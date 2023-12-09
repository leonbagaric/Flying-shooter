using System;

public class Game
{
    public int width, height;
    public bool isRunning = false;

    public void Run()
    {
        isRunning = true;
        PlayerObject player = new(width);

        new Thread(delegate ()
        {
            InputManager(player);
        }).Start();

        GameLoop();
    }
    public void InputManager(PlayerObject player)
    {
        while (isRunning)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                player.Move(key.Key);
            }
            Thread.Sleep(250);
        }
    }
    public void GameLoop()
    {

        while (isRunning)
        {
            Render();
        }
    }
    public void Render()
    {
        
        Console.Clear();
        for (int y = this.height - 1; y >= 0; y--)
        {
            for (int x = 0; x < this.width; x++)
            {
                if (x == 0 && y == 0)
                {
                    Console.Write('└');
                }
                else if (x == this.width - 1 && y == 0)
                {
                    Console.Write('┘');
                }
                else if (x == 0 && y == this.height - 1)
                {
                    Console.Write('┌');
                }
                else if (x == this.width - 1 && y == this.height - 1)
                {
                    Console.Write('┐');
                }
                else if (x == 0 || x == this.width - 1)
                {
                    Console.Write('│');
                }
                else if (y == 0 || y == this.height - 1)
                {
                    Console.Write('─');
                }
                else
                {
                    Console.Write(' ');
                }
            }
            Console.Write('\n');
        }
        Thread.Sleep(250);
    }
}