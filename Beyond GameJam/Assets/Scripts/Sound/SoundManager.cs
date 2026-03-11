using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }


    public AudioSource BGM;
    public AudioSource SFX;

    [Header("BGM")]
    public AudioClip bgmMusic;

    [Header("SFX")]
    public AudioClip bark;


    private void Start()
    {
        PlayBGM(bgmMusic);
    }


    public void PlayBGM(AudioClip bgmMusic)
    {
        if (BGM != null)
        {
            BGM.Stop();
        }



        BGM.clip = bgmMusic;
        BGM.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }
}
