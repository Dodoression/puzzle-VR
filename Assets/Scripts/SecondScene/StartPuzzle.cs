using System.Collections;
using UnityEngine;

public class StartPuzzle : MonoBehaviour
{
    [SerializeField]
    private GameObject instructions1;
    [SerializeField] 
    private GameObject uiTimer;
    [SerializeField]
    private GameObject puzzle;

    private void OnTriggerEnter(Collider other)
    {
        instructions1.SetActive(true);
    }

    public void StartClick()
    {
        instructions1.SetActive(false);
        uiTimer.SetActive(true);
        MainManager.Instance.RunTimer();
        puzzle.SetActive(true);
        Destroy(this);
    }
}
