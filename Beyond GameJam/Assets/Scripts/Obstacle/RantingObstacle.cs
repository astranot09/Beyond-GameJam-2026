using UnityEngine;

public class RantingObstacle : MonoBehaviour
{
    [SerializeField] private bool giveDamage = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Dog"))
        {
            MovementDog dog = collision.GetComponent<MovementDog>();

            if (!dog.crouch && !giveDamage)
            {
                giveDamage = true;
                DogScript.instance.TakeDamage(1f);
            }
        }
    }
}
