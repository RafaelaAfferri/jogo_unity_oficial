#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class DoorController : MonoBehaviour
{
    [Header("Distâncias (em unidades)")]
    public float openDistance = 3f;    // raio para tocar animação de abrir
    public float enterDistance = 1f;   // raio para entrar na próxima cena

    [Header("Cena de destino")]
    public string nextScene;

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

        float dist = Vector2.Distance(player.position, transform.position);

        if (!opened && dist <= openDistance)
        {
            animator.SetTrigger(openTrigger);
            opened = true;
        }

        if (opened && dist <= enterDistance)
        {
            sceneLoaded = true;
            // Usa o fade, se tiver SceneFader na cena; senão, carrega direto
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