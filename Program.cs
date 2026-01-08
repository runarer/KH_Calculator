using Spectre.Console;

string[] choices = ["Addition", "Subtraction", "Multiplication","Division","Exit"];

while (true) {
    //Show menu
    string choice = AnsiConsole.Prompt( new SelectionPrompt<string>()
        .Title("Please select action ([yellow]up[/] and [yellow]down[/], [yellow]enter[/] to select)")
        .AddChoices(choices)
    );

    // Exit?
    if(choice == choices[^1])
        break;

    // Ask user to input numbers
    // string numbersRaw = AnsiConsole.Ask<string>("Enter numbers (separeted by [yellow]space[/]):");

    var inputPrompt = new TextPrompt<string>("Enter numbers (separeted by [yellow]space[/]):")
        .Validate( line =>
        {
            string[] numbersRaw = line.Split(' ',StringSplitOptions.RemoveEmptyEntries);
            
            if(numbersRaw.Length < 2)
            {
                return ValidationResult.Error("[red]You must enter atleast two numbers![/]");
            }

            return ValidationResult.Success();
        });
    
    var result = AnsiConsole.Prompt(inputPrompt);
}