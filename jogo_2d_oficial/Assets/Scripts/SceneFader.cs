using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    public static SceneFader Instance { get; private set; }
    public Image fadeImage;
    public float fadeDuration = 1f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    void Start()
    {
        fadeImage.color = new Color(0f, 0f, 0f, 1f);
        StartCoroutine(Fade(1f, 0f));
    }

    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOutIn(sceneName));
    }

    IEnumerator Fade(float from, float to)
    {
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float a = Mathf.Lerp(from, to, elapsed / fadeDuration);
            fadeImage.color = new Color(0f, 0f, 0f, a);
            yield return null;
        }
        fadeImage.color = new Color(0f, 0f, 0f, to);
    }

    IEnumerator FadeOutIn(string sceneName)
    {
        yield return Fade(0f, 1f);
        SceneManager.LoadScene(sceneName);
        yield return Fade(1f, 0f);
    }
}