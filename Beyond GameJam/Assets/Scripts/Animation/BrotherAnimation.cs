using UnityEngine;

public class BrotherAnimation : MonoBehaviour
{
    private Animator brotherAnimator;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        brotherAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Mathf.Abs(rb.linearVelocityX) > 0 || Mathf.Abs(rb.linearVelocityY) > 0)
        {
            brotherAnimator.SetBool("isWalking", true);
        }
        else
        {
            brotherAnimator.SetBool("isWalking", false);
        }


    }
}
