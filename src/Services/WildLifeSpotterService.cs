using Spectre.Console;
using System;
using System.Collections.Generic;
using WildLifeSpotter.Models;

namespace WildLifeSpotter.Services
{
    public class WildLifeSpotterService
    {
        private readonly SaveService _saveService = new();

        public void Run()
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
                    var saves = _saveService.ListSaves();
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
                    save = _saveService.LoadSave(saveName);
                    break;
            }

            AnsiConsole.Clear();

            AnsiConsole.MarkupLine($"Welcome to {save.Name}!");

            AnsiConsole.MarkupLine("Press any key to exit.");
            System.Console.ReadKey();
        }

        private Save CreateNewSave()
        {
            var name = AnsiConsole.Ask<string>("What is the name of your save?");
            Save save = new Save { Name = name };
            _saveService.SaveSave(save);
            return save;
        }
    }
}