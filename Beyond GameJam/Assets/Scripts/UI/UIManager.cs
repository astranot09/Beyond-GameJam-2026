using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject creditPanel;
    public GameObject optionPanel;

    private void Start()
    {
        Time.timeScale = 1.0f;
    }
    public void optionPanelUI()
    {
        optionPanel.SetActive(!optionPanel.activeSelf);
        if (optionPanel.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
        
    }
    public void creditPanelUI()
    {
        creditPanel.SetActive(!creditPanel.activeSelf);
    }
    public void reloadScene()
    {
        SceneController.instance.RestartLevel();
    }
    public void ExitGame()
    {
        SceneController.instance.Exit();
    }
}
