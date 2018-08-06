using UnityEngine;
using UnityEngine.EventSystems;

public class MovementButtons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Declare variables.
    private Joystick _joystickScript;
    [SerializeField] private Direction _direction;
    private MovementLogic _movementLogicScript;
    
    /// <summary>
    /// Movement directions for player.
    /// </summary>
    private enum Direction
    {
        None,
        Up,
        Right,
        Down,
        Left
    }
    
    /// <summary>
    /// Calling before start.
    /// </summary>
    private void Awake()
    {
        // Get scripts and components.
        _joystickScript = GetComponent<Joystick>();
        _movementLogicScript = GameObject.FindGameObjectWithTag("Player").GetComponent<MovementLogic>();
    }
    
    /// <summary>
    /// Calling per frame.
    /// </summary>
    private void Update()
    {
        // Virtual stick movement.
        if (_joystickScript != null)
        {
            if (_joystickScript.Horizontal < 0.0f || _joystickScript.Horizontal > 0.0f)
                _movementLogicScript.Horizontal = _joystickScript.Horizontal;
            
            Vertical = _joystickScript.Vertical;
        }

        // Keyboard / Controller movement.
        if (Input.GetAxis("Horizontal") < 0.0f || Input.GetAxis("Horizontal") > 0.0f)
            _movementLogicScript.Horizontal = Input.GetAxis("Horizontal");
        
        Vertical = Input.GetAxis("Vertical");
    }

    // Calling by clicking or touching.
    public void OnPointerDown(PointerEventData eventData) 
    {
        // Control pad movement.
        switch (_direction)
        {
            case Direction.None:
                return;
            case Direction.Up:
                Vertical = 1.0f;
                break;
            case Direction.Right:
                _movementLogicScript.Horizontal = 1.0f;
                break;
            case Direction.Down:
                Vertical = -1.0f;
                break;
            case Direction.Left:
                _movementLogicScript.Horizontal = -1.0f;
                break;
            default:
                return;
        }
    }
    
    // Calling after by clicking or touching.
    public void OnPointerUp(PointerEventData eventData)
    {
        // Control pad movement.
        Vertical = 0.0f;
        _movementLogicScript.Horizontal = 0.0f;
    }
    
    // Auto-properties.
    public float Vertical { get; private set; }
}