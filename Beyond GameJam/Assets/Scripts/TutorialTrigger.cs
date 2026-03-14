using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    [SerializeField] private GameObject panelTutorial;
    [SerializeField] private bool OnAwake = false;

    private void Start()
    {
        if (OnAwake)
            TutorialTime();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dog"))
        {
            TutorialTime();
        }
    }

    public void TutorialTime()
    {
        if (panelTutorial.activeSelf)
        {
            panelTutorial.SetActive(false);
            Time.timeScale = 1f;
        }
        else if (!panelTutorial.activeSelf)
        {
            panelTutorial.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
