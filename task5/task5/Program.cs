using System;
using System.Diagnostics;
using System.Threading.Tasks;

public class ParallelUtils<T, TR>
{
    private readonly Func<T, T, TR> operation;
    private readonly T operand1;
    private readonly T operand2;

    public TR Result { get; private set; }

    public ParallelUtils(Func<T, T, TR> operation, T operand1, T operand2)
    {
        this.operation = operation;
        this.operand1 = operand1;
        this.operand2 = operand2;
    }

    public void StartEvaluation()
    {
        Task.Run(Evaluate);
    }

    public void Evaluate()
    {
        Result = operation(operand1, operand2);
    }
}


class Program
{
    static async Task Main(string[] args)
    {
        Func<int, int, int> addFunction = (a, b) => a + b;
        int operand1 = 45;
        int operand2 = 20;

        ParallelUtils<int, int> parallelUtils = new ParallelUtils<int, int>(addFunction, operand1, operand2);

        parallelUtils.StartEvaluation();
        Task.Delay(100).Wait();
        Console.WriteLine($"Result: {parallelUtils.Result}");

    }
}

