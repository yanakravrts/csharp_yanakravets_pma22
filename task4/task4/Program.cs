using System;

public interface ISwimmable
{
    void Swim()
    {
        Console.WriteLine("I can swim!");
    }
}

public interface IFlyable
{
    int MaxHeight { get; }

    void Fly()
    {
        Console.WriteLine($"I can fly at {MaxHeight} meters height!");
    }
}

public interface IRunnable
{
    int MaxSpeed { get; }

    void Run()
    {
        Console.WriteLine($"I can run up to {MaxSpeed} kilometers per hour!");
    }
}

public interface IAnimal
{
    int LifeDuration { get; }

    void Voice()
    {
        Console.WriteLine("No voice!");
    }

    void ShowInfo()
    {
        Console.WriteLine($"I am a {GetType().Name} and I live approximately {LifeDuration} years.");
    }
}

public class Cat : IAnimal, IRunnable
{
    public int MaxSpeed { get; } = 48; 

    public int LifeDuration { get; } = 16; 

    public void Voice()
    {
        Console.WriteLine("Meow!");
    }

    public void Run()
    {
        Console.WriteLine($"I can run up to {MaxSpeed} kilometers per hour!");
    }

    public void ShowInfo()
    {
        Console.WriteLine($"I am a Cat and I live approximately {LifeDuration} years.");
    }
}

public class Eagle : IAnimal, IFlyable
{
    public int MaxHeight { get; } = 8000; 

    public int LifeDuration { get; } = 40; 

    public void Fly()
    {
        Console.WriteLine($"I can fly at {MaxHeight} meters height!");
    }

    public void ShowInfo()
    {
        Console.WriteLine($"I am an Eagle and I live approximately {LifeDuration} years.");
    }
}

public class Shark : IAnimal, ISwimmable
{
    public int LifeDuration { get; } = 25; 

    public void Swim()
    {
        Console.WriteLine("I can swim!");
    }

    public void ShowInfo()
    {
        Console.WriteLine($"I am a Shark and I live approximately {LifeDuration} years.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Cat cat = new Cat();
        cat.ShowInfo(); 
        cat.Run(); 
        cat.Voice(); 

        Console.WriteLine();

        Eagle eagle = new Eagle();
        eagle.ShowInfo(); 
        eagle.Fly(); 

        Console.WriteLine();

        Shark shark = new Shark();
        shark.ShowInfo(); 
        shark.Swim(); 
    }
}
