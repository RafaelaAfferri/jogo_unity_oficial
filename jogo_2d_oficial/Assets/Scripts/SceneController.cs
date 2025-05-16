using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string sala1 = "Sala I";
    public string config = "Config - gubs";
    public string intro = "Intro";
    public string prox;

    public void Jogar()
    {
        SceneManager.LoadScene(sala1);
    }

    public void Config()
    {
        SceneManager.LoadScene(config);
    }

    public void Intro()
    {
        SceneManager.LoadScene(intro);
    }

    public void Prox()
    {
        SceneManager.LoadScene(prox);
    }
}
