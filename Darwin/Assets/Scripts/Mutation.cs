using System.Collections;
using UnityEngine;

public class Mutation : MonoBehaviour 
{
    // Declare variables.
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private ParticleSystem _transformationParticleSystem;
    private SpriteRenderer _spriteRenderer;

    /// <summary>
    /// Calling by start.
    /// </summary>
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// Calling per frame.
    /// </summary>
    private void Update()
    {
        // Set sprite.
        if (Input.GetKeyDown(KeyCode.Alpha1)) // Elephant.
            StartCoroutine(Transformation(_sprites[0], 0.0f, 1));
        else if (Input.GetKeyDown(KeyCode.Alpha2)) // Fish.
            StartCoroutine(Transformation(_sprites[1], -90.0f, 2));
        else if (Input.GetKeyDown(KeyCode.Alpha3)) // Hawk.
            StartCoroutine(Transformation(_sprites[2], 0.0f, 3));
        else if (Input.GetKeyDown(KeyCode.Alpha4)) // Rhino.
            StartCoroutine(Transformation(_sprites[3], 0.0f, 4));
        else if (Input.GetKeyDown(KeyCode.Alpha5)) // Turtle.
            StartCoroutine(Transformation(_sprites[4], 0.0f, 5));
    }

    /// <summary>
    /// Change the sprite.
    /// </summary>
    /// <param name="sprite">Mutation.</param>
    /// <param name="rotationZ">Horizontal or Vertical position.</param>
    /// <param name="id">Identifier in integer.</param>
    /// <returns>Seconds.</returns>
    private IEnumerator Transformation(Sprite sprite, float rotationZ, int id)
    {
        // Set id.
        MutationId = id;
        
        // Activate particle.
        _transformationParticleSystem.gameObject.SetActive(true);
        
        // Wait one second.
        yield return new WaitForSeconds(1);
        
        // Override the spriter renderer with another sprite.
        _spriteRenderer.sprite = sprite;
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, rotationZ);
        _transformationParticleSystem.gameObject.SetActive(false);
        StopAllCoroutines();
    }
    
    // Auto-properties.
    public int MutationId { get; set; }
}