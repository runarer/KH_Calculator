
using System.Globalization;
using Spectre.Console;

string[] cs  = [..Enum.GetValues<Choice>().Select( c => c.ToString())];

while (true) {
    //Show menu
    string choiceInput = AnsiConsole.Prompt( new SelectionPrompt<string>()
        .Title("Please select action ([yellow]up[/] and [yellow]down[/], [yellow]enter[/] to select)")
        .AddChoices(cs)
    );

    _ = Enum.TryParse(choiceInput, out Choice choice);

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
    
    var result = AnsiConsole.Prompt(inputPrompt);


}
enum Choice
{
    Addition,
    Subtraction, 
    Multiplication,
    Division,
    Exit,
}

