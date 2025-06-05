#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class DoorController : MonoBehaviour
{
    [Header("Distâncias (unidades)")]
    public float openDistance = 4f;
    public float enterDistance = 1f;

    [Header("Cena de destino")]
    public string nextScene;

    [Header("Puzzles exigidos")]
    public string[] requiredPuzzles;

    [Header("Animator")]
    public Animator animator;
    public string openTrigger = "OpenDoor";

    [Header("Áudio")]
    public AudioClip openClip;
    private AudioSource _audioSrc;

    Transform player;
    bool opened, sceneLoaded;

    void Awake()
    {
        _audioSrc = GetComponent<AudioSource>();
    }

    void Start()
    {
        player = GameObject.FindWithTag("Player")?.transform;
    }

    void Update()
    {
        if (player == null || sceneLoaded) return;

        // Só abre se puzzles resolvidos
        if (requiredPuzzles.Length > 0 &&
            !PuzzleProgressManager.Instance.AllSolved(requiredPuzzles))
            return;

        float dist = Vector2.Distance(player.position, transform.position);

        if (!opened && dist <= openDistance)
        {
            animator.SetTrigger(openTrigger);
            if (openClip != null)
                _audioSrc.PlayOneShot(openClip);
            opened = true;
        }

        if (opened && dist <= enterDistance)
        {
            sceneLoaded = true;
            if (SceneFader.Instance != null)
                SceneFader.Instance.FadeToScene(nextScene);
            else
                SceneManager.LoadScene(nextScene);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0f,1f,0f,0.5f);
        Gizmos.DrawWireSphere(transform.position, openDistance);
        Gizmos.color = new Color(1f,0f,0f,0.5f);
        Gizmos.DrawWireSphere(transform.position, enterDistance);
    }
}