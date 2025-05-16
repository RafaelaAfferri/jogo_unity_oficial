using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TypewriterWithEnterPrompt : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    [TextArea]
    public string fullText;
    public float typingSpeed = 0.05f;
    public float startDelay = 1f;
    public string sceneToLoad;

    public GameObject enterPrompt;
    public AudioClip typeSound; // Som da máquina de escrever
    public AudioSource audioSource; // Fonte de áudio para digitação

    void Start()
    {
        enterPrompt.SetActive(false);
        StartCoroutine(TypeText());
    }

    bool typingDone = false;

    void Update()
    {
        if (typingDone && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    IEnumerator TypeText()
    {
        yield return new WaitForSeconds(startDelay);

        textMeshPro.text = "";

        foreach (char c in fullText)
        {
            textMeshPro.text += c;

            if (!char.IsWhiteSpace(c) && typeSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(typeSound);
            }

            yield return new WaitForSeconds(typingSpeed);
        }

        enterPrompt.SetActive(true);
        typingDone = true;
    }
}
