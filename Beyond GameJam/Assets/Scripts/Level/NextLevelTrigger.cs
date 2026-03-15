using System.Collections;
using UnityEngine;

public class NextLevelTrigger : MonoBehaviour
{
    [SerializeField] private GameObject tutorialText;
    [SerializeField] private string finishName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dog"))
        {
            Finish();
        }
    }

    public void Finish()
    {
        var x = Instantiate(tutorialText, FindObjectOfType<Canvas>().transform);
        x.GetComponent<TutorialScript>().SpawnInfo(finishName);
    }

    IEnumerator TeleportNextScene()
    {
        yield return new WaitForSeconds(3f);
        SceneController.instance.NextLevel();
    }
}
