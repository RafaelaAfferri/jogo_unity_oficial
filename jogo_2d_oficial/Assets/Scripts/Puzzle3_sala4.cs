using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using TMPro;

public class Puzzle3_sala4 : MonoBehaviour
{
    public Button[] botoes;
    public Color corSelecionada = new Color(1f, 0.9f, 0.6f);
    public Color corOriginal = Color.white;
    public Color corHover = new Color(0.9f, 0.9f, 1f);

    private bool[] selecionado;
    private List<int> ordemClicada = new List<int>();

    public TextMeshProUGUI textoFeedback; // Referência ao texto de feedback

    public Button avancarBotao;


    // Sequência correta esperada (índice base 0 → botoes[2], botoes[3], botoes[0])
    public int[] sequenciaCorreta = new int[] { 2, 3, 0 };

    void Start()
    {
        textoFeedback.gameObject.SetActive(false); // Desativa o feedback de resposta
        avancarBotao.gameObject.SetActive(false); // Desativa o botão de avançar
        selecionado = new bool[botoes.Length];

        for (int i = 0; i < botoes.Length; i++)
        {
            int index = i;
            botoes[i].onClick.AddListener(() => AlternarCor(index));

            EventTrigger trigger = botoes[i].gameObject.GetComponent<EventTrigger>();
            if (trigger == null)
                trigger = botoes[i].gameObject.AddComponent<EventTrigger>();

            EventTrigger.Entry enter = new EventTrigger.Entry();
            enter.eventID = EventTriggerType.PointerEnter;
            enter.callback.AddListener((data) => OnHoverEnter(index));
            trigger.triggers.Add(enter);

            EventTrigger.Entry exit = new EventTrigger.Entry();
            exit.eventID = EventTriggerType.PointerExit;
            exit.callback.AddListener((data) => OnHoverExit(index));
            trigger.triggers.Add(exit);
        }
    }

    void AlternarCor(int index)
    {
        RawImage imagem = botoes[index].transform.parent.GetComponent<RawImage>();
        if (imagem == null) return;

        selecionado[index] = !selecionado[index];

        if (selecionado[index])
        {
            imagem.color = corSelecionada;
            ordemClicada.Add(index);
        }
        else
        {
            imagem.color = corOriginal;
            ordemClicada.RemoveAll(i => i == index); // remove todas ocorrências se quiser garantir
        }

        // Se nenhum botão estiver selecionado, resetar a ordem
        if (TodosDesmarcados())
        {
            ordemClicada.Clear();
        }
    }

    void OnHoverEnter(int index)
    {
        RawImage imagem = botoes[index].transform.parent.GetComponent<RawImage>();
        if (imagem == null) return;

        imagem.color = corHover;
    }

    void OnHoverExit(int index)
    {
        RawImage imagem = botoes[index].transform.parent.GetComponent<RawImage>();
        if (imagem == null) return;

        imagem.color = selecionado[index] ? corSelecionada : corOriginal;
    }

    bool TodosDesmarcados()
    {
        foreach (bool s in selecionado)
        {
            if (s) return false;
        }
        return true;
    }

    public void Verificar()
    {
        if (ordemClicada.Count != sequenciaCorreta.Length)
        {
            textoFeedback.text = "Isso não parece estar certo... Lembre-se tudo na vida tem uma ordem!";
            textoFeedback.gameObject.SetActive(true); // Ativa o feedback de resposta incorreta
            return;
        }

        for (int i = 0; i < sequenciaCorreta.Length; i++)
        {
            if (ordemClicada[i] != sequenciaCorreta[i])
            {
                textoFeedback.text = "Isso não parece estar certo... Lembre-se tudo na vida tem uma ordem!";
                textoFeedback.gameObject.SetActive(true); // Ativa o feedback de resposta incorreta
                return;
            }
        }

        textoFeedback.text = "Correto! Você conseguiu!";
        avancarBotao.gameObject.SetActive(true); // Ativa o botão de avançar
        textoFeedback.gameObject.SetActive(true); // Ativa o feedback de resposta correta
    }
}
