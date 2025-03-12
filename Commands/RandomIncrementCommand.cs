using ekvip.Interfaces;

namespace ekvip.Commands;

public class RandomIncrementCommand : ICommand
{
    private int _randomValue;
    private readonly Random _random = new();

    public int Execute(int currentValue)
    {
        // Assumption: Random value is between 0 and 10
        _randomValue = _random.Next(0, 11);
        
        return currentValue + _randomValue;
    }

    public int Undo(int currentValue) => currentValue - _randomValue;
}