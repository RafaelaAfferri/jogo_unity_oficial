using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImageHoverColor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private RawImage image;

    public Color corNormal = Color.white;
    private Color corHover;

    void Awake()
    {
        image = GetComponent<RawImage>();

        if (image == null)
        {
            Debug.LogError("RawImage não encontrado no objeto " + gameObject.name);
            return;
        }

        ColorUtility.TryParseHtmlString("#AFAC92", out corHover);
        image.color = corNormal;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = corHover;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = corNormal;
    }
}
