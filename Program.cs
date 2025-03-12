using ekvip.Processors;
using ekvip.Utils;

static class Program
{
    private static void Main(string[] args)
    {
        //Get user input value or exit
        var initialValue = Utils.GetIntegerInput(args);
        
        Utils.DisplayCommandList();
        
        var processor = new CommandProcessor(initialValue);

        Utils.RunCommandLoop(processor);
    }
}