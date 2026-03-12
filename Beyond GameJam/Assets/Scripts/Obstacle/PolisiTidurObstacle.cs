using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class PolisiTidurObstacle : MonoBehaviour
{

    public PlayableDirector timeline;
    public Transform startPivot;

    [Header("Anim")]

    [SerializeField]private Rigidbody2D dog;
    [SerializeField] private bool movingToPivot;
    [SerializeField] private MovementDog dogMove;
    [SerializeField] private float speed = 2f;

    [SerializeField] private float delayAnim = 3f;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(dog!=null)
            return;

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
                movingToPivot = false;
                dogMove.lockMovement = false;
                timeline.Play();
            }
        }
    }
}
