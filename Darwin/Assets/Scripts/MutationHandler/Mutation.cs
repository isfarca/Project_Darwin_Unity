using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mutation : MonoBehaviour, IPointerDownHandler
{
    // Declare variables.
    private ParticleSystem _transformationParticleSystem;
    [SerializeField] private MutationIcons.MutationType _mutationType;
    [SerializeField] private Image _elephant, _fish, _hawk, _rhino, _turtle;
    private MutationSprites _mutationSpritesScript;

    /// <summary>
    /// Calling before start.
    /// </summary>
    private void Awake()
    {
        // Get particle system and deactivate this.
        _transformationParticleSystem = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0)
            .GetComponent<ParticleSystem>();
        _transformationParticleSystem.gameObject.SetActive(false);
        
        // Get the sprites.
        _mutationSpritesScript = GameObject.FindGameObjectWithTag("MutationSprites").GetComponent<MutationSprites>();
    }

    // Calling by clicking or touching.
    public void OnPointerDown(PointerEventData eventData) 
    {
        switch (_mutationType)
        {
            case MutationIcons.MutationType.Elephant:
                _elephant.sprite = _mutationSpritesScript.Selected[0];
                _fish.sprite = _mutationSpritesScript.DeSelected[1];
                _hawk.sprite = _mutationSpritesScript.DeSelected[2];
                _rhino.sprite = _mutationSpritesScript.DeSelected[3];
                _turtle.sprite = _mutationSpritesScript.DeSelected[4];
                break;
            case MutationIcons.MutationType.Fish:
                _elephant.sprite = _mutationSpritesScript.DeSelected[0];
                _fish.sprite = _mutationSpritesScript.Selected[1];
                _hawk.sprite = _mutationSpritesScript.DeSelected[2];
                _rhino.sprite = _mutationSpritesScript.DeSelected[3];
                _turtle.sprite = _mutationSpritesScript.DeSelected[4];
                break;
            case MutationIcons.MutationType.Hawk:
                _elephant.sprite = _mutationSpritesScript.DeSelected[0];
                _fish.sprite = _mutationSpritesScript.DeSelected[1];
                _hawk.sprite = _mutationSpritesScript.Selected[2];
                _rhino.sprite = _mutationSpritesScript.DeSelected[3];
                _turtle.sprite = _mutationSpritesScript.DeSelected[4];
                break;
            case MutationIcons.MutationType.Rhino:
                _elephant.sprite = _mutationSpritesScript.DeSelected[0];
                _fish.sprite = _mutationSpritesScript.DeSelected[1];
                _hawk.sprite = _mutationSpritesScript.DeSelected[2];
                _rhino.sprite = _mutationSpritesScript.Selected[3];
                _turtle.sprite = _mutationSpritesScript.DeSelected[4];
                break;
            case MutationIcons.MutationType.Turtle:
                _elephant.sprite = _mutationSpritesScript.DeSelected[0];
                _fish.sprite = _mutationSpritesScript.DeSelected[1];
                _hawk.sprite = _mutationSpritesScript.DeSelected[2];
                _rhino.sprite = _mutationSpritesScript.DeSelected[3];
                _turtle.sprite = _mutationSpritesScript.Selected[4];
                break;
            default:
                return;
        }
    }
}