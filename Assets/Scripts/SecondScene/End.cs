using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class End : MonoBehaviour
{
    [SerializeField]
    private AudioSource sceneAudio;
    [SerializeField]
    private AudioSource creepyAudio;
    [SerializeField]
    private Image fadingScreen;

    public Color fadeColor = new Color(1, 1, 1, 0);
    public float fadeDuration = 2f;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;

            // Calculate new alpha value (0 to 1)
            fadeColor.a = Mathf.Clamp01(elapsed / fadeDuration);
            sceneAudio.volume = 1f - Mathf.Clamp01(elapsed / fadeDuration);
            creepyAudio.volume = 1f - Mathf.Clamp01(elapsed / fadeDuration);

            fadingScreen.color = fadeColor;

            yield return null;
        }
        sceneAudio.volume = 0f;
        creepyAudio.volume = 0f;
    }
}
