using UnityEngine;
using UnityEngine.InputSystem;

public class MovementDog : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    private GroundCheckDog groundCheck;
    private Vector2 dir;
    private Rigidbody2D rb;

    [Header("Crouch")]
    public bool crouch = false;

    private void Start()
    {
        groundCheck = GameObject.Find("GroundCheck").GetComponent<GroundCheckDog>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //rb.linearVelocity = new Vector2(dir.normalized.x * speed, rb.linearVelocityY);
        rb.linearVelocity = dir.normalized * speed;
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
            crouch = true;
        }
    }
}
