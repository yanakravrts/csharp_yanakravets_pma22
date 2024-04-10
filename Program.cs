class MyAccessModifiers
{
    private int birthYear
    { get; set; }
    protected string personalInfo
    { get; set; }
    internal string IdNumber
    { get; set; }


    public MyAccessModifiers(int birthYear, string IdNumber, string personalInfo)
    {
        this.birthYear = birthYear;
        IdNumber = IdNumber;
        this.personalInfo = personalInfo;
    }

    public int UserAge
    {
        get
        {
            return DateTime.Now.Year - birthYear;
        }
    }

    public static byte averageMiddleAge
    { get; set; } = 50;
    public string Name
    { get; set; }
    public string NickName
    {
        get
        {
            return Name + IdNumber;
        }
        internal set
        {
           
        }
    }

    protected internal void HasLivedHalfOfLife()
    {
        if (UserAge >= averageMiddleAge)
        {
            Console.WriteLine("User has lived half of life");
        }
        else
        {
            Console.WriteLine("User hasn't lived half of life");
        }
    }

    public static bool operator ==(MyAccessModifiers modifier1, MyAccessModifiers modifier2)
    {
        if (ReferenceEquals(modifier1, modifier2))
            return true;
        if (modifier1 is null || modifier2 is null)
            return false;
        return modifier1.Name == modifier2.Name && modifier1.UserAge == modifier2.UserAge && modifier1.personalInfo == modifier2.personalInfo;
    }

    public static bool operator !=(MyAccessModifiers modifier1, MyAccessModifiers modifier2)
    {
        return !(modifier1 == modifier2);
    }


    public virtual void Input()
    {
        Console.Write("Enter your birth year: ");
        birthYear = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter your ID number: ");
        IdNumber = Console.ReadLine();
        Console.Write("Enter your personal information: ");
        personalInfo = Console.ReadLine();
        Console.Write("Enter your name: ");
        Name = Console.ReadLine();
    }

    public void Output()
    {
        Console.WriteLine($"Name: {Name} ,Birth Year: {birthYear}, Age: {UserAge}, ID Number: {IdNumber}, Personal Info: {personalInfo}, Nickname: {NickName}");
    }

}

class task1
{
    static void Main(string[] args)
    {
        Console.Write("Enter number of users: ");
        int numOfUsers = Convert.ToInt32(Console.ReadLine());

        List<MyAccessModifiers> usersList = new List<MyAccessModifiers>();

        for (int i = 0; i < numOfUsers; i++)
        {
            Console.WriteLine($"\nEnter details for User {i + 1}:");
            MyAccessModifiers user = new MyAccessModifiers(0, "", "");
            user.Input();
            usersList.Add(user);
        }

        foreach (var user in usersList)
        {
            Console.WriteLine("Details about user: ");
            user.Output();
            user.HasLivedHalfOfLife();
        }

        for (int i = 0; i < usersList.Count - 1; i++)
        {
            for (int j = i + 1; j < usersList.Count; j++)
            {
                Console.WriteLine($"\nComparing User {i + 1} with User {j + 1}:");
                if (usersList[i] == usersList[j])
                {
                    Console.WriteLine("Users are equal.");
                }
                else
                {
                    Console.WriteLine("Users are not equal.");
                }
            }
        }
    }
}