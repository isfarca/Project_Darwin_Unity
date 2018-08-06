using UnityEngine;

public class CameraAutoMovement : MonoBehaviour 
{
    // Declare variables.
    private GameObject _playerGameObject;
    private CameraShaker _cameraShakerScript;
    private float _cameraSpeedMultiplicator;
    
    /// <summary>
    /// Calling before start.
    /// </summary>
    private void Awake()
    {
        // Get the scripts and components.
        _playerGameObject = GameObject.FindGameObjectWithTag("Player");
        _cameraShakerScript = GetComponent<CameraShaker>();
    }

    /// <summary>
    /// Called once per frame, after update has finished.
    /// </summary>
    private void LateUpdate()
    {
        // Move the camera horizontal.
        transform.Translate(Vector3.right * _cameraSpeedMultiplicator * Time.deltaTime);
        
        // Shake the camera, when the player stand on the left side.
        if (transform.position.x > _playerGameObject.transform.position.x + 5.0f)
            _cameraShakerScript.ShouldShake = true;
        
        // Game over, when the player out of the screen.
        if (transform.position.x > _playerGameObject.transform.position.x + 7.0f)
            Debug.Log("Game over!");
        
        // Push the camera to right, when the player stand on the right side.
        _cameraSpeedMultiplicator = _playerGameObject.transform.position.x > transform.position.x + 5.5f ? 5.5f : 1.0f;
        
        // Smooth follow the camera vertical.
        Vector3 cameraPosition = transform.position;
        
        cameraPosition.y = Mathf.Lerp(cameraPosition.y, _playerGameObject.transform.position.y + 0.9357735f, Time.deltaTime);
        transform.position = cameraPosition;
    }
}