using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject creditPanel;
    public GameObject optionPanel;

    public void optionPanelUI()
    {
        optionPanel.SetActive(!optionPanel.activeSelf);
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
