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
        // garante que o Image comece ativo e bloqueando
        fadeImage.gameObject.SetActive(true);
        fadeImage.raycastTarget = true;
        StartCoroutine(InitialFadeIn());
    }

    IEnumerator InitialFadeIn()
    {
        // fade de preto para transparente
        yield return Fade(1f, 0f);
        // agora que terminou, não bloqueia mais cliques e oculto a imagem
        fadeImage.raycastTarget = false;
        fadeImage.gameObject.SetActive(false);
    }

    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOutIn(sceneName));
    }

    IEnumerator Fade(float from, float to)
    {
        float elapsed = 0f;
        // se for começar um fade, garanta que a imagem esteja ativa e bloqueando
        fadeImage.gameObject.SetActive(true);
        fadeImage.raycastTarget = true;

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
        // fade-out
        yield return Fade(0f, 1f);
        // carrega a cena
        SceneManager.LoadScene(sceneName);
        // fade-in
        yield return Fade(1f, 0f);
        // finalmente, desativa o bloqueio
        fadeImage.raycastTarget = false;
        fadeImage.gameObject.SetActive(false);
    }
}