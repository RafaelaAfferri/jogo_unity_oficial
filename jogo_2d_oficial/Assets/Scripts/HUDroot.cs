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
        string[] cenasSemHUD = { "rafa-sala1-puzzle1", "rafa-sala2-puzzle1", "rafa-sala2-puzzle2", "rafa-sala3-puzzle1", "rafa-sala3-puzzle2", "rafa-sala4-puzzle1", "rafa-sala4-puzzle2", "rafa-sala4-puzzle3", "rafa-salaSecreta-puzzle1", "rafa-sala5-puzzle1", "Menu" };

        if (System.Array.Exists(cenasSemHUD, nome => nome == scene.name))
        {
            canvasHUD.SetActive(false);
        }
        else
        {
            canvasHUD.SetActive(true);
        }

    }
}
