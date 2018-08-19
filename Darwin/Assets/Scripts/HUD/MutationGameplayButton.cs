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
    
    /// <summary>
    /// Calling per timestep.
    /// </summary>
    private void FixedUpdate()
    {
        // When the platform android, then return this update function.
        if (Application.platform == RuntimePlatform.Android)
            return;
        
        // Call the function for select the mutation with pc or joystick buttons.
        if (Input.GetButtonDown("Mutation1"))
            SelectMutation(_mutationHandlerScript.ThreeMutations[0]);
        else if (Input.GetButtonDown("Mutation2"))
            SelectMutation(_mutationHandlerScript.ThreeMutations[1]);
        else if (Input.GetButtonDown("Mutation3"))
            SelectMutation(_mutationHandlerScript.ThreeMutations[2]);
    }

    // Calling by clicking or touching.
    public void OnPointerDown(PointerEventData eventData) 
    {
        SelectMutation(_mutationType);
    }

    /// <summary>
    /// Select the mutation.
    /// </summary>
    /// <param name="currentMutationType">Type of the current mutation icon.</param>
    private void SelectMutation(MutationHandler.MutationType currentMutationType)
    {
        switch (currentMutationType)
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