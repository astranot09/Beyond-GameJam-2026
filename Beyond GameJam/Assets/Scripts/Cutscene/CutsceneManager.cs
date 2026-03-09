using UnityEngine;
using UnityEngine.UI;

public class CutsceneManager : MonoBehaviour
{
    public static CutsceneManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    [SerializeField] public CutsceneSO cutsceneSO;
    [SerializeField] private Image cutsceneImage;
    private int index;

    public void CutsceneOn(CutsceneSO newCutscene)
    {
        cutsceneSO = newCutscene;
        index = 0;

        cutsceneImage.sprite = cutsceneSO.cutsceneSprite[index];
        cutsceneImage.gameObject.SetActive(true);
    }

    public void NextSlide()
    {
        index++;

        if (index < cutsceneSO.cutsceneSprite.Count)
        {
            cutsceneImage.sprite = cutsceneSO.cutsceneSprite[index];
        }
        else
        {
            EndCutscene();
        }
    }

    void EndCutscene()
    {
        cutsceneImage.gameObject.SetActive(false);
        Debug.Log("Cutscene selesai");
    }
}
