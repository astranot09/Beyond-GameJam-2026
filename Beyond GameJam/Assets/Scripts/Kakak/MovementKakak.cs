using System.Collections;
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
    public bool isPanic = false;
    public bool alreadyTriggered;

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
        if (collision.CompareTag("PanicMode") && !alreadyTriggered)
        {
            isPanic = true;
            alreadyTriggered = true;
            rb.linearVelocityX = 0;
        }
    }

    public void DontPanic()
    {
        isPanic = false;
        StartCoroutine(delay());
    }
    private IEnumerator delay()
    {
        yield return new WaitForSeconds(0.5f);
        alreadyTriggered = false;
    }
}
