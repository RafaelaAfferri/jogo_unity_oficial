using UnityEngine;
using System.Collections.Generic;

public class SlotController : MonoBehaviour
{
    public GameObject panel; 
    public GameObject slotPrefab;
    public int numberOfSlots = 5;
    public GameObject[] texts; 

    // Adicione esta lista
    public List<Slot> slotsCriados = new List<Slot>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < numberOfSlots; i++)
        {
            Slot slot = Instantiate(slotPrefab, panel.transform).GetComponent<Slot>(); // Cria o slot e obtém o componente Slot
            slot.slotId = i; // Atribui um ID ao slot
            slotsCriados.Add(slot);
            if (i < texts.Length)
            {
                GameObject item = Instantiate(texts[i], slot.transform); // Cria o item dentro do slot
                item.GetComponent<RectTransform>().anchoredPosition = Vector2.zero; // Define a posição do item dentro do slot
                slot.currentItem = item; // Atribui o item ao slot
            }

        }
        
        // Enviar os slots para o PuzzleManager depois de criá-los
        PuzzleManager puzzle = FindFirstObjectByType<PuzzleManager>();

        {
            puzzle.DefinirSlots(slotsCriados.ToArray());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
