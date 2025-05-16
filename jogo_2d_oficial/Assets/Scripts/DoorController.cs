#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class DoorController : MonoBehaviour
{
    [Header("Distâncias (unidades)")]
    public float openDistance = 3f;     // toca animação
    public float enterDistance = 1f;    // troca de cena

    [Header("Cena de destino")]
    public string nextScene;

    [Header("Puzzles exigidos")]
    public string[] requiredPuzzles;    // IDs que precisam estar resolvidos

    [Header("Animator")]
    public Animator animator;
    public string openTrigger = "OpenDoor";

    Transform player;
    bool opened;
    bool sceneLoaded;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (player == null || sceneLoaded) return;

        // só abre se todos os puzzles estiverem resolvidos
        bool canOpen = requiredPuzzles == null ||
                       requiredPuzzles.Length == 0 ||
                       PuzzleProgressManager.Instance.AllSolved(requiredPuzzles);

        if (!canOpen) return;                        // puzzles pendentes → sai

        float dist = Vector2.Distance(player.position, transform.position);

        if (!opened && dist <= openDistance)
        {
            animator.SetTrigger(openTrigger);        // animação de abrir
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
        Gizmos.color = new Color(0f, 1f, 0f, 0.5f);
        Gizmos.DrawWireSphere(transform.position, openDistance);

        Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
        Gizmos.DrawWireSphere(transform.position, enterDistance);
    }
}