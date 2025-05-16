using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIButtonSound : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip hoverSound;
    public AudioClip clickSound;
    public string sceneToLoad; // Nome da próxima cena

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GameObject.Find("UIAudioManager").GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (hoverSound != null)
            audioSource.PlayOneShot(hoverSound);
    }

    public void PlayClickSound()
    {
        if (clickSound != null)
            audioSource.PlayOneShot(clickSound);

        StartCoroutine(DelayedSceneLoad());
    }

    private System.Collections.IEnumerator DelayedSceneLoad()
    {
        yield return new WaitForSeconds(0.2f); // espera curta para o som tocar
        SceneManager.LoadScene(sceneToLoad);
    }
}
