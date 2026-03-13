using UnityEngine;

public class MovementKakak : MonoBehaviour
{
    [SerializeField] private GameObject dog;
    [SerializeField] private Transform dogTransform;

    public float moveSpeed = 5f;
    [SerializeField] private float checkDistance = 2f;
    [SerializeField] private float maxDistance = 4f;
    Rigidbody2D rb;

    [Header("Panic")]
    [SerializeField] private bool isPanic = false;


    private void Start()
    {
        dog = GameObject.FindGameObjectWithTag("Dog");
        dogTransform = dog.transform;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (!isPanic)
        {
            float distance = Vector2.Distance(transform.position, dogTransform.position);

            if (distance > maxDistance)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PanicMode"))
        {
            isPanic = true;
            rb.linearVelocityX = 0;
        }
    }
}
