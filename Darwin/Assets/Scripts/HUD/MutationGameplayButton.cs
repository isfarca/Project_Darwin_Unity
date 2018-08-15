using UnityEngine;
using UnityEngine.EventSystems;

public class MutationGameplayButton : MonoBehaviour, IPointerDownHandler
{
    // Declare variables.
    [SerializeField] private MutationHandler.MutationType _mutationType;
    private MutationHandler _mutationHandlerScript;

    /// <summary>
    /// Calling before start.
    /// </summary>
    private void Awake()
    {
        // Get the sprites.
        _mutationHandlerScript = GameObject.FindGameObjectWithTag("MutationHandler").GetComponent<MutationHandler>();
    }

    // Calling by clicking or touching.
    public void OnPointerDown(PointerEventData eventData) 
    {
        switch (_mutationType)
        {
            case MutationHandler.MutationType.Elephant:
                _mutationHandlerScript.SelectElephant();
                break;
            case MutationHandler.MutationType.Fish:
                _mutationHandlerScript.SelectFish();
                break;
            case MutationHandler.MutationType.Hawk:
                _mutationHandlerScript.SelectHawk();
                break;
            case MutationHandler.MutationType.Rhino:
                _mutationHandlerScript.SelectRhino();
                break;
            case MutationHandler.MutationType.Turtle:
                _mutationHandlerScript.SelectTurtle();
                break;
            default:
                return;
        }
    }
}