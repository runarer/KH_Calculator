
using System.Globalization;
using System.Security.Cryptography;
using Core;
using Spectre.Console;

string[] choices = Enum.GetNames<Choice>();

while (true) {
    //Show menu
    string choiceInput = AnsiConsole.Prompt( new SelectionPrompt<string>()
        .Title("Please select action ([yellow]up[/] and [yellow]down[/], [yellow]enter[/] to select)")
        .AddChoices(choices)
    );

    // Turn input into a enum
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
    
    // Try to convert all numbes to int.
    int index = 0;
    bool integers =  numbersRaw.All(number => int.TryParse(number,out integerNumbers[index++]));

    // Numbers are allready validated to be parseable to double.
    if(!integers)
        desimalNumbers = Array.ConvertAll(numbersRaw,double.Parse);

    string answer = string.Empty;
    switch (choice)
    {
        case Choice.Addition : 
            answer =  integers  ? Calculator.Add(integerNumbers).ToString() 
                                : Calculator.Add(desimalNumbers).ToString();  
            break;
        case Choice.Subtraction :
            answer =  integers  ? Calculator.Add(integerNumbers).ToString() 
                                : Calculator.Add(desimalNumbers).ToString();  
            break;
        case Choice.Division : 
            try {
                answer =  integers  ? Calculator.Add(integerNumbers).ToString() 
                                    : Calculator.Add(desimalNumbers).ToString();
            } catch (DivideByZeroException)
            {
                answer = "NaN";
            }
            break;
        case Choice.Multiplication : 
            answer =  integers  ? Calculator.Add(integerNumbers).ToString() 
                                : Calculator.Add(desimalNumbers).ToString();  
            break;
    }


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
