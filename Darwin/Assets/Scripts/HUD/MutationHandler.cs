using System;
using UnityEngine;
using UnityEngine.UI;

public class MutationHandler : MonoBehaviour 
{
    // Declare variables.
    public Sprite[] Selected;
    public Sprite[] DeSelected;
    private Image _elephant, _fish, _hawk, _rhino, _turtle;
    
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
        // Get the images.
        _elephant = transform.GetChild(0).GetComponent<Image>();
        _fish = transform.GetChild(1).GetComponent<Image>();
        _hawk = transform.GetChild(2).GetComponent<Image>();
        _rhino = transform.GetChild(3).GetComponent<Image>();
        _turtle = transform.GetChild(4).GetComponent<Image>();
    }

    /// <summary>
    /// Calling by start.
    /// </summary>
    private void Start()
    {
        // Declare variables.
        float yPosition = -25.0f;
        
        // Test values.
        ThreeMutations = new[]
        {
            MutationType.Elephant,
            MutationType.Fish,
            MutationType.Hawk
        };
        
        // Set default values.
        IsNormal = true;
        IsElephant = IsFish = IsHawk = IsRhino = IsTurtle = false;

        // Set mutation icons and activates this.
        foreach (MutationType currentMutation in ThreeMutations)
        {
            if ((currentMutation & MutationType.Elephant) != 0)
            {
                transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition =
                    new Vector3(269.0f, yPosition, 0.0f);
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else if ((currentMutation & MutationType.Fish) != 0)
            {
                transform.GetChild(1).GetComponent<RectTransform>().anchoredPosition =
                    new Vector3(269.0f, yPosition, 0.0f);
                transform.GetChild(1).gameObject.SetActive(true);
            }
            else if ((currentMutation & MutationType.Hawk) != 0)
            {
                transform.GetChild(2).GetComponent<RectTransform>().anchoredPosition =
                    new Vector3(269.0f, yPosition, 0.0f);
                transform.GetChild(2).gameObject.SetActive(true);
            }
            else if ((currentMutation & MutationType.Rhino) != 0)
            {
                transform.GetChild(3).GetComponent<RectTransform>().anchoredPosition =
                    new Vector3(269.0f, yPosition, 0.0f);
                transform.GetChild(3).gameObject.SetActive(true);
            }
            else if ((currentMutation & MutationType.Turtle) != 0)
            {
                transform.GetChild(4).GetComponent<RectTransform>().anchoredPosition =
                    new Vector3(269.0f, yPosition, 0.0f);
                transform.GetChild(4).gameObject.SetActive(true);
            }

            // Add offset.
            yPosition += 50.0f;
        }
    }

    /// <summary>
    /// Körper in einzelne Funktionen aufteilen [DeSelectAll(), SelectElephant(), etc.].**********
    /// </summary>
    private void Update()
    {
        // By normal, load deselected button sprites.
        if (IsNormal)
        {
            _elephant.sprite = DeSelected[0];
            _fish.sprite = DeSelected[1];
            _hawk.sprite = DeSelected[2];
            _rhino.sprite = DeSelected[3];
            _turtle.sprite = DeSelected[4];
        }

        // Who are you?
        if (IsElephant)
        {
            // Switch selected / deselected images.
            _elephant.sprite = Selected[0];
            _fish.sprite = DeSelected[1];
            _hawk.sprite = DeSelected[2];
            _rhino.sprite = DeSelected[3];
            _turtle.sprite = DeSelected[4];
        }
        else if (IsFish)
        {
            // Switch selected / deselected images.
            _fish.sprite = Selected[1];
            _elephant.sprite = DeSelected[0];
            _hawk.sprite = DeSelected[2];
            _rhino.sprite = DeSelected[3];
            _turtle.sprite = DeSelected[4];
        }
        else if (IsHawk)
        {
            // Switch selected / deselected images.
            _hawk.sprite = Selected[2];
            _elephant.sprite = DeSelected[0];
            _fish.sprite = DeSelected[1];
            _rhino.sprite = DeSelected[3];
            _turtle.sprite = DeSelected[4];
        }
        else if (IsRhino)
        {
            // Switch selected / deselected images.
            _rhino.sprite = Selected[3];
            _elephant.sprite = DeSelected[0];
            _fish.sprite = DeSelected[1];
            _hawk.sprite = DeSelected[2];
            _turtle.sprite = DeSelected[4];
        }
        else if (IsTurtle)
        {
            // Switch selected / deselected images.
            _turtle.sprite = Selected[4];
            _elephant.sprite = DeSelected[0];
            _fish.sprite = DeSelected[1];
            _hawk.sprite = DeSelected[2];
            _rhino.sprite = DeSelected[3];
        }
    }

    // Auto-properties.
    public MutationType[] ThreeMutations { private get; set; }
    public bool IsNormal { get; set; }
    public bool IsElephant { get; set; }
    public bool IsFish { get; set; }
    public bool IsHawk { get; set; }
    public bool IsRhino { get; set; }
    public bool IsTurtle { get; set; }
}