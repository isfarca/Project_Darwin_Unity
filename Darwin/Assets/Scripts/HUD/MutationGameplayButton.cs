using UnityEngine;
using UnityEngine.EventSystems;

public class MutationGameplayButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Declare variables.
    [SerializeField] private MutationHandler.MutationType _mutationType;
    private MutationHandler _mutationSpritesScript;
    private int _elephantCounter, _fishCounter, _hawkCounter, _rhinoCounter, _turtleCounter;

    /// <summary>
    /// Calling before start.
    /// </summary>
    private void Awake()
    {
        // Get the sprites.
        _mutationSpritesScript = GameObject.FindGameObjectWithTag("MutationHandler").GetComponent<MutationHandler>();
    }

    /// <summary>
    /// Calling by start.
    /// </summary>
    private void Start()
    {
        // Set default values.
        _elephantCounter = _fishCounter = _hawkCounter = _rhinoCounter = _turtleCounter = 0;
    }

    // Calling by clicking or touching.
    public void OnPointerDown(PointerEventData eventData) 
    {
        switch (_mutationType)
        {
            case MutationHandler.MutationType.Elephant:
                
                // Who are you?
                _mutationSpritesScript.IsNormal = false;
                _mutationSpritesScript.IsElephant = true;
                _mutationSpritesScript.IsFish = false;
                _mutationSpritesScript.IsHawk = false;
                _mutationSpritesScript.IsRhino = false;
                _mutationSpritesScript.IsTurtle = false;
                
                break;
            
            case MutationHandler.MutationType.Fish:
                
                // Who are you?
                _mutationSpritesScript.IsNormal = false;
                _mutationSpritesScript.IsElephant = false;
                _mutationSpritesScript.IsFish = true;
                _mutationSpritesScript.IsHawk = false;
                _mutationSpritesScript.IsRhino = false;
                _mutationSpritesScript.IsTurtle = false;
                
                break;
            
            case MutationHandler.MutationType.Hawk:
                
                // Who are you?
                _mutationSpritesScript.IsNormal = false;
                _mutationSpritesScript.IsElephant = false;
                _mutationSpritesScript.IsFish = false;
                _mutationSpritesScript.IsHawk = true;
                _mutationSpritesScript.IsRhino = false;
                _mutationSpritesScript.IsTurtle = false;
                
                break;
            
            case MutationHandler.MutationType.Rhino:
                
                // Who are you?
                _mutationSpritesScript.IsNormal = false;
                _mutationSpritesScript.IsElephant = false;
                _mutationSpritesScript.IsFish = false;
                _mutationSpritesScript.IsHawk = false;
                _mutationSpritesScript.IsRhino = true;
                _mutationSpritesScript.IsTurtle = false;
                
                break;
            
            case MutationHandler.MutationType.Turtle:
                
                // Who are you?
                _mutationSpritesScript.IsNormal = false;
                _mutationSpritesScript.IsElephant = false;
                _mutationSpritesScript.IsFish = false;
                _mutationSpritesScript.IsHawk = false;
                _mutationSpritesScript.IsRhino = false;
                _mutationSpritesScript.IsTurtle = true;
                
                break;
            
            default:
                return;
        }
    }
    
    // Calling after by clicking or touching.
    public void OnPointerUp(PointerEventData eventData)
    {
        switch (_mutationType)
        {
            case MutationHandler.MutationType.Elephant:
                
                // Set default transformation by second click this mutation button.
                _fishCounter = _hawkCounter = _rhinoCounter = _turtleCounter = 0;
                _elephantCounter++;
                if (_elephantCounter > 1)
                {
                    _mutationSpritesScript.IsNormal = true;
                    _mutationSpritesScript.IsElephant = false;
                    _elephantCounter = 0;
                }
                
                break;
            
            case MutationHandler.MutationType.Fish:
                
                // Set default transformation by second click this mutation button.
                _elephantCounter = _hawkCounter = _rhinoCounter = _turtleCounter = 0;
                _fishCounter++;
                if (_fishCounter > 1)
                {
                    _mutationSpritesScript.IsNormal = true;
                    _mutationSpritesScript.IsFish = false;
                    _fishCounter = 0;
                }
                
                break;
            
            case MutationHandler.MutationType.Hawk:
                
                // Set default transformation by second click this mutation button.
                _elephantCounter = _fishCounter = _rhinoCounter = _turtleCounter = 0;
                _hawkCounter++;
                if (_hawkCounter > 1)
                {
                    _mutationSpritesScript.IsNormal = true;
                    _mutationSpritesScript.IsHawk = false;
                    _hawkCounter = 0;
                }
                
                break;
            
            case MutationHandler.MutationType.Rhino:
                
                // Set default transformation by second click this mutation button.
                _elephantCounter = _fishCounter = _hawkCounter = _turtleCounter = 0;
                _rhinoCounter++;
                if (_rhinoCounter > 1)
                {
                    _mutationSpritesScript.IsNormal = true;
                    _mutationSpritesScript.IsRhino = false;
                    _rhinoCounter = 0;
                }
                
                break;
            
            case MutationHandler.MutationType.Turtle:
                
                // Set default transformation by second click this mutation button.
                _elephantCounter = _fishCounter = _hawkCounter = _rhinoCounter = 0;
                _turtleCounter++;
                if (_turtleCounter > 1)
                {
                    _mutationSpritesScript.IsNormal = true;
                    _mutationSpritesScript.IsTurtle = false;
                    _turtleCounter = 0;
                }
                
                break;
            
            default:
                return;
        }
    }
}