using ekvip.Interfaces;

namespace ekvip.Commands;

public class IncrementCommand : ICommand
{
    public int Execute(int currentValue) => ++currentValue;
    
    public int Undo(int currentValue) => --currentValue;
}