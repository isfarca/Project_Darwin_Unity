using UnityEngine;

public class Control : MonoBehaviour 
{
    // Declare variables.
    [SerializeField] private GameObject[] _controlsGameObject;
    [SerializeField] private Canvas _actionCanvas;
    [SerializeField] private MovementSelectionCanvas _movementSelectionCanvas;
    
    /// <summary>
    /// Calling per frame bundle.
    /// </summary>
    private void FixedUpdate()
    {
        // By runtime platform 'Android' enable display controls, by another runtime platforms enable keyboard/controller.
        if (Application.platform != RuntimePlatform.Android)
        {
            _controlsGameObject[0].SetActive(false);
            _controlsGameObject[1].SetActive(false);
            _controlsGameObject[2].SetActive(false);
            _controlsGameObject[3].SetActive(true); // Activate keyboard controller movement.
            
            _actionCanvas.gameObject.SetActive(false);
        }
        else if (!_movementSelectionCanvas.IsAwaked)
            return;
        
        // Disable movement selection canvas and this game object.
        _movementSelectionCanvas.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}