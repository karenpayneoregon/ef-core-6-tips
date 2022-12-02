
namespace SqlLiteSimpleApp.Classes;

internal class Prompts
{
    public static string GetPath() =>
        AnsiConsole.Prompt(
            new TextPrompt<string>("[white]Enter new path[/]?")
                .PromptStyle("yellow"));
}