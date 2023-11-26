class Program
{
    static void Main()
    {
        Calculator calculator = new Calculator();
        calculator.RunApp();
    }
}

public class Calculator
{
    public void RunApp()
    {
        Menu();
        string request = Console.ReadLine();
        while (request != "0")
        {
            Console.ResetColor();
            switch (request)
            {
                case "1":
                    Calculate();
                    break;
                default:
                    resultColor(true);
                    Console.WriteLine("Invalid Option!");
                    break;
            }
            Console.ResetColor();
            Menu();
            request = Console.ReadLine();
        }
    }
    void Menu()
    {
        Console.WriteLine("1.Calculate");
        Console.WriteLine("0.Close");
    }

    void Calculate()
    {
        Console.WriteLine("Input your operation:");
        string input = Console.ReadLine();

        int operatorIndex = input.IndexOf('+');
        if (operatorIndex == -1)
        {
            operatorIndex = input.IndexOf('-');
            if (operatorIndex == -1)
            {
                operatorIndex = input.IndexOf('*');
                if (operatorIndex == -1)
                {
                    operatorIndex = input.IndexOf('/');
                }
            }
        }

        if (operatorIndex != -1)
        {
            string num1String = input.Substring(0, operatorIndex);
            string num2String = input.Substring(operatorIndex + 1);

            if (int.TryParse(num1String, out int num1) && int.TryParse(num2String, out int num2))
            {
                char op = input[operatorIndex];

                int result = 0;
                switch (op)
                {
                    case '+':
                        result = num1 + num2;
                        break;
                    case '-':
                        result = num1 - num2;
                        break;
                    case '*':
                        result = num1 * num2;
                        break;
                    case '/':
                        if (num2 != 0)
                        {
                            result = num1 / num2;
                        }
                        else
                        {
                            resultColor(true);
                            Console.WriteLine("Error: Division by zero.");
                            return;
                        }
                        break;
                    default:
                        resultColor(true);
                        Console.WriteLine("Error: Unsupported operator.");
                        return;
                }
                resultColor(false);
                Console.WriteLine($"{num1} {op} {num2} = {result}");
            }
            else
            {
                resultColor(true);
                Console.WriteLine("Error: Unable to parse numbers.");
            }
        }
        else
        {
            resultColor(true);
            Console.WriteLine("No operator found in the input.");
        }
    }
    void resultColor(bool b)
    {
        if (b)
            Console.ForegroundColor = ConsoleColor.Red;
        else
            Console.ForegroundColor = ConsoleColor.Green;
    }
}