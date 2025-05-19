using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    [SerializeField]
    private Image fadingScreen;
    [SerializeField]
    private AudioClip openDoor;
    [SerializeField] 
    private AudioClip gasp;
    [SerializeField]
    private AudioClip fallingDown;

    [SerializeField]
    private AudioSource sceneAudio;
    [SerializeField]
    private AudioSource windAudio;

    [SerializeField]
    private GameObject locomotion;

    public Color fadeColor = new Color(1, 1, 1, 0);
    public float fadeDuration = 2f;

    private void OnTriggerEnter(Collider collision)
    {
        fadingScreen.gameObject.SetActive(true);
        StartCoroutine(FadeIn());
        StartCoroutine(PlayAudio());

        locomotion.SetActive(false);
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
            windAudio.volume = 1f - Mathf.Clamp01(elapsed / fadeDuration);

            fadingScreen.color = fadeColor;

            yield return null;
        }
        sceneAudio.volume = 0f;
        windAudio.volume = 0f;
    }

    IEnumerator PlayAudio()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        yield return new WaitForSeconds(fadeDuration);

        audioSource.clip = openDoor;
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length + 1f);

        audioSource.volume = 0.5f;
        audioSource.clip = gasp;    
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length - 0.5f);
        audioSource.volume = 2f;

        audioSource.clip = fallingDown;
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length + 1f);

        SceneManager.LoadScene("Puzzle Game");
    }
}
