using UnityEngine;

public class BrotherAnimation : MonoBehaviour
{
    private Animator brotherAnimator;
    private Rigidbody2D rb;
    [SerializeField] private MovementDog movementDog;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        brotherAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Mathf.Abs(rb.linearVelocityX) > 0.1 || Mathf.Abs(rb.linearVelocityY) > 0.1)
        {
            
            brotherAnimator.SetBool("isWalking", true);
        }
        else
        {
            brotherAnimator.SetBool("isWalking", false);
        }

        if (movementDog.isCrouching)
        {
            brotherAnimator.SetBool("isCrouching", true);
        }
        else
        {
            brotherAnimator.SetBool("isCrouching", false);
        }

    }
}
