using UnityEngine;

public class DogAnimation : MonoBehaviour
{
    public static DogAnimation instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private Animator dogAnimator;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dogAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Mathf.Abs(rb.linearVelocityX) > 0.1 || Mathf.Abs(rb.linearVelocityY) > 0.1)
        {
            dogAnimator.SetBool("isWalking", true);
        }
        else
        {
            dogAnimator.SetBool("isWalking", false);
        }


    }

    public void WoofTrigger()
    {
        dogAnimator.SetTrigger("isBarking");
    }
}
