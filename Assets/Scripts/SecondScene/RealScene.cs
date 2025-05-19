using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RealScene : MonoBehaviour
{
    [SerializeField]
    private GameObject UIStory1;
    [SerializeField]
    private GameObject UIStory2;
    [SerializeField] 
    private AudioSource breathingAudio;
    [SerializeField]
    private Image fadingScreen;

    public float fadeDuration = 2f;
    public Color fadeColor;

    private void OnEnable()
    {
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        Debug.Log(fadeColor);
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;

            // Calculate new alpha value (0 to 1)
            fadeColor.a = 1f - Mathf.Clamp01(elapsed / fadeDuration);
            breathingAudio.volume = Mathf.Clamp01(elapsed / fadeDuration);

            fadingScreen.color = fadeColor;

            yield return null;
        }
        fadingScreen.gameObject.SetActive(false);
        Debug.Log(fadeColor);
        StartCoroutine(StartStory());
    }

    IEnumerator StartStory()
    {
        UIStory1.SetActive(true);
        yield return new WaitForSeconds(fadeDuration + 1f);
        UIStory1 .SetActive(false);

        UIStory2.SetActive(true);   
        yield return new WaitForSeconds(fadeDuration + 1f);
        UIStory2.SetActive(false);
        yield return null;
    }
}
