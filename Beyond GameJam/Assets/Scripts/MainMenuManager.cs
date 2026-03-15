using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public AudioClip bgmMusic;
    void Start()
    {
        SoundManager.instance.PlayBGM(bgmMusic);
    }
}
