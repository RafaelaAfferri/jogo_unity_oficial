using UnityEngine;
using TMPro;

public class PuzzleManager : MonoBehaviour
{
    private Slot[] slots;
    public GameObject panel; // Referência ao painel onde os slots estão localizados
    
    public GameObject botaoAvancar; // Referência ao botão de fechar o puzzle

    public TextMeshProUGUI textoFeedback; // Referência ao texto de feedback

    public void DefinirSlots(Slot[] listaSlots)
    {
        slots = listaSlots;
    }

    public void CheckPuzzle()
    {
        foreach (Slot slot in slots)
        {
            if (slot.currentItem == null)
            {
                Debug.Log("Slot vazio!");
                return;
            }

            ItemDragHandle item = slot.currentItem.GetComponent<ItemDragHandle>();
            if (item.itemId != slot.slotId)
            {
                Debug.Log($"Item {item.itemId} está no slot {slot.slotId} → incorreto");
                textoFeedback.text = "Não parece estar certo..."; // Atualiza o feedback de resposta incorreta
                textoFeedback.gameObject.SetActive(true); // Ativa o feedback de resposta incorreta
                return;
            }
        }

        Debug.Log("Puzzle resolvido corretamente!");
        textoFeedback.text = "Correto!"; // Atualiza o feedback de resposta correta
        textoFeedback.gameObject.SetActive(true); // Ativa o feedback de resposta correta
        botaoAvancar.gameObject.SetActive(true); // Ativa o botão de avançar
    }

    public void Voltar()
    {
        panel.SetActive(false); // Desativa o painel do puzzle
        textoFeedback.gameObject.SetActive(false); // Desativa o feedback de resposta incorreta
        
    }

    public void Avancar(){
        panel.SetActive(false); // Desativa o painel do puzzle
        // Aqui você pode adicionar a lógica para avançar no jogo, como abrir uma porta ou trocar de cena
        Debug.Log("Avançar para a próxima parte do jogo!");
    }
}
