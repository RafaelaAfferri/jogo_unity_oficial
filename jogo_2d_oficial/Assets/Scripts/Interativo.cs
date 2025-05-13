using UnityEngine;
using UnityEngine.SceneManagement;
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

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.playOnAwake = false;
        _audioSource.spatialBlend = 0f;
    }

    private void Update()
    {
        if (_isInRange)
        {
            if (!textToShow.activeSelf) textToShow.SetActive(true);

            if (Input.GetKeyDown(keyToPress) && !_sceneLoading)
                StartCoroutine(PlaySoundAndLoadScene());
        }
        else
        {
            if (textToShow.activeSelf) textToShow.SetActive(false);
        }
    }

    private IEnumerator PlaySoundAndLoadScene()
    {
        _sceneLoading = true;

        if (interactionClip != null)
        {
            _audioSource.PlayOneShot(interactionClip);
            float wait = sceneLoadDelay > 0f ? sceneLoadDelay : interactionClip.length;
            yield return new WaitForSeconds(wait);
        }

        SceneManager.LoadScene(sceneToLoad);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) _isInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) _isInRange = false;
    }
}