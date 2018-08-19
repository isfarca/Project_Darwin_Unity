using System;
using UnityEngine;
using UnityEngine.UI;

public class MutationHandler : MonoBehaviour 
{
    // Declare variables.
    public Sprite[] Selected;
    public Sprite[] DeSelected;
    private Image _elephant, _fish, _hawk, _rhino, _turtle;
    private int _elephantCounter, _fishCounter, _hawkCounter, _rhinoCounter, _turtleCounter;
    private Transformation _transformationScript;

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
        
        // Get the transformation script.
        _transformationScript = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0)
            .GetComponent<Transformation>();
    }

    /// <summary>
    /// Calling by start.
    /// </summary>
    private void Start()
    {
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
        _elephantCounter = _fishCounter = _hawkCounter = _rhinoCounter = _turtleCounter = 0;

        // Add mutation icon position by platform.
        if (Application.platform != RuntimePlatform.Android)
        {
            transform.GetChild(5).gameObject.SetActive(true);
            transform.GetChild(6).gameObject.SetActive(true);
            transform.GetChild(7).gameObject.SetActive(true);
            transform.GetChild(8).gameObject.SetActive(true);
            
            SetMutationIcons(100.0f, -125.0f);
        }
        else
            SetMutationIcons(269.0f, 0.0f);
    }

    /// <summary>
    /// Set mutation icons and activate this.
    /// </summary>
    private void SetMutationIcons(float xPosition, float yPosition)
    {
        foreach (MutationType currentMutation in ThreeMutations)
        {
            if ((currentMutation & MutationType.Elephant) != 0)
            {
                transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition =
                    new Vector3(xPosition, yPosition, 0.0f);
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else if ((currentMutation & MutationType.Fish) != 0)
            {
                transform.GetChild(1).GetComponent<RectTransform>().anchoredPosition =
                    new Vector3(xPosition, yPosition, 0.0f);
                transform.GetChild(1).gameObject.SetActive(true);
            }
            else if ((currentMutation & MutationType.Hawk) != 0)
            {
                transform.GetChild(2).GetComponent<RectTransform>().anchoredPosition =
                    new Vector3(xPosition, yPosition, 0.0f);
                transform.GetChild(2).gameObject.SetActive(true);
            }
            else if ((currentMutation & MutationType.Rhino) != 0)
            {
                transform.GetChild(3).GetComponent<RectTransform>().anchoredPosition =
                    new Vector3(xPosition, yPosition, 0.0f);
                transform.GetChild(3).gameObject.SetActive(true);
            }
            else if ((currentMutation & MutationType.Turtle) != 0)
            {
                transform.GetChild(4).GetComponent<RectTransform>().anchoredPosition =
                    new Vector3(xPosition, yPosition, 0.0f);
                transform.GetChild(4).gameObject.SetActive(true);
            }

            // Add offset.
            xPosition = Application.platform != RuntimePlatform.Android ? xPosition + 50.0f : xPosition;
            yPosition = Application.platform != RuntimePlatform.Android ? yPosition : yPosition + 50.0f;
        }
    }

    /// <summary>
    /// De select all images.
    /// </summary>
    private void DeSelectAll()
    {
        // Switch selected / deselected images.
        _elephant.sprite = DeSelected[0];
        _fish.sprite = DeSelected[1];
        _hawk.sprite = DeSelected[2];
        _rhino.sprite = DeSelected[3];
        _turtle.sprite = DeSelected[4];
    }

    /// <summary>
    /// Select elephant image.
    /// </summary>
    public void SelectElephant()
    {
        // Set default transformation by second click this mutation button.
        _fishCounter = _hawkCounter = _rhinoCounter = _turtleCounter = 0;
        _elephantCounter++;
        if (_elephantCounter <= 1) // Switch to elephant.
        {
            // Start transformation process.
            _transformationScript.GetTranformation("Elephant");

            // Set boolean.
            IsNormal = false;
            IsElephant = true;
            IsFish = false;
            IsHawk = false;
            IsRhino = false;
            IsTurtle = false;

            // Switch selected / deselected images.
            _elephant.sprite = Selected[0];
            _fish.sprite = DeSelected[1];
            _hawk.sprite = DeSelected[2];
            _rhino.sprite = DeSelected[3];
            _turtle.sprite = DeSelected[4];
        }
        else if (_elephantCounter > 1) // Switch to normal.
        {
            // Start transformation process.
            _transformationScript.GetTranformation("Normal");

            // Set default values.
            IsNormal = true;
            IsElephant = false;
            _elephantCounter = 0;

            // Set the normal transformation.
            DeSelectAll();
        }
    }

    /// <summary>
    /// Select fish image.
    /// </summary>
    public void SelectFish()
    {
        // Set default transformation by second click this mutation button.
        _elephantCounter = _hawkCounter = _rhinoCounter = _turtleCounter = 0;
        _fishCounter++;
        if (_fishCounter <= 1) // Switch to fish.
        {
            // Start transformation process.
            _transformationScript.GetTranformation("Fish");

            // Set boolean.
            IsNormal = false;
            IsElephant = false;
            IsFish = true;
            IsHawk = false;
            IsRhino = false;
            IsTurtle = false;

            // Switch selected / deselected images.
            _elephant.sprite = DeSelected[0];
            _fish.sprite = Selected[1];
            _hawk.sprite = DeSelected[2];
            _rhino.sprite = DeSelected[3];
            _turtle.sprite = DeSelected[4];
        }
        else if (_fishCounter > 1) // Switch to normal.
        {
            // Start transformation process.
            _transformationScript.GetTranformation("Normal");

            // Set default values.
            IsNormal = true;
            IsFish = false;
            _fishCounter = 0;

            // Set the normal transformation.
            DeSelectAll();
        }
    }

    /// <summary>
    /// Select hawk image.
    /// </summary>
    public void SelectHawk()
    {
        // Set default transformation by second click this mutation button.
        _elephantCounter = _fishCounter = _rhinoCounter = _turtleCounter = 0;
        _hawkCounter++;
        if (_hawkCounter <= 1) // Switch to hawk.
        {
            // Start transformation process.
            _transformationScript.GetTranformation("Hawk");

            // Set boolean.
            IsNormal = false;
            IsElephant = false;
            IsFish = false;
            IsHawk = true;
            IsRhino = false;
            IsTurtle = false;

            // Switch selected / deselected images.
            _elephant.sprite = DeSelected[0];
            _fish.sprite = DeSelected[1];
            _hawk.sprite = Selected[2];
            _rhino.sprite = DeSelected[3];
            _turtle.sprite = DeSelected[4];
        }
        else if (_hawkCounter > 1) // Switch to normal.
        {
            // Start transformation process.
            _transformationScript.GetTranformation("Normal");

            // Set default values.
            IsNormal = true;
            IsHawk = false;
            _hawkCounter = 0;

            // Set the normal transformation.
            DeSelectAll();
        }
    }

    /// <summary>
    /// Select rhino image.
    /// </summary>
    public void SelectRhino()
    {
        // Set default transformation by second click this mutation button.
        _elephantCounter = _fishCounter = _hawkCounter = _turtleCounter = 0;
        _rhinoCounter++;
        if (_rhinoCounter <= 1) // Switch to hawk.
        {
            // Start transformation process.
            _transformationScript.GetTranformation("Rhino");

            // Set boolean.
            IsNormal = false;
            IsElephant = false;
            IsFish = false;
            IsHawk = false;
            IsRhino = true;
            IsTurtle = false;

            // Switch selected / deselected images.
            _elephant.sprite = DeSelected[0];
            _fish.sprite = DeSelected[1];
            _hawk.sprite = DeSelected[2];
            _rhino.sprite = Selected[3];
            _turtle.sprite = DeSelected[4];
        }
        else if (_rhinoCounter > 1) // Switch to normal.
        {
            // Start transformation process.
            _transformationScript.GetTranformation("Normal");

            // Set default values.
            IsNormal = true;
            IsRhino = false;
            _rhinoCounter = 0;

            // Set the normal transformation.
            DeSelectAll();
        }
    }

    /// <summary>
    /// Select turtle image.
    /// </summary>
    public void SelectTurtle()
    {
        // Set default transformation by second click this mutation button.
        _elephantCounter = _fishCounter = _hawkCounter = _rhinoCounter = 0;
        _turtleCounter++;
        if (_turtleCounter <= 1) // Switch to hawk.
        {
            // Start transformation process.
            _transformationScript.GetTranformation("Turtle");

            // Set boolean.
            IsNormal = false;
            IsElephant = false;
            IsFish = false;
            IsHawk = false;
            IsRhino = false;
            IsTurtle = true;

            // Switch selected / deselected images.
            _elephant.sprite = DeSelected[0];
            _fish.sprite = DeSelected[1];
            _hawk.sprite = DeSelected[2];
            _rhino.sprite = DeSelected[3];
            _turtle.sprite = Selected[4];
        }
        else if (_turtleCounter > 1) // Switch to normal.
        {
            // Start transformation process.
            _transformationScript.GetTranformation("Normal");

            // Set default values.
            IsNormal = true;
            IsTurtle = false;
            _turtleCounter = 0;

            // Set the normal transformation.
            DeSelectAll();
        }
    }

    // Auto-properties.
    public MutationType[] ThreeMutations { get; set; }
    private bool IsNormal { get; set; }
    public bool IsElephant { get; private set; }
    public bool IsFish { get; private set; }
    public bool IsHawk { get; private set; }
    public bool IsRhino { get; private set; }
    public bool IsTurtle { get; private set; }
}