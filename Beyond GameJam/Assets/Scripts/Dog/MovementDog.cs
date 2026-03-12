using UnityEngine;
using UnityEngine.InputSystem;

public class MovementDog : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    private GroundCheckDog groundCheck;
    public Vector2 dir;
    private Rigidbody2D rb;

    [Header("Crouch")]
    public bool crouch = false;

    [Header("Animation")]
    public bool lockMovement = false;
    private void Start()
    {
        groundCheck = GameObject.Find("GroundCheck").GetComponent<GroundCheckDog>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (lockMovement) return;
        if(!crouch)
            rb.linearVelocity = dir.normalized * speed;
        else if(crouch)
            rb.linearVelocity = dir.normalized * speed * 0.3f;
        Debug.Log(rb.linearVelocityX);
    }

    public void Movement(InputAction.CallbackContext ctx)
    {
        dir = ctx.ReadValue<Vector2>();
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && groundCheck.isGrounded)
        {
            rb.linearVelocityY = jumpPower;
        }
    }
    public void Crouch(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            crouch = !crouch;
        }
    }
}
