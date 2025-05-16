using UnityEngine;
using TMPro;

public class TextFadeIn : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float duration = 2f;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    System.Collections.IEnumerator FadeIn()
    {
        Color originalColor = textMeshPro.color;
        Color fadedColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        textMeshPro.color = fadedColor;

        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsed / duration);
            textMeshPro.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        textMeshPro.color = originalColor; // garante alpha 1 no final
    }
}
