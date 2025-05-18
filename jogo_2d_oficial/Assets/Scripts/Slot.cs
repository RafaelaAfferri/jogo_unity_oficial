using UnityEngine;

public class Slot : MonoBehaviour
{

    public GameObject currentItem; // O item que está atualmente no slot

    public int slotId;
    
    public string acceptedTag = ""; // A tag que o slot aceita (se vazio, aceita qualquer tag)

}
