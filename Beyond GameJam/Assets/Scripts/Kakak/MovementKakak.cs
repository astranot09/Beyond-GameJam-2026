using UnityEngine;

public class MovementKakak : MonoBehaviour
{
    [SerializeField] private GameObject dog;
    [SerializeField] private Transform dogTransform;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float checkDistance = 2f;
    [SerializeField] private float maxDistance = 4f;
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

        if(distance > maxDistance)
        {
            Debug.Log("pppp");
        }

        if (distance > checkDistance)
        {
            Vector2 direction = (dogTransform.position - transform.position).normalized;
            rb.linearVelocity = moveSpeed * direction;
        }
        else
            rb.linearVelocityX = 0;
    }
}
