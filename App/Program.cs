
using System.Globalization;
using Core;
using Spectre.Console;

string[] choices = Enum.GetNames<Choice>();

while (true) {
    //Show menu
    string choiceInput = AnsiConsole.Prompt( new SelectionPrompt<string>()
        .Title("Please select action ([yellow]up[/] and [yellow]down[/], [yellow]enter[/] to select)")
        .AddChoices(choices)
    );

    // _ = Enum.TryParse(choiceInput, out Choice choice);
    Choice choice = Enum.Parse<Choice>(choiceInput);

    // Exit?
    if(choice == Choice.Exit)
        break;

    //Get correct desimal seperator
    string decimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

    // Ask user to input numbers, and validates answer
    var inputPrompt = new TextPrompt<string>($"Enter numbers (separeted by [yellow]space[/], use [yellow]{decimalSeparator}[/] for decimals):")
        .Validate( line =>
        {
            string[] numbersRaw = line.Split(' ',StringSplitOptions.RemoveEmptyEntries);
            
            if(numbersRaw.Length < 2)
            {
                return ValidationResult.Error("[red]You must enter atleast two numbers![/]");
            }

            foreach (var number in numbersRaw)
            {
                if (!double.TryParse(number, out double _))
                    return ValidationResult.Error($"[red]Can't convert[/] {number} [red]to a number![/]");
            }

            return ValidationResult.Success();
        });    
    string result = AnsiConsole.Prompt(inputPrompt);


    // Convert to numbers
    string[] numbersRaw = result.Split(' ',StringSplitOptions.RemoveEmptyEntries);

    int[] integerNumbers = new int[numbersRaw.Length];
    double[] desimalNumbers = new double[numbersRaw.Length];
    
    int index = 0;
    bool integers =  numbersRaw.All(number => int.TryParse(number,out integerNumbers[index++]));

    // Numbers are allready validated to be parseable to double.
    if(!integers)
        desimalNumbers = Array.ConvertAll(numbersRaw,double.Parse);

    

    // Do the calculation
    string answer = integers ?  Calculators.Calculate(integerNumbers,choice) : 
                                Calculators.Calculate(desimalNumbers,choice) ; 

    AnsiConsole.MarkupLineInterpolated($"{choice} on {result} = [green]{answer}[/]");
    Console.ReadKey();

}








public enum Choice
{
    Addition,
    Subtraction, 
    Multiplication,
    Division,
    Exit,
}


public static class Calculators
{
    public static string Calculate(int[] numbers,Choice operation) => operation switch
    {
        Choice.Addition => Calculator.Add(numbers).ToString(),
        Choice.Subtraction => Calculator.Sub(numbers).ToString(),
        Choice.Multiplication => Calculator.Multi(numbers).ToString(),
        Choice.Division => Calculator.Div(numbers).ToString(), 
        _ => throw new NotImplementedException(),
    };

    public static string Calculate(double[] numbers,Choice operation) => operation switch
    {
        Choice.Addition => Calculator.Add(numbers).ToString(),
        Choice.Subtraction => Calculator.Sub(numbers).ToString(),
        Choice.Multiplication => Calculator.Multi(numbers).ToString(),
        Choice.Division => Calculator.Div(numbers).ToString(), 
        _ => throw new NotImplementedException(),
    };
}
