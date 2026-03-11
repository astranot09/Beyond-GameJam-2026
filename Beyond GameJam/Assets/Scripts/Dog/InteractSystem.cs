using UnityEngine;
using UnityEngine.InputSystem;

public class InteractSystem : MonoBehaviour
{

    [SerializeField] private float interactRadius;
    [SerializeField] private float interactDistance;
    [SerializeField] private LayerMask interactLayer;
    public IInteractables interactables;
    public IInteractables lastInteractables;
    private MovementDog movementDog;
    private RaycastHit2D hit;
    private Vector2 lastDir;

    private void Start()
    {
        movementDog = GetComponent<MovementDog>();
    }

    private void Update()
    {
        if (movementDog.dir != Vector2.zero)
        {
            lastDir = movementDog.dir.normalized;
        } 
        hit = Physics2D.CircleCast(transform.position, interactRadius, lastDir, interactDistance, interactLayer);
        if (hit.collider != null)
        {

        }
    }

    public void Interact(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Debug.Log("tried to interact");
        }
    }
}
