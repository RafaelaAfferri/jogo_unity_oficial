using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundTrack : MonoBehaviour
{
    private static SoundTrack _instance;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);

            var src = GetComponent<AudioSource>();
            src.loop = true;
            src.playOnAwake = true; // já pode estar marcado no Inspector
        }
        else
        {
            Destroy(gameObject);
        }
    }
}