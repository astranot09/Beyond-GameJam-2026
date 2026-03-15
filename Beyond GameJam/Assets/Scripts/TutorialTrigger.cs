using System.Collections;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    [SerializeField] private GameObject tutorialText;
    [SerializeField] private string tutorialName;
    [SerializeField] private bool OnAwake = false;

    private void Start()
    {
        if (OnAwake)
            TutorialTime();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dog")&& !OnAwake)
        {
            TutorialTime();
        }
    }

    public void TutorialTime()
    {
        var x = Instantiate(tutorialText, FindObjectOfType<Canvas>().transform);
        x.GetComponent<TutorialScript>().SpawnInfo(tutorialName);
    }
}
