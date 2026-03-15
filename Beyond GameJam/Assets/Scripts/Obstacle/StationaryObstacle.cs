using UnityEngine;

public class StationaryObstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("asda");
        if (collision.CompareTag("Dog") || collision.CompareTag("Brother"))
        {
            Debug.Log("ppppppppppsdaada");
            DogScript.instance.TakeDamage(1f);
        }
    }

}
