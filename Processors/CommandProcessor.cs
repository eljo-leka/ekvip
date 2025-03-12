using ekvip.Commands;
using ekvip.Enums;
using ekvip.Enums.Helpers;
using ekvip.Interfaces;

namespace ekvip.Processors;

public class CommandProcessor(int initialValue)
{
    private Stack<ICommand> _commandHistory = new();
    private Stack<ICommand> _undoneCommands = new();
    
    public int Result { get; private set; } = initialValue;
    
    public void ProcessCommand(string commandName)
    {
        var commandType = EnumHelper.TryParseStrict(commandName);
        
        switch (commandType)
        {
            case CommandTypeEnum.Increment:
                ExecuteCommand(new IncrementCommand());
                break;
            case CommandTypeEnum.Decrement:
                ExecuteCommand(new DecrementCommand());
                break;
            case CommandTypeEnum.Double:
                ExecuteCommand(new DoubleCommand());
                break;
            case CommandTypeEnum.RandAdd:
                ExecuteCommand(new RandomIncrementCommand());
                break;
            case CommandTypeEnum.Undo:
                UndoLastCommand();
                break;
            default:
                Console.WriteLine($"Unknown command type. ");
                Utils.Utils.DisplayCommandList();
                break;
        }
    }

    private void ExecuteCommand(ICommand command)
    {
        Result = command.Execute(Result);
        
        _commandHistory.Push(command);
        
        _undoneCommands.Clear();
    }

    private void UndoLastCommand()
    {
        if (_commandHistory.Count > 0)
        {
            var command = _commandHistory.Pop();
            
            Result = command.Undo(Result);
            
            _undoneCommands.Push(command);
        }
        else
        {
            Console.WriteLine("Nothing to undo.");
        }
    }
}