using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandle2 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform originalParent;
    CanvasGroup canvasGroup;

    RectTransform rectTransform;

    public int itemId; // ID do item, se necessário

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent; //Save OG parent
        transform.SetParent(transform.root); //Above other canvas'
        transform.position = Vector2.zero; //Center of screen
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f; //Semi-transparent during drag
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Magica para o drag funcionar.

        print($"Input.mousePosition{Input.mousePosition}");
        print($"rectTransform.rect.width{rectTransform.rect.width}");
        transform.localPosition = new Vector3(
            Input.mousePosition.x - rectTransform.rect.width*4.5f,
            Input.mousePosition.y - 300, 
            0); //Follow the mouse
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true; //Enables raycasts
        canvasGroup.alpha = 1f; //No longer transparent

        Slot dropSlot = eventData.pointerEnter?.GetComponent<Slot>(); //Slot where item dropped
        if(dropSlot == null)
        {
            GameObject dropItem = eventData.pointerEnter;
            if (dropItem != null)
            {
                dropSlot = dropItem.GetComponentInParent<Slot>();
            }
        }
        Slot originalSlot = originalParent.GetComponent<Slot>();

        if (dropSlot != null)
        {
            // VERIFICA SE O SLOT ACEITA A TAG DO ITEM
            if (dropSlot.acceptedTag != "" && !CompareTag(dropSlot.acceptedTag))
            {
                // Slot rejeita esse tipo de item, volta para o original
                transform.SetParent(originalParent);
                GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                return;
            }

            // Slot aceita o item
            if (dropSlot.currentItem != null)
            {
                // Troca de lugar com o item que já estava no slot
                dropSlot.currentItem.transform.SetParent(originalSlot.transform);
                originalSlot.currentItem = dropSlot.currentItem;
                dropSlot.currentItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            }
            else
            {
                originalSlot.currentItem = null;
            }

            // Move este item para o novo slot
            transform.SetParent(dropSlot.transform);
            dropSlot.currentItem = gameObject;
        }
        else
        {
            //No slot under drop point
            transform.SetParent(originalParent);
        }

        GetComponent<RectTransform>().anchoredPosition = Vector2.zero; //Center
    }
}
