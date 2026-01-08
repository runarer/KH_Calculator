using Spectre.Console;

string[] choices = ["Addition", "Subtraction", "Multiplication","Division","Exit"];

while (true) {
    string choice = AnsiConsole.Prompt( new SelectionPrompt<string>()
        .Title("Please select action (up and down, enter to select)")
        .AddChoices(choices)
    );

    if(choice == choices[^1])
        break;


}