using System.Collections;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField]
    private GameObject warningPanel;
    public int warningDuration;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ShowWarning());
    }

    private IEnumerator ShowWarning()
    {
        warningPanel.SetActive(true);
        yield return new WaitForSeconds(warningDuration);
        warningPanel.SetActive(false);
    }
}
