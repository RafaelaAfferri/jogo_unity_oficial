using UnityEngine;
using UnityEngine.EventSystems;

public class QuadroClicker : MonoBehaviour, IPointerClickHandler
{
    public Puzzle2_sala4 lineManager;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Quadro clicado: " + gameObject.name);
        lineManager.QuadroClicado(transform as RectTransform);
    }
}
