using UnityEngine;

public class PuzzleSaver : MonoBehaviour
{
    public static PuzzleSaver Instance;

    public bool puzzle1_sala1 = false;
    public bool puzzle1_sala2 = false;
    public bool puzzle2_sala2 = false;
    public bool puzzle1_sala3 = false;
    public bool puzzle2_sala3 = false;
    public bool puzzle2_sala4 = false;
    public bool puzzle1_sala4 = false;
    public bool puzzle3_sala4 = false;
    public bool puzzle1_salaSecreta = false;

    public bool puzzle1_sala5 = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
