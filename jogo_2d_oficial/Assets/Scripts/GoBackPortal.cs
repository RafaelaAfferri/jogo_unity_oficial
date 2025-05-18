using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class GoBackPortal : MonoBehaviour
{
    [Tooltip("Nome exato da cena para a qual o player será levado")]
    public string sceneToLoad;

    void Reset()
    {
        // Garante que o Collider2D exista e seja trigger
        var col = GetComponent<Collider2D>();
        col.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}