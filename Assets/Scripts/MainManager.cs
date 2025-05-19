using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject uiTimer;

    public Difficulty chosenDiff;
    public bool finishedPuzzle;

    private float time;

    public bool runTimer = false;
    public int numOfPutPieces = 0;

    public enum Difficulty
    {
        Easy,
        Normal,
        Hard
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void RunTimer()
    {
        switch (PlayerPrefs.GetInt("Difficulty"))
        {
            case (int)Difficulty.Easy:
            {
                time = 120f; 
                break;
            }
            case (int)Difficulty.Normal:
            {
                time = 90f;
                break;
            }
            case (int)Difficulty.Hard:
            {
                time = 45f;
                break;
            }
            default:
            {
            break;
            }
        }
        runTimer = true;
    }

    private void Update()
    {
        if (numOfPutPieces == 15)
        {
            finishedPuzzle = true;
        }

        if (runTimer)
        {
            if (time < 0 || finishedPuzzle)
            {
                uiTimer.SetActive(false);

                if (finishedPuzzle)
                {
                    ShowWinPanel();
                }
                else
                {
                    ShowLosePanel();
                }
                runTimer = false;
            }
            else if (time > 0)
            {
                time -= Time.deltaTime;
            }
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    private void ShowWinPanel()
    {
        winPanel.SetActive(true);
    }

    private void ShowLosePanel()
    {
        losePanel.SetActive(true);
    }

    public void CloseEndPanel()
    {
        winPanel.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Puzzle Intro");
    }    
}