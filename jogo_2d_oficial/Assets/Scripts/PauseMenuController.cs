using UnityEngine;

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
}
