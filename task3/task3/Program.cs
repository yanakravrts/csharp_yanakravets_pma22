public delegate double CalcDelegate(double a, double b, char operation);

public class CalcProgram
{
    public static double Calc(double a, double b, char operation)
    {
        switch (operation)
        {
            case '+':
                return a + b;
            case '-':
                return a - b;
            case '*':
                return a * b;
            case '/':
                if (b != 0)
                    return a / b;
                else
                    return 0; 
            default:
                throw new ArgumentException("Invalid operation");
        }
    }

    public static CalcDelegate funcCalc = new CalcDelegate(Calc);
}

class Program
{
    static void Main(string[] args)
    {
        bool continueCalculating = true;

        while (continueCalculating)
        {
            Console.WriteLine("Enter the first number:");
            double a = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the second number:");
            double b= double.Parse(Console.ReadLine());

            Console.WriteLine("Enter the operation (+, -, *, /):");
            char operation = char.Parse(Console.ReadLine());

            Console.WriteLine($"Result: {CalcProgram.funcCalc(a, b, operation)}");

            Console.WriteLine("Do you want to continue calculation? (y/n)");
            char choice = char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine();

            continueCalculating = (choice == 'y');
        }
    }
}