using ekvip.Interfaces;

namespace ekvip.Commands;

public class DoubleCommand : ICommand
{
    private int _previousValue;

    public int Execute(int currentValue)
    {
        _previousValue = currentValue;
        
        return currentValue * 2;
    }

    public int Undo(int currentValue) => _previousValue;
}