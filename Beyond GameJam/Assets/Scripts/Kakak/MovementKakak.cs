using UnityEngine;

public class MovementKakak : MonoBehaviour
{
    [SerializeField] private GameObject dog;
    [SerializeField] private Transform dogTransform;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float checkDistance = 1f;

    Rigidbody2D rb;


    private void Start()
    {
        dog = GameObject.FindGameObjectWithTag("Dog");
        dogTransform = dog.transform;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {

        float distance = Vector2.Distance(transform.position, dogTransform.position);

        if (distance > checkDistance)
        {
            Vector2 direction = (dogTransform.position - transform.position).normalized;
            rb.linearVelocity = new Vector2(moveSpeed * direction.x, rb.linearVelocity.y);
        }
        else
            rb.linearVelocityX = 0;
    }
}
