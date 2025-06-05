using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FootstepAudio : MonoBehaviour
{
    public AudioSource footstepAudioSource;
    public float speedThreshold = 0.1f;
    public float fadeDuration = 0.5f;

    private Animator animator;
    private Coroutine fadeCoroutine;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float speed = animator.GetFloat("Speed");

        if (speed > speedThreshold)
        {
            if (fadeCoroutine != null)
                StopCoroutine(fadeCoroutine);

            if (!footstepAudioSource.isPlaying)
            {
                footstepAudioSource.volume = 0f;
                footstepAudioSource.Play();
            }

            fadeCoroutine = StartCoroutine(FadeVolume(1f));
        }
        else
        {
            if (fadeCoroutine != null)
                StopCoroutine(fadeCoroutine);

            if (footstepAudioSource.isPlaying)
                fadeCoroutine = StartCoroutine(FadeOutAndStop());
        }
    }

    private IEnumerator FadeVolume(float targetVolume)
    {
        float startVolume = footstepAudioSource.volume;
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            footstepAudioSource.volume = Mathf.Lerp(startVolume, targetVolume, elapsed / fadeDuration);
            yield return null;
        }

        footstepAudioSource.volume = targetVolume;
    }

    private IEnumerator FadeOutAndStop()
    {
        float startVolume = footstepAudioSource.volume;
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            footstepAudioSource.volume = Mathf.Lerp(startVolume, 0f, elapsed / fadeDuration);
            yield return null;
        }

        footstepAudioSource.volume = 0f;
        footstepAudioSource.Stop();
    }
}