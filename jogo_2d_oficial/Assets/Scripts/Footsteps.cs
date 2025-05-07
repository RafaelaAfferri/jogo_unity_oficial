using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FootstepAudio : MonoBehaviour
{
    public AudioSource footstepAudioSource;
    public float speedThreshold = 0.1f;

    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float speed = animator.GetFloat("Speed");
        if (speed > speedThreshold)
        {
            if (!footstepAudioSource.isPlaying)
                footstepAudioSource.Play();
        }
        else
        {
            if (footstepAudioSource.isPlaying)
                footstepAudioSource.Stop();
        }
    }
}   