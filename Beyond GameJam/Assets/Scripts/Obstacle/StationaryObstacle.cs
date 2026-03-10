using UnityEngine;

public class StationaryObstacle : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Dog"))
        {
            DogScript.instance.health--;
        }
    }
}
