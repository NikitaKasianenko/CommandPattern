using UnityEngine;

public class MoveToCommand : ICommand
{
    private Vector3 _targetPosition;
    private MoveController _moveController;

    public MoveToCommand(Vector3 targetPosition, MoveController moveController)
    {
        _targetPosition = targetPosition;
        _moveController = moveController;
    }

    public void Execute()
    {
        _moveController.MoveTo(_targetPosition);
    }
}
