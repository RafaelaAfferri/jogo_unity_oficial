using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Interativo : MonoBehaviour
{
    public KeyCode keyToPress = KeyCode.E;
    public GameObject textToShow;
    public string sceneToLoad;
    public AudioClip interactionClip;
    [Min(0)] public float sceneLoadDelay;

    private AudioSource _audioSource;
    private bool _sceneLoading;
    private bool _isInRange;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.playOnAwake = false;
        _audioSource.spatialBlend = 0f;
    }

    void Update()
    {
        if (_isInRange)
        {
            if (!textToShow.activeSelf) textToShow.SetActive(true);

            if (Input.GetKeyDown(keyToPress) && !_sceneLoading)
                StartCoroutine(PlaySoundAndTransition());
        }
        else
        {
            if (textToShow.activeSelf) textToShow.SetActive(false);
        }
    }

    IEnumerator PlaySoundAndTransition()
    {
        _sceneLoading = true;

        if (interactionClip != null)
        {
            _audioSource.PlayOneShot(interactionClip);
            float wait = sceneLoadDelay > 0f ? sceneLoadDelay : interactionClip.length;
            yield return new WaitForSeconds(wait);
        }

        SceneFader.Instance.FadeToScene(sceneToLoad);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) _isInRange = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) _isInRange = false;
    }
}