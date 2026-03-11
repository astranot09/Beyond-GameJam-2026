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

    private void Awake()
    {
        interactables = null;
        lastInteractables = null;
    }

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
            interactables = hit.collider.GetComponent<IInteractables>();
            Debug.Log(interactables);
            if (interactables != lastInteractables && lastInteractables != null)
            {
                lastInteractables.OffFocus();
                lastInteractables = interactables;
                interactables.OnFocus();
            }
        else if (hit.collider == null)
            {
                if (interactables != null)
                {
                    interactables.OffFocus();
                    interactables = null;
                    return;
                }
                else if(interactables == null)
                {
                    return;
                }
            }
        }
    }

    public void Interact(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            Debug.Log("tried to interact");
            if (interactables != null)
            {
                interactables.Interact();
                Debug.Log("Interacted");
            }
            else
            {
                Debug.Log("Not Interacted");
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;

        Gizmos.color = Color.green;

        Vector3 start = transform.position;
        Vector3 dir3 = (Vector3)lastDir.normalized;

        // Draw starting circle
        Gizmos.DrawWireSphere(start, interactRadius);

        // Draw ending circle
        Vector3 end = start + dir3 * interactDistance;
        Gizmos.DrawWireSphere(end, interactRadius);

        // Draw line between them
        Gizmos.DrawLine(start, end);
    }
}
