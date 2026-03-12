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
    [SerializeField] private Vector2 dir;


    [Header("Triggered")]
    [SerializeField] private bool onTrigger = false;
    [SerializeField] private bool alreadyDidIt = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(dog!=null)
            return;

        if (collision.CompareTag("Dog"))
        {
            dog = collision.GetComponent<Rigidbody2D>();
            dogMove = collision.GetComponent<MovementDog>();
            onTrigger = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Dog"))
        {
            onTrigger = false;
            movingToPivot = false;
            dogMove.lockMovement = false;
            if(!alreadyDidIt)
                DogScript.instance.health--;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && onTrigger)
        {
            dir = (startPivot.position - dog.gameObject.transform.position).normalized;
            dog.linearVelocity = dir * speed;
            onTrigger = false;
            dogMove.lockMovement = true;
            movingToPivot = true;
            alreadyDidIt = true;
        }

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
