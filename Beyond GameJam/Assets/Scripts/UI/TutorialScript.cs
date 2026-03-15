using UnityEngine;
using TMPro;
public class TutorialScript : MonoBehaviour
{

    [SerializeField] private TMP_Text text;

    public void SpawnInfo(string info)
    {
        text.text = info;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
