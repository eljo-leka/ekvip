using ekvip.Interfaces;

namespace ekvip.Commands;

public class DecrementCommand : ICommand
{
    public int Execute(int currentValue) => --currentValue;
    
    public int Undo(int currentValue) => ++currentValue;
}