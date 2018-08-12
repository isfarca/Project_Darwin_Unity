using System;
using UnityEngine;
using UnityEngine.UI;

public class MutationIcons : MonoBehaviour 
{
    // Declare variables.
    private MutationSprites _mutationSpritesScript;
    
    /// <summary>
    /// Set mutation sprite.
    /// </summary>
    [Flags]
    public enum MutationType
    {
        Elephant = 1 << 0,
        Fish = 1 << 1,
        Hawk = 1 << 2,
        Rhino = 1 << 3,
        Turtle = 1 << 4
    }

    /// <summary>
    /// Calling before start.
    /// </summary>
    private void Awake()
    {
        // Get the scripts and components.
        _mutationSpritesScript = GameObject.FindGameObjectWithTag("MutationSprites").GetComponent<MutationSprites>();
    }

    /// <summary>
    /// Calling by start.
    /// </summary>
    private void Start()
    {
        // Declare variables.
        float yPosition = -25.0f;
        
        // Set default values.
        IsElephant = IsFish = IsHawk = IsRhino = IsTurtle = false;
        
        // Test values.
        ThreeMutations = new[]
        {
            MutationType.Elephant,
            MutationType.Fish,
            MutationType.Hawk
        };

        // Create icons.
        foreach (MutationType currentMutation in ThreeMutations)
        {
            // Set mutation icon.
            if ((currentMutation & MutationType.Elephant) != 0)
            {
                GameObject instance = Instantiate(_mutationSpritesScript.Images[0], transform);
                instance.GetComponent<RectTransform>().anchoredPosition = new Vector3(269.0f, yPosition, 0.0f);
            }
            else if ((currentMutation & MutationType.Fish) != 0)
            {
                GameObject instance = Instantiate(_mutationSpritesScript.Images[1], transform);
                instance.GetComponent<RectTransform>().anchoredPosition = new Vector3(269.0f, yPosition, 0.0f);
            }
            else if ((currentMutation & MutationType.Hawk) != 0)
            {
                GameObject instance = Instantiate(_mutationSpritesScript.Images[2], transform);
                instance.GetComponent<RectTransform>().anchoredPosition = new Vector3(269.0f, yPosition, 0.0f);
            }
            else if ((currentMutation & MutationType.Rhino) != 0)
            {
                GameObject instance = Instantiate(_mutationSpritesScript.Images[3], transform);
                instance.GetComponent<RectTransform>().anchoredPosition = new Vector3(269.0f, yPosition, 0.0f);
            }
            else if ((currentMutation & MutationType.Turtle) != 0)
            {
                GameObject instance = Instantiate(_mutationSpritesScript.Images[4], transform);
                instance.GetComponent<RectTransform>().anchoredPosition = new Vector3(269.0f, yPosition, 0.0f);
            }

            // Add offset.
            yPosition += 50.0f;
        }
    }
    
    /// <summary>
    /// Controlled calling.
    /// </summary>
    private void FixedUpdate()
    {
        if (IsElephant)
        {
            _mutationSpritesScript.Images[0].GetComponent<Image>().sprite = _mutationSpritesScript.Selected[0];
            
            // Image in eine eigene Variable packen! Continue...
        }
    }

    // Auto-properties.
    public MutationType[] ThreeMutations { private get; set; }
    public bool IsElephant { private get; set; }
    public bool IsFish { private get; set; }
    public bool IsHawk { private get; set; }
    public bool IsRhino { private get; set; }
    public bool IsTurtle { private get; set; }
}