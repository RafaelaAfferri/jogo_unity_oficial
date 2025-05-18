using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Collider2D))]
public class SecretDoorController : MonoBehaviour
{
    [Header("Proximidade para abrir")]
    public float openDistance = 2f;
    [Header("Trigger no Animator")]
    public Animator animator;
    public string openTrigger = "OpenSecret";
    [Header("Cena a carregar após passar pela porta")]
    public string sceneToLoad;

    Transform player;
    bool hasOpened;

    void Start()
    {
        var go = GameObject.FindGameObjectWithTag("Player");
        if (go != null) player = go.transform;
    }

    void Update()
    {
        if (hasOpened || player == null) return;
        if (Vector2.Distance(player.position, transform.position) <= openDistance)
        {
            animator.SetTrigger(openTrigger);
            hasOpened = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (hasOpened && other.CompareTag("Player"))
        {
            if (SceneFader.Instance != null)
                SceneFader.Instance.FadeToScene(sceneToLoad);
            else
                SceneManager.LoadScene(sceneToLoad);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0f, 1f, 1f, 0.5f);
        Gizmos.DrawWireSphere(transform.position, openDistance);
    }
}