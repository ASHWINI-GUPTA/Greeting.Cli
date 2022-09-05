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

return await rootCommand.InvokeAsync(args);