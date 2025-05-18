using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Puzzle1_sala5 : MonoBehaviour
{
    public Disco[] discos;
    private bool resolvido = false;

    public AudioSource audioSource;
    public AudioClip somErro;
    public AudioClip somAcerto;

    public AudioClip re;

    public TextMeshProUGUI textFeedback;

    public Button botaoAvancar;

    private PuzzleSaver puzzle;

    public Button tocar;

    public Button doButton;
    public Button faButton; 
    public Button reButton;
    public Button miButton;


    void Start()
    {
        puzzle = PuzzleSaver.Instance;
        if (!puzzle.puzzle1_sala5)
        {

            botaoAvancar.gameObject.SetActive(false); // Desativa o botão de avançar no início
            textFeedback.gameObject.SetActive(false); // Desativa o feedback de resposta incorreta
            tocar.gameObject.SetActive(false); // Desativa o botão de tocar no início
            doButton.gameObject.SetActive(false);
            faButton.gameObject.SetActive(false);
            reButton.gameObject.SetActive(false);
            miButton.gameObject.SetActive(false);
        }

    }


    void Update()
    {
        if (resolvido) return;

        if (TodosDiscosCorretos())
        {
            audioSource.PlayOneShot(somAcerto);
            textFeedback.text = "Parabéns!";
            tocar.gameObject.SetActive(true);
            doButton.gameObject.SetActive(true);
            faButton.gameObject.SetActive(true);
            reButton.gameObject.SetActive(true);
            miButton.gameObject.SetActive(true);
            
            
        }
        
    }

    private bool TodosDiscosCorretos()
    {
        foreach (var disco in discos)
        {
            if (!disco.EstaCorreto())
            {
                return false;
            }
        }

        return true;
    }

    public void _do()
    {
        textFeedback.text = "Não é esse som!";
        audioSource.PlayOneShot(somErro);
        textFeedback.gameObject.SetActive(true);
    }


    public void _fa()
    {
        textFeedback.text = "Não é esse som!";
        audioSource.PlayOneShot(somErro);
        textFeedback.gameObject.SetActive(true);
    }

    public void _re()
    {
        textFeedback.text = "Esse é o som!";
        audioSource.PlayOneShot(somAcerto);
        textFeedback.gameObject.SetActive(true);
        botaoAvancar.gameObject.SetActive(true); // Ativa o botão de avançar
        
    }

    public void _mi()
    {
        textFeedback.text = "Não é esse som!";
        audioSource.PlayOneShot(somErro);
        textFeedback.gameObject.SetActive(true);
    }


    public void TocarSom()
    {
        audioSource.PlayOneShot(re);
    }

    public void Voltar()
    {
        SceneManager.LoadScene("Sala V");
    }

    public void Avancar()
    {
        puzzle.puzzle1_sala5 = true;
        PuzzleProgressManager.Instance.MarkSolved("Puzzle1_Sala5");
        SceneManager.LoadScene("Sala V");
    }
}
