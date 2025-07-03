using System;

public static class GameEvents
{
    public static event Action<float> OnSpeedChanged;
    public static event Action<ICommand> OnCommandRequested;

    public static void RequestCommand(ICommand command) => OnCommandRequested?.Invoke(command);
    public static void ChangeSpeed(float speed) => OnSpeedChanged?.Invoke(speed);
}