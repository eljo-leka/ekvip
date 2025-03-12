using ekvip.Enums;
using ekvip.Enums.Helpers;
using ekvip.Processors;

namespace ekvip.Utils;

public static class Utils
{
    private const string ExitCommand = "exit";
    
    public static void DisplayCommandList()
    {
        var displayCommandNamesAsArray = EnumHelper.GetEnumDisplayNames<CommandTypeEnum>();
        
        var displayNamesAsString = string.Join(", ", displayCommandNamesAsArray).ToLowerInvariant();
        
        Console.WriteLine($"Available commands: {displayNamesAsString}. Insert '{ExitCommand}' to exit.");
    }
    
    public static void RunCommandLoop(CommandProcessor processor)
    {
        while (true)
        {
            Console.Write("> ");
            
            var cmdInput = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(cmdInput)
                || cmdInput.Equals(ExitCommand, StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Exiting application as requested by user.");
                
                break;
            }

            processor.ProcessCommand(cmdInput);
            
            Console.WriteLine($"Result: {processor.Result}");
        }
    }
    
    /// <summary>
    /// Gets an integer value from command line arguments or prompts the user for input if needed.
    /// Allows user to exit the application by typing a special exit command.
    /// </summary>
    /// <param name="args">Command line arguments array</param>
    /// <param name="argIndex">Index of the argument to parse (default: 0)</param>
    /// <param name="exitCommand">String that user can type to exit the application (default: "exit")</param>
    /// <returns>The parsed integer value</returns>
    public static int GetIntegerInput(string[] args, int argIndex = 0, string exitCommand = ExitCommand)
    {
        if (args.Length > argIndex && int.TryParse(args[argIndex].Trim(), out var value))
        {
            Console.WriteLine($"Using command line value: {value}");
                
            return value;
        }
        
        var invalidMessage =  $"Please enter a valid integer value (or type '{exitCommand}' to exit the application): ";
        
        while (true)
        {
            Console.Write(invalidMessage);
            
            var userInput = Console.ReadLine();
            
            // Check if user wants to exit
            if (string.Equals(userInput, exitCommand, StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("Exiting application as requested by user.");
                    
                Environment.Exit(0);
            }
            
            if (int.TryParse(userInput, out value))
                break;
        }
        
        Console.WriteLine($"Using command line value: {value}");
        
        return value;
    }
}