using UnityEngine;

public class DelayedWhisper : MonoBehaviour
{
    public float delay = 11f; // tempo até tocar o áudio

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke(nameof(PlayWhisper), delay);
    }

    void PlayWhisper()
    {
        audioSource.Play();
    }
}
