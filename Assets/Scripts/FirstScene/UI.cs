using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField]
    private GameObject introPanel;
    [SerializeField]
    private GameObject diffPanel;
    [SerializeField]
    private GameObject continuePanel;
    [SerializeField]
    private GameObject storyPanel; 
    [SerializeField]
    private GameObject teleportArea;
    [SerializeField]
    private GameObject locomotion;

    public void OnPlayClicked()
    {
        introPanel.SetActive(false);
        diffPanel.SetActive(true);
    }

    public void OnQuitClicked()
    {
        Application.Quit();
    }

    public void Easy()
    {
        diffPanel.SetActive(false);
        continuePanel.SetActive(true);
        PlayerPrefs.SetInt("Difficulty", (int)MainManager.Difficulty.Easy);
    }

    public void Normal()
    {
        diffPanel.SetActive(false);
        continuePanel.SetActive(true);
        PlayerPrefs.SetInt("Difficulty", (int)MainManager.Difficulty.Normal);
    }

    public void Hard()
    {
        diffPanel.SetActive(false);
        continuePanel.SetActive(true);
        PlayerPrefs.SetInt("Difficulty", (int)MainManager.Difficulty.Hard);
    }

    public void Okay()
    {
        continuePanel.SetActive(false);
        storyPanel.SetActive(true);
    }

    public void Hide()
    {
        storyPanel.SetActive(false);
        teleportArea.SetActive(true);
        locomotion.SetActive(true);
    }
}
