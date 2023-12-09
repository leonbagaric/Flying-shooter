using System;

public class Game
{
    public int width, height;
    public bool isRunning = false;
    public PlayerObject player;

    public Game(int width, int height)
    {
        this.width = width;
        this.height = height;

        this.player = new(width);
        Run();
    }
    public Game()
    {
        this.width=60;
        this.height=40;

        this.player = new(this.width);
        Run();
    }

    public void Run()
    {
        isRunning = true;
        Synchronize();
    }
    public async Task Synchronize()
    {
        while(isRunning)
        {
            await InputManager(player);
            Render();
            Thread.Sleep(100);
        }
        
    }
    public async Task InputManager(PlayerObject player)
    {
        if (Console.KeyAvailable && isRunning)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            player.Move(key.Key);
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
        Console.WriteLine($"Player pos: {player.Position}");

    }
}