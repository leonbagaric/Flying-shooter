using System;

public abstract class FlyingObject
{
    private Tuple<int, int> position = new(0,0);
    public char skin;
    public int hp;

    public Tuple<int,int> Position
    {
        get { return position;}
        set { position = value;}
    }
}

public class PlayerObject : FlyingObject
{
    
    public PlayerObject(int width)
    {
        this.skin = '╩';
        Position = new Tuple<int, int>(width / 2, 1);
    }
        

    public void Move(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.A:
            case ConsoleKey.LeftArrow:
                Position = new Tuple<int, int>(Position.Item1 - 1, Position.Item2);
                break;
            case ConsoleKey.D:
            case ConsoleKey.RightArrow:
                Position = new Tuple<int, int>(Position.Item1 + 1, Position.Item2);
                break;
            default:
                break;
        }
    }

    public Rockets Shoot()
    {
        return new Rockets(Position.Item1);
    }

}


public class Enemy : FlyingObject
{
    Random rnd;                                                                 

    public Enemy(int width, int height)
    {
        rnd = new Random();
        this.Position = new Tuple<int, int>(rnd.Next(1, width), height - 1);
        this.skin = '¤';
    }
}

public class Rockets : FlyingObject
{
    public Rockets(int positionX)
    {
        this.Position = new Tuple<int, int>(positionX, 2);
    }

    public void Move()
    {
        this.Position = new Tuple<int, int>(this.Position.Item1, Position.Item2+1);
    }
}
