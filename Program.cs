using System.CommandLine;

static void Greeting(string name) => Console.WriteLine($"Hello, {name}!");

var nameOption = new Option<string>(
    name: "--name",
    description: "The person name to greet.");

nameOption.AddAlias("-n");
nameOption.IsRequired = true;

var rootCommand = new RootCommand("Greeting CLI!");
rootCommand.AddOption(nameOption);
rootCommand.SetHandler((name) => Greeting(name), nameOption);

// -- Template Sub-Command --

var templateOption = new Option<string>(
    name: "--template",
    description: "The template use for greeting.");

templateOption.AddAlias("-t");
templateOption.IsRequired = true;

var templateCommand = new Command("template", "Print greeting in provided format.");
templateCommand.AddOption(nameOption);
templateCommand.AddOption(templateOption);
templateCommand.SetHandler((template, name) =>
{
  var parsedString = string.Format(template, name);
  Console.WriteLine(parsedString);
}, templateOption, nameOption);

rootCommand.AddCommand(templateCommand);

// -- Template Sub-Command end --

return await rootCommand.InvokeAsync(args);