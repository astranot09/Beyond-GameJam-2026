using UnityEngine;

public class MuteSound : MonoBehaviour
{
    private AudioSource SFXSource;
    private AudioSource BGMSource;

    private void Awake()
    {
        SFXSource = SoundManager.instance.SFX;
        BGMSource = SoundManager.instance.BGM;
    }
    public void MuteSFX()
    {
        Debug.Log("muteSFX");
        SFXSource.mute = !SFXSource.mute;
    }

    public void MuteBGM()
    {
        Debug.Log("muteBGM");
        BGMSource.mute = !BGMSource.mute;
    }
}
