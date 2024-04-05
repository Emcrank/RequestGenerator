using System.Windows.Input;

namespace RequestGenerator.WPFApp.Commands;

public class RelayCommand : ICommand
{
    private readonly Predicate<object?>? canExecute;
    private readonly Action<object?> execute;

    public RelayCommand(Action<object?> execute)
    {
        ArgumentNullException.ThrowIfNull(execute);

        this.execute = execute;
    }

    public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
    {
        ArgumentNullException.ThrowIfNull(execute);

        this.execute = execute;
        this.canExecute = canExecute;
    }

    public bool CanExecute(object? parameter)
    {
        if (canExecute == null)
            return true;

        return canExecute(parameter);
    }

    public void Execute(object? parameter)
    {
        execute(parameter);
    }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}