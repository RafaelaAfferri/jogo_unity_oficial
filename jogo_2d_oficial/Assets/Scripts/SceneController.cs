using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string sala1 = "Esther";  
    public string config = "Config - gubs";  
    public string controls = "Controles - gubs";  

    public void Jogar()
    {
        SceneManager.LoadScene(sala1);
    }

    public void Config()
    {
        SceneManager.LoadScene(config);
    }

    public void Controls()
    {
        SceneManager.LoadScene(controls);
    }
}
