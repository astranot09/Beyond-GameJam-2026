using UnityEngine;
using UnityEngine.Playables;

public class PolisiTidurObstacle : MonoBehaviour
{

    public PlayableDirector timeline;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dog"))
        {
            timeline.Play();
        }
    }
}
