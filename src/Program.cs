using Spectre.Console;

namespace WildLifeSpotter;

class Program
{
    static void Main()
    {

        var saveChoice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("Welcome! To the Wildlife Spotter.")
            .AddChoices(new[] {
                "New Save", "Load Save"
            })
        );

        Save save = new Save();

        switch (saveChoice)
        {
            case ("New Save"):
                save = CreateNewSave();
                break;
            case ("Load Save"):
                var saves = save.ListSaves();
                if (saves.Count == 0)
                {
                    AnsiConsole.MarkupLine("No saves found.\nCreating new save.");
                    save = CreateNewSave();
                    return;
                }
                var saveName = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("Which save would you like to load?")
                    .AddChoices(saves)
                );
                save.LoadSave(saveName);
                break;
        }

        AnsiConsole.Clear();

        AnsiConsole.MarkupLine($"Welcome to {save.Name}!");
    }

    private static Save CreateNewSave()
    {
        var name = AnsiConsole.Ask<string>("What is the name of your save?");
        Save save = new Save { Name = name };
        save.SaveSave();
        return save;
    }
}