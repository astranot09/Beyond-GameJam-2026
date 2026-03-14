using UnityEngine;

public class DogAnimation : MonoBehaviour
{
    private Animator dogAnimator;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dogAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Mathf.Abs(rb.linearVelocityX) > 0 || Mathf.Abs(rb.linearVelocityY) > 0)
        {
            dogAnimator.SetBool("isWalking", true);
        }
        else
        {
            dogAnimator.SetBool("isWalking", false);
        }


    }
}
