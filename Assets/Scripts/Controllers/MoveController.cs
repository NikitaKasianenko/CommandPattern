using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{

    [Header("Movement Settings")]
    [SerializeField] private float _speed = 500f;

    private Queue<ICommand> _commands = new Queue<ICommand>();
    private bool _isMoving = false;

    public static MoveController Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance == this)
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        GameEvents.OnSpeedChanged += UpdateSpeed;
        GameEvents.OnCommandRequested += AddCommand;
    }

    private void OnDisable()
    {
        GameEvents.OnSpeedChanged -= UpdateSpeed;
        GameEvents.OnCommandRequested -= AddCommand;
    }

    public void MoveTo(Vector3 targetPos)
    {
        StartCoroutine(MoveRoutine(targetPos));
    }

    private IEnumerator MoveRoutine(Vector3 targetPos)
    {
        _isMoving = true;
        while (Vector3.Distance(transform.position, targetPos) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, _speed * Time.deltaTime);
            yield return null;
        }
        _isMoving = false;
        TryToExecuteNext();

    }

    public void AddCommand(ICommand command)
    {
        _commands.Enqueue(command);
        TryToExecuteNext();

    }

    private void TryToExecuteNext()
    {
        if (_commands.Count > 0 && !_isMoving)
        {
            ICommand command = _commands.Dequeue();
            command.Execute();
        }
    }

    private void UpdateSpeed(float newSpeed)
    {
        _speed = newSpeed;
    }
}