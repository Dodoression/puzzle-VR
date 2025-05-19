using System.Collections;
using UnityEngine;

public class InFrontOfDoor : MonoBehaviour
{
    [SerializeField]
    private GameObject hintPanel;
    private float hintDuration = 2.5f;

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().Play();
        StartCoroutine(ShowHintPanel());
    }

    private IEnumerator ShowHintPanel()
    {
        hintPanel.SetActive(true);
        yield return new WaitForSeconds(hintDuration);
        hintPanel.SetActive(false);
    }
}
