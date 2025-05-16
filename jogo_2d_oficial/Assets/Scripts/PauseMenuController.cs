using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseMenuController : MonoBehaviour
{
    public GameObject MenuCanvas;

    void Start()
    {
        MenuCanvas.SetActive(false);  
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            MenuCanvas.SetActive(!MenuCanvas.activeSelf);  
        }
    }

    public void QuitGame()
    {
        Debug.Log("Saindo do jogo...");

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
