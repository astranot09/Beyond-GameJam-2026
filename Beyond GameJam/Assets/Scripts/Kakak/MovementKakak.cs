using System.Collections;
using Unity.Cinemachine;
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
    [SerializeField] private float PanicTime = 5f;
    [SerializeField] private float currTime;

    [SerializeField] private CinemachineImpulseSource impulseSource;

    private void Start()
    {
        dog = GameObject.FindGameObjectWithTag("Dog");
        dogTransform = dog.transform;
        rb = GetComponent<Rigidbody2D>();
        impulseSource = GetComponent<CinemachineImpulseSource>();
        currTime = PanicTime;
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
        if (isPanic)
        {
            if(currTime > 0)
            {
                currTime -= Time.deltaTime;
            }
            else
            {
                DogScript.instance.TakeDamage(1);
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PanicMode") && !alreadyTriggered)
        {
            isPanic = true;
            alreadyTriggered = true;
            rb.linearVelocityX = 0;
            impulseSource.GenerateImpulse();
        }
    }

    public void DontPanic()
    {
        isPanic = false;
        currTime = PanicTime;
        StartCoroutine(delay());
    }
    private IEnumerator delay()
    {
        yield return new WaitForSeconds(0.5f);
        alreadyTriggered = false;
    }
}
