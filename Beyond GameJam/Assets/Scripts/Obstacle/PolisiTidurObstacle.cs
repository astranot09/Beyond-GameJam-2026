using UnityEngine;
using UnityEngine.Playables;

public class PolisiTidurObstacle : MonoBehaviour
{

    public PlayableDirector timeline;
    public Transform startPivot;

    [SerializeField]private Rigidbody2D dog;
    [SerializeField] private bool movingToPivot;
    [SerializeField] private MovementDog dogMove;
    [SerializeField] private float speed = 2f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dog"))
        {
            dog = collision.GetComponent<Rigidbody2D>();
            dogMove = collision.GetComponent<MovementDog>();
            dogMove.lockMovement = true;

            Vector2 dir = (startPivot.position - collision.transform.position).normalized;
            dog.linearVelocity = dir * speed;

            movingToPivot = true;
        }
    }

    private void Update()
    {
        if (movingToPivot && dog != null)
        {
            float distance = Vector2.Distance(startPivot.position, dog.transform.position);

            if (distance < 0.01f)
            {
                dog.linearVelocity = Vector2.zero;
                timeline.Play();
                dogMove.lockMovement = false;
                movingToPivot = false;
                Debug.Log("tes");
            }
        }
    }
}
