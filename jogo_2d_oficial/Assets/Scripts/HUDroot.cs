using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDroot : MonoBehaviour
{
    private static HUDroot instance;

    public GameObject canvasHUD; // arraste o Canvas aqui no Inspector

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persiste o Canvas + HUD
        }
        else
        {
            Destroy(gameObject); // Evita duplicações em cenas futuras
        }
    }


    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Lista de cenas onde o HUD deve ficar escondido
        string[] cenasComHud = {"Sala I", "Sala II", "Sala III", "Sala IV", "Sala V", "Sala VI", "Sala 6", "Sala Secreta"};

        if (System.Array.Exists(cenasComHud, nome => nome == scene.name))
        {
            canvasHUD.SetActive(true);
        }
        else
        {
            canvasHUD.SetActive(false);
        }

    }
}
