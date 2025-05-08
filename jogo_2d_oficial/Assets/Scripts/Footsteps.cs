using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class FootstepAudio : MonoBehaviour
{
    public AudioSource footstepAudioSource;
    public float speedThreshold = 0.1f;
    public float fadeDuration = 0.1f;

    private Animator animator;
    private Coroutine fadeCoroutine;
    private float initialVolume;

    void Awake()
    {
        animator = GetComponent<Animator>();
        initialVolume = footstepAudioSource.volume;
    }

    void Update()
    {
        float speed = animator.GetFloat("Speed");
        if (speed > speedThreshold)
        {
            if (fadeCoroutine != null)
            {
                StopCoroutine(fadeCoroutine);
                fadeCoroutine = null;
                footstepAudioSource.volume = initialVolume;
            }
            if (!footstepAudioSource.isPlaying)
                footstepAudioSource.Play();
        }
        else
        {
            if (footstepAudioSource.isPlaying && fadeCoroutine == null)
                fadeCoroutine = StartCoroutine(FadeOutAndStop());
        }
    }

    IEnumerator FadeOutAndStop()
    {
        float startVol = footstepAudioSource.volume;
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            footstepAudioSource.volume = Mathf.Lerp(startVol, 0f, t / fadeDuration);
            yield return null;
        }
        footstepAudioSource.Stop();
        footstepAudioSource.volume = initialVolume;
        fadeCoroutine = null;
    }
}