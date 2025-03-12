namespace ekvip.Interfaces;

public interface ICommand
{
    int Execute(int currentValue);
    
    int Undo(int currentValue);
}