using UnityEngine;

public class Manstacle : MonoBehaviour
{
    private bool isTriggered;
    private Rigidbody2D rb;
    [SerializeField] private float triggerRadius;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask triggerLayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        isTriggered = Physics2D.OverlapCircle(transform.position, triggerRadius, triggerLayer);
        if (isTriggered)
        {
            Debug.Log("AAAAAAHHHHH");
            walk();
        }
    }

    private void walk()
    {
        rb.linearVelocityX = -speed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }
}
