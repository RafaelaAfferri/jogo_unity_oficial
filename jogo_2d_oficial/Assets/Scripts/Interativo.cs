using UnityEngine;
using UnityEngine.SceneManagement; 

public class Interativo : MonoBehaviour
{

    public bool isInRange = false; // Variável para verificar se o jogador está dentro do range do objeto interativo
    public KeyCode keyToPress;

    public GameObject textToShow; // Referência ao objeto de texto que será exibido quando o jogador estiver no range
    
    public string sceneToLoad; // Nome da cena a ser carregada



    public 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isInRange)
        {
            textToShow.SetActive(true); // Ativa o objeto de texto quando o jogador está no range

            //aparecer texto
            if(Input.GetKeyDown(keyToPress))
            {
                //abrir mini-game  
                Debug.Log("Mini-game opened!");
                SceneManager.LoadScene(sceneToLoad); 

            }
            
        }
        else
        {
            textToShow.SetActive(false); // Desativa o objeto de texto quando o jogador não está no range
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player is in range of the interactive object.");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Player is out of range of the interactive object.");
        }
    }

}
