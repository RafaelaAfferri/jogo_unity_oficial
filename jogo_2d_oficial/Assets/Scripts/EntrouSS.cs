using UnityEngine;

public class EntrouSS : MonoBehaviour
{

    private PuzzleSaver puzzle;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        puzzle = PuzzleSaver.Instance;
        puzzle.entrouSalaSecreta = true; // Define que o jogador entrou na sala secreta
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
