public class Employee
{
    internal string name;
    private DateTime hiringDate;

    public Employee(string name, DateTime hiringDate)
    {
        this.name = name;
        this.hiringDate = hiringDate;
    }

    public int Experience()
    {
        DateTime current = DateTime.Now;
        int experience = current.Year - hiringDate.Year;
        if (current.Month < hiringDate.Month || (current.Month == hiringDate.Month && current.Day < hiringDate.Day))
        {
            experience--;
        }

        return experience;
    }
    
    public virtual void ShowInfo()
    {
        Console.WriteLine($"{name} has {Experience()} years of experience");
    }
}

public class Developerr : Employee
{
    private string programmingLanguage;

    public Developerr(string name, DateTime hiringDate, string programmingLanguage) : base(name, hiringDate)
    {
        this.programmingLanguage = programmingLanguage;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"{name} is {programmingLanguage} programmer");
    }
}

public class Tester : Employee
{
    private bool isAuthomation;

    public Tester(string name, DateTime hiringDate, bool isAuthomation) : base(name, hiringDate)
    {
        this.isAuthomation = isAuthomation;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        string type = isAuthomation ? "authomated" : "manual";
        Console.WriteLine($"{name} is {type} tester");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Developer:");
        Developerr developer = new Developerr("Austin", new DateTime(2020,10,12),"Python");
        developer.ShowInfo();

        Console.WriteLine("\nTesters:");
        Tester tester1 = new Tester("Max", new DateTime(2017, 02, 15), true);
        tester1.ShowInfo();

        Tester tester2 = new Tester("Nina", new DateTime(2022, 11, 21), false);
        tester2.ShowInfo();
    }
}