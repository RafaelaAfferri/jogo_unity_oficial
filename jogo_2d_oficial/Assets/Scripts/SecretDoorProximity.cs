using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
public class SecretDoorController : MonoBehaviour
{
    [Header("Distâncias (unidades)")]
    [Tooltip("Quando o jogador chegar aqui, toca a animação")]
    public float openDistance = 2f;
    [Tooltip("Quando o jogador chegar aqui, carrega a próxima cena")]
    public float enterDistance = 1f;

    [Header("Cena de destino")]
    public string sceneToLoad;

    [Header("Animator")]
    public Animator animator;
    public string openTrigger = "OpenSecret";

    private Transform player;
    private bool opened;
    private bool loading;

    void Start()
    {
        var go = GameObject.FindGameObjectWithTag("Player");
        if (go == null)
            Debug.LogError("SecretDoorController: nenhum objeto com tag 'Player' encontrado!");
        else
            player = go.transform;
    }

    void Update()
    {
        if (loading || player == null) return;

        float dist = Vector2.Distance(player.position, transform.position);

        // 1) dispara a animação de abrir somente uma vez
        if (!opened && dist <= openDistance)
        {
            animator.SetTrigger(openTrigger);
            opened = true;
        }

        // 2) quando já abriu e o player chegar perto de novo, carrega cena
        if (opened && dist <= enterDistance)
        {
            loading = true;
            if (SceneFader.Instance != null)
                SceneFader.Instance.FadeToScene(sceneToLoad);
            else
                SceneManager.LoadScene(sceneToLoad);
        }
    }

    // Mostra os raios na Scene View para ajuste
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0f, 1f, 1f, 0.5f);
        Gizmos.DrawWireSphere(transform.position, openDistance);
        Gizmos.color = new Color(1f, 0f, 0f, 0.5f);
        Gizmos.DrawWireSphere(transform.position, enterDistance);
    }
}