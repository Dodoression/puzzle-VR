using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TryToExit : MonoBehaviour
{
    [SerializeField]
    private GameObject warningPopUp;
    [SerializeField]
    private Image fadingScreen;

    public Color fadeColor = new Color(1, 1, 1, 0);
    private float fadeDuration = 2.0f;

    [SerializeField]
    private AudioSource sceneAudio1;
    [SerializeField]
    private AudioSource sceneAudio2;

    private void OnTriggerEnter(Collider other)
    {
        if (!MainManager.Instance.finishedPuzzle)
        {
            StartCoroutine(ShowPopUp());
        }
        else
        {
            StartCoroutine(FadeIn());
        }
    }

    IEnumerator ShowPopUp()
    {
        warningPopUp.SetActive(true);
        yield return new WaitForSeconds(4);
        warningPopUp.SetActive(false);
    }

    IEnumerator FadeIn()
    {
        fadingScreen.gameObject.SetActive(true);
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;

            // Calculate new alpha value (0 to 1)
            fadeColor.a = Mathf.Clamp01(elapsed / fadeDuration);
            sceneAudio1.volume = 1f - Mathf.Clamp01(elapsed / fadeDuration);
            sceneAudio2.volume = 1f - Mathf.Clamp01(elapsed / fadeDuration);

            fadingScreen.color = fadeColor;

            yield return null;
        }
        Application.Quit();
    }
}
